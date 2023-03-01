using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Projectiles.Melee.Swords
{
    public class DarkMatterImpacterProj : ModProjectile
    {
		public override string Texture => "MultidimensionMod/Items/Weapons/Melee/Swords/DarkMatterImpacter";
		public int ChargeTime = 0;
        public int MaxCharge = 160;
		public float[] oldrotato = new float[4];
		private float SwingingSpeed;
		float oldRotation = 0f;
		int locked = 0;
		public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Void Matter Impacter");
			ProjectileID.Sets.TrailCacheLength[Projectile.type] = 4;
			ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
		}

		public override void SetDefaults()
		{
			Projectile.height = 60;
			Projectile.width = 60;
			Projectile.aiStyle = -1;
			Projectile.friendly = true;
			Projectile.penetrate = -1;
			Projectile.tileCollide = false;
			Projectile.DamageType = DamageClass.Melee;
			Projectile.usesLocalNPCImmunity = true;
		}

		public override void AI()
        {
			Player player = Main.player[Projectile.owner];
			if (player.dead || !player.active)
            {
				Projectile.Kill();
            }

			for (int h = Projectile.oldPos.Length - 1; h > 0; h--)
				oldrotato[h] = oldrotato[h - 1];
			oldrotato[0] = Projectile.rotation;

			Vector2 playerCenter = player.RotatedRelativePoint(player.MountedCenter, true);
			float weaponRotation = 0f;
			if (player.channel)
			{
				ChargeTime++;
				Projectile.damage = 0;
			}

			if (ChargeTime > MaxCharge)
			{
				ChargeTime = MaxCharge;
				SoundEngine.PlaySound(SoundID.DD2_SonicBoomBladeSlash, Projectile.position);
			}
			if (Main.myPlayer == Projectile.owner)
            {
				if (Projectile.ai[0] == 0)
                {
                    weaponRotation = MathHelper.ToRadians(-45f * player.direction - 90f);
					if (!player.channel)
                    {
						Projectile.ai[0] = 1;
						oldRotation = weaponRotation;
						locked = player.direction;
						SoundEngine.PlaySound(SoundID.Item71, Projectile.position);
						Projectile.damage = 63;
					    if (ChargeTime == MaxCharge)
						{
							Projectile.damage *= 2;
							Projectile.knockBack = 12f;
						}
						Projectile.NewProjectile(Projectile.GetSource_FromAI(), player.Center, Vector2.Zero, ModContent.ProjectileType<ImpactZone>(), Projectile.damage, 0, Projectile.owner);
					}
                }
				if (Projectile.ai[0] >= 1)
                {
					player.direction = locked;
					Projectile.ai[0]++;
					float swingTimer = Projectile.ai[0] - 1;
					weaponRotation = oldRotation.AngleLerp(MathHelper.ToRadians(120f * player.direction - 90f), swingTimer / (Projectile.localAI[0] == 1 ? 6f : 17f) / SwingingSpeed);

					if (Projectile.ai[0] >= (Projectile.localAI[0] == 1 ? 48 : 17) * SwingingSpeed)
                    {
						Projectile.Kill();
                    }
                }
            }

			Projectile.velocity = weaponRotation.ToRotationVector2();
			Projectile.spriteDirection = player.direction;
			if (Projectile.spriteDirection == 1)
				Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver4;
			else
			    Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.ToRadians(135f);

			Projectile.Center = player.Center + Projectile.velocity * 60f;
			player.heldProj = Projectile.whoAmI;

			if (Projectile.ai[0] == 0)
            {
				player.itemRotation = MathHelper.ToRadians(-90 * player.direction);
				player.bodyFrame.Y = 5 * player.bodyFrame.Height;
			}
			else
				player.SetCompositeArmFront(true, Player.CompositeArmStretchAmount.Full, (player.Center - Projectile.Center).ToRotation() + MathHelper.PiOver2);
		}

		private float drawTimer;
		public override bool PreDraw(ref Color lightColor)
		{
			SpriteEffects spriteEffects = Projectile.spriteDirection == 1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
			Texture2D texture = TextureAssets.Projectile[Projectile.type].Value;
			Vector2 origin = new(texture.Width / 2f, texture.Height / 2f);

			Main.spriteBatch.End();
			Main.spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.Additive, Main.DefaultSamplerState, DepthStencilState.None, RasterizerState.CullCounterClockwise, null, Main.GameViewMatrix.TransformationMatrix);

			Main.spriteBatch.End();
			Main.spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, Main.DefaultSamplerState, DepthStencilState.None, RasterizerState.CullCounterClockwise, null, Main.GameViewMatrix.TransformationMatrix);

			Main.EntitySpriteDraw(texture, Projectile.Center - Main.screenPosition + Vector2.UnitY * Projectile.gfxOffY, null, Projectile.GetAlpha(lightColor), Projectile.rotation, origin, Projectile.scale, spriteEffects, 0);
			return false;
		}
	}
}