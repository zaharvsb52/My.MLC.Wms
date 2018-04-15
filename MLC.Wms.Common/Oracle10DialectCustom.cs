using NHibernate.Dialect;

namespace MLC.Wms.Common
{
    public class Oracle10DialectCustom : Oracle10gDialect
    {
        protected override void RegisterFunctions()
        {
            base.RegisterFunctions();
            this.Keywords.Add("keep");
            this.Keywords.Add("dense_rank");
            this.Keywords.Add("last");
            this.Keywords.Add("within");
            //this.RegisterFunction("keep", (ISQLFunction)new StandardSQLFunction("keep"));
            // this.RegisterFunction("dense_rank", (ISQLFunction)new StandardSQLFunction("dense_rank"));
            // this.RegisterFunction("last", (ISQLFunction)new StandardSQLFunction("last"));
            // this.RegisterFunction("kdl", (ISQLFunction)new SQLFunctionTemplate((IType)null, "keep (dense_rank last order by ?1)"));
        }
    }
}
