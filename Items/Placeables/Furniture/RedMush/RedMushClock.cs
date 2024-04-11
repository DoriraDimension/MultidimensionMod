using MultidimensionMod.Tiles.Furniture.RedMush;
using MultidimensionMod.Items.Placeables.Biomes.ShroomForest;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Placeables.Furniture.RedMush
{
    public class RedMushClock : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<RedMushClockPlaced>(), 0);
            Item.width = 18;
            Item.height = 40;
            Item.maxStack = 9999;
            Item.value = Item.sellPrice(silver: 15);
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<MushroomBlock>(), 10)
                .AddRecipeGroup(RecipeGroupID.IronBar, 3)
                .AddIngredient(ItemID.Glass, 6)
                .AddTile(TileID.Sawmill)
                .Register();
        }
    }
}