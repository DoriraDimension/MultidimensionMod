using MultidimensionMod.Tiles.Furniture.RedMush;
using MultidimensionMod.Items.Placeables.Biomes.ShroomForest;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;

namespace MultidimensionMod.Items.Placeables.Furniture.RedMush
{
    public class RedMushLantern : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<RedMushLanternPlaced>());
            Item.width = 16;
            Item.height = 26;
            Item.maxStack = 9999;
            Item.value = Item.sellPrice(silver: 23);
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<MushroomBlock>(), 6)
                .AddIngredient(ItemID.Torch)
                .AddTile(TileID.WorkBenches)
                .Register();
        }
    }
}