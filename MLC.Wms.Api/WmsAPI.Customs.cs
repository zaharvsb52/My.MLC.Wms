using System;
using System.Collections.Generic;
using System.Linq;
using MLC.Wms.Model.Entities;

namespace MLC.Wms.Api
{
    public partial class WmsAPI
    {
        public const string FillReqCustomsPosMethodName = "FillReqCustomsPos";

        /// <summary>
        /// Рассчитывает позиции "Заявки на декларирование".
        /// <exception cref="InvalidOperationException"> "Не удалось найти заявку с id {reqCustomsId}" </exception>
        /// <exception cref="InvalidOperationException"> "К заявке id {reqCustomsId} не привязана ни одна накладная." </exception>
        /// <exception cref="InvalidOperationException"> Если есть позиции и нет разрешения на их перезапись: "У заявки id {reqCustomsId} уже имеются позиции." </exception>
        /// <exception cref="InvalidOperationException"> "У заявки id {reqCustomsId} одновременно имеются привязки как к приходным, так и к расходным накладным." </exception>
        /// <exception cref="InvalidOperationException"> "Формирование позиций по расходным накладным не реализовано. Заявка {reqCustomsId}." </exception>
        /// <exception cref="InvalidOperationException"> "У заявки id {reqCustomsId} нет привязки к приходным накладным." </exception>
        /// <exception cref="InvalidOperationException"> "У заявки id {reqCustomsId} нет накладных с позициями." </exception>
        /// <exception cref="InvalidOperationException"> "У заявки id {reqCustomsId} для позиции {iwbPos.IWBPosID} не удалось определить страну происхождения." </exception>
        /// <exception cref="InvalidOperationException"> "У заявки id {reqCustomsId} для позиции {iwbPos.IWBPosID} не удалось определить код ТНВД." </exception>
        /// </summary>
        /// <param name="reqCustomsId">Идентификатор заявки</param>
        /// <param name="allowRemoveExistsPos">Признак, разрешающий удаление имеющихся у заявки позиций</param>
        /// <returns>True - если позиции были добавлены. Иначе - False</returns>
        public bool FillReqCustomsPos(int reqCustomsId, bool allowRemoveExistsPos)
        {
            //TODO: алгоритм можно сильно оптимизировать (если не идти от заявки)
            using (var session = SessionFactory.OpenSession())
            {
                var reqCustoms = session.Get<CstReqCustoms>(reqCustomsId);

                if (reqCustoms == null)
                    throw new InvalidOperationException($"Не удалось найти заявку с id {reqCustomsId}.");

                if (reqCustoms.ReqCustoms_CstReqCustoms2WB_List.Count == 0)
                    throw new InvalidOperationException($"К заявке id {reqCustomsId} не привязана ни одна накладная.");

                if (!allowRemoveExistsPos && reqCustoms.ReqCustoms_CstReqCustomsPos_List.Count > 0)
                    throw new InvalidOperationException($"У заявки id {reqCustomsId} уже имеются позиции.");

                var iwbList = reqCustoms.ReqCustoms_CstReqCustoms2WB_List.Where(i => i.IWB != null).Select(i => i.IWB).ToList();
                //var iwbList = session.Query<CstReqCustoms2WB>()
                //    .Where(i => i.ReqCustoms == reqCustoms)
                //    .Select(i => i.IWB)
                //    .FetchMany(i => i.IWB_WmsIWBPos_List)
                //    .ThenFetch(i => i.SKU)
                //    .ThenFetch(i => i.Art)
                //    .ToList()
                //    ;

                var owbList = reqCustoms.ReqCustoms_CstReqCustoms2WB_List.Where(i => i.OWB != null).Select(i => i.OWB).ToList();

                if (iwbList.Any() && owbList.Any())
                    throw new InvalidOperationException($"У заявки id {reqCustomsId} одновременно имеются привязки как к приходным, так и к расходным накладным.");

                if (owbList.Any())
                    throw new InvalidOperationException($"Формирование позиций по расходным накладным не реализовано. Заявка {reqCustomsId}.");

                if (!iwbList.Any())
                    throw new InvalidOperationException($"У заявки id {reqCustomsId} нет привязки к приходным накладным.");

                var iwbPosList = iwbList.SelectMany(i => i.IWB_WmsIWBPos_List).ToList();
                if (iwbPosList.Count == 0)
                    throw new InvalidOperationException($"У заявки id {reqCustomsId} нет накладных с позициями.");

                var resItems = new List<CstReqCustomsPos>();
                foreach (var iwbPos in iwbPosList)
                {
                    var countryCode = iwbPos.Country != null
                        ? iwbPos.Country.CountryCode
                        : iwbPos.SKU.Art.Country?.CountryCode;
                    if (string.IsNullOrEmpty(countryCode))
                        throw new InvalidOperationException($"У заявки id {reqCustomsId} для позиции {iwbPos.IWBPosID} не удалось определить страну происхождения.");

                    var tnvdCode = GetTnvdCode(iwbPos);
                    if (string.IsNullOrEmpty(tnvdCode))
                        throw new InvalidOperationException($"У заявки id {reqCustomsId} для позиции {iwbPos.IWBPosID} не удалось определить код ТНВЭД.");

                    var grossWeight = iwbPos.CPV_List
                        .Where(i => i.CustomParam.CustomParamCode == WmsIWBPosCPV.IWBPosWeightGross)
                        .Sum(i => string.IsNullOrEmpty(i.CPVValue) ? 0 : int.Parse(i.CPVValue));

                    var resItem = resItems.SingleOrDefault(i =>
                        i.ReqCustomsTNVD == tnvdCode &&
                        i.Country.CountryCode == countryCode &&
                        i.Art.ArtCode == iwbPos.SKU.Art.ArtCode);
                    if (resItem == null)
                    {
                        resItem = new CstReqCustomsPos
                        {
                            ReqCustoms = reqCustoms,
                            ReqCustomsTNVD = tnvdCode,
                            Country = session.Get<IsoCountry>(countryCode),
                            Art = iwbPos.SKU.Art,
                            ReqCustomsPosNumber = resItems.Count + 1,

                            ReqCustomsCount = iwbPos.IWBPosCount,
                            ReqCustomsWeightGross = grossWeight,
                            ReqCustomsAmount = iwbPos.IWBPosPriceValue
                        };
                        resItems.Add(resItem);
                    }
                    else
                    {
                        resItem.ReqCustomsCount += iwbPos.IWBPosCount;
                        resItem.ReqCustomsWeightGross += grossWeight;
                        if (iwbPos.IWBPosPriceValue.HasValue)
                            resItem.ReqCustomsAmount += iwbPos.IWBPosPriceValue;
                    }
                }

                if (resItems.Count == 0)
                    return false;

                // заполняем
                using (var transaction = session.BeginTransaction())
                {
                    if (allowRemoveExistsPos)
                        foreach (var item in reqCustoms.ReqCustoms_CstReqCustomsPos_List)
                            session.Delete(item);

                    foreach (var item in resItems)
                        session.Save(item);

                    transaction.Commit();
                }
                return true;
            }
        }

        private string GetTnvdCode(WmsIWBPos iwbPos)
        {
            var iwbPosTnvd = iwbPos.CPV_List.FirstOrDefault(i => i.CustomParam.CustomParamCode == WmsIWBPosCPV.IWBPosTNVD);
            if (!string.IsNullOrEmpty(iwbPosTnvd?.CPVValue))
                return iwbPosTnvd.CPVValue.ToUpperInvariant();
            var artTnvd = iwbPos.SKU.Art.CPV_List.FirstOrDefault(i => i.CustomParam.CustomParamCode == WmsArtCPV.ARTTNVD);
            return artTnvd?.CPVValue.ToUpperInvariant();
        }
    }
}