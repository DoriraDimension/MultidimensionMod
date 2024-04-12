using Terraria.ModLoader;
using Terraria.ID;

namespace MultidimensionMod.Items.Placeables.Furniture.RazewoodF
{
    public class RazewoodPlatform : ModItem
	{
		public override void SetStaticDefaults()
		{
            //DisplayName.SetDefault("Razewood Platform");
		}

		public override void SetDefaults()
		{
			Item.width = 8;
			Item.height = 10;
			Item.maxStack = 9999;
			Item.useTurn = true;
			Item.autoReuse = true;
			Item.useAnimation = 15;
			Item.useTime = 10;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.consumable = true;
			Item.createTile = ModContent.TileType<Tiles.Furniture.Razewood.RazewoodPlatformPlaced>();
		}

		public override void AddRecipes()
        {
            CreateRecipe(2)
            .AddIngredient(ModContent.ItemType<Biomes.Inferno.Razewood>(), 2)
            .Register();
        }
	}
}
