using MultidimensionMod.Items.Accessories;
using MultidimensionMod.Items.Materials;
using MultidimensionMod.Items.Weapons.Melee.Boomerangs;
using MultidimensionMod.Items.Weapons.Melee.Swords;
using MultidimensionMod.Items.Weapons.Magic.Guns;
using MultidimensionMod.Items.Weapons.Ranged;
using MultidimensionMod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Reflection;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria.ModLoader.IO;

namespace MultidimensionMod
{
	public class MDGlobalItem : GlobalItem
	{
		public override void SetDefaults(Item item)
		{
			Mod calamityMod = ModLoader.GetMod("CalamityMod");
			if (calamityMod != null)
			{
				calamityMod.GetItem("GrandDad").DisplayName.AddTranslation(GameCulture.English, "Grand Daddy");
			}
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
				item.useStyle = ItemUseStyleID.EatingUsing;
				item.useAnimation = 15;
				item.useTime = 15;
				item.UseSound = SoundID.Item2;
				item.consumable = true;
				item.buffType = (11); //Shine
				item.buffTime = 1800;
            }
			if (item.type == ItemID.Deathweed)
			{
				item.useStyle = ItemUseStyleID.EatingUsing;
				item.useAnimation = 15;
				item.useTime = 15;
				item.UseSound = SoundID.Item2;
				item.consumable = true;
				item.buffType = (70); //Venom
				item.buffTime = 1800;
			}
			if (item.type == ItemID.Fireblossom)
			{
				item.useStyle = ItemUseStyleID.EatingUsing;
				item.useAnimation = 15;
				item.useTime = 15;
				item.UseSound = SoundID.Item2;
				item.consumable = true;
				item.buffType = (124); //Warmth
				item.buffTime = 1800;
			}
			if (item.type == ItemID.Daybloom)
			{
				item.useStyle = ItemUseStyleID.EatingUsing;
				item.useAnimation = 15;
				item.useTime = 15;
				item.UseSound = SoundID.Item2;
				item.consumable = true;
				item.buffType = (2); //Life Regen
				item.buffTime = 1800;
			}
			if (item.type == ItemID.Moonglow)
			{
				item.useStyle = ItemUseStyleID.EatingUsing;
				item.useAnimation = 15;
				item.useTime = 15;
				item.UseSound = SoundID.Item2;
				item.consumable = true;
				item.buffType = (20); //Poison
				item.buffTime = 1800;
			}
			if (item.type == ItemID.Shiverthorn)
			{
				item.useStyle = ItemUseStyleID.EatingUsing;
				item.useAnimation = 15;
				item.useTime = 15;
				item.UseSound = SoundID.Item2;
				item.consumable = true;
				item.buffType = (46); //Chilled
				item.buffTime = 1800;
			}
			if (item.type == ItemID.Waterleaf)
			{
				item.useStyle = ItemUseStyleID.EatingUsing;
				item.useAnimation = 15;
				item.useTime = 15;
				item.UseSound = SoundID.Item2;
				item.consumable = true;
				item.healLife = 10;
			}
		}
	}
}