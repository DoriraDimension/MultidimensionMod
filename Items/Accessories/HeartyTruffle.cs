using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using MultidimensionMod.Common.Players;

namespace MultidimensionMod.Items.Accessories
{
    public class HeartyTruffle : ModItem
    {

        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Hearty Truffle");
            //Tooltip.SetDefault("+50 Health\nDon't eat it");
        }


        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 32;
            Item.value = Item.sellPrice(0, 1, 0, 0);
            Item.rare = ItemRarityID.Expert;
            Item.accessory = true;
            Item.expert = true; 
            Item.expertOnly = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<MDPlayer>().MonarchHeart = true;
            player.GetDamage(DamageClass.Generic) += 0.10f;
        }
    }
}