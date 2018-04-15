using System.Reflection;

namespace MLC.Wms.WF.Activities.Business
{
    public interface IMethodContainer
    {
        MethodInfo[] GetMethods();
    }
}