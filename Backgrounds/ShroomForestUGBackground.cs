using Terraria.ModLoader;

namespace MultidimensionMod.Backgrounds
{
    public class ShroomForestUGBackground : ModUndergroundBackgroundStyle
    {
        public override void FillTextureArray(int[] textureSlots)
        {
            textureSlots[0] = BackgroundTextureLoader.GetBackgroundSlot("MultidimensionMod/Backgrounds/ShroomForestUGBGTransition");
            textureSlots[1] = BackgroundTextureLoader.GetBackgroundSlot("MultidimensionMod/Backgrounds/ShroomForestUGBG");
            textureSlots[2] = BackgroundTextureLoader.GetBackgroundSlot("MultidimensionMod/Backgrounds/ShroomForestUGBGTransition");
            textureSlots[3] = BackgroundTextureLoader.GetBackgroundSlot("MultidimensionMod/Backgrounds/ShroomForestUGBG");
        }
    }
}