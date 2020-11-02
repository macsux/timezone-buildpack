using System.Web;
using HarmonyLib;

namespace TimezoneBuildpackModule
{
    public class TimezoneBuildpackHttpModule: IHttpModule
    {
        public void Init(HttpApplication context)
        {
            var harmony = new Harmony("TimezoneBuildpack");
            harmony.PatchAll();
        }
       
        public void Dispose()
        {
        }
    }
}