using Terraria;
using Microsoft.Xna.Framework;
using MultidimensionMod.Base;
using Terraria.ModLoader;

namespace MultidimensionMod.Rarities.Souls
{
	public class EmpressSoulRarity : ModRarity
	{
		public override Color RarityColor => BaseUtility.MultiLerpColor(Main.LocalPlayer.miscCounter % 100 / 100f, MDColors.EmpressYellow, MDColors.EmpressBlue, MDColors.EmpressPink, MDColors.EmpressYellow);

		public override int GetPrefixedRarity(int offset, float valueMult)
		{
			return Type;
		}
	}
}