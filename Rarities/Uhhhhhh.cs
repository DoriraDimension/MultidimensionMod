using Terraria;
using Microsoft.Xna.Framework;
using MultidimensionMod.Base;
using Terraria.ModLoader;

namespace MultidimensionMod.Rarities
{
	public class Uhhhhhh : ModRarity
	{
		public override Color RarityColor => BaseUtility.MultiLerpColor(Main.LocalPlayer.miscCounter % 100 / 100f, MDColors.BossSoulRed, MDColors.BossSoulPink, MDColors.BossSoulPurple, MDColors.BossSoulPink, MDColors.BossSoulRed);

		public override int GetPrefixedRarity(int offset, float valueMult)
		{
			return Type;
		}
	}
}