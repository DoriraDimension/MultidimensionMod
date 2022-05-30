using MultidimensionMod.Projectiles.Magic;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Magic.Staffs
{
	public class StarRod : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Star Rod");
			Tooltip.SetDefault("The power of the stars is on your side.");
		}

		public override void SetDefaults()
		{
			Item.damage = 16;
			Item.width = 26;
			Item.height = 26;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.useTime = 55;
			Item.useAnimation = 55;
			Item.knockBack = 2f;
			Item.DamageType = DamageClass.Magic;
			Item.noMelee = true;
			Item.value = Item.sellPrice(copper: 67);
			Item.rare = ItemRarityID.Blue;
			Item.mana = 4;
			Item.shoot = ModContent.ProjectileType<PoyoStar>();
			Item.shootSpeed = 10f;
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			int Damage = Item.damage;
			float KnockBack = Item.knockBack;
			int shoot = Item.shoot;
			float speed = Item.shootSpeed;
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
			    Projectile.NewProjectile(source, position.X, position.Y, speedX4, speedY5, shoot, Damage, KnockBack, player.whoAmI, 0f, Main.rand.Next(5));
			return false;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ItemID.FallenStar)
			.AddRecipeGroup("Wood", 5)
			.AddTile(TileID.WorkBenches)
			.Register();
		}
	}
}