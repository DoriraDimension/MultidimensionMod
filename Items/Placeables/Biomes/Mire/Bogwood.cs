using MultidimensionMod.Tiles.Biomes.Mire;
using Terraria.ModLoader;
using Terraria.ID;

namespace MultidimensionMod.Items.Placeables.Biomes.Mire
{
    class Bogwood : ModItem
    {
        public override void SetDefaults()
        {

            Item.width = 20;
            Item.height = 20;
            Item.maxStack = 9999;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.consumable = true;
            Item.createTile = ModContent.TileType<BogwoodPlaced>();
            Item.rare = ItemRarityID.White;
        }

        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Bogwood");
            //Tooltip.SetDefault("");
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<Furniture.BogwoodF.BogwoodWall>(), 4)
            .AddTile(TileID.WorkBenches)
            .Register();

            CreateRecipe()
            .AddIngredient(ModContent.ItemType<Furniture.BogwoodF.BogwoodPlatform>(), 2)
            .AddTile(TileID.WorkBenches)
            .Register();
        }
    }
}
