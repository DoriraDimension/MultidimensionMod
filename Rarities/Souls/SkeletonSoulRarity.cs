using Terraria;
using Microsoft.Xna.Framework;
using MultidimensionMod.Base;
using Terraria.ModLoader;

namespace MultidimensionMod.Rarities.Souls
{
	public class SkeletonSoulRarity : ModRarity
	{
		public override Color RarityColor => BaseUtility.MultiLerpColor(Main.LocalPlayer.miscCounter % 100 / 100f, MDColors.Bone, MDColors.DarkBone, MDColors.Bone);

		public override int GetPrefixedRarity(int offset, float valueMult)
		{
			return Type;
		}
	}
}