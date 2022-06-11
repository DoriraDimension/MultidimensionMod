﻿using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Projectiles.Melee.Spears
{
	public class Tonbogiri2Proj : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Tonbogiri's son");
		}

		public override void SetDefaults()
		{
			Projectile.width = 18;
			Projectile.height = 18;
			Projectile.aiStyle = 19;
			Projectile.penetrate = -1;
			Projectile.scale = 1.3f;
			Projectile.alpha = 0;

			Projectile.hide = true;
			Projectile.ownerHitCheck = true;
			Projectile.DamageType = DamageClass.Melee;
			Projectile.tileCollide = false;
			Projectile.friendly = true;
		}

		public float movementFactor
		{
			get => Projectile.ai[0];
			set => Projectile.ai[0] = value;
		}

		public override void AI()
		{
			Player projOwner = Main.player[Projectile.owner];
			Vector2 ownerMountedCenter = projOwner.RotatedRelativePoint(projOwner.MountedCenter, true);
			Projectile.direction = projOwner.direction;
			projOwner.heldProj = Projectile.whoAmI;
			projOwner.itemTime = projOwner.itemAnimation;
			Projectile.position.X = ownerMountedCenter.X - (float)(Projectile.width / 2);
			Projectile.position.Y = ownerMountedCenter.Y - (float)(Projectile.height / 2);
			if (!projOwner.frozen)
			{
				if (movementFactor == 0f)
				{
					movementFactor = 3f;
					Projectile.netUpdate = true;
				}
				if (projOwner.itemAnimation < projOwner.itemAnimationMax / 3)
				{
					movementFactor -= 3.3f;
				}
				else
				{
					movementFactor += 3.3f;
				}
			}

			Projectile.position += Projectile.velocity * movementFactor;
			if (projOwner.itemAnimation == 0)
			{
				Projectile.Kill();
			}

			Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.ToRadians(135f);
			if (Projectile.spriteDirection == -1)
			{
				Projectile.rotation -= MathHelper.ToRadians(90f);
			}
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(BuffID.Venom, 900);
		}
	}
}