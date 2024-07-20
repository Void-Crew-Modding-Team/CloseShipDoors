using VoidManager.CustomGUI;
using VoidManager.Utilities;

namespace CloseShipDoors
{
    internal class GUI : ModSettingsMenu
    {
        private static string delayString = Configs.delayConfig.Value.ToString();
        private static readonly string defaultValue = Configs.delayConfig.DefaultValue.ToString();

        public override string Name() => "Close Ship Doors";

        public override void Draw()
        {
            if (GUITools.DrawTextField("Delay (ms)", ref delayString, defaultValue))
            {
                if (int.TryParse(delayString, out var delay))
                {
                    Configs.delayConfig.Value = delay;
                }
                else
                {
                    delayString = Configs.delayConfig.Value.ToString();
                }
            }
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
