using Terraria.ModLoader;

namespace MultidimensionMod.Backgrounds
{
    public class LakeDepthsBackground : ModUndergroundBackgroundStyle
    {
        public override void FillTextureArray(int[] textureSlots)
        {
            textureSlots[0] = BackgroundTextureLoader.GetBackgroundSlot("MultidimensionMod/Backgrounds/MireUnderground1");
            textureSlots[1] = BackgroundTextureLoader.GetBackgroundSlot("MultidimensionMod/Backgrounds/MireUnderground");
            textureSlots[2] = BackgroundTextureLoader.GetBackgroundSlot("MultidimensionMod/Backgrounds/MireCavern1");
            textureSlots[3] = BackgroundTextureLoader.GetBackgroundSlot("MultidimensionMod/Backgrounds/MireCavern");
        }
    }
}