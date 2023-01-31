using Terraria;
using Microsoft.Xna.Framework;
using MultidimensionMod.Base;
using Terraria.ModLoader;

namespace MultidimensionMod.Rarities.Souls
{
	public class KingSlimeSoulRarity : ModRarity
	{
		public override Color RarityColor => BaseUtility.MultiLerpColor(Main.LocalPlayer.miscCounter % 100 / 100f, MDColors.KingSlimeBlue, MDColors.KingSlimeGold, MDColors.KingSlimeBlue);

		public override int GetPrefixedRarity(int offset, float valueMult)
		{
			return Type;
		}
	}
}