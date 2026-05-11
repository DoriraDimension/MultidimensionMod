using MultidimensionMod.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using MultidimensionMod.Common.Players;
using System;

namespace MultidimensionMod.Items.Accessories
{
    public class HiveNugget : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 22;
            Item.height = 26;
            Item.accessory = true;
            Item.value = Item.sellPrice(0, 1, 20, 50);
            Item.rare = ItemRarityID.Green;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<MDPlayer>().hiveNugget = true;
            player.sticky = false;
            if (player.honeyWet)
            {
                player.ignoreWater = true;
            }
        }
    }
}