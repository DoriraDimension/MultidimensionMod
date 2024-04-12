using MultidimensionMod.Tiles.Biomes.Inferno;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Placeables.Biomes.Inferno
{
    public class IncineriteBrick : ModItem
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
            Item.createTile = ModContent.TileType<IncineriteBrickPlaced>();
        }

        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Incinerite Brick");
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<Incinerite>(), 1)
            .AddIngredient(ItemID.StoneBlock, 1)
            .AddTile(TileID.Furnaces)
            .Register();
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<IncineriteWall>(), 4)
            .AddTile(TileID.WorkBenches)
            .Register();
        }
    }
}
