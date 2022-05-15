using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Hooks
{
	internal class GlowingKelpHook : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Glowing Kelp Hook");
			Tooltip.SetDefault("Kelp is said to be very grabby.");
		}

		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.AmethystHook);
			Item.width = 36;
			Item.height = 24;
			Item.shootSpeed = 18f;
			Item.rare = ItemRarityID.Pink;
			Item.shoot = ModContent.ProjectileType<KelpHookTip>();
		}

		public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
		{
			Texture2D texture = ModContent.Request<Texture2D>("MultidimensionMod/Items/Hooks/GlowingKelpHook_Glow").Value;
			spriteBatch.Draw
			(
				texture,
				new Vector2
				(
					Item.position.X - Main.screenPosition.X + Item.width * 0.5f,
					Item.position.Y - Main.screenPosition.Y + Item.height - texture.Height * 0.5f + 2f
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

		internal class KelpHookTip : ModProjectile
		{
			private static Asset<Texture2D> chainTexture;

			public override void Load()
			{ // This is called once on mod (re)load when this piece of content is being loaded.
			  // This is the path to the texture that we'll use for the hook's chain. Make sure to update it.
				chainTexture = ModContent.Request<Texture2D>("MultidimensionMod/Items/Hooks/KelpHookChain");
			}

			public override void Unload()
			{ // This is called once on mod reload when this piece of content is being unloaded.
			  // It's currently pretty important to unload your static fields like this, to avoid having parts of your mod remain in memory when it's been unloaded.
				chainTexture = null;
			}

			public override void SetStaticDefaults()
			{
				DisplayName.SetDefault("${ProjectileName.GemHookAmethyst}");
			}

			public override void SetDefaults()
			{
				Projectile.CloneDefaults(ProjectileID.GemHookAmethyst); 
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
				speed = 15;
			}

			public override void GrappleTargetPoint(Player player, ref float grappleX, ref float grappleY)
			{
				Vector2 dirToPlayer = Projectile.DirectionTo(player.Center);
				float hangDist = 10f;
				grappleX += dirToPlayer.X * hangDist;
				grappleY += dirToPlayer.Y * hangDist;
			}

			public override bool PreDrawExtras()
			{
				Vector2 playerCenter = Main.player[Projectile.owner].MountedCenter;
				Vector2 center = Projectile.Center;
				Vector2 directionToPlayer = playerCenter - Projectile.Center;
				float chainRotation = directionToPlayer.ToRotation() - MathHelper.PiOver2;
				float distanceToPlayer = directionToPlayer.Length();

				while (distanceToPlayer > 20f && !float.IsNaN(distanceToPlayer))
				{
					directionToPlayer /= distanceToPlayer;
					directionToPlayer *= chainTexture.Height();

					center += directionToPlayer;
					directionToPlayer = playerCenter - center;
					distanceToPlayer = directionToPlayer.Length();

					Color drawColor = Lighting.GetColor((int)center.X / 16, (int)(center.Y / 16));

					Main.EntitySpriteDraw(chainTexture.Value, center - Main.screenPosition,
						chainTexture.Value.Bounds, drawColor, chainRotation,
						chainTexture.Size() * 0.5f, 1f, SpriteEffects.None, 0);
				}
				return false;
			}

			public override bool PreDraw(ref Color lightColor)
			{
				Texture2D glowMask = ModContent.Request<Texture2D>("MultidimensionMod/Items/Hooks/KelpHookTip_Glow").Value;
				return true;
			}
		}
	}
}
