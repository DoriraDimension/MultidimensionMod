using MultidimensionMod.Items.Placeables.Biomes.Inferno;
using MultidimensionMod.Tiles.Furniture.Razewood;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Placeables.Furniture.RazewoodF
{
    public class RazewoodBeam : ModItem
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
            Item.createTile = ModContent.TileType<RazewoodBeamPlaced>();
        }

        public override void SetStaticDefaults()
        {
        }

        public override void AddRecipes()
        {
            CreateRecipe(2)
            .AddIngredient(ModContent.ItemType<Razewood>(), 1)
            .AddTile(TileID.Sawmill)
            .Register();
        }
    }
}