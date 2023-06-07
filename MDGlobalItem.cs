using MultidimensionMod.Items.Quest;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod
{
	public class MDGlobalItem : GlobalItem
	{
		public override void SetStaticDefaults()
        {
			ItemID.Sets.ShimmerTransformToItem[ItemID.FallenStar] = ModContent.ItemType<TeamStar>();
		}
		public override void SetDefaults(Item item)
		{
			Player player = Main.LocalPlayer;
			if (item.type == ItemID.SpiritFlame)
			{
				item.UseSound = SoundID.Item103;
			}
			if (item.type == ItemID.NightsEdge)
			{
				item.autoReuse = true;
			}
			if (item.type == ItemID.TrueNightsEdge)
			{
				item.autoReuse = true;
			}
			if (item.type == ItemID.TrueExcalibur)
			{
				item.autoReuse = true;
			}
			if (item.type == ItemID.BoneSword)
			{
				item.damage = 31;
				item.autoReuse = true;
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
	}
}