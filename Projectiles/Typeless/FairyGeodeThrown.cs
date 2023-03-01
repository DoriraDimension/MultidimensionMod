using MultidimensionMod.Common.Players;
using MultidimensionMod.Items.Accessories;
using MultidimensionMod.Items.Weapons.Typeless;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace MultidimensionMod.Projectiles.Typeless
{
	internal class FairyGeodeThrown : ModProjectile
	{

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Fairy Geode");
		}

		public override void SetDefaults()
		{
			Projectile.width = 18;
			Projectile.height = 18;
			Projectile.friendly = true;
			Projectile.DamageType = DamageClass.Generic;
			Projectile.ignoreWater = false;
			Projectile.tileCollide = true;
			Projectile.hide = false;
		}

		public override void AI()
		{
			Player player = Main.LocalPlayer;
			Projectile.ai[0] += 1f;
			if (Projectile.ai[0] >= 15f)
			{
				Projectile.ai[0] = 15f;
				Projectile.velocity.Y = Projectile.velocity.Y + 0.5f;
			}
			if (Projectile.velocity.Y > 16f)
			{
				Projectile.velocity.Y = 16f;
			}

			Projectile.rotation += 0.4f * (float)Projectile.direction;

			if (player.GetModPlayer<MDPlayer>().Geodes)
			{
				if (Projectile.timeLeft % 20 == 19 && Projectile.owner == Main.myPlayer)
				{
					Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, new Vector2(Main.rand.NextFloat(-10, 10), Main.rand.NextFloat(-9, 10)), ProjectileID.CrystalStorm, (int)((double)((float)Projectile.damage) * 0.3), 0f, Projectile.owner);
				}
			}
		}

		public override void Kill(int timeLeft)
		{
			Player player = Main.LocalPlayer;
			SoundEngine.PlaySound(SoundID.Dig, Projectile.position);
			for (int i = 0; i < 5; i++)
			{
				int dustIndex = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustID.PinkCrystalShard, 0f, 0f, 100, default(Color), 2f);
				Main.dust[dustIndex].velocity *= 1.4f;
			}
			if (!player.GetModPlayer<MDPlayer>().Geodes)
            {
				if (Projectile.owner == Main.myPlayer)
				{
					int choice = Main.rand.Next(4);
					if (choice == 0)
					{
						Item.NewItem(new EntitySource_Loot(Projectile), Projectile.position, Projectile.Size, ItemID.PearlstoneBlock, 50);
						if (Main.rand.NextFloat() < .2500f)
						{
							Item.NewItem(new EntitySource_Loot(Projectile), Projectile.position, Projectile.Size, ItemID.QueenSlimeCrystal, 1);
						}
					}
					else if (choice == 1)
					{
						Item.NewItem(new EntitySource_Loot(Projectile), Projectile.position, Projectile.Size, ItemID.CrystalShard, 5);
						if (Main.rand.NextFloat() < .2500f)
						{
							Item.NewItem(new EntitySource_Loot(Projectile), Projectile.position, Projectile.Size, ItemID.QueenSlimeCrystal, 1);
						}
					}
					else if (choice == 2)
					{
						Item.NewItem(new EntitySource_Loot(Projectile), Projectile.position, Projectile.Size, ItemID.CrystalShard, 5);
						if (Main.rand.NextFloat() < .2500f)
						{
							Item.NewItem(new EntitySource_Loot(Projectile), Projectile.position, Projectile.Size, ItemID.QueenSlimeCrystal, 1);
						}
					}
					else if (choice == 3)
					{
						Item.NewItem(new EntitySource_Loot(Projectile), Projectile.position, Projectile.Size, ItemID.PearlstoneBlock, 25);
						if (Main.rand.NextFloat() < .2500f)
						{
							Item.NewItem(new EntitySource_Loot(Projectile), Projectile.position, Projectile.Size, ItemID.QueenSlimeCrystal, 1);
						}
					}
				}
			}
			else if (player.GetModPlayer<MDPlayer>().Geodes)
			{
				if (Main.rand.NextFloat() < .3300f)
				{
					Item.NewItem(new EntitySource_Loot(Projectile), Projectile.position, Projectile.Size, ModContent.ItemType<FairyGeode>(), 1);
				}
			}
			if (player.GetModPlayer<MDPlayer>().Geodes)
            {
				float x = Projectile.position.X + (float)Main.rand.Next(-400, 400);
				float y = Projectile.position.Y - (float)Main.rand.Next(600, 900);
				Vector2 vector18 = new Vector2(x, y);
				float num513 = Projectile.position.X + (float)(Projectile.width / 2) - vector18.X;
				float num514 = Projectile.position.Y + (float)(Projectile.height / 2) - vector18.Y;
				int num515 = 22;
				float num516 = (float)Math.Sqrt((double)(num513 * num513 + num514 * num514));
				num516 = (float)num515 / num516;
				num513 *= num516;
				num514 *= num516;
				int num517 = Projectile.damage;
				num517 /= 2;
				int num518 = Projectile.NewProjectile(Projectile.GetSource_FromThis(), x, y, num513, num514, ProjectileID.HallowStar, num517, Projectile.knockBack, Projectile.owner);
				Main.projectile[num518].ai[1] = Projectile.position.Y;
				Main.projectile[num518].ai[0] = 1f;
			}
		}
	}
}