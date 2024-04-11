using MultidimensionMod.Tiles.Furniture.RedMush;
using MultidimensionMod.Items.Placeables.Biomes.ShroomForest;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Placeables.Furniture.RedMush
{
    public class RedMushBed : ModItem
    {
        public override void SetStaticDefaults()
        {
           Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<RedMushBedPlaced>(), 0);
            Item.width = 34;
            Item.height = 18;
            Item.maxStack = 9999;
            Item.value = Item.sellPrice(silver: 23);
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<MushroomBlock>(), 15)
                .AddIngredient(ItemID.Silk, 5)
                .AddTile(TileID.Sawmill)
                .Register();
        }
    }
}