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
        public override void AI()
        {
            float distance = NPC.Distance(Main.player[NPC.target].Center);
            Player target = Main.player[NPC.target];
            NPC.TargetClosest();
            //Turn on lantern just before getting into bite range and face the player
            if (distance <= 60)
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
                    NPC.frame.Y += 46;
                    if (NPC.frame.Y > (46 * 3))
                    {
                        NPC.frameCounter = 0;
                        NPC.frame.Y = 46 * 3;
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