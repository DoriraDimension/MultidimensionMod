﻿using MultidimensionMod.Projectiles.Typeless;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Typeless
{
	public class MuddyGeode : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Muddy Geode");
			Tooltip.SetDefault("A geode found in the Jungle.\nA blacksmith can break this open for you, sadly, there is none.\nRight click to recieve Jungle minerals.");
		}

		public override void SetDefaults()
		{
			Item.damage = 74;
			Item.width = 20;
			Item.height = 24;
			Item.rare = ItemRarityID.Lime;
			Item.maxStack = 9999;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.DamageType = DamageClass.Generic;
			Item.useTime = 30;
			Item.useAnimation = 30;
			Item.noMelee = true;
			Item.consumable = true;
			Item.knockBack = 2;
			Item.noUseGraphic = true;
			Item.UseSound = SoundID.Item1;
			Item.shoot = ModContent.ProjectileType<MuddyGeodeThrown>();
			Item.shootSpeed = 14f;
		}
	}
}