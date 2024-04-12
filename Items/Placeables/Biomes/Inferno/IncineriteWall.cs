using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Placeables.Biomes.Inferno
{
    public class IncineriteWall : ModItem
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
            Item.createWall = ModContent.WallType<Walls.IncineriteWallPlaced>();
        }
        
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Incinerite Brick Wall");
        }

        public override void AddRecipes()
        {
            CreateRecipe(4)
            .AddIngredient(ModContent.ItemType<IncineriteBrick>())
            .AddTile(TileID.WorkBenches)
            .Register();
        }
    }
}
