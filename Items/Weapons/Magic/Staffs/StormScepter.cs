using MultidimensionMod.Projectiles.Magic;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Magic.Staffs
{
	public class StormScepter : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Storm Scepter");
			// Tooltip.SetDefault("Call forth a shower from the sky.\nRains Storm Droplets from above the mouse cursor");
			Item.staff[Item.type] = true;
		}

		public override void SetDefaults()
		{
			Item.damage = 73;
			Item.width = 62;
			Item.height = 62;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useTime = 11;
			Item.useAnimation = 11;
			Item.autoReuse = true;
			Item.knockBack = 1f;
			Item.DamageType = DamageClass.Magic;
			Item.noMelee = true;
			Item.value = Item.sellPrice(gold: 1);
			Item.rare = ItemRarityID.Lime;
			Item.mana = 7;
			Item.shoot = ModContent.ProjectileType<StormDroplet>();
			Item.shootSpeed = 20f;
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
			float ai2 = num71 + position.Y;
			int num99 = 5;
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

		public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
		{
			Texture2D texture = ModContent.Request<Texture2D>("MultidimensionMod/Items/Weapons/Magic/Staffs/StormScepter_Glow").Value;
			spriteBatch.Draw
			(
				texture,
				new Vector2
				(
					Item.position.X - Main.screenPosition.X + Item.width * 0.5f,
					Item.position.Y - Main.screenPosition.Y + Item.height - texture.Height * 0.5f
				),
				new Rectangle(0, 0, texture.Width, texture.Height),
				Color.White,
				rotation,
				texture.Size() * 0.5f,
				scale,
				SpriteEffects.None,
				0f
			);
		}
	}
}