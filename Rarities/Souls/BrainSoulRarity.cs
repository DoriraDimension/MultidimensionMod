using Terraria;
using Microsoft.Xna.Framework;
using MultidimensionMod.Base;
using Terraria.ModLoader;

namespace MultidimensionMod.Rarities.Souls
{
	public class BrainSoulRarity : ModRarity
	{
		public override Color RarityColor => BaseUtility.MultiLerpColor(Main.LocalPlayer.miscCounter % 100 / 100f, MDColors.BrainBrightRed, MDColors.BrainDeepRed, MDColors.BrainBrightRed);

		public override int GetPrefixedRarity(int offset, float valueMult)
		{
			return Type;
		}
	}
}