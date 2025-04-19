using MultidimensionMod.Items.Critters;
using MultidimensionMod.Dusts;
using MultidimensionMod.Biomes;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Bestiary;
using MultidimensionMod.Base;
using Microsoft.Xna.Framework.Graphics;

namespace MultidimensionMod.NPCs.Mire
{
    public class Biofeeder : ModNPC
    {
        public override void SetStaticDefaults()
        {

        }

        public override void SetDefaults()
        {
            NPC.width = 22;
            NPC.height = 16;
            NPC.defense = 0;
            NPC.lifeMax = 5;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.value = 0;
            NPC.knockBackResist = 0.5f;
            NPC.aiStyle = NPCAIStyleID.Snail;
            AIType = NPCID.Snail;
            SpawnModBiomes = new int[1] { ModContent.GetInstance<TheLakeDepths>().Type };
        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[]
            {
                new FlavorTextBestiaryInfoElement("Mods.MultidimensionMod.Bestiary.Biofeeder")
            });
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (spawnInfo.Player.InModBiome(ModContent.GetInstance<TheLakeDepths>()))
            {
                return 0.10f;
            }
            return base.SpawnChance(spawnInfo);
        }
        /*public override void FindFrame(int frameHeight)
        {
            NPC.frameCounter += 1.0;
            if (NPC.frameCounter >= 7.0)
            {
                NPC.frameCounter = 0.0;
                NPC.frame.Y += frameHeight;
                if (NPC.frame.Y >= 3 * frameHeight)
                {
                    NPC.frame.Y = 0 * frameHeight;
                }
            }
        }*/

        public int AITimer = 0;
        public int TimerRand = 0;
        public bool Swimmer = false;
        public bool goLeft = false;
        public bool goRight = false;

        public override void AI()
        {
            /*TimerRand = Main.rand.Next(600, 1200);
            AITimer++;
            if (AITimer >= TimerRand && !Swimmer)
            {
                NPC.rotation = 0;
                NPC.aiStyle = -1;
                AIType = -1;
                Swimmer = true;
                AITimer = 0;
            }
            if (Swimmer)
            {
                NPC.velocity.Y = 0;
                if (BaseAI.HitTileOnSide(NPC, 1))
                {
                    if (AITimer >= 180)
                    {
                        NPC.aiStyle = NPCAIStyleID.Snail;
                        AIType = NPCID.Snail;
                        Swimmer = false;
                        AITimer = 0;
                    }
                    else
                    {
                        goRight = false;
                        NPC.netUpdate = true;
                    }
                }
                if (BaseAI.HitTileOnSide(NPC, 0))
                {
                    if (AITimer >= 180)
                    {
                        NPC.aiStyle = NPCAIStyleID.Snail;
                        AIType = NPCID.Snail;
                        Swimmer = false;
                        AITimer = 0;
                    }
                    else
                    {
                        goRight = true;
                        NPC.netUpdate = true;
                    }
                }
                if (!goRight)
                {
                    NPC.velocity.X = -3f;
                }
                else if (goRight)
                {
                    NPC.velocity.X = 3f;
                }
            }*/
        }

        public override void HitEffect(NPC.HitInfo hit)
        {
            if (NPC.life <= 0)
            {
                int dust = DustID.SlimeBunny;
                Dust.NewDust(new Vector2(NPC.position.X, NPC.position.Y), NPC.width, NPC.height, dust, 0f, 0f, 0);
                Dust.NewDust(new Vector2(NPC.position.X, NPC.position.Y), NPC.width, NPC.height, dust, 0f, 0f, 0);
                Dust.NewDust(new Vector2(NPC.position.X, NPC.position.Y), NPC.width, NPC.height, dust, 0f, 0f, 0);
            }

            Dust.NewDust(NPC.position + NPC.velocity, NPC.width, NPC.height, DustID.t_Slime, NPC.velocity.X * 0.5f,
                NPC.velocity.Y * 0.5f);
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
        {
            Texture2D horse = ModContent.Request<Texture2D>(NPC.ModNPC.Texture).Value;
            Texture2D glow = ModContent.Request<Texture2D>(NPC.ModNPC.Texture + "_Glow").Value;
            SpriteEffects effects = NPC.spriteDirection == -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
            spriteBatch.Draw(horse, NPC.Center + new Vector2(0f, -5f) - screenPos, NPC.frame, drawColor, NPC.rotation, NPC.frame.Size() / 2, NPC.scale, effects, 0);
            spriteBatch.Draw(glow, NPC.Center + new Vector2(0f, -5f) - screenPos, NPC.frame, Color.White, NPC.rotation, NPC.frame.Size() / 2, NPC.scale, effects, 0);
            return false;
        }
    }
}