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
	internal class OreGeodeThrown : ModProjectile
	{

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Ore Geode");
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

		public override void Kill(int timeLeft)
		{
			Player player = Main.LocalPlayer;
			SoundEngine.PlaySound(SoundID.Dig, Projectile.position);
			for (int i = 0; i < 5; i++)
			{
				int dustIndex = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustID.Dirt, 0f, 0f, 100, default(Color), 2f);
				Main.dust[dustIndex].velocity *= 1.4f;
			}
			if (!player.GetModPlayer<MDPlayer>().Geodes)
			{
				if (Projectile.owner == Main.myPlayer)
				{
					int stack = 20;
					int choice = Main.rand.Next(8);
					if (choice == 0)
					{
						Item.NewItem(new EntitySource_Loot(Projectile), Projectile.position, Projectile.Size, ItemID.CopperOre, stack);
					}
					else if (choice == 1)
					{
						Item.NewItem(new EntitySource_Loot(Projectile), Projectile.position, Projectile.Size, ItemID.TinOre, stack);
					}
					else if (choice == 2)
					{
						Item.NewItem(new EntitySource_Loot(Projectile), Projectile.position, Projectile.Size, ItemID.LeadOre, stack);
					}
					else if (choice == 3)
					{
						Item.NewItem(new EntitySource_Loot(Projectile), Projectile.position, Projectile.Size, ItemID.IronOre, stack);
					}
					else if (choice == 4)
					{
						Item.NewItem(new EntitySource_Loot(Projectile), Projectile.position, Projectile.Size, ItemID.TungstenOre, stack);
					}
					else if (choice == 5)
					{
						Item.NewItem(new EntitySource_Loot(Projectile), Projectile.position, Projectile.Size, ItemID.SilverOre, stack);
					}
					else if (choice == 6)
					{
						Item.NewItem(new EntitySource_Loot(Projectile), Projectile.position, Projectile.Size, ItemID.GoldOre, stack);
					}
					else if (choice == 7)
					{
						Item.NewItem(new EntitySource_Loot(Projectile), Projectile.position, Projectile.Size, ItemID.PlatinumOre, stack);
					}
				}
			}
			else if (player.GetModPlayer<MDPlayer>().Geodes)
			{
				if (Main.rand.NextFloat() < .3300f)
				{
					Item.NewItem(new EntitySource_Loot(Projectile), Projectile.position, Projectile.Size, ModContent.ItemType<Geode>(), 1);
				}
			}
			if (player.GetModPlayer<MDPlayer>().Geodes)
            {
				for (int i = 0; i < 7; i++)
				{
					Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, new Vector2(Main.rand.NextFloat(-10, 10), Main.rand.NextFloat(-9, 10)), ModContent.ProjectileType<GeodeFragment>(), (int)((double)((float)Projectile.damage) * 0.3f), 0f, Main.myPlayer);
				}
			}
			if (player.GetModPlayer<MDPlayer>().Geodes && Main.hardMode)
			{
				for (int i = 0; i < 2; i++)
				{
					Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, Projectile.velocity, ProjectileID.BoulderStaffOfEarth, (int)((double)((float)Projectile.damage) * 0.3f), 0f, Main.myPlayer);
				}
			}
		}
	}
}