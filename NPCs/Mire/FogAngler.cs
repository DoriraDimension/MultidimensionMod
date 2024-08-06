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
    public class FogAngler : ModNPC
	{
		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Fog Angler");
            Main.npcFrameCount[NPC.type] = 4;
		}

		public override void SetDefaults()
        {
            NPC.width = 68;
            NPC.height = 38;
            NPC.damage = 80;
			NPC.defense = 20;
			NPC.lifeMax = 70;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath1;
            NPC.value = 5000;
            NPC.knockBackResist = .10f;
            NPC.aiStyle = -1;
            SpawnModBiomes = new int[2] { ModContent.GetInstance<TheShroudedMire>().Type, ModContent.GetInstance<TheLakeDepths>().Type };
        }

        public override void SetBestiary(BestiaryDatabase dataNPC, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[]
            {
                new FlavorTextBestiaryInfoElement("Mods.MultidimensionMod.Bestiary.FogAngler")
            });
        }

        public override void AI()
        {
            float distance = NPC.Distance(Main.player[NPC.target].Center);
            if (distance <= 200)
            {
                Lighting.AddLight(NPC.Center, Color.Yellow.R / 255, Color.Orange.G / 255, Color.Yellow.B / 255);
            }
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

        public override void FindFrame(int frameHeight)
        {
            Player player = Main.player[NPC.target];
            float playerDistX = Math.Abs(player.Center.X - NPC.Center.X);
            float playerDistY = Math.Abs(player.Center.Y - NPC.Center.Y);
            bool BiteAttack = playerDistX < 35f && playerDistY < 40f;
            int frameMax = BiteAttack ? 8 : 5;
            if (NPC.frameCounter++ >= frameMax)
            {
                NPC.frameCounter = 0;
                if (BiteAttack)
                {
                    NPC.frame.Y += 48;
                    if (NPC.frame.Y < 48 * 2 || NPC.frame.Y > 48 * 3)
                    {
                        NPC.frame.Y = 48 * 2;
                    }
                }
                else
                {
                    NPC.frame.Y += 48;
                    if (NPC.frame.Y > 48)
                    {
                        NPC.frame.Y = 0;
                    }
                }
            }
        }
	}
}