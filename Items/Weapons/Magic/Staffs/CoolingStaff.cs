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
			DisplayName.SetDefault("Cooling Staff");
			Tooltip.SetDefault("A staff that was restored from old relics, it shoots a icicle that bursts into 4 smaller icicles.");
			DisplayName.AddTranslation(GameCulture.German, "Külender Stab");
			Tooltip.AddTranslation(GameCulture.German, "Ein Stab der aus alten Relikten restauriert wurde, er schießt einen Eiszapfen der in kleinere Eiszapfen explodiert.");
			Item.staff[item.type] = true;
		}

		public override void SetDefaults()
		{
			item.damage = 19;
			item.magic = true;
			item.mana = 6;
			item.width = 40;
			item.height = 40;
			item.useTime = 40;
			item.useAnimation = 40;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true;
			item.knockBack = 2;
			item.value = Item.sellPrice(silver: 34);
			item.rare = ItemRarityID.Green;
			item.UseSound = SoundID.Item20;
			item.autoReuse = true;
			item.shoot = ModContent.ProjectileType<Icicle>();
			item.shootSpeed = 15f;
			item.crit = 8;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<OldFrozenStaffHead>());
			recipe.AddIngredient(ModContent.ItemType<OldFrozenRod>());
			recipe.AddIngredient(ModContent.ItemType<FrostScale>(), 5);
			recipe.AddTile(377);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}