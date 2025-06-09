using Microsoft.Xna.Framework;
using MultidimensionMod.Water;
using Terraria;
using Terraria.ModLoader;

namespace MultidimensionMod.Water
{
    public class VoidWaterStyle : ModWaterStyle
	{
		public override int ChooseWaterfallStyle()
		{
            return ModContent.GetInstance<VoidWaterfallStyle>().Slot;
        }

		public override int GetSplashDust()
		{
            return ModContent.DustType<VoidWaterSplash>();
        }

		public override int GetDropletGore()
		{
            return ModContent.Find<ModGore>("MultidimensionMod/VoidDroplet").Type;
        }

		public override void LightColorMultiplier(ref float r, ref float g, ref float b)
		{
			r = 1f;
			g = 1f;
			b = 1f;
		}

		public override Color BiomeHairColor()
		{
			return Color.Black;
		}
	}
}