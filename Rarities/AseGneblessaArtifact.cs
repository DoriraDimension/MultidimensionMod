using Terraria;
using Microsoft.Xna.Framework;
using MultidimensionMod.Base;
using Terraria.ModLoader;

namespace MultidimensionMod.Rarities
{
	public class AseGneblessaArtifact : ModRarity
	{
		public override Color RarityColor => BaseUtility.MultiLerpColor(Main.LocalPlayer.miscCounter % 100 / 100f, MDColors.ForbiddenLavender, MDColors.ForbiddenEldritch, MDColors.ForbiddenLavender);

		public override int GetPrefixedRarity(int offset, float valueMult)
		{
			return Type;
		}
	}
}