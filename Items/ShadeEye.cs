using MultidimensionMod.Rarities;
using Terraria;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace MultidimensionMod.Items
{
	public class ShadeEye : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
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