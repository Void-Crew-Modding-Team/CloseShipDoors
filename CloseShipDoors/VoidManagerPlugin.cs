using VoidManager.MPModChecks;

namespace CloseShipDoors
{
    public class VoidManagerPlugin : VoidManager.VoidPlugin
    {
        public VoidManagerPlugin()
        {
            VoidManager.Events.Instance.MasterClientSwitched += (_, _) => AbstractDoorPatch.CloseAllDoors();
        }

        public override MultiplayerType MPType => MultiplayerType.Host;

        public override string Author => "18107";

        public override string Description => "Closes ship doors a short time after they are opened";
    }
}
