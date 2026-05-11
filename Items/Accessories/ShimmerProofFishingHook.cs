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
            Item.width = 24;
            Item.height = 36;
            Item.value = Item.sellPrice(0, 2);
            Item.rare = ItemRarityID.LightRed;
            Item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<MDPlayer>().shimmerProofHook = true;
        }
    }
}