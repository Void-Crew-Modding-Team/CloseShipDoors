using VoidManager.CustomGUI;
using VoidManager.Utilities;

namespace CloseShipDoors
{
    internal class GUI : ModSettingsMenu
    {
        public override string Name() => "Close Ship Doors";

        public override void Draw()
        {
            GUITools.DrawTextField("Delay (ms)", ref Configs.delayConfig);
            if (GUITools.DrawCheckbox("Include interior doors", ref Configs.interiorDoorsConfig))
            {
                AbstractDoorPatch.CloseAllDoors();
            }
            if (GUITools.DrawCheckbox("Include airlock doors", ref Configs.airlockDoorsConfig))
            {
                AbstractDoorPatch.CloseAllDoors();
            }
        }
    }
}
