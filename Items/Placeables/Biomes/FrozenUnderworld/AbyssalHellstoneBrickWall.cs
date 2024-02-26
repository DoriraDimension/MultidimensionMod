using MultidimensionMod.Walls;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria;

namespace MultidimensionMod.Items.Placeables.Biomes.FrozenUnderworld
{
    public class AbyssalHellstoneBrickWall : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 400;
        }
        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 24;
            Item.maxStack = 9999;
            Item.DefaultToPlaceableWall(ModContent.WallType<AbyssalHellstoneBrickWallPlaced>());
        }

        public override void AddRecipes()
        {
            CreateRecipe(4)
                .AddIngredient(ModContent.ItemType<AbyssalHellstoneBrick>())
                .AddTile(TileID.WorkBenches)
                .Register();
        }
    }
}