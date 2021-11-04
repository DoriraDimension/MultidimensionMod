using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Hooks
{
	internal class GlowingKelpHook : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Glowing Kelp Hook");
			Tooltip.SetDefault("Kelp is said to be very grabby.");
			DisplayName.AddTranslation(GameCulture.German, "Glühender Seetanghaken");
			Tooltip.AddTranslation(GameCulture.German, "Es wird gesagt das Seetang sehr handgreiflich sein kann.");
		}

		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.AmethystHook);
			item.width = 36;
			item.height = 24;
			item.shootSpeed = 18f;
			item.rare = ItemRarityID.Pink;
			item.shoot = ModContent.ProjectileType<KelpHookTip>();
		}

		public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
		{
			Texture2D texture = mod.GetTexture("Items/Hooks/GlowingKelpHook_Glow");
			spriteBatch.Draw
			(
				texture,
				new Vector2
				(
					item.position.X - Main.screenPosition.X + item.width * 0.5f,
					item.position.Y - Main.screenPosition.Y + item.height - texture.Height * 0.5f + 2f
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

	internal class KelpHookTip : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Glowing Kelp Hook");
			DisplayName.AddTranslation(GameCulture.German, "Glühender Seetanghaken");
		}

		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.GemHookAmethyst);
		}

		public override bool? SingleGrappleHook(Player player)
		{
			return true;
		}

		public override float GrappleRange()
		{
			return 1000f;
		}

		public override void NumGrappleHooks(Player player, ref int numHooks)
		{
			numHooks = 2;
		}

		public override void GrappleRetreatSpeed(Player player, ref float speed)
		{
			speed = 26f;
		}

		public override void GrapplePullSpeed(Player player, ref float speed)
		{
			speed = 10;
		}

		public override void GrappleTargetPoint(Player player, ref float grappleX, ref float grappleY)
		{
			Vector2 dirToPlayer = projectile.DirectionTo(player.Center);
			float hangDist = 10f;
			grappleX += dirToPlayer.X * hangDist;
			grappleY += dirToPlayer.Y * hangDist;
		}

		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			Vector2 playerCenter = Main.player[projectile.owner].MountedCenter;
			Vector2 center = projectile.Center;
			Vector2 distToProj = playerCenter - projectile.Center;
			float projRotation = distToProj.ToRotation() - 1.57f;
			float distance = distToProj.Length();
			while (distance > 30f && !float.IsNaN(distance))
			{
				distToProj.Normalize();                
				distToProj *= 14f;                      
				center += distToProj;                   
				distToProj = playerCenter - center;    
				distance = distToProj.Length();
				Color drawColor = lightColor;

				spriteBatch.Draw(mod.GetTexture("Items/Hooks/KelpHookChain"), new Vector2(center.X - Main.screenPosition.X, center.Y - Main.screenPosition.Y),
					new Rectangle(0, 0, Main.chain30Texture.Width, Main.chain30Texture.Height), drawColor, projRotation,
					new Vector2(Main.chain30Texture.Width * 0.5f, Main.chain30Texture.Height * 0.5f), 1f, SpriteEffects.None, 0f);
			}
			return true;
		}

		public override void PostDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			Texture2D glowMask = mod.GetTexture("Items/Hooks/KelpHookTip_Glow");
			Rectangle frame = glowMask.Frame(1, Main.projFrames[projectile.type], 0, projectile.frame);
			frame.Height -= 1;
			float originOffsetX = (glowMask.Width - projectile.width) * 0.5f + projectile.width * 0.5f + drawOriginOffsetX;
			spriteBatch.Draw
			(
				 glowMask,
				 projectile.position - Main.screenPosition + new Vector2(originOffsetX + drawOffsetX, projectile.height / 2 + projectile.gfxOffY),
				 frame,
				 Color.White,
				 projectile.rotation,
				 new Vector2(originOffsetX, projectile.height / 2 - drawOriginOffsetY),
				 projectile.scale,
				 projectile.spriteDirection == -1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None,
				 0f
			);
		}
	}
}
