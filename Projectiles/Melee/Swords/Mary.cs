using MultidimensionMod.Buffs.Debuffs;
using MultidimensionMod.Base;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.Audio;
using Terraria.ModLoader;
using Terraria.Chat;
using Terraria.Localization;

namespace MultidimensionMod.Projectiles.Melee.Swords
{
    internal class Mary : ModProjectile
    {

        public override void SetStaticDefaults()
        {
            Main.projFrames[Projectile.type] = 10;
        }

        public override void SetDefaults()
        {
            Projectile.width = 38;
            Projectile.height = 58;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
            Projectile.penetrate = -1;
            Projectile.alpha = 255;
            Projectile.timeLeft = 240;
        }

        public override void OnKill(int timeLeft)
        {
            int pieCut = 20;
            for (int m = 0; m < pieCut; m++)
            {
                int dustID = Dust.NewDust(new Vector2(Projectile.Center.X - 1, Projectile.Center.Y - 1), 2, 2, DustID.Blood, 0f, 0f, 100, Color.White, 1.6f);
                Main.dust[dustID].velocity = BaseUtility.RotateVector(default, new Vector2(6f, 0f), m / (float)pieCut * 6.28f);
            }
        }

        public int scream = 0;

        public override void AI()
        {
            Player player = Main.player[Projectile.owner];
            Projectile.Center = player.Center + Vector2.UnitY * (player.gfxOffY - 180f);
            Projectile.alpha -= 5;
            Projectile.spriteDirection = player.direction;
            if (Projectile.alpha <= 0)
            {
                scream++;

                if (scream == 120)
                {
                    for (int m = 0; m < 20; m++)
                    {
                        int dustID = Dust.NewDust(new Vector2(Projectile.Center.X - 1, Projectile.Center.Y - 1), 2, 2, DustID.Blood, 0f, 0f, 100, Color.White, 1.6f);
                        Main.dust[dustID].velocity = BaseUtility.RotateVector(default, new Vector2(6f, 0f), m / (float)20 * 6.28f);
                    }
                    SoundEngine.PlaySound(SoundID.DD2_BetsyScream with { Pitch = 1.50f }, Projectile.position);
                    for (int i = 0; i < Main.maxNPCs; i++)
                    {
                        NPC target = Main.npc[i];
                        if (target.HasBuff(ModContent.BuffType<MarysWrath>()))
                        {
                            if (!target.immortal)
                            {
                                if (Main.netMode != 1)
                                {
                                    target.SimpleStrikeNPC(150, 0, false, 0f, DamageClass.Melee, false, 0, true);
                                }
                            }
                            target.RequestBuffRemoval(ModContent.BuffType<MarysWrath>());
                        }
                    }
                }
            }
            if (scream < 120)
            {
                if (++Projectile.frameCounter >= 7)
                {
                    Projectile.frameCounter = 0;
                    if (++Projectile.frame >= 5)
                    {
                        Projectile.frame = 0;
                    }
                }
            }
            else if (scream >= 120)
            {
                if (++Projectile.frameCounter >= 5)
                {
                    Projectile.frameCounter = 0;
                    if (++Projectile.frame >= 9)
                    {
                        Projectile.frame = 9;
                    }
                }
                if (Projectile.frame < 6)
                {
                    Projectile.frame = 6;
                }
            }
            if (Main.rand.NextBool(4))
            {
                Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustID.Blood, Projectile.velocity.X * 0.2f, Projectile.velocity.Y * 0.2f, 100, default(Color), 2f);
            }
        }
    }
}