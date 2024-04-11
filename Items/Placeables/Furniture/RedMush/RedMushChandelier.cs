using MultidimensionMod.Tiles.Furniture.RedMush;
using MultidimensionMod.Items.Placeables.Biomes.ShroomForest;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Placeables.Furniture.RedMush
{
    public class RedMushChandelier : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<RedMushChandelierPlaced>());
            Item.width = 34;
            Item.height = 34;
            Item.maxStack = 9999;
            Item.value = Item.sellPrice(silver: 10);
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<MushroomBlock>(), 4)
                .AddIngredient(ItemID.Torch, 4)
                .AddIngredient(ItemID.Chain)
                .AddTile(TileID.WorkBenches)
                .Register();
        }
    }
}