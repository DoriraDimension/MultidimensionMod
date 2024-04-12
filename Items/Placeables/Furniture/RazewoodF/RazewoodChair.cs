using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Placeables.Furniture.RazewoodF
{
    public class RazewoodChair : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Razewood Chair");
        }

        public override void SetDefaults()
        {
            Item.width = 16;
            Item.height = 32;
            Item.maxStack = 9999;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.consumable = true;
            Item.value = 250;
            Item.createTile = ModContent.TileType<Tiles.Furniture.Razewood.RazewoodChairPlaced>();
        }
        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<Biomes.Inferno.Razewood>(), 4)
            .AddTile(TileID.WorkBenches)
            .Register();
        }
    }
}