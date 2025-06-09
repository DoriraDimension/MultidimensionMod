using Terraria;
using Terraria.ModLoader;

namespace MultidimensionMod.Backgrounds
{
    public class HarmonyUGBG : ModUndergroundBackgroundStyle
    {
        public override void FillTextureArray(int[] textureSlots)
        {
            textureSlots[0] = BackgroundTextureLoader.GetBackgroundSlot("Backgrounds/TerrariumBG");
            textureSlots[1] = BackgroundTextureLoader.GetBackgroundSlot("Backgrounds/TerrariumBG");
            textureSlots[2] = BackgroundTextureLoader.GetBackgroundSlot("Backgrounds/TerrariumBG");
            textureSlots[3] = BackgroundTextureLoader.GetBackgroundSlot("Backgrounds/TerrariumBG");
        }
    }
}
