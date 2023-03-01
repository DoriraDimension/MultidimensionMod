using MultidimensionMod.Tiles.Furniture.VoidMatter;
using MultidimensionMod.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Placeables.Furniture.VoidMatter
{
	public class VoidMatterDoor : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Void Matter Door");
			// Tooltip.SetDefault("You can close the door, but the void will always find a way in.");
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
			Item.value = Item.sellPrice(silver: 7);
			Item.createTile = ModContent.TileType<VoidMatterDoorClosed>();
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ModContent.ItemType<DarkMatterClump>(), 6)
			.AddTile(ModContent.TileType<EmptyKingsFabricatorPlaced>())
			.Register();
		}
	}
}