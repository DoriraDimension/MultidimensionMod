using MultidimensionMod.Tiles.Furniture.VoidMatter;
using MultidimensionMod.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Placeables.Furniture.VoidMatter
{
	public class EmptyKingsFabricator : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Void Fabricator");
			// Tooltip.SetDefault("Is used to craft Void Matter items.\nAll Darklings were once forged in such a fabricator by the Empty King, a entity unseen to this day.");
		}

		public override void SetDefaults()
		{
			Item.width = 44;
			Item.height = 46;
			Item.maxStack = 9999;
			Item.useTurn = true;
			Item.autoReuse = true;
			Item.useAnimation = 15;
			Item.useTime = 10;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.consumable = true;
			Item.rare = ItemRarityID.Orange;
			Item.value = Item.sellPrice(silver: 23);
			Item.createTile = ModContent.TileType<EmptyKingsFabricatorPlaced>();
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ModContent.ItemType<DarkMatterClump>(), 12)
			.Register();
		}
	}
}