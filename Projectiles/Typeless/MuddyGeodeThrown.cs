using MultidimensionMod.Common.Players;
using MultidimensionMod.Items.Weapons.Typeless;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace MultidimensionMod.Projectiles.Typeless
{
	internal class MuddyGeodeThrown : ModProjectile
	{

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Muddy Geode");
		}

		public override void SetDefaults()
		{
			Projectile.width = 18;
			Projectile.height = 18;
			Projectile.friendly = true;
			Projectile.DamageType = DamageClass.Generic;
			Projectile.ignoreWater = false;
			Projectile.penetrate = 4;
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
		}

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			Player player = Main.LocalPlayer;
			if (!player.GetModPlayer<MDPlayer>().Geodes)
            {
				return true;
            }
			if (player.GetModPlayer<MDPlayer>().Geodes)
			{
				Projectile.penetrate--;
				if (Projectile.penetrate <= 0)
				{
					Projectile.Kill();
				}
				else
				{
					Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
					SoundEngine.PlaySound(SoundID.Dig, Projectile.position);
					if (Projectile.velocity.X != oldVelocity.X)
					{
						Projectile.velocity.X = -oldVelocity.X;
					}
					if (Projectile.velocity.Y != oldVelocity.Y)
					{
						Projectile.velocity.Y = -oldVelocity.Y;
					}
					Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, Projectile.velocity, ProjectileID.SeedlerNut, (int)((double)((float)Projectile.damage) * 0.3f), 0f, Main.myPlayer);
				}
			}
            return false;
		}

		public override void Kill(int timeLeft)
		{
			Player player = Main.LocalPlayer;
			SoundEngine.PlaySound(SoundID.Dig, Projectile.position);
			for (int i = 0; i < 5; i++)
			{
				int dustIndex = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustID.Mud, 0f, 0f, 100, default(Color), 2f);
				Main.dust[dustIndex].velocity *= 1.4f;
			}
			if (!player.GetModPlayer<MDPlayer>().Geodes)
			{
				if (Projectile.owner == Main.myPlayer)
				{
					int choice = Main.rand.Next(5);
					if (choice == 0)
					{
						Item.NewItem(new EntitySource_Loot(Projectile), Projectile.position, Projectile.Size, ItemID.MudBlock, 50);
					}
					else if (choice == 1)
					{
						Item.NewItem(new EntitySource_Loot(Projectile), Projectile.position, Projectile.Size, ItemID.MudBlock, 25);
					}
					else if (choice == 2)
					{
						Item.NewItem(new EntitySource_Loot(Projectile), Projectile.position, Projectile.Size, ItemID.ChlorophyteOre, 20);
					}
					else if (choice == 3)
					{
						Item.NewItem(new EntitySource_Loot(Projectile), Projectile.position, Projectile.Size, ItemID.RichMahogany, 50);
					}
					else if (choice == 4)
					{
						Item.NewItem(new EntitySource_Loot(Projectile), Projectile.position, Projectile.Size, ItemID.ArchaeologistsHat, 1);
					}
				}
			}
			else if (player.GetModPlayer<MDPlayer>().Geodes)
			{
				if (Main.rand.NextFloat() < .3300f)
				{
					Item.NewItem(new EntitySource_Loot(Projectile), Projectile.position, Projectile.Size, ModContent.ItemType<MuddyGeode>(), 1);
				}
			}
		}
	}
}