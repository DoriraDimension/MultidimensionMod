using Terraria;
using Microsoft.Xna.Framework;
using MultidimensionMod.Base;
using Terraria.ModLoader;

namespace MultidimensionMod.Rarities.Souls
{
	public class CultistSoulRarity : ModRarity
	{
		public override Color RarityColor => BaseUtility.MultiLerpColor(Main.LocalPlayer.miscCounter % 100 / 100f, MDColors.CultistSolar, MDColors.CultistVortex, MDColors.CultistNebula, MDColors.CultistStardust, MDColors.CultistSolar);

		public override int GetPrefixedRarity(int offset, float valueMult)
		{
			return Type;
		}
	}
}