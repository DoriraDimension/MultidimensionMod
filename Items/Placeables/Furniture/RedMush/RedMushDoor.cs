using MultidimensionMod.Tiles.Furniture.RedMush;
using MultidimensionMod.Items.Placeables.Biomes.ShroomForest;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Placeables.Furniture.RedMush
{
    public class RedMushDoor : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<RedMushDoorClosed>(), 0);
            Item.width = 20;
            Item.height = 34;
            Item.maxStack = 9999;
            Item.value = Item.sellPrice(silver: 7);
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<MushroomBlock>(), 6)
                .AddTile(TileID.WorkBenches)
                .Register();
        }
    }
}