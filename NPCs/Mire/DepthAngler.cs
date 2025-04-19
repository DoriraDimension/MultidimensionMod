using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using MultidimensionMod.Base;
using System;
using Microsoft.Xna.Framework;
using MultidimensionMod.Biomes;
using Terraria.GameContent.Bestiary;

namespace MultidimensionMod.NPCs.Mire
{
    public class DepthAngler : ModNPC
    {
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[NPC.type] = 4;
        }

        public override void SetDefaults()
        {
            NPC.width = 64;
            NPC.height = 38;
            NPC.damage = 0;
            NPC.defense = 20;
            NPC.lifeMax = 70;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.value = 5000;
            NPC.knockBackResist = 0f;
            NPC.aiStyle = -1;
            SpawnModBiomes = new int[1] { ModContent.GetInstance<TheLakeDepths>().Type };
        }

        public override void SetBestiary(BestiaryDatabase dataNPC, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[]
            {
                new FlavorTextBestiaryInfoElement("Mods.MultidimensionMod.Bestiary.DepthAngler")
            });
        }

        public int goingToBite = 0;
        public int cooldown = 0;
        public bool theBiteOf87 = false;
        public Entity GetTarget()
        {
            NPC.TargetClosest();
            Player p = Main.player[NPC.target];
            float distanceToNPC = 9999999f;
            NPC thePrey=null;
            for (int i = 0; i < Main.maxNPCs; i++)
                {
                    NPC npc = Main.npc[i];
                    if (npc.type == ModContent.NPCType<Darkdrifter>() && npc.active && (Vector2.Distance(npc.Center,NPC.Center)<distanceToNPC))
                    {
                        distanceToNPC=Vector2.Distance(npc.Center,NPC.Center);
                        thePrey=npc;
                    }
                    
                }
            if(thePrey is not null)
            {
                if(distanceToNPC<Vector2.Distance(p.Center,NPC.Center))
                    return thePrey;
            }

            return p;
        }
        public override void AI()
        {
            Entity target = GetTarget();

            float distance = NPC.Distance(target.Center);

            //Turn on lantern just before getting into bite range and face the player
            if (distance <= 120)
            {
                Lighting.AddLight(NPC.Center, Color.Yellow.R / 255, Color.Orange.G / 255, Color.Yellow.B / 255);
                if (target.Center.X > NPC.Center.X)
                {
                    NPC.spriteDirection = -1;
                }
                else
                {
                    NPC.spriteDirection = 1;
                }
            }
            if (cooldown > 0)
                cooldown--;
            if (distance <= 40 && !theBiteOf87 && cooldown == 0)
            {
                //go into bite mode
                if (goingToBite < 5)
                    goingToBite++;
                if (goingToBite == 5)
                {
                    theBiteOf87 = true;
                }
            }
            if (theBiteOf87)
            {
                //Enable contact damage during bite
                NPC.damage = 100;
                goingToBite++;
                NPC.frameCounter++;
                if (NPC.frameCounter >= 3)
                {
                    NPC.frame.Y += 48;
                    if (NPC.frame.Y > (48 * 3))
                    {
                        NPC.frameCounter = 0;
                        NPC.frame.Y = 48 * 3;
                    }
                }
                if (goingToBite == 15)
                {
                    //Disable biting mode and contact damage
                    //Set cooldown to 2 seconds and reset frame
                    theBiteOf87 = false;
                    NPC.damage = 0;
                    goingToBite = 0;
                    NPC.frame.Y = 0;
                    cooldown = 120;
                }
            }
        }
    }
}