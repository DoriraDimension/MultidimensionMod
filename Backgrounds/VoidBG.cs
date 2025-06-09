using Terraria;
using Terraria.ModLoader;

namespace MultidimensionMod.Backgrounds
{
    class VoidBG : ModSurfaceBackgroundStyle
    {
        public override void ModifyFarFades(float[] fades, float transitionSpeed)
        {
            for (int i = 0; i < fades.Length; i++)
            {
                if (i == Slot)
                {
                    fades[i] += transitionSpeed;
                    if (fades[i] > 1f)
                    {
                        fades[i] = 1f;
                    }
                }
                else
                {
                    fades[i] -= transitionSpeed;
                    if (fades[i] < 0f)
                    {
                        fades[i] = 0f;
                    }
                }
            }
        }

        /*public override int ChooseCloseTexture(ref float scale, ref double parallax, ref float a, ref float b)
        {
            
        }

        public override int ChooseMiddleTexture()
        {
            
        }

        public override int ChooseFarTexture()
        {
            
        }*/
    }

    public class VoidUGBG : ModUndergroundBackgroundStyle
    {
        public override void FillTextureArray(int[] textureSlots)
        {
            textureSlots[0] = BackgroundTextureLoader.GetBackgroundSlot("Backgrounds/VoidUG");
            textureSlots[1] = BackgroundTextureLoader.GetBackgroundSlot("Backgrounds/VoidUG");
            textureSlots[2] = BackgroundTextureLoader.GetBackgroundSlot("Backgrounds/VoidUG");
            textureSlots[3] = BackgroundTextureLoader.GetBackgroundSlot("Backgrounds/VoidUG");
        }
    }
}
