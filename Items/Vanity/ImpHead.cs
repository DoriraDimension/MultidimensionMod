using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using System;

namespace MultidimensionMod.Items.Vanity
{
    [AutoloadEquip(EquipType.Head)]
    public class ImpHead : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 28;
            Item.height = 26;
            Item.value = Item.sellPrice(0, 0, 50, 0);
            Item.rare = ItemRarityID.Orange;
            Item.vanity = true;
            ArmorIDs.Head.Sets.DrawHead[Item.headSlot] = false;
        }
    }
}