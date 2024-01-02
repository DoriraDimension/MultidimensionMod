using MultidimensionMod.Items.Weapons.Magic.Tomes;
using MultidimensionMod.Items.Weapons.Summon;
using MultidimensionMod.Items.Vanity;
using MultidimensionMod.Items.Accessories;
using MultidimensionMod.Items.Pets;
using MultidimensionMod.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.ItemDropRules;
using Terraria.GameContent.Creative;
using System;

namespace MultidimensionMod.Items.Bags
{
    public class FungusBag : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 3;
            ItemID.Sets.BossBag[Type] = true;
            ItemID.Sets.PreHardmodeLikeBossBag[Type] = true;
        }

        public override void SetDefaults()
        {
            Item.maxStack = 9999;
            Item.consumable = true;
            Item.width = 42;
            Item.height = 40;
            Item.rare = ItemRarityID.Blue;
            Item.expert = true;
        }

        public override bool CanRightClick()
        {
            return true;
        }

        public override void ModifyItemLoot(ItemLoot Itemloot)
        {
            Itemloot.Add(ItemDropRule.Common(ModContent.ItemType<FungusMask>(), 7));
            Itemloot.Add(ItemDropRule.OneFromOptions(1, ModContent.ItemType<UmosShower>(), ModContent.ItemType<RadianceTalisman>()));
            Itemloot.Add(ItemDropRule.Common(ModContent.ItemType<TheStem>()));
            Itemloot.Add(ItemDropRule.Common(ModContent.ItemType<GlowingMushmatter>(), 1, 5, 10));
            Itemloot.Add(ItemDropRule.Common(ModContent.ItemType<SusGlowsporeBag>(), 10));
        }
    }
}