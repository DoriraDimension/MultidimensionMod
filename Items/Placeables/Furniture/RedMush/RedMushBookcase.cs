using MultidimensionMod.Tiles.Furniture.RedMush;
using MultidimensionMod.Items.Placeables.Biomes.ShroomForest;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Placeables.Furniture.RedMush
{
    public class RedMushBookcase : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<RedMushBookcasePlaced>(), 0);
            Item.width = 26;
            Item.height = 32;
            Item.maxStack = 9999;
            Item.value = Item.sellPrice(silver: 23);
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<MushroomBlock>(), 20)
                .AddIngredient(ItemID.Book, 10)
                .AddTile(TileID.Sawmill)
                .Register();
        }
    }
}