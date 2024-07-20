using BepInEx.Configuration;

namespace CloseShipDoors
{
    internal class Configs
    {
        internal static ConfigEntry<int> delayConfig;
        internal static ConfigEntry<bool> interiorDoorsConfig;
        internal static ConfigEntry<bool> airlockDoorsConfig;

        internal static void Load(BepinPlugin plugin)
        {
            delayConfig = plugin.Config.Bind("CloseShipDoors", "delayMs", 3000);
            interiorDoorsConfig = plugin.Config.Bind("CloseShipDoors", "includeInteriorDoors", true);
            airlockDoorsConfig = plugin.Config.Bind("CloseShipDoors", "includeAirlocks", true);
        }
    }
}
