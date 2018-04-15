using System;
using System.Collections.Generic;
using System.Linq;
using MLC.Wms.Model.Entities;
using NHibernate;
using NHibernate.Linq;
using WebClient.Common.ExtDirect;

namespace MLC.Wms.WebApp.DataServices.MainMenuService
{
    [ExtDirectService]
    public class DataService
    {
        private readonly ISession _session;

        public DataService(ISession session)
        {
            _session = session;
        }

        public object LoadMenu()
        {
            var menuItems = _session.Query<SysObjectTreeMenu>().Where(o => o.ObjectTreeMenuType == "BadgeOffice").Fetch(x => x.ObjectTreeParent).ToArray();
            return BuildTree(menuItems);
        }

        public MenuDto[] BuildTree(SysObjectTreeMenu[] list)
        {
            if (list == null)
                throw new ArgumentNullException("list");

            var treeFlatList = new Dictionary<string, MenuDto>();
            var parentNotAssigned = new Dictionary<string, List<MenuDto>>();

            foreach (var catalog in list.OrderByDescending(x => x.ObjectTreeOrder.HasValue).ThenBy(e => e.ObjectTreeOrder))
            {
                var node = new MenuDto()
                {
                    Code = catalog.ObjectTreeCode,
                    Command = catalog.ObjectTreeAction,
                    ParentCode = catalog.ObjectTreeParent == null ? null : catalog.ObjectTreeParent.ObjectTreeCode,
                    Leaf = true,
                    Text = catalog.ObjectTreeName,
                    Order = catalog.ObjectTreeOrder
                };

                if (list.Any(x => x.ObjectTreeParent != null && x.ObjectTreeParent.ObjectTreeCode == catalog.ObjectTreeCode))
                    node.Leaf = false;

                var key = catalog.ObjectTreeCode;
                treeFlatList.Add(key, node);

                if (parentNotAssigned.ContainsKey(key))
                {
                    IList<MenuDto> children = parentNotAssigned[key];
                    if (node.Children == null)
                    {
                        node.Children = new List<MenuDto>();
                    }
                    node.Children.AddRange(children);
                    parentNotAssigned.Remove(key);
                }

                if (catalog.ObjectTreeParent == null)
                    continue;


                if (treeFlatList.ContainsKey(catalog.ObjectTreeParent.ObjectTreeCode))
                {
                    if (treeFlatList[catalog.ObjectTreeParent.ObjectTreeCode].Children == null)
                        treeFlatList[catalog.ObjectTreeParent.ObjectTreeCode].Children = new List<MenuDto>();

                    treeFlatList[catalog.ObjectTreeParent.ObjectTreeCode].Children.Add(node);
                }
                else if (parentNotAssigned.ContainsKey(catalog.ObjectTreeParent.ObjectTreeCode))
                {
                    parentNotAssigned[catalog.ObjectTreeParent.ObjectTreeCode].Add(node);
                }
                else
                    parentNotAssigned.Add(catalog.ObjectTreeParent.ObjectTreeCode, new List<MenuDto> { node });
            }

            var ret = treeFlatList.Where(e => String.IsNullOrEmpty(e.Value.ParentCode)).Select(e => e.Value).OrderByDescending(x => x.Order.HasValue).ThenBy(e => e.Order).ToArray();

            return ret;
        }
    }
}