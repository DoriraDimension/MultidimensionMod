using MultidimensionMod.Dusts;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Audio;
using Terraria.ModLoader;
using MultidimensionMod.Base;

namespace MultidimensionMod.NPCs.Bosses.FeudalFungus
{
    internal class IlluminaRing : ModProjectile
    {
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
            Projectile.Center = npc.Center;
            Projectile.light = 0.5f;
        }
    }
}