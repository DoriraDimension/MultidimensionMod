using MultidimensionMod.Tiles.Furniture.RedMush;
using MultidimensionMod.Items.Placeables.Biomes.ShroomForest;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Placeables.Furniture.RedMush
{
    public class RedMushPiano : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<RedMushPianoPlaced>(), 0);
            Item.width = 38;
            Item.height = 24;
            Item.maxStack = 9999;
            Item.value = Item.sellPrice(silver: 23);
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.Bone, 4)
                .AddIngredient(ModContent.ItemType<MushroomBlock>(), 15)
                .AddIngredient(ItemID.Book)
                .AddTile(TileID.Sawmill)
                .Register();
        }
    }
}