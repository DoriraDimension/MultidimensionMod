using MultidimensionMod.Tiles.Furniture.VoidMatter;
using MultidimensionMod.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Placeables.Furniture.VoidMatter
{
	public class VoidMatterLamp : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Void Matter Lamp");
			// Tooltip.SetDefault("A shady man stands under a lamp outside, he asks you to come closer, will you?");
		}

		public override void SetDefaults()
		{
			Item.width = 12;
			Item.height = 32;
			Item.maxStack = 9999;
			Item.useTurn = true;
			Item.autoReuse = true;
			Item.useAnimation = 15;
			Item.useTime = 10;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.consumable = true;
			Item.rare = ItemRarityID.Orange;
			Item.value = Item.sellPrice(silver: 23);
			Item.createTile = ModContent.TileType<VoidMatterLampPlaced>();
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ModContent.ItemType<DarkMatterClump>(), 3)
			.AddIngredient(ModContent.ItemType<Dimensium>())
			.AddTile(ModContent.TileType<EmptyKingsFabricatorPlaced>())
			.Register();
		}
	}
}