using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Placeables.Furniture.BogwoodF
{
    public class BogwoodChest : ModItem
	{
		public override void SetStaticDefaults()
		{
            //DisplayName.SetDefault("Bogwood Chest");
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
            Item.rare = 1;
            Item.useStyle = 1;
			Item.consumable = true;
			Item.value = 500;
			Item.createTile = ModContent.TileType<Tiles.Furniture.Bogwood.BogwoodChestPlaced>();
        }

		public override void AddRecipes()
		{
            CreateRecipe()
                .AddRecipeGroup(RecipeGroupID.IronBar, 2)
                .AddIngredient(ModContent.ItemType<Biomes.Mire.Bogwood>(), 12)
                .AddTile(TileID.WorkBenches)
                .Register();
        }
    }
}