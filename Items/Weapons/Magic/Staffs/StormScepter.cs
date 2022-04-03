using MultidimensionMod.Projectiles.Magic;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Magic.Staffs
{
	public class StormScepter : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Storm Scepter");
			Tooltip.SetDefault("Call forth a shower from the sky.\nRains Storm Droplets from above the mouse cursor");
			DisplayName.AddTranslation(GameCulture.German, "Sturm Zeptar");
			Tooltip.AddTranslation(GameCulture.German, "Rufe eine Dusche vom Himmel.\nRegnet Sturm Tropfen von über dem Maus Cursor");
			Item.staff[item.type] = true;
		}

		public override void SetDefaults()
		{
			item.damage = 73;
			item.width = 62;
			item.height = 62;
			item.useStyle = 5;
			item.useTime = 55;
			item.useAnimation = 55;
			item.autoReuse = true;
			item.knockBack = 1f;
			item.magic = true;
			item.noMelee = true;
			item.value = Item.sellPrice(gold: 1);
			item.rare = ItemRarityID.Lime;
			item.mana = 7;
			item.shoot = ModContent.ProjectileType<StormDroplet>();
			item.shootSpeed = 20f;
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
			float ai2 = num71 + position.Y;
			int num99 = 5;
			for (int num100 = 0; num100 < num99; num100++)
			{
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
				Projectile.NewProjectile(position.X, position.Y, speedX4, speedY5, shoot, Damage, KnockBack, player.whoAmI, 0f, Main.rand.Next(5));
			}
			return false;
		}
	}
}