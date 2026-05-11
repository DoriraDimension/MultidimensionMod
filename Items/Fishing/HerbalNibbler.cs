using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Fishing
{
    public class HerbalNibbler : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 3;
            ItemID.Sets.CanBePlacedOnWeaponRacks[Type] = true;
        }

        public override void SetDefaults()
        {
            Item.width = 58;
            Item.height = 60;
            Item.maxStack = 9999;
            Item.rare = ItemRarityID.Green;
            Item.value = Item.sellPrice(0, 0, 0, 10);
        }
    }
}