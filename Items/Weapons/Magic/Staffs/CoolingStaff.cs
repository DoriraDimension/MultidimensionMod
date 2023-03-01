using System.Collections.Generic;
using MultidimensionMod.Projectiles.Magic;
using MultidimensionMod.Items.Materials;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Magic.Staffs
{
	public class CoolingStaff : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Cooling Staff");
			// Tooltip.SetDefault("A staff that was restored from old relics, it shoots a icicle that bursts into 4 smaller icicles.");
			Item.staff[Item.type] = true;
		}

		public override void SetDefaults()
		{
			Item.damage = 19;
			Item.DamageType = DamageClass.Magic;
			Item.mana = 6;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 40;
			Item.useAnimation = 40;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 2;
			Item.value = Item.sellPrice(silver: 34);
			Item.rare = ItemRarityID.Green;
			Item.UseSound = SoundID.Item20;
			Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<Icicle>();
			Item.shootSpeed = 15f;
			Item.crit = 8;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ModContent.ItemType<OldFrozenStaff>())
			.AddIngredient(ModContent.ItemType<FrostScale>(), 5)
			.AddTile(377)
			.Register();
		}
	}
}