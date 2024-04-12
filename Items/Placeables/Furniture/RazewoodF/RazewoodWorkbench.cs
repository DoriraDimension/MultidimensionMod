using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Placeables.Furniture.RazewoodF
{
    public class RazewoodWorkbench : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Razewood Workbench");
        }

        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 18;
            Item.maxStack = 9999;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.consumable = true;
            Item.value = 250;
            Item.createTile = ModContent.TileType<Tiles.Furniture.Razewood.RazewoodWorkbenchPlaced>();
        }
        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<Biomes.Inferno.Razewood>(), 10)
            .AddTile(TileID.WorkBenches)
            .Register();
        }
    }
}