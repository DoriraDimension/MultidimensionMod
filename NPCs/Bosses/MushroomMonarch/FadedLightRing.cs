using MultidimensionMod.Dusts;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Audio;
using Terraria.ModLoader;
using MultidimensionMod.Base;
using Terraria.GameContent;
using Microsoft.CodeAnalysis;
using Mono.Cecil;
using MultidimensionMod.NPCs.TownNPCs;
using Terraria.DataStructures;

namespace MultidimensionMod.NPCs.Bosses.MushroomMonarch
{
    internal class FadedLightRing : ModProjectile
    {
        public override string Texture => "MultidimensionMod/ExtraTextures/Aura";
        public override void SetStaticDefaults()
        {
        }

        public override void SetDefaults()
        {
            Projectile.width = 165;
            Projectile.height = 165;
            Projectile.hostile = true;
            Projectile.aiStyle = -1;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
            Projectile.penetrate = -1;
            Projectile.alpha = 255;
            Projectile.timeLeft = 180;
            Projectile.AL().CantHurtDapper = true;
        }

        public override void OnSpawn(IEntitySource source)
        {
            if (source is EntitySource_Parent parent && parent.Entity is NPC npc && npc.type == ModContent.NPCType<MushroomMonarch>())
            {

            }
        }

        public int ShootTimer = 0;

        public override void AI()
        {
            ShootTimer++;
            Projectile.alpha -= 5;
            if (Projectile.alpha < 100)
            {
                Projectile.alpha = 100;
            }
            NPC mushmon = Main.npc[(int)Projectile.ai[0]];
            if (!mushmon.active)
            {
                Projectile.Kill();
            }
            if (ShootTimer == 60)
            {
                Player player = Main.LocalPlayer;
                Vector2 targetCenter = player.position;
                float ProjSpeed = 14f;
                Vector2 velocity = targetCenter - Projectile.Center;
                velocity.Normalize();
                velocity *= ProjSpeed;
                Projectile.velocity = velocity;
            }
            else if (mushmon.active && mushmon.type == ModContent.NPCType<MushroomMonarch>() && ShootTimer < 60)
                Projectile.Center = mushmon.Center;
            Projectile.light = 0.15f;
        }

        public override bool PreDraw(ref Color lightColor)
        {
            Texture2D texture = TextureAssets.Projectile[Projectile.type].Value;
            Vector2 position = Projectile.Center - Main.screenPosition;
            Rectangle rect = new(0, 0, texture.Width, texture.Height);
            Vector2 origin = new(texture.Width / 2f, texture.Height / 2f);

            Main.EntitySpriteDraw(texture, position, new Rectangle?(rect), Color.Red, Projectile.rotation, origin, 0.3f, SpriteEffects.None, 0);

            return false;
        }
    }
}