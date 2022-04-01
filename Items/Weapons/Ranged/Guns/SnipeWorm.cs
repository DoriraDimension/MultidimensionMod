using System.Collections.Generic;
using MultidimensionMod.Items.Materials;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Ranged.Guns
{
	public class SnipeWorm : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Snipe Worm");
			Tooltip.SetDefault("A sniper rifle that was restored from old relics, it has rotten skin around its metal.\nConverts normal bullets into Cursed Bullets.");
			DisplayName.AddTranslation(GameCulture.German, "Snipe Wurm");
			Tooltip.AddTranslation(GameCulture.German, "Ein Snipergewehr das aus alten Relikten restauriert wurde, es hat verottetes Fleisch um seine Metall.\nKonvertiert normale Kugeln zu Verfluchten Kugeln.");
		}

		public override void SetDefaults()
		{
			item.damage = 43;
			item.ranged = true;
			item.width = 64;
			item.height = 22;
			item.useTime = 52;
			item.useAnimation = 52;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true;
			item.knockBack = 4;
			item.value = Item.sellPrice(silver: 23);
			item.rare = ItemRarityID.Green;
			item.UseSound = SoundID.Item11;
			item.autoReuse = true;
			item.shoot = 10;
			item.shootSpeed = 30f;
			item.useAmmo = AmmoID.Bullet;
			item.crit = 10;
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-10, 0);
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<OldTaintedMandible>());
			recipe.AddIngredient(ModContent.ItemType<OldTaintedCurseContainer>());
			recipe.AddIngredient(ItemID.ShadowScale, 20);
			recipe.AddTile(377);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			if (type == ProjectileID.Bullet)
			{
				type = ProjectileID.CursedBullet;
			}
			return true;
		}
	}
}
