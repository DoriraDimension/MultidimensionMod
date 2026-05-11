using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Fishing
{
    public class StargazerBass : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 3;
            ItemID.Sets.CanBePlacedOnWeaponRacks[Type] = true;
        }

        public override void SetDefaults()
        {
            Item.width = 34;
            Item.height = 34;
            Item.maxStack = 9999;
            Item.rare = ItemRarityID.White;
            Item.value = Item.sellPrice(0, 0, 0, 10);
        }
    }
}