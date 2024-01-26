﻿using MultidimensionMod.Buffs.Minions;
using MultidimensionMod.Common;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace MultidimensionMod.Projectiles.Summon.Sentries
{
    public class PrayingTwins : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.MinionSacrificable[Projectile.type] = true;
            ProjectileID.Sets.DontAttachHideToAlpha[Type] = true;
            ProjectileID.Sets.CultistIsResistantTo[Projectile.type] = true;
        }

        public override void SetDefaults()
        {
            Projectile.width = 74;
            Projectile.height = 68;
            Projectile.tileCollide = true;
            Projectile.sentry = true;
            Projectile.timeLeft = Projectile.SentryLifeTime;
            Projectile.friendly = true;
            Projectile.ignoreWater = true;
            Projectile.DamageType = DamageClass.Summon;
            Projectile.penetrate = -1;
        }
        public override bool? CanDamage() => false;

        public override void AI()
        {
            Player pope = Main.player[Projectile.owner];
            if (!CheckActive(pope))
                return;
            for (int i = 0; i < Main.maxPlayers; i++)
            {
                Player player = Main.player[i];
                if (!player.active || player.dead || Projectile.DistanceSQ(player.Center) > 350 * 350)
                    continue;

                player.AddBuff(ModContent.BuffType<TwinPrayerBuff>(), 4);
            }
            if (Projectile.localAI[0]++ % 60 == 0)
            {
                MDDrawing.DrawAura(Projectile.Center, Color.Blue, 1f, Projectile);
                MDDrawing.DrawAura(Projectile.Center, Color.Red, 1f, Projectile);
            }
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            if (oldVelocity.Y > 0)
                Projectile.velocity.Y = 0;
            return false;
        }

        public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough, ref Vector2 hitboxCenterFrac)
        {
            fallThrough = false;
            return true;
        }

        private bool CheckActive(Player owner)
        {
            if (owner.dead || !owner.active)
            {
                Projectile.Kill();
                return false;
            }
            return true;
        }
    }
}