using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using System;

namespace MultidimensionMod.Items.Vanity
{
    [AutoloadEquip(EquipType.Head)]
    public class FungusMask : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 28;
            Item.height = 26;
            Item.value = Item.sellPrice(0, 0, 60, 0);
            Item.rare = ItemRarityID.Green;
            Item.vanity = true;
            ArmorIDs.Head.Sets.DrawHead[Item.headSlot] = false;

        }
    }
}