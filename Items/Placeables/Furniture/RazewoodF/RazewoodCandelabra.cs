using MultidimensionMod.Tiles.Furniture.Razewood;
using MultidimensionMod.Items.Placeables.Biomes.Inferno;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Placeables.Furniture.RazewoodF
{
    public class RazewoodCandelabra : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Razewood Candelabra");
        }

        public override void SetDefaults()
        {
            Item.width = 26;
            Item.height = 32;
            Item.maxStack = 9999;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.consumable = true;
            Item.value = 250;
            Item.createTile = ModContent.TileType<RazewoodCandelabraPlaced>();
        }
        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<Razewood>(), 5)
            .AddIngredient(ItemID.Torch, 3)
            .AddTile(TileID.WorkBenches)
            .Register();

        }

    }
}