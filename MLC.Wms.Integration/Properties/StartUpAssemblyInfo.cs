using System.Web;
using MLC.Wms.Integration;

[assembly: PreApplicationStartMethod(typeof(Initializer), "AppInitialize")]