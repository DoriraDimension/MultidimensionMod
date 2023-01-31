using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace MultidimensionMod.Rarities
{
	public class DoriraRarity : ModRarity
	{
		public override Color RarityColor => MDColors.DoriraColor;

		public override int GetPrefixedRarity(int offset, float valueMult)
		{
			return Type;
		}
	}
}