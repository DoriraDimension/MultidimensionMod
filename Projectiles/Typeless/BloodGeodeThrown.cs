using MultidimensionMod.Common.Players;
using MultidimensionMod.Items.Materials;
using MultidimensionMod.Items.Weapons.Typeless;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace MultidimensionMod.Projectiles.Typeless
{
	internal class BloodGeodeThrown : ModProjectile
	{

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Blood Geode");
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
					Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X, Projectile.Center.Y, 0f, 15f, ModContent.ProjectileType<BloodTear>(), (int)((double)((float)Projectile.damage) * 0.5), 0f, Projectile.owner);
				}
			}
		}

		public override void Kill(int timeLeft)
		{
			Player player = Main.LocalPlayer;
			SoundEngine.PlaySound(SoundID.Dig, Projectile.position);
			for (int i = 0; i < 5; i++)
			{
				int dustIndex = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustID.Crimstone, 0f, 0f, 100, default(Color), 2f);
				Main.dust[dustIndex].velocity *= 1.4f;
			}
			if (!player.GetModPlayer<MDPlayer>().Geodes)
			{
				if (Projectile.owner == Main.myPlayer)
				{
					int stack = 20;
					int choice = Main.rand.Next(5);
					if (choice == 0)
					{
						Item.NewItem(new EntitySource_Loot(Projectile), Projectile.position, Projectile.Size, ItemID.CrimtaneOre, 20);
					}
					else if (choice == 1)
					{
						Item.NewItem(new EntitySource_Loot(Projectile), Projectile.position, Projectile.Size, ItemID.CrimstoneBlock, 50);
					}
					else if (choice == 2)
					{
						Item.NewItem(new EntitySource_Loot(Projectile), Projectile.position, Projectile.Size, ItemID.CrimstoneBlock, 25);
					}
					else if (choice == 3)
					{
						Item.NewItem(new EntitySource_Loot(Projectile), Projectile.position, Projectile.Size, ModContent.ItemType<OldStainedScythe>(), 1);
					}
					else if (choice == 4)
					{
						Item.NewItem(new EntitySource_Loot(Projectile), Projectile.position, Projectile.Size, ItemID.Vertebrae, 5);
					}
				}
			}
			else if (player.GetModPlayer<MDPlayer>().Geodes)
			{
				if (Main.rand.NextFloat() < .3300f)
				{
					Item.NewItem(new EntitySource_Loot(Projectile), Projectile.position, Projectile.Size, ModContent.ItemType<BloodGeode>(), 1);
				}
			}
			if (player.GetModPlayer<MDPlayer>().Geodes)
			{
				Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X, Projectile.Center.Y + 0f, 0f, 0f, ProjectileID.SharpTears, (int)((double)((float)Projectile.damage) * 0.2), 0f, Main.myPlayer);
			}
			if (player.GetModPlayer<MDPlayer>().Geodes && Main.hardMode)
			{
				for (int i = 0; i < 4; i++)
				{
					Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, new Vector2(Main.rand.NextFloat(-10, 10), Main.rand.NextFloat(-9, 10)), ModContent.ProjectileType<BloodTear>(), (int)((double)((float)Projectile.damage) * 0.3f), 0f, Main.myPlayer);
				}
			}
		}
	}
}