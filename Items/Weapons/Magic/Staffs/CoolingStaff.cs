using System.Collections.Generic;
using MultidimensionMod.Projectiles;
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
			Tooltip.SetDefault("A staff that was restored from old relics, it shoots a cold gravity affected ice ball.");
			DisplayName.AddTranslation(GameCulture.German, "Külender Stab");
			Tooltip.AddTranslation(GameCulture.German, "Ein Stab der aus alten Relikten restauriert wurde, er schießt von der Schwerkraft betroffene Eisbälle.");
			Item.staff[item.type] = true;
		}

		public override void SetDefaults()
		{
			item.damage = 27;
			item.magic = true;
			item.mana = 6;
			item.width = 36;
			item.height = 36;
			item.useTime = 40;
			item.useAnimation = 40;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true;
			item.knockBack = 2;
			item.value = 10000;
			item.rare = ItemRarityID.Green;
			item.UseSound = SoundID.Item20;
			item.autoReuse = true;
			item.shoot = ProjectileID.BallofFrost;
			item.shootSpeed = 10f;
			item.crit = 8;
		}

		public override void ModifyTooltips(List<TooltipLine> list)
		{
			foreach (TooltipLine item in list)
			{
				if (item.mod == "Terraria" && item.Name == "ItemName")
				{
					item.overrideColor = MDRarity.RelicWeapon;
				}
			}
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