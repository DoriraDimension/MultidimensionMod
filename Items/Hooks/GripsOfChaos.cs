using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Hooks
{
	internal class GripsOfChaos : ModItem
	{
		public override void SetStaticDefaults() 
		{
			//DisplayName.SetDefault("The Grips of Chaos");
			/*Tooltip.SetDefault(@"Fires 2 different hooks depending on which one is already out
Red has a longer range
Blue pulls in/retracts quicker");*/
		}

		public override void SetDefaults() 
		{
			Item.CloneDefaults(ItemID.DualHook);
            Item.rare = ItemRarityID.Blue;
            Item.shootSpeed = 12f;
            Item.shoot = ModContent.ProjectileType<GripRed>();
		}

        public int hookSwitch = 0;

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
            hookSwitch++;
            if (hookSwitch == 0)
                Item.shoot = ModContent.ProjectileType<GripNotRed>();
            if (hookSwitch == 1)
                Item.shoot = ModContent.ProjectileType<GripRed>();
            if (hookSwitch >= 2)
                hookSwitch = 0;
            return true;
		}
	}

    internal class GripRed : ModProjectile
    {
        private static Asset<Texture2D> chainTexture;

        public override void Load()
        { // This is called once on mod (re)load when this piece of content is being loaded.
          // This is the path to the texture that we'll use for the hook's chain. Make sure to update it.
            chainTexture = ModContent.Request<Texture2D>("MultidimensionMod/Items/Hooks/GripRed_Chain");
        }

        public override void Unload()
        { // This is called once on mod reload when this piece of content is being unloaded.
          // It's currently pretty important to unload your static fields like this, to avoid having parts of your mod remain in memory when it's been unloaded.
            chainTexture = null;
        }

        public override void SetStaticDefaults()
        {
        }

        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileID.GemHookAmethyst);
        }

        public override bool? CanUseGrapple(Player player)
        {
            int hooksOut = 0;
            for (int l = 0; l < 1000; l++)
            {
                if (Main.projectile[l].active && Main.projectile[l].owner == Main.myPlayer && (Main.projectile[l].type == ModContent.ProjectileType<GripRed>() || Main.projectile[l].type == ModContent.ProjectileType<GripNotRed>()))
                {
                    hooksOut++;
                }
            }
            return hooksOut <= 1;
        }

        public override void UseGrapple(Player player, ref int type)
        {
            int hooksOut = 0;
            int oldestHookIndex = -1;
            int oldestHookTimeLeft = 100000;
            for (int i = 0; i < 1000; i++)
            {
                if (Main.projectile[i].active && Main.projectile[i].owner == Projectile.whoAmI && Main.projectile[i].type == Projectile.type)
                {
                    hooksOut++;
                    if (player.ownedProjectileCounts[ModContent.ProjectileType<GripNotRed>()] == 0)
                        type = ModContent.ProjectileType<GripNotRed>();
                    if (Main.projectile[i].timeLeft < oldestHookTimeLeft)
                    {
                        oldestHookIndex = i;
                        oldestHookTimeLeft = Main.projectile[i].timeLeft;
                    }
                }
            }
            if (hooksOut > 1)
            {
                Main.projectile[oldestHookIndex].Kill();
            }
        }

        public override float GrappleRange()
        {
            return 300f;
        }

        public override void NumGrappleHooks(Player player, ref int numHooks)
        {
            numHooks = 2;
        }

        public override void GrappleRetreatSpeed(Player player, ref float speed)
        {
            speed = 14f;
        }

        public override void GrapplePullSpeed(Player player, ref float speed)
        {
            speed = 10;
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
            Texture2D glowMask = ModContent.Request<Texture2D>("MultidimensionMod/Items/Hooks/GripRed").Value;
            return true;
        }
    }

    internal class GripNotRed : ModProjectile
    {
        private static Asset<Texture2D> chainTexture;

        public override void Load()
        { // This is called once on mod (re)load when this piece of content is being loaded.
          // This is the path to the texture that we'll use for the hook's chain. Make sure to update it.
            chainTexture = ModContent.Request<Texture2D>("MultidimensionMod/Items/Hooks/GripNotRed_Chain");
        }

        public override void Unload()
        { // This is called once on mod reload when this piece of content is being unloaded.
          // It's currently pretty important to unload your static fields like this, to avoid having parts of your mod remain in memory when it's been unloaded.
            chainTexture = null;
        }

        public override void SetStaticDefaults()
        {
        }

        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileID.GemHookAmethyst);
        }

        public override bool? CanUseGrapple(Player player)
        {
            int hooksOut = 0;
            for (int l = 0; l < 1000; l++)
            {
                if (Main.projectile[l].active && Main.projectile[l].owner == Main.myPlayer && (Main.projectile[l].type == ModContent.ProjectileType<GripRed>() || Main.projectile[l].type == ModContent.ProjectileType<GripNotRed>()))
                {
                    hooksOut++;
                }
            }
            return hooksOut <= 1;
        }

        public override void UseGrapple(Player player, ref int type)
        {
            int hooksOut = 0;
            int oldestHookIndex = -1;
            int oldestHookTimeLeft = 100000;
            for (int i = 0; i < 1000; i++)
            {
                if (Main.projectile[i].active && Main.projectile[i].owner == Projectile.whoAmI && Main.projectile[i].type == Projectile.type)
                {
                    hooksOut++;
                    if (player.ownedProjectileCounts[ModContent.ProjectileType<GripRed>()] == 0)
                        type = ModContent.ProjectileType<GripRed>();
                    if (Main.projectile[i].timeLeft < oldestHookTimeLeft)
                    {
                        oldestHookIndex = i;
                        oldestHookTimeLeft = Main.projectile[i].timeLeft;
                    }
                }
            }
            if (hooksOut > 1)
            {
                Main.projectile[oldestHookIndex].Kill();
            }
        }

        public override float GrappleRange()
        {
            return 300f;
        }

        public override void NumGrappleHooks(Player player, ref int numHooks)
        {
            numHooks = 2;
        }

        public override void GrappleRetreatSpeed(Player player, ref float speed)
        {
            speed = 14f;
        }

        public override void GrapplePullSpeed(Player player, ref float speed)
        {
            speed = 10;
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
    }
}
