using System;
using HarmonyLib;

namespace TimezoneBuildpackModule
{
    [HarmonyPatch(typeof(DateTime), "get_Now", new Type[0])]
    public class MyPatch
    {
        static bool Prefix(ref DateTime __result)
        {
            TimeZoneInfo timezoneInfo;
            try
            {
                timezoneInfo = TimeZoneInfo.FindSystemTimeZoneById(Environment.GetEnvironmentVariable("TIMEZONE") ?? "UTC");
            }
            catch (Exception)
            {
                timezoneInfo = TimeZoneInfo.Utc;
            }
            __result = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, timezoneInfo);
            return false;
        }
    }
}