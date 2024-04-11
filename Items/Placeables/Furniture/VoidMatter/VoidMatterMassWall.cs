using MultidimensionMod.Walls;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria;

namespace MultidimensionMod.Items.Placeables.Furniture.VoidMatter
{
    public class VoidMatterMassWall : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 400;
        }
        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 32;
            Item.maxStack = 9999;
            Item.DefaultToPlaceableWall(ModContent.WallType<VoidMatterMassWallPlaced>());
        }

        public override void AddRecipes()
        {
            CreateRecipe(4)
                .AddIngredient(ModContent.ItemType<VoidMatterMass>())
                .AddTile(TileID.HeavyWorkBench)
                .Register();
        }
    }
}