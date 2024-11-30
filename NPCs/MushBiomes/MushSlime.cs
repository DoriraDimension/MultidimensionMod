using MultidimensionMod.Biomes;
using MultidimensionMod.Dusts;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using Terraria.GameContent.Bestiary;
using Terraria.Audio;
using MultidimensionMod.Base;
using MultidimensionMod.Items.Critters;

namespace MultidimensionMod.NPCs.MushBiomes
{
    public class MushSlime : ModNPC
    {
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[NPC.type] = 3;
        }

        public override void SetDefaults()
        {
            NPC.width = 32;
            NPC.height = 30;
            NPC.defense = 4;
            NPC.damage = 12;
            NPC.lifeMax = 30;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.knockBackResist = 0.7f;
            NPC.value = 1000f;
            NPC.chaseable = false;
            SpawnModBiomes = new int[1] { ModContent.GetInstance<ShroomForest>().Type };
        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[]
            {
                new FlavorTextBestiaryInfoElement("Mods.MultidimensionMod.Bestiary.MushSlime")
            });
        }

        public int farting = 0; //timer for spore cloud attack
        public bool upset = false; //Indicates that this guy has lost health and wants to kill you now
        public int jump = 0; //Sololy exists to measure time for the sped up animation

        public override void AI()
        {
            if (!BaseAI.HitTileOnSide(NPC, 3))
            {
                jump = 0; //Reset timer after jump
            }
            if (BaseAI.HitTileOnSide(NPC, 3)) //Only increase if on the ground
            {
                jump++;
                if (upset) //Only increase if lost health
                {
                    farting++;
                    jump++;
                }
            }
            if (NPC.life < NPC.lifeMax)
            {
                upset = true; //initiate ability to emit spores
                NPC.chaseable = true; //Make it so minions can attack now
            }
            BaseAI.AISlime(NPC, ref NPC.ai, true, 120, 2, -6, 3, -8); //Main AI code
            if (farting >= 80 && !BaseAI.HitTileOnSide(NPC, 3)) //Emit spore cloud when jump occours
            {
                farting = 0; //reset timer
                if (Main.netMode != NetmodeID.MultiplayerClient)
                {
                    Projectile.NewProjectile(NPC.GetSource_FromAI(), NPC.Center, new Vector2(0f, 0f), ModContent.ProjectileType<SlimeFart>(), 10, 0);
                }
            }
        }

        public override void FindFrame(int frameHeight)
        {
            if (!BaseAI.HitTileOnSide(NPC, 3))
            {
                NPC.frame.Y = 0;
            }
            else if (farting >= 140 && farting < 180 && BaseAI.HitTileOnSide(NPC, 3))
            {
                NPC.frame.Y = (34 * 2);
            }
            else
            {
                int frameSpeed = 8; //Initial animation speed
                if (jump >= 120)
                {
                    frameSpeed = 4; //Become faster one second before jump
                }
                NPC.frameCounter += 1.0;
                if (NPC.frameCounter >= frameSpeed)
                {
                    NPC.frameCounter = 0.0;
                    NPC.frame.Y += 34;
                    if (NPC.frame.Y > (34 * 1))
                    {
                        NPC.frameCounter = 0;
                        NPC.frame.Y = 0;
                    }
                }
            }
        }

        public override bool CanHitPlayer(Player target, ref int cooldownSlot)
        {
            if (NPC.life < NPC.lifeMax) //Only enable hitbox after it lost health
            {
                return true;
            }
            return false;
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (spawnInfo.Player.InModBiome(ModContent.GetInstance<ShroomForest>()))
            {
                return 0.15f;
            }
            return base.SpawnChance(spawnInfo);
        }

        public override void HitEffect(NPC.HitInfo hit)
        {

            int dust1 = ModContent.DustType<MushroomDust>();
            if (NPC.life <= 0)
            {
                for (int i = 0; i < 3; i++) //Execute code thrice
                {
                    Dust.NewDust(new Vector2(NPC.position.X, NPC.position.Y), NPC.width, NPC.height, dust1, 0f, 0f, 0);
                    Dust.NewDust(new Vector2(NPC.position.X, NPC.position.Y), NPC.width, NPC.height, dust1, 0f, 0f, 0);
                    Dust.NewDust(new Vector2(NPC.position.X, NPC.position.Y), NPC.width, NPC.height, dust1, 0f, 0f, 0);
                }
            }
        }
    }

    internal class SlimeFart : ModProjectile
    {
        public override string Texture => "MultidimensionMod/Projectiles/NoTexture";

        public override void SetStaticDefaults()
        {
        }

        public override void SetDefaults()
        {
            Projectile.width = 40;
            Projectile.height = 40;
            Projectile.hostile = true;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
            Projectile.penetrate = -1;
            Projectile.timeLeft = 60;
        }

        public override void AI()
        {
            for (int i = 0; i < 2; i++)
            {
                int purple = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, ModContent.DustType<PufferFartDust>(), Projectile.velocity.X * 0.30f, Projectile.velocity.Y * 0.30f, 200, default(Color), 1f);
                Main.dust[purple].noGravity = true;
                Main.dust[purple].velocity.X *= 1f - Main.rand.NextFloat(0.3f);
                Main.dust[purple].velocity.Y *= 1f - Main.rand.NextFloat(0.3f);
            }
        }
    }
}