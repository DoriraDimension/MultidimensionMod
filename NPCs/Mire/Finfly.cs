using MultidimensionMod.Items.Critters;
using MultidimensionMod.Dusts;
using MultidimensionMod.Biomes;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Bestiary;
using Terraria.DataStructures;
using MultidimensionMod.NPCs.Corruption;
using MultidimensionMod.NPCs.TownNPCs;
using Terraria.Audio;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ModLoader.Utilities;

namespace MultidimensionMod.NPCs.Mire
{
    public class Finfly : ModNPC
    {
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[NPC.type] = 4;
        }

        public override void SetDefaults()
        {
            NPC.width = 20;
            NPC.height = 30;
            NPC.defense = 0;
            NPC.damage = 10;
            NPC.lifeMax = 40;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.value = 0;
            NPC.npcSlots = 1f;
            NPC.knockBackResist = 1f;
            NPC.noGravity = true;
            SpawnModBiomes = new int[1] { ModContent.GetInstance<TheLakeDepths>().Type };
        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[]
            {
                new FlavorTextBestiaryInfoElement("Mods.MultidimensionMod.Bestiary.Finfly")
            });
        }

        public int STOP = 0;

        public override void AI()
        {
            NPC.spriteDirection = NPC.direction;
            STOP--;
            if (NPC.wet)
            {
                if (Main.rand.NextBool(180))
                {
                    NPC.velocity.X = Main.rand.Next(-6, 6);
                    NPC.velocity.Y = Main.rand.Next(-6, 6);
                    STOP = 40;
                }
                else if (STOP == 0)
                {
                    NPC.velocity.X = 0;
                    NPC.velocity.Y = 0;
                }
            }
        }

        public override bool CanHitPlayer(Player target, ref int cooldownSlot) => false;

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

        public override void FindFrame(int frameHeight)
        {
            NPC.rotation = NPC.velocity.X * 0.05f;
            NPC.frameCounter += 1.0;
            if (NPC.frameCounter >= 3.0)
            {
                NPC.noGravity = true;
                NPC.frameCounter = 0.0;
                NPC.frame.Y += frameHeight;
                if (NPC.frame.Y >= (NPC.frame.Y = frameHeight * 3))
                {
                    NPC.frame.Y = 0;
                }
            }
            if (!NPC.wet)
            {
                NPC.noGravity = false;
            }
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