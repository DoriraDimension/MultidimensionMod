using MultidimensionMod.Common.Players;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Accessories
{
    public class TheBrick : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 34;
            Item.height = 30;
            Item.accessory = true;
            Item.rare = ItemRarityID.Green;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<MDPlayer>().Brick = true;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.ClayBlock, 200)
            .AddTile(TileID.Furnaces)
            .Register();
        }
    }
}