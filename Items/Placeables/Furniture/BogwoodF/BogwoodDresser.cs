using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Placeables.Furniture.BogwoodF
{
    public class BogwoodDresser : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Bogwood Dresser");
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
            Item.createTile = ModContent.TileType<Tiles.Furniture.Bogwood.BogwoodDresserPlaced>();
        }
        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<Biomes.Mire.Bogwood>(), 16)
            .AddTile(TileID.Sawmill)
            .Register();

        }

    }
}