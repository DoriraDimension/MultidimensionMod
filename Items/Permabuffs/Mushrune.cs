﻿using MultidimensionMod.Common.Players;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Permabuffs
{
    internal class Mushrune : ModItem
    {
        public static readonly int MaxUsage = 1;
        public static readonly int ManaPerCrystal = 50;

        public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(ManaPerCrystal, MaxUsage);

        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.ManaCrystal);
            Item.width = 34;
            Item.height = 38;
            Item.rare = ItemRarityID.Cyan;
            Item.useAnimation = 20;
            Item.useTime = 20;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.UseSound = SoundID.Thunder;
            Item.consumable = true;
        }

        public override bool CanUseItem(Player player)
        {
            return player.ConsumedManaCrystals == Player.ManaCrystalMax;
        }

        public override bool? UseItem(Player player)
        {
            if (player.GetModPlayer<PermabuffPlayer>().mushrune >= MaxUsage)
            {
                return null;
            }

            player.UseManaMaxIncreasingItem(ManaPerCrystal);

            player.GetModPlayer<PermabuffPlayer>().mushrune++;

            return true;
        }
    }
}