using MultidimensionMod.Items.Placeables;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Placeables
{
	public class BrokenAncientDepictionItem : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Broken Ancient Depiction");
			// Tooltip.SetDefault("A big and heavy sandstone tablet, it seems to be broken and it's difficult to guess what it is showing.\nDont drop it on the ground, its fragile");
		}

		public override void SetDefaults()
		{
			Item.width = 34;
			Item.height = 20;
			Item.maxStack = 9999;
			Item.useTurn = true;
			Item.autoReuse = true;
			Item.useAnimation = 15;
			Item.useTime = 10;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.consumable = true;
			Item.rare = ItemRarityID.White;
			Item.value = Item.sellPrice(silver: 20);
			Item.createTile = ModContent.TileType<Tiles.BrokenAncientDepiction>();
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ModContent.ItemType<AncientDepictionItem>())
			.Register();
		}
	}
}