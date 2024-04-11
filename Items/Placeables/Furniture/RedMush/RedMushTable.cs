using MultidimensionMod.Tiles.Furniture.RedMush;
using MultidimensionMod.Items.Placeables.Biomes.ShroomForest;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Placeables.Furniture.RedMush
{
    public class RedMushTable : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<RedMushTablePlaced>());
            Item.width = 38;
            Item.height = 24;
            Item.maxStack = 9999;
            Item.value = Item.sellPrice(silver: 23);
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<MushroomBlock>(), 8)
                .AddTile(TileID.WorkBenches)
                .Register();
        }
    }
}