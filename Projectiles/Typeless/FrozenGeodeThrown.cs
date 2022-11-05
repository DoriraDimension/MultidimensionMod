using MultidimensionMod.Items.Materials;
using MultidimensionMod.Projectiles.Magic;
using MultidimensionMod.Items.Weapons.Typeless;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace MultidimensionMod.Projectiles.Typeless
{
	internal class FrozenGeodeThrown : ModProjectile
	{

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Frozen Geode");
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
			Projectile.penetrate = 3;
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

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
			Player player = Main.LocalPlayer;
			if (player.GetModPlayer<MDPlayer>().Geodes)
            {
				target.AddBuff(BuffID.Frostburn, 240);
            }
			if (player.GetModPlayer<MDPlayer>().Geodes && Main.hardMode)
            {
				for (int i = 0; i < 6; i++)
				{
					int numProj = 2;
					float rotation = MathHelper.ToRadians(50f);
					Vector2 perturbedSpeed = Projectile.velocity.RotatedBy(MathHelper.Lerp(0f - rotation, rotation, (float)(i / (numProj - 1))));
					Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, perturbedSpeed, ModContent.ProjectileType<Smallcicle>(), (int)((double)((float)Projectile.damage) * 0.1f), knockback, player.whoAmI);
				}
			}
        }

		public override void Kill(int timeLeft)
		{
			Player player = Main.LocalPlayer;
			SoundEngine.PlaySound(SoundID.Dig, Projectile.position);
			for (int i = 0; i < 5; i++)
			{
				int dustIndex = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustID.Ice, 0f, 0f, 100, default(Color), 2f);
				Main.dust[dustIndex].velocity *= 1.4f;
			}
			if (!player.GetModPlayer<MDPlayer>().Geodes)
			{
				if (Projectile.owner == Main.myPlayer)
				{
					int choice = Main.rand.Next(6);
					if (choice == 0)
					{
						Item.NewItem(new EntitySource_Loot(Projectile), Projectile.position, Projectile.Size, ItemID.IceBlock, 50);
						if (Main.hardMode && Main.rand.NextFloat() < .2500f)
						{
							Item.NewItem(new EntitySource_Loot(Projectile), Projectile.position, Projectile.Size, ItemID.FrostCore, 1);
						}
					}
					else if (choice == 1)
					{
						Item.NewItem(new EntitySource_Loot(Projectile), Projectile.position, Projectile.Size, ItemID.IceBlock, 25);
						if (Main.hardMode && Main.rand.NextFloat() < .2500f)
						{
							Item.NewItem(new EntitySource_Loot(Projectile), Projectile.position, Projectile.Size, ItemID.FrostCore, 1);
						}
					}
					else if (choice == 2)
					{
						Item.NewItem(new EntitySource_Loot(Projectile), Projectile.position, Projectile.Size, ItemID.VikingHelmet, 1);
						if (Main.hardMode && Main.rand.NextFloat() < .2500f)
						{
							Item.NewItem(new EntitySource_Loot(Projectile), Projectile.position, Projectile.Size, ItemID.FrostCore, 1);
						}
					}
					else if (choice == 3)
					{
						Item.NewItem(new EntitySource_Loot(Projectile), Projectile.position, Projectile.Size, ItemID.SlushBlock, 25);
						if (Main.hardMode && Main.rand.NextFloat() < .2500f)
						{
							Item.NewItem(new EntitySource_Loot(Projectile), Projectile.position, Projectile.Size, ItemID.FrostCore, 1);
						}
					}
					else if (choice == 4)
					{
						Item.NewItem(new EntitySource_Loot(Projectile), Projectile.position, Projectile.Size, ModContent.ItemType<OldFrozenStaff>(), 1);
						if (Main.hardMode && Main.rand.NextFloat() < .2500f)
						{
							Item.NewItem(new EntitySource_Loot(Projectile), Projectile.position, Projectile.Size, ItemID.FrostCore, 1);
						}
					}
					else if (choice == 5)
					{
						Item.NewItem(new EntitySource_Loot(Projectile), Projectile.position, Projectile.Size, ModContent.ItemType<VikingRelic>(), 1);
						if (Main.hardMode && Main.rand.NextFloat() < .2500f)
						{
							Item.NewItem(new EntitySource_Loot(Projectile), Projectile.position, Projectile.Size, ItemID.FrostCore, 1);
						}
					}
				}
			}
			else if (player.GetModPlayer<MDPlayer>().Geodes)
            {
				if (Main.rand.NextFloat() < .3300f)
				{
					Item.NewItem(new EntitySource_Loot(Projectile), Projectile.position, Projectile.Size, ModContent.ItemType<FrozenGeode>(), 1);
				}
			}
		}
	}
}