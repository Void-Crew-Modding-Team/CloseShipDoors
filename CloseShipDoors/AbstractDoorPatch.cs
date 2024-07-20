using CG.Game;
using CG.Ship.Hull;
using HarmonyLib;
using Photon.Pun;
using VoidManager.Utilities;

namespace CloseShipDoors
{
    [HarmonyPatch(typeof(AbstractDoor))]
    internal class AbstractDoorPatch
    {
        [HarmonyPostfix]
        [HarmonyPatch("set_IsOpen")]
        static void IsOpen(AbstractDoor __instance, bool value)
        {
            if (!PhotonNetwork.IsMasterClient || !value) return;

            if (__instance is not AirlockDoor && Configs.interiorDoorsConfig.Value)
            {
                Tools.DelayDo(() => __instance.SetOpen(false), Configs.delayConfig.Value);
            }

            if (__instance is AirlockDoor && Configs.airlockDoorsConfig.Value)
            {
                Tools.DelayDo(() => __instance.SetOpen(false), Configs.delayConfig.Value + 500);
            }
        }

        internal static void CloseAllDoors()
        {
            ClientGame.Current?.PlayerShip?.GetComponentsInChildren<AbstractDoor>()?.Do(door => IsOpen(door, door.IsOpen));
        }
    }
}
