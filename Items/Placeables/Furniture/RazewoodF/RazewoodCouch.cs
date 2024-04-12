using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Placeables.Furniture.RazewoodF
{
    public class RazewoodCouch : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Razewood Couch");
        }

        public override void SetDefaults()
        {
            Item.width = 38;
            Item.height = 24;
            Item.maxStack = 9999;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = 1;
            Item.consumable = true;
            Item.value = 250;
            Item.createTile = ModContent.TileType<Tiles.Furniture.Razewood.RazewoodCouchPlaced>();
        }
        public override void AddRecipes()
        {
           CreateRecipe()
            .AddIngredient(ModContent.ItemType<Biomes.Inferno.Razewood>(), 5)
            .AddIngredient(ItemID.Silk, 2)
            .AddTile(TileID.Sawmill)
            .Register();

        }
    }
}