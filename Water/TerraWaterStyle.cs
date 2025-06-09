using Microsoft.Xna.Framework;
using MultidimensionMod.Water;
using Terraria;
using Terraria.ModLoader;

namespace MultidimensionMod.Water
{
    public class TerraWaterStyle : ModWaterStyle
	{
		public override int ChooseWaterfallStyle()
		{
            return ModContent.GetInstance<TerraWaterfallStyle>().Slot;
        }

		public override int GetSplashDust()
		{
			return ModContent.DustType<TerraWaterSplash>();
        }

		public override int GetDropletGore()
		{
            return ModContent.Find<ModGore>("MultidimensionMod/TerraDroplet").Type;
        }

		public override void LightColorMultiplier(ref float r, ref float g, ref float b)
		{
			r = 1f;
			g = 1f;
			b = 1f;
		}

		public override Color BiomeHairColor()
		{
			return Color.Green;
		}
	}
}