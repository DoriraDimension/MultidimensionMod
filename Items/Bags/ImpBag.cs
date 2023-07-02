using MultidimensionMod.Items.Vanity;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using System;

namespace MultidimensionMod.Items.Bags
{
    public class ImpBag : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 30;
            Item.height = 30;
            Item.rare = ItemRarityID.Orange;
            Item.maxStack = 99;
            Item.value = Item.sellPrice(0, 0, 5, 0);
        }

        public override bool CanRightClick()
        {
            return true;
        }

        public override void RightClick(Player player)
        {
            var source = player.GetSource_OpenItem(Type);
            player.QuickSpawnItem(source, ModContent.ItemType<ImpHead>());
            player.QuickSpawnItem(source, ModContent.ItemType<ImpBodyPlate>());
            player.QuickSpawnItem(source, ModContent.ItemType<ImpLegs>());
        }
    }
}