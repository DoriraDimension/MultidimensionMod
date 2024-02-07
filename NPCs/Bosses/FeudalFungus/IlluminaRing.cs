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

namespace MultidimensionMod.NPCs.Bosses.FeudalFungus
{
    internal class IlluminaRing : ModProjectile
    {
        public override string Texture => "MultidimensionMod/ExtraTextures/Aura";
        public override void SetStaticDefaults()
        {
        }

        public override void SetDefaults()
        {
            Projectile.width = 218;
            Projectile.height = 218;
            Projectile.hostile = true;
            Projectile.aiStyle = -1;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
            Projectile.penetrate = -1;
            Projectile.alpha = 255;
            Projectile.timeLeft = 180;
            Projectile.AL().CantHurtDapper = true;
        }

        public override void AI()
        {
            Projectile.alpha -= 5;
            if (Projectile.alpha < 100)
            {
                Projectile.alpha = 100;
            }
            int Feudal = NPC.FindFirstNPC(ModContent.NPCType<FeudalFungus>());
            NPC npc = Main.npc[Feudal];
            if (Feudal <= 1)
            {
                Projectile.Kill();
            }
            Projectile.Center = npc.Center;
            Projectile.light = 0.5f;
        }

        public override bool PreDraw(ref Color lightColor)
        {
            Texture2D texture = TextureAssets.Projectile[Projectile.type].Value;
            Vector2 position = Projectile.Center - Main.screenPosition;
            Rectangle rect = new(0, 0, texture.Width, texture.Height);
            Vector2 origin = new(texture.Width / 2f, texture.Height / 2f);

            Main.EntitySpriteDraw(texture, position, new Rectangle?(rect), Color.Blue, Projectile.rotation, origin, 0.4f, SpriteEffects.None, 0);

            return false;
        }
    }

    internal class RadiantIlluminaRing : ModProjectile
    {
        public override string Texture => "MultidimensionMod/ExtraTextures/Aura";
        public override void SetStaticDefaults()
        {
        }

        public override void SetDefaults()
        {
            Projectile.width = 250;
            Projectile.height = 250;
            Projectile.hostile = true;
            Projectile.aiStyle = -1;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
            Projectile.penetrate = -1;
            Projectile.alpha = 255;
            Projectile.timeLeft = 180;
            Projectile.AL().CantHurtDapper = true;
        }

        public override void AI()
        {
            Projectile.alpha -= 5;
            if (Projectile.alpha < 100)
            {
                Projectile.alpha = 100;
            }
            int Feudal = NPC.FindFirstNPC(ModContent.NPCType<FeudalFungus>());
            NPC npc = Main.npc[Feudal];
            if (Feudal <= 1)
            {
                Projectile.Kill();
            }
            Projectile.Center = npc.Center;
            Projectile.light = 0.5f;
        }

        public override bool PreDraw(ref Color lightColor)
        {
            Texture2D texture = TextureAssets.Projectile[Projectile.type].Value;
            Vector2 position = Projectile.Center - Main.screenPosition;
            Rectangle rect = new(0, 0, texture.Width, texture.Height);
            Vector2 origin = new(texture.Width / 2f, texture.Height / 2f);

            Main.EntitySpriteDraw(texture, position, new Rectangle?(rect), Color.Teal, Projectile.rotation, origin, 0.5f, SpriteEffects.None, 0);

            return false;
        }
    }
}