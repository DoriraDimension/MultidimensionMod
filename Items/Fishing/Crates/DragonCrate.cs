using MultidimensionMod.Common.ItemDropRules.DropConditions;
using MultidimensionMod.Common.Systems;
using MultidimensionMod.Items.Accessories;
using MultidimensionMod.Items.Materials;
using MultidimensionMod.Items.Placeables.Biomes.Inferno;
using MultidimensionMod.Items.Summons;
using MultidimensionMod.Items.Weapons.Melee.Flails;
using MultidimensionMod.Tiles;
using System;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Fishing.Crates
{
    public class DragonCrate : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 5;
            ItemID.Sets.IsFishingCrate[Type] = true;
            ItemID.Sets.IsFishingCrateHardmode[Type] = true;
            ItemID.Sets.ShimmerTransformToItem[Type] = ModContent.ItemType<ScorchedCrate>();
        }

        public override void SetDefaults()
        {
            Item.width = 12;
            Item.height = 12;
            Item.maxStack = 9999;
            Item.consumable = true;
            Item.rare = ItemRarityID.Green;
            Item.value = Item.sellPrice(gold: 1);
            Item.createTile = ModContent.TileType<CratePlaced>();
            Item.placeStyle = 3;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = ItemUseStyleID.Swing;
        }

        public override bool CanRightClick() => true;

        public override void ModifyItemLoot(ItemLoot itemLoot)
        {
            itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<DragonScale>(), 1, 5, 10));
            itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<Incinerite>(), 5, 10, 20));
            itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<IncineriteBar>(), 3, 4, 11));
            //itemLoot.Add(ItemDropRule.ByCondition(new DownedBroodmotherCondition(), ModContent.ItemType<ScorchedScale>(), 3, 2, 4));

            itemLoot.Add(ItemDropRule.Common(ItemID.GoldCoin, 4, 5, 13));

            IItemDropRule[] VolcanoLoot = [
               ItemDropRule.Common(ModContent.ItemType<Pyrosphere>(), 1),
               ItemDropRule.Common(ModContent.ItemType<DragonsGuard>(), 1),
               ItemDropRule.Common(ModContent.ItemType<OrnateBand>(), 1),
            ];
            itemLoot.Add(new OneFromRulesRule(1, VolcanoLoot));

            IItemDropRule[] Ores = [
                ItemDropRule.Common(ItemID.CopperOre, 1, 20, 35),
                ItemDropRule.Common(ItemID.TinOre, 1, 20, 35),
                ItemDropRule.Common(ItemID.IronOre, 1, 20, 35),
                ItemDropRule.Common(ItemID.LeadOre, 1, 20, 35),
                ItemDropRule.Common(ItemID.SilverOre, 1, 20, 35),
                ItemDropRule.Common(ItemID.TungstenOre, 1, 20, 35),
                ItemDropRule.Common(ItemID.GoldOre, 1, 20, 35),
                ItemDropRule.Common(ItemID.PlatinumOre, 1, 20, 35),
            ];
            itemLoot.Add(new OneFromRulesRule(14, Ores));

            IItemDropRule[] HardmodeOres = [
                ItemDropRule.Common(ItemID.CobaltOre, 1, 20, 35),
                ItemDropRule.Common(ItemID.PalladiumOre, 1, 20, 35),
                ItemDropRule.Common(ItemID.MythrilOre, 1, 20, 35),
                ItemDropRule.Common(ItemID.OrichalcumOre, 1, 20, 35),
                ItemDropRule.Common(ItemID.AdamantiteOre, 1, 20, 35),
                ItemDropRule.Common(ItemID.TitaniumOre, 1, 20, 35),
            ];
            itemLoot.Add(new OneFromRulesRule(7, HardmodeOres));

            IItemDropRule[] Bars = [
                ItemDropRule.Common(ItemID.IronBar, 1, 6, 16),
                ItemDropRule.Common(ItemID.LeadBar, 1, 6, 16),
                ItemDropRule.Common(ItemID.SilverBar, 1, 6, 16),
                ItemDropRule.Common(ItemID.TungstenBar, 1, 6, 16),
                ItemDropRule.Common(ItemID.GoldBar, 1, 6, 16),
                ItemDropRule.Common(ItemID.PlatinumBar, 1, 6, 16),
            ];
            itemLoot.Add(new OneFromRulesRule(12, Bars));

            IItemDropRule[] HardmodeBars = [
                ItemDropRule.Common(ItemID.CobaltBar, 1, 6, 16),
                ItemDropRule.Common(ItemID.PalladiumBar, 1, 6, 16),
                ItemDropRule.Common(ItemID.MythrilBar, 1, 6, 16),
                ItemDropRule.Common(ItemID.OrichalcumBar, 1, 6, 16),
                ItemDropRule.Common(ItemID.AdamantiteBar, 1, 6, 16),
                ItemDropRule.Common(ItemID.TitaniumBar, 1, 6, 16),
            ];
            itemLoot.Add(new OneFromRulesRule(6, HardmodeBars));

            IItemDropRule[] explorationPotions = [
                ItemDropRule.Common(ItemID.ObsidianSkinPotion, 1, 2, 4),
                ItemDropRule.Common(ItemID.SpelunkerPotion, 1, 2, 4),
                ItemDropRule.Common(ItemID.HunterPotion, 1, 2, 4),
                ItemDropRule.Common(ItemID.GravitationPotion, 1, 2, 4),
                ItemDropRule.Common(ItemID.MiningPotion, 1, 2, 4),
                ItemDropRule.Common(ItemID.HeartreachPotion, 1, 2, 4),
            ];
            itemLoot.Add(new OneFromRulesRule(4, explorationPotions));

            IItemDropRule[] resourcePotions = [
                ItemDropRule.Common(ItemID.HealingPotion, 1, 5, 17),
                ItemDropRule.Common(ItemID.ManaPotion, 1, 5, 17),
            ];
            itemLoot.Add(new OneFromRulesRule(2, resourcePotions));

            IItemDropRule[] highendBait = [
                ItemDropRule.Common(ItemID.JourneymanBait, 1, 2, 6),
                ItemDropRule.Common(ItemID.MasterBait, 1, 2, 6),
            ];
            itemLoot.Add(new OneFromRulesRule(2, highendBait));
        }
    }
}