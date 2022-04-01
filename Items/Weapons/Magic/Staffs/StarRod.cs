using MultidimensionMod.Projectiles.Magic;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Magic.Staffs
{
	public class StarRod : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Star Rod");
			Tooltip.SetDefault("The power of the stars is on your side.");
			DisplayName.AddTranslation(GameCulture.German, "Sternenzepter");
			Tooltip.AddTranslation(GameCulture.German, "Die kraft der Sterne ist auf deiner seite.");
		}

		public override void SetDefaults()
		{
			item.damage = 8;
			item.width = 26;
			item.height = 26;
			item.useStyle = 1;
			item.useTime = 20;
			item.useAnimation = 20;
			item.knockBack = 2f;
			item.magic = true;
			item.noMelee = true;
			item.value = Item.sellPrice(copper: 67);
			item.rare = ItemRarityID.Blue;
			item.mana = 4;
			item.shoot = ModContent.ProjectileType<PoyoStar>();
			item.shootSpeed = 10f;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			int Damage = item.damage;
			float KnockBack = item.knockBack;
			int shoot = item.shoot;
			float speed = item.shootSpeed;
			float num70 = (float)Main.mouseX + Main.screenPosition.X - position.X;
			float num71 = (float)Main.mouseY + Main.screenPosition.Y - position.Y;
			float num72 = (float)Math.Sqrt(num70 * num70 + num71 * num71);
			int num99 = 2;
				position = new Vector2(player.position.X + (float)player.width * 0.5f + (float)(Main.rand.Next(201) * -player.direction) + ((float)Main.mouseX + Main.screenPosition.X - player.position.X), player.MountedCenter.Y - 600f);
				position.X = (position.X + player.Center.X) / 2f + (float)Main.rand.Next(-200, 201);
				num70 = (float)Main.mouseX + Main.screenPosition.X - position.X;
				num71 = (float)Main.mouseY + Main.screenPosition.Y - position.Y;
				if (num71 < 0f)
				{
					num71 *= -1f;
				}
				if (num71 < 20f)
				{
					num71 = 20f;
				}
				num72 = (float)Math.Sqrt(num70 * num70 + num71 * num71);
				num72 = speed / num72;
				num70 *= num72;
				num71 *= num72;
				float speedX4 = num70 + (float)Main.rand.Next(-40, 41) * 0.02f;
				float speedY5 = num71 + (float)Main.rand.Next(-40, 41) * 0.02f;
				Projectile.NewProjectile(position.X, position.Y, speedX4, speedY5, shoot, Damage, KnockBack);
			return false;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.FallenStar);
			recipe.AddRecipeGroup("Wood", 5);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}