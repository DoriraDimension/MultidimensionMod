using System.Collections.Generic;
using MultidimensionMod.Projectiles.Boomerangs;
using MultidimensionMod.Items.Materials;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Melee.Boomerangs
{
	public class InjectorScythe : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Injector Scythe");
			Tooltip.SetDefault("A throwable scythe that was restored from old relics, inflicts the ichor debuff on hit for 3 seconds.");
			DisplayName.AddTranslation(GameCulture.German, "Injektor´Sense");
			Tooltip.AddTranslation(GameCulture.German, "Eine werfbare Sense die aus alten Relikten restauriert wurde, verursacht den Ichor debuff für 3 Sekunden.");
		}

		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.Bananarang);
			item.shootSpeed *= 1f;
			item.width = 38;
			item.height = 52;
			item.damage = 55;
			item.useTime = 25;
			item.useAnimation = 25;
			item.value = Item.sellPrice(silver: 78);
			item.rare = ItemRarityID.LightRed;
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
			type = ModContent.ProjectileType<InjectorScytheProj>();
			return base.Shoot(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<OldStainedBone>());
			recipe.AddIngredient(ModContent.ItemType<OldStainedFleshStick>());
			recipe.AddIngredient(ItemID.Ichor, 8);
			recipe.AddIngredient(ItemID.Vertebrae, 20);
			recipe.AddTile(377);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}