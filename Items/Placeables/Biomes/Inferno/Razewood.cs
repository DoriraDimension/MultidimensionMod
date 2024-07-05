using MultidimensionMod.Tiles.Biomes.Inferno;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using MultidimensionMod.Items.Placeables.Furniture.RazewoodF;

namespace MultidimensionMod.Items.Placeables.Biomes.Inferno
{
    class Razewood : ModItem
    {
        public override void SetDefaults()
        {

            Item.width = 24;
            Item.height = 22;
            Item.maxStack = 9999;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.consumable = true;
            Item.createTile = ModContent.TileType<RazewoodPlaced>(); //put your CustomBlock Tile name
            Item.ammo = Item.type;
            Item.notAmmo = true;
        }

        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Razewood");
            //Tooltip.SetDefault("");
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<RazewoodWall>(), 4)
                .AddTile(TileID.WorkBenches)
                .Register();

            CreateRecipe()
            .AddIngredient(ModContent.ItemType<RazewoodPlatform>(), 2)
            .Register();
        }
    }
}
