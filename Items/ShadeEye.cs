using MultidimensionMod.Rarities;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace MultidimensionMod.Items
{
	public class ShadeEye : ModItem
	{
		public override void SetStaticDefaults()
		{
		}

		public override void SetDefaults()
		{
			Item.width = 30;
			Item.height = 32;
			Item.rare = ModContent.RarityType<ShadeItem>();
		}

		public override void AddRecipes()
		{
		}
	}
}