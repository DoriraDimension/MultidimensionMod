using MultidimensionMod.Common.Players;
using MultidimensionMod.Items.Materials;
using MultidimensionMod.Items.Weapons.Typeless;
using MultidimensionMod.Projectiles.Melee.Swords;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace MultidimensionMod.Projectiles.Typeless
{
	internal class MagmaGeodeThrown : ModProjectile
	{

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Magma Geode");
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

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			Player player = Main.LocalPlayer;
			if (player.GetModPlayer<MDPlayer>().Geodes && Main.hardMode)
            {
                target.damage -= 10;
				target.defense -= 5;
            }
        }

		public override void Kill(int timeLeft)
		{
			Player player = Main.LocalPlayer;
			SoundEngine.PlaySound(SoundID.Dig, Projectile.position);
			for (int i = 0; i < 5; i++)
			{
				int dustIndex = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustID.Torch, 0f, 0f, 100, default(Color), 2f);
				Main.dust[dustIndex].velocity *= 1.4f;
			}
			if (!player.GetModPlayer<MDPlayer>().Geodes)
            {

				if (Projectile.owner == Main.myPlayer)
				{
					int choice = Main.rand.Next(5);
					if (choice == 0)
					{
						Item.NewItem(new EntitySource_Loot(Projectile), Projectile.position, Projectile.Size, ItemID.AshBlock, 50);
						if (Main.hardMode && Main.rand.NextFloat() < .2500f)
						{
							Item.NewItem(new EntitySource_Loot(Projectile), Projectile.position, Projectile.Size, ItemID.MagmaStone, 1);
						}
					}
					else if (choice == 1)
					{
						Item.NewItem(new EntitySource_Loot(Projectile), Projectile.position, Projectile.Size, ItemID.AshBlock, 25);
						if (Main.hardMode && Main.rand.NextFloat() < .2500f)
						{
							Item.NewItem(new EntitySource_Loot(Projectile), Projectile.position, Projectile.Size, ItemID.MagmaStone, 1);
						}
					}
					else if (choice == 2)
					{
						Item.NewItem(new EntitySource_Loot(Projectile), Projectile.position, Projectile.Size, ItemID.Hellstone, 20);
						if (Main.hardMode && Main.rand.NextFloat() < .2500f)
						{
							Item.NewItem(new EntitySource_Loot(Projectile), Projectile.position, Projectile.Size, ItemID.MagmaStone, 1);
						}
					}
					else if (choice == 3)
					{
						Item.NewItem(new EntitySource_Loot(Projectile), Projectile.position, Projectile.Size, ItemID.Obsidian, 20);
						if (Main.hardMode && Main.rand.NextFloat() < .2500f)
						{
							Item.NewItem(new EntitySource_Loot(Projectile), Projectile.position, Projectile.Size, ItemID.MagmaStone, 1);
						}
					}
					else if (choice == 4)
					{
						Item.NewItem(new EntitySource_Loot(Projectile), Projectile.position, Projectile.Size, ModContent.ItemType<OldPetrifiedBlade>(), 1);
						if (Main.hardMode && Main.rand.NextFloat() < .2500f)
						{
							Item.NewItem(new EntitySource_Loot(Projectile), Projectile.position, Projectile.Size, ItemID.MagmaStone, 1);
						}
					}
				}
			}
			else if (player.GetModPlayer<MDPlayer>().Geodes)
			{
				if (Main.rand.NextFloat() < .3300f)
				{
					Item.NewItem(new EntitySource_Loot(Projectile), Projectile.position, Projectile.Size, ModContent.ItemType<MagmaGeode>(), 1);
				}
			}
			if (player.GetModPlayer<MDPlayer>().Geodes)
            {
				SoundEngine.PlaySound(SoundID.NPCDeath14, Projectile.position);
				Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X, Projectile.Center.Y + 0f, 0f, 0f, ModContent.ProjectileType<Explosion>(), (int)((double)((float)Projectile.damage) * 1.0), 0f, Main.myPlayer);
			}
		}
	}
}