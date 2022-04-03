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
	public class FleshRipper : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Flesh Ripper");
			Tooltip.SetDefault("A throwable Scythe that was restored from old relics, perfect for making big wounds.");
			DisplayName.AddTranslation(GameCulture.German, "Fleischreißer");
			Tooltip.AddTranslation(GameCulture.German, "Eine werfbare Sense die aus alten Relikten restauriert wurde, perfekt um große wunden zu verursachen.");
		}

		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.WoodenBoomerang);
			item.shootSpeed *= 2f;
			item.width = 30;
			item.height = 42;
			item.damage = 19;
			item.autoReuse = true;
			item.value = Item.sellPrice(silver: 25);
			item.rare = ItemRarityID.Green;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			type = ModContent.ProjectileType<FleshRipperProj>();
			return base.Shoot(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<OldStainedBone>());
			recipe.AddIngredient(ModContent.ItemType<OldStainedFleshStick>());
			recipe.AddIngredient(ItemID.TissueSample, 20);
			recipe.AddTile(377);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}