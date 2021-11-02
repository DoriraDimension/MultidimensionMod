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
	public class IceCrystalStaff : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ice Crystal Staff");
			Tooltip.SetDefault("A staff that was restored from old relics, it shoots three Frost Bolts.");
			DisplayName.AddTranslation(GameCulture.German, "Eis Kristall Stab");
			Tooltip.AddTranslation(GameCulture.German, "Ein Stab der aus alten Relikten restauriert wurde, er verschießt drei Eis Bolzen.");
			Item.staff[item.type] = true;
		}


		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.SkyFracture);
			item.shootSpeed *= 0.75f;
			item.damage = 60;
			item.width = 50;
			item.height = 50;
			item.magic = true;
			item.value = Item.sellPrice(silver: 90);
			item.rare = ItemRarityID.LightRed;
			item.UseSound = SoundID.Item1;

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

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			type = ProjectileID.FrostBoltSword;
			return base.Shoot(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<OldFrozenStaffHead>());
			recipe.AddIngredient(ModContent.ItemType<OldFrozenRod>());
			recipe.AddIngredient(ItemID.FrostCore);
			recipe.AddTile(377);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}