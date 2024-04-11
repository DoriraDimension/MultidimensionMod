using MultidimensionMod.Tiles.Furniture.RedMush;
using MultidimensionMod.Items.Placeables.Biomes.ShroomForest;
using Terraria.ModLoader;
using Terraria;

namespace MultidimensionMod.Items.Placeables.Furniture.RedMush
{
    public class RedMushPlatform : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 200;
        }

        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<RedMushPlatformPlaced>(), 0);
            Item.width = 24;
            Item.height = 14;
            Item.maxStack = 9999;
        }

        public override void AddRecipes()
        {
            CreateRecipe(2)
                .AddIngredient(ModContent.ItemType<MushroomBlock>())
                .Register();
        }
    }
}