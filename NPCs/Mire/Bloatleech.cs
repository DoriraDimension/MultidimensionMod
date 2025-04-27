using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using MultidimensionMod.Base;
using System;
using Microsoft.Xna.Framework;
using MultidimensionMod.Biomes;
using Terraria.GameContent.Bestiary;
using MultidimensionMod.Items.Accessories;
using MultidimensionMod.Items.Materials;
using Terraria.GameContent.ItemDropRules;

namespace MultidimensionMod.NPCs.Mire
{
    public class Bloatleech : ModNPC
    {
        public override void SetStaticDefaults()
        {
            //Main.npcFrameCount[NPC.type] = 3;
        }

        public override void SetDefaults()
        {
            NPC.width = 60;
            NPC.height = 40;
            NPC.damage = 30;
            NPC.defense = 15;
            NPC.lifeMax = 6;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.value = 5000;
            NPC.knockBackResist = .10f;
            NPC.aiStyle = -1;
            SpawnModBiomes = new int[1] { ModContent.GetInstance<TheLakeDepths>().Type };
        }

        public override void SetBestiary(BestiaryDatabase dataNPC, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[]
            {
                new FlavorTextBestiaryInfoElement("Mods.MultidimensionMod.Bestiary.Bloatleech")
            });
        }

        public override void AI()
        {
            if (NPC.wet)
            {
                NPC.noGravity = true;
                BaseAI.AIFish(NPC, ref NPC.ai, true, true, true, 4f, 3f);
                BaseAI.Look(NPC, 1);
                if (!Collision.WetCollision(NPC.position + NPC.velocity, NPC.width, NPC.height)) { NPC.velocity.Y -= 3f; }
            }
            else
            {
                if (NPC.velocity.Y == 0f)
                {
                    NPC.velocity.Y = Main.rand.Next(-50, -20) * 0.1f;
                    NPC.velocity.X = Main.rand.Next(-20, 20) * 0.1f;
                    NPC.netUpdate = true;
                }
                NPC.velocity.Y = NPC.velocity.Y + 0.3f;
                if (NPC.velocity.Y > 10f)
                {
                    NPC.velocity.Y = 10f;
                }
                NPC.ai[0] = 1f;
                NPC.noGravity = false;
            }
        }
    }
}