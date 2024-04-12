using MultidimensionMod.Tiles.Furniture.Razewood;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Placeables.Furniture.RazewoodF
{
    public class RazewoodChest : ModItem
	{
		public override void SetStaticDefaults()
		{
            //DisplayName.SetDefault("Razewood Chest");
		}

		public override void SetDefaults()
		{
			Item.width = 32;
			Item.height = 32;
			Item.maxStack = 9999;
			Item.useTurn = true;
			Item.autoReuse = true;
			Item.useAnimation = 15;
			Item.useTime = 10;
            Item.rare = ItemRarityID.Blue;
            Item.useStyle = ItemUseStyleID.Swing;
			Item.consumable = true;
			Item.value = 500;
			Item.createTile = ModContent.TileType<RazewoodChestPlaced>();
		}

		public override void AddRecipes()
		{
            {
                CreateRecipe()
                .AddRecipeGroup(RecipeGroupID.IronBar, 2)
                .AddIngredient(ModContent.ItemType<Placeables.Biomes.Inferno.Razewood>(), 12)
                .AddTile(TileID.WorkBenches)
                .Register();
            }
        }
    }
}