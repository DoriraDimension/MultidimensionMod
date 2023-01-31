using Terraria;
using Microsoft.Xna.Framework;
using MultidimensionMod.Base;
using Terraria.ModLoader;

namespace MultidimensionMod.Rarities.Souls
{
	public class MetalWormSoulRarity : ModRarity
	{
		public override Color RarityColor => BaseUtility.MultiLerpColor(Main.LocalPlayer.miscCounter % 100 / 100f, MDColors.MechMetal, MDColors.MightSoul, MDColors.MechMetal);

		public override int GetPrefixedRarity(int offset, float valueMult)
		{
			return Type;
		}
	}
}