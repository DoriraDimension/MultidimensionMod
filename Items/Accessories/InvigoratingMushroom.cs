using Terraria;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Accessories
{
    public class InvigoratingMushroom : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 26;
            Item.height = 26;
            Item.rare = 1;
            Item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.statLifeMax2 += 20;
        }
    }
}