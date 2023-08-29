using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace MultidimensionMod.Water
{
    public class MushroomWaterStyle : ModWaterStyle
    {
        public override int ChooseWaterfallStyle()
        {
            return ModContent.GetInstance<MushroomWaterfallStyle>().Slot;
        }

        public override int GetSplashDust()
        {
            return ModContent.DustType<MushroomWaterSplash>();
        }

        public override int GetDropletGore()
        {
            return ModContent.Find<ModGore>("Water/MushroomDroplet").Type;
        }

        public override void LightColorMultiplier(ref float r, ref float g, ref float b)
        {
            r = 1f;
            g = 1f;
            b = 1f;
        }

        public override Color BiomeHairColor()
        {
            return Color.OrangeRed;
        }
    }
}