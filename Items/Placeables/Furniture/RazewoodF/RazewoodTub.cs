using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Placeables.Furniture.RazewoodF
{
    public class RazewoodTub : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Razewood Bathtub");
        }

        public override void SetDefaults()
        {
            Item.width = 34;
            Item.height = 26;
            Item.maxStack = 9999;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = 1;
            Item.consumable = true;
            Item.value = 250;
            Item.createTile = ModContent.TileType < Tiles.Furniture.Razewood.RazewoodTubPlaced>();
        }
        public override void AddRecipes()
        {
           CreateRecipe()
            .AddIngredient(ModContent.ItemType<Biomes.Inferno.Razewood>(), 14)
            .AddTile(TileID.Sawmill)
            .Register();
        }
    }
}