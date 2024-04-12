using Terraria.ModLoader;
using Terraria.ID;

namespace MultidimensionMod.Items.Placeables.Furniture.RazewoodF
{
    public class RazewoodWall : ModItem
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
            Item.useStyle = ItemUseStyleID.Swing;
            Item.consumable = true;
            Item.createWall = ModContent.WallType<Walls.RazewoodWallPlaced>();
        }
        
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Razewood Wall");
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<Biomes.Inferno.Razewood>())
            .AddTile(TileID.WorkBenches)
            .Register();
        }
    }
}
