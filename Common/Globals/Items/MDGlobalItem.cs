//using MultidimensionMod.Items.Quest;
using MultidimensionMod.Items.Placeables.Banners;
using MultidimensionMod.Items.Pets;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Microsoft.Xna.Framework;

namespace MultidimensionMod.Common.Globals.Items
{
	public class MDGlobalItem : GlobalItem
	{
		public override void SetStaticDefaults()
        {
			ItemID.Sets.ShimmerTransformToItem[ItemID.FallenStar] = ModContent.ItemType<Cassiopeia>();
            ItemID.Sets.ShimmerTransformToItem[ItemID.IceSlimeBanner] = ModContent.ItemType<FrostburnSlimeBanner>();
        }
		public override void SetDefaults(Item item)
		{
			Player player = Main.LocalPlayer;
			if (item.type == ItemID.SpiritFlame)
			{
				item.UseSound = SoundID.Item103;
			}
			if (item.type == ItemID.Blinkroot)
            {
				item.useStyle = ItemUseStyleID.EatFood;
				item.useAnimation = 15;
				item.useTime = 15;
				item.UseSound = SoundID.Item2;
				item.consumable = true;
				item.buffType = (11); //Shine
				item.buffTime = 1800;
            }
			if (item.type == ItemID.Deathweed)
			{
				item.useStyle = ItemUseStyleID.EatFood;
				item.useAnimation = 15;
				item.useTime = 15;
				item.UseSound = SoundID.Item2;
				item.consumable = true;
				item.buffType = (70); //Venom
				item.buffTime = 1800;
			}
			if (item.type == ItemID.Fireblossom)
			{
				item.useStyle = ItemUseStyleID.EatFood;
				item.useAnimation = 15;
				item.useTime = 15;
				item.UseSound = SoundID.Item2;
				item.consumable = true;
				item.buffType = (124); //Warmth
				item.buffTime = 1800;
			}
			if (item.type == ItemID.Daybloom)
			{
				item.useStyle = ItemUseStyleID.EatFood;
				item.useAnimation = 15;
				item.useTime = 15;
				item.UseSound = SoundID.Item2;
				item.consumable = true;
				item.buffType = (2); //Life Regen
				item.buffTime = 1800;
			}
			if (item.type == ItemID.Moonglow)
			{
				item.useStyle = ItemUseStyleID.EatFood;
				item.useAnimation = 15;
				item.useTime = 15;
				item.UseSound = SoundID.Item2;
				item.consumable = true;
				item.buffType = (20); //Poison
				item.buffTime = 1800;
			}
			if (item.type == ItemID.Shiverthorn)
			{
				item.useStyle = ItemUseStyleID.EatFood;
				item.useAnimation = 15;
				item.useTime = 15;
				item.UseSound = SoundID.Item2;
				item.consumable = true;
				item.buffType = (46); //Chilled
				item.buffTime = 1800;
			}
			if (item.type == ItemID.Waterleaf)
			{
				item.useStyle = ItemUseStyleID.EatFood;
				item.useAnimation = 15;
				item.useTime = 15;
				item.UseSound = SoundID.Item2;
				item.consumable = true;
				item.healLife = 10;
				item.buffType = (BuffID.PotionSickness);
				item.buffTime = 600;
			}
		}

		public override bool CanUseItem(Item item, Player player)
        {
			if (item.type == ItemID.Waterleaf)
            {
				return !player.HasBuff(BuffID.PotionSickness);
            }
			return true;
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            if (item.type == ItemID.PickaxeAxe || item.type == ItemID.Drax)
            {
                TooltipLine line = new(Mod, "Locked", Language.GetTextValue("Mods.MultidimensionMod.VanillaTooltipEdits.DraxDenseBlockTip"))
                {
                    OverrideColor = Color.White
                };
                tooltips.Add(line);
            }
            if (item.type == ItemID.Blinkroot)
            {
                TooltipLine line = new(Mod, "Locked", Language.GetTextValue("Mods.MultidimensionMod.VanillaTooltipEdits.BlinkrootTip"))
                {
                    OverrideColor = Color.White
                };
                tooltips.Add(line);
            }
            if (item.type == ItemID.Deathweed)
            {
                TooltipLine line = new(Mod, "Locked", Language.GetTextValue("Mods.MultidimensionMod.VanillaTooltipEdits.DeathweedTip"))
                {
                    OverrideColor = Color.White
                };
                tooltips.Add(line);
            }
            if (item.type == ItemID.Fireblossom)
            {
                TooltipLine line = new(Mod, "Locked", Language.GetTextValue("Mods.MultidimensionMod.VanillaTooltipEdits.FireblossomTip"))
                {
                    OverrideColor = Color.White
                };
                tooltips.Add(line);
            }
            if (item.type == ItemID.Daybloom)
            {
                TooltipLine line = new(Mod, "Locked", Language.GetTextValue("Mods.MultidimensionMod.VanillaTooltipEdits.DaybloomTip"))
                {
                    OverrideColor = Color.White
                };
                tooltips.Add(line);
            }
            if (item.type == ItemID.Moonglow)
            {
                TooltipLine line = new(Mod, "Locked", Language.GetTextValue("Mods.MultidimensionMod.VanillaTooltipEdits.MoonglowTip"))
                {
                    OverrideColor = Color.White
                };
                tooltips.Add(line);
            }
            if (item.type == ItemID.Shiverthorn)
            {
                TooltipLine line = new(Mod, "Locked", Language.GetTextValue("Mods.MultidimensionMod.VanillaTooltipEdits.ShiverthornTip"))
                {
                    OverrideColor = Color.White
                };
                tooltips.Add(line);
            }
            if (item.type == ItemID.Waterleaf)
            {
                TooltipLine line = new(Mod, "Locked", Language.GetTextValue("Mods.MultidimensionMod.VanillaTooltipEdits.WaterleafTip"))
                {
                    OverrideColor = Color.White
                };
                tooltips.Add(line);
            }
        }
    }
}