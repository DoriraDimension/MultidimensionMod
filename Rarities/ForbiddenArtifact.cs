using Terraria;
using Microsoft.Xna.Framework;
using MultidimensionMod.Base;
using Terraria.ModLoader;

namespace MultidimensionMod.Rarities
{
	public class ForbiddenArtifact : ModRarity
	{
		public override Color RarityColor => BaseUtility.MultiLerpColor(Main.LocalPlayer.miscCounter % 100 / 100f, MDColors.ForbiddenLavender, MDColors.ForbiddenPurple, MDColors.ForbiddenLavender);

		public override int GetPrefixedRarity(int offset, float valueMult)
		{
			return Type;
		}
	}
}