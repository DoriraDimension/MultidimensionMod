using MultidimensionMod.Items.Accessories;
using MultidimensionMod.Items.Materials;
using MultidimensionMod.Items.Pets;
using MultidimensionMod.Items.Potions.Food;
using MultidimensionMod.Items.Vanity;
using MultidimensionMod.Items.Weapons.Melee.Boomerangs;
using MultidimensionMod.Items.Weapons.Ranged.Bows;
using System;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Fishing
{
    public class TreasureClam : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.Item.ResearchUnlockCount = 3;
            ItemID.Sets.CanBePlacedOnWeaponRacks[Type] = true;
        }

        public override void SetDefaults()
        {
            Item.width = 34;
            Item.height = 34;
            Item.maxStack = 9999;
            Item.rare = ItemRarityID.Green;
            Item.value = Item.sellPrice(0, 0, 0, 10);
        }

        public override bool CanRightClick()
        {
            return true;
        }

        public override void ModifyItemLoot(ItemLoot Itemloot)
        {
            Itemloot.Add(ItemDropRule.Common(ItemID.ShimmerBlock, 1, 10, 15));
            Itemloot.Add(ItemDropRule.Common(ItemID.WhitePearl, 10));
            Itemloot.Add(ItemDropRule.Common(ItemID.BlackPearl, 20));
            Itemloot.Add(ItemDropRule.Common(ItemID.PinkPearl, 40));
            Itemloot.Add(ItemDropRule.Common(ModContent.ItemType<FortunePearl>(), 60));
        }
    }
}