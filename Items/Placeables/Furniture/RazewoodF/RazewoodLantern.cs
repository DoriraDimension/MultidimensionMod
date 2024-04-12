using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Placeables.Furniture.RazewoodF
{
    public class RazewoodLantern : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Razewood Lantern");
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
            Item.createTile = ModContent.TileType<Tiles.Furniture.Razewood.RazewoodLanternPlaced>();
        }
        public override void AddRecipes()
        {
           CreateRecipe()
            .AddIngredient(ModContent.ItemType<Biomes.Inferno.Razewood>(), 6)
            .AddIngredient(ItemID.Torch)
            .AddTile(TileID.WorkBenches)
            .Register();
        }
    }
}