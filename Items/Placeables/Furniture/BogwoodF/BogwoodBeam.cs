using MultidimensionMod.Items.Placeables.Biomes.Mire;
using MultidimensionMod.Tiles.Furniture.Bogwood;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Placeables.Furniture.BogwoodF
{
    public class BogwoodBeam : ModItem
    {
        public override void SetDefaults()
        {

            Item.width = 16;
            Item.height = 16;
            Item.maxStack = 9999;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = 1;
            Item.consumable = true;
            Item.createTile = ModContent.TileType<BogwoodBeamPlaced>();
        }

        public override void SetStaticDefaults()
        {
        }

        public override void AddRecipes()
        {
            CreateRecipe(2)
            .AddIngredient(ModContent.ItemType<Bogwood>(), 1)
            .AddTile(TileID.Sawmill)
            .Register();
        }
    }
}