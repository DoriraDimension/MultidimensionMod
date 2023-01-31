using Terraria;
using Microsoft.Xna.Framework;
using MultidimensionMod.Base;
using Terraria.ModLoader;

namespace MultidimensionMod.Rarities
{
	public class ShadeItem : ModRarity
	{
		public override Color RarityColor => BaseUtility.MultiLerpColor(Main.LocalPlayer.miscCounter % 100 / 100f, Color.DarkGray, MDColors.ShadeYellow, Color.DarkGray);

		public override int GetPrefixedRarity(int offset, float valueMult)
		{
			return Type;
		}
	}
}