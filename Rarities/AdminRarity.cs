using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace MultidimensionMod.Rarities
{
	public class AdminRarity : ModRarity
	{
		public override Color RarityColor => MDColors.AdminColor;

		public override int GetPrefixedRarity(int offset, float valueMult)
		{
			return Type;
		}
	}
}