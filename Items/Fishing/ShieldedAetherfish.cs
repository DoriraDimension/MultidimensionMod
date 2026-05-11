using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Fishing
{
    public class ShieldedAetherfish : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.Item.ResearchUnlockCount = 3;
            ItemID.Sets.CanBePlacedOnWeaponRacks[Type] = true;
        }

        public override void SetDefaults()
        {
            Item.width = 48;
            Item.height = 44;
            Item.maxStack = 9999;
            Item.rare = ItemRarityID.Blue;
            Item.value = Item.sellPrice(0, 0, 0, 10);
        }
    }
}