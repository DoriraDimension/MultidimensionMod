using Terraria.ModLoader;
using Terraria.ID;

namespace MultidimensionMod.Items.Placeables.Furniture.BogwoodF
{
    public class BogwoodWall : ModItem
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
            Item.createWall = ModContent.WallType<Walls.BogwoodWallPlaced>();
        }

        
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Bogwood Wall");
        }

        public override void AddRecipes()
        {
            CreateRecipe(4)
            .AddIngredient(ModContent.ItemType<Biomes.Mire.Bogwood>())
            .AddTile(TileID.WorkBenches)
            .Register();
        }
    }
}
