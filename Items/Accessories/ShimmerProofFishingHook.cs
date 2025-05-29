using MultidimensionMod.Common.Players;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Accessories
{
    public class ShimmerProofFishingHook : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 30;
            Item.height = 56;
            Item.rare = 7;
            Item.value = Item.sellPrice(0, 2);
            Item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<MDPlayer>().shimmerProofHook = true;
        }

        /*public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<ThornScarf>())
            .AddIngredient(ItemID.VialofVenom, 2)
            .AddIngredient(ItemID.Deathweed, 3)
            .AddTile(TileID.MythrilAnvil)
            .Register();
        }*/
    }
}