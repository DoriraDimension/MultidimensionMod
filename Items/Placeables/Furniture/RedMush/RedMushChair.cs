using MultidimensionMod.Tiles.Furniture.RedMush;
using MultidimensionMod.Items.Placeables.Biomes.ShroomForest;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;

namespace MultidimensionMod.Items.Placeables.Furniture.RedMush
{
    public class RedMushChair : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<RedMushChairPlaced>(), 0);
            Item.width = 16;
            Item.height = 34;
            Item.maxStack = 9999;
            Item.value = Item.sellPrice(silver: 8);
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<MushroomBlock>(), 4)
                .AddTile(TileID.WorkBenches)
                .Register();
        }
    }
}