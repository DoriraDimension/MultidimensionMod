using Terraria.ModLoader;

namespace MultidimensionMod.Backgrounds
{
    public class DragonBurrowBackground : ModUndergroundBackgroundStyle
    {
        public override void FillTextureArray(int[] textureSlots)
        {
            textureSlots[0] = BackgroundTextureLoader.GetBackgroundSlot("MultidimensionMod/Backgrounds/InfernoUnderground1");
            textureSlots[1] = BackgroundTextureLoader.GetBackgroundSlot("MultidimensionMod/Backgrounds/InfernoUnderground");
            textureSlots[2] = BackgroundTextureLoader.GetBackgroundSlot("MultidimensionMod/Backgrounds/InfernoCavern1");
            textureSlots[3] = BackgroundTextureLoader.GetBackgroundSlot("MultidimensionMod/Backgrounds/InfernoCavern");
        }
    }
}