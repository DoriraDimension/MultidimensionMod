using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Placeables.Furniture.RazewoodF
{
    public class RazewoodLamp: ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Razewood Lamp");
        }

        public override void SetDefaults()
        {
            Item.width = 12;
            Item.height = 34;
            Item.maxStack = 9999;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.consumable = true;
            Item.value = 250;
            Item.createTile = ModContent.TileType<Tiles.Furniture.Razewood.RazewoodLampPlaced>();
        }
        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<Biomes.Inferno.Razewood>(), 3)
            .AddIngredient(ItemID.Torch)
            .AddTile(TileID.WorkBenches)
            .Register();
        }
    }
}