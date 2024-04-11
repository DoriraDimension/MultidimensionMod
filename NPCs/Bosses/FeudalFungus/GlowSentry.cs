using MultidimensionMod.Base;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Bestiary;
using MultidimensionMod.Dusts;
using Terraria.Audio;

namespace MultidimensionMod.NPCs.Bosses.FeudalFungus
{
    public class GlowSentry : ModNPC
    {

        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[NPC.type] = 10;
            NPCID.Sets.DontDoHardmodeScaling[Type] = true;
            NPCID.Sets.CantTakeLunchMoney[Type] = true;
            NPCID.Sets.NPCBestiaryDrawModifiers value = new(0) { Hide = true };
            NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, value);
        }

        public override void SetDefaults()
        {
            NPC.lifeMax = 200;
            NPC.damage = 0;
            NPC.defense = 0;
            NPC.knockBackResist = 0f;
            NPC.value = Item.sellPrice(0, 0, 0, 0);
            NPC.aiStyle = -1;
            NPC.width = 16;
            NPC.height = 18;
            NPC.npcSlots = 0f;
            NPC.netAlways = true;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
        }

        public override void AI()
        {
            Lighting.AddLight(NPC.Center, 0, 0, (255 - NPC.alpha) * 0.15f / 255f);
            int Feudal = NPC.FindFirstNPC(ModContent.NPCType<FeudalFungus>());
            if (Feudal <= 0)
            {
                NPC.active = false;
            }
            NPC.frameCounter++;
            int FrameSpeed = 6;
            if (NPC.frameCounter >= FrameSpeed)
            {
                NPC.frame.Y += 28;
                NPC.frameCounter = 0;
                if (NPC.frame.Y > (28 * 9))
                {
                    NPC.frameCounter = 0;
                    NPC.frame.Y = 28 * 5;
                }
            }
        }

        public override void HitEffect(NPC.HitInfo hit)
        {
            if (NPC.life <= 0)
            {
                //Gore.NewGore(NPC.GetSource_FromThis(), NPC.position, NPC.velocity, ModContent.Find<ModGore>("MultidimensionMod/RedMushGore1").Type, 1);
            }
        }
    }

    public class GlowBomb : ModNPC
    {

        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[NPC.type] = 7;
            NPCID.Sets.DontDoHardmodeScaling[Type] = true;
            NPCID.Sets.CantTakeLunchMoney[Type] = true;
            NPCID.Sets.NPCBestiaryDrawModifiers value = new(0) { Hide = true };
            NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, value);
        }

        public override void SetDefaults()
        {
            NPC.lifeMax = 100;
            NPC.damage = 0;
            NPC.defense = 0;
            NPC.knockBackResist = 0f;
            NPC.value = Item.sellPrice(0, 0, 0, 0);
            NPC.aiStyle = -1;
            NPC.width = 16;
            NPC.height = 18;
            NPC.npcSlots = 0f;
            NPC.netAlways = true;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
        }

        public override void AI()
        {
            Lighting.AddLight(NPC.Center, 0, 0, (255 - NPC.alpha) * 0.15f / 255f);
            int Feudal = NPC.FindFirstNPC(ModContent.NPCType<FeudalFungus>());
            if (Feudal <= 0)
            {
                NPC.active = false;
            }
            NPC.frameCounter++;
            int FrameSpeed = 6;
            if (NPC.frameCounter >= FrameSpeed)
            {
                NPC.frame.Y += 28;
                NPC.frameCounter = 0;
                if (NPC.frame.Y > (28 * 6))
                {
                    NPC.frame.Y = (28 * 6);
                }
            }
        }

        public override void OnKill()
        {
           Projectile.NewProjectile(NPC.GetSource_FromAI(), NPC.Center.X, NPC.Center.Y, 0, 0, ModContent.ProjectileType<Glowxplosion>(), 20, 0);
           SoundEngine.PlaySound(SoundID.NPCDeath14, NPC.position);
        }
    }

    public class Glowxplosion : ModProjectile
    {
        public override string Texture => "MultidimensionMod/Projectiles/NoTexture";

        public override void SetStaticDefaults()
        {
        }

        public override void SetDefaults()
        {
            Projectile.width = 70;
            Projectile.height = 70;
            Projectile.hostile = true;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
            Projectile.penetrate = -1;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = -1;
        }

        public override void AI()
        {
            if (Projectile.timeLeft > 60)
                Projectile.timeLeft = 60;
            int pieCut = 20;
            for (int m = 0; m < pieCut; m++)
            {
                int dustID = Dust.NewDust(new Vector2(Projectile.Center.X - 1, Projectile.Center.Y - 1), 2, 2, DustID.GlowingMushroom, 0f, 0f, 100, Color.White, 1.6f);
                Main.dust[dustID].velocity = BaseUtility.RotateVector(default, new Vector2(6f, 0f), m / (float)pieCut * 6.28f);
                Main.dust[dustID].noLight = false;
                Main.dust[dustID].noGravity = true;
            }
        }
    }
}