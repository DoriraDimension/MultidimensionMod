﻿using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using System;

namespace MultidimensionMod.Items.Vanity
{
    [AutoloadEquip(EquipType.Head)]
    public class TheDapperCap : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 16;
            Item.value = Item.sellPrice(0, 0, 0, 30);
            Item.rare = ItemRarityID.Blue;
            Item.vanity = true;
        }
    }
}