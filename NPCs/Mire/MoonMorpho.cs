using MultidimensionMod.Biomes;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria.GameContent.Bestiary;
using MultidimensionMod.Items.Critters;
using System;
using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;
using Terraria.Enums;

namespace MultidimensionMod.NPCs.Mire
{
    public class MoonMorpho : ModNPC
    {
        public override void SetStaticDefaults()
        {
            NPCID.Sets.CountsAsCritter[Type] = true;
            NPCID.Sets.DontDoHardmodeScaling[Type] = true;
            NPCID.Sets.TakesDamageFromHostilesWithoutBeingFriendly[Type] = true;
            NPCID.Sets.ShimmerTransformToNPC[NPC.type] = NPCID.Shimmerfly;
            Main.npcFrameCount[NPC.type] = 3;
        }

        public override void SetDefaults()
        {
            NPCID.Sets.TownCritter[NPC.type] = true;
            NPC.width = 28;
            NPC.height = 24;
            NPC.defense = 0;
            NPC.lifeMax = 5;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.knockBackResist = 0.0f;
            NPC.aiStyle = 64;
            NPC.noGravity = true;
            AIType = NPCID.Firefly;
            NPC.dontTakeDamageFromHostiles = false;
            NPC.catchItem = (short)ModContent.ItemType<MoonMorphoItem>();
            SpawnModBiomes = new int[1] { ModContent.GetInstance<TheShroudedMire>().Type };
        }

        public override void SetBestiary(BestiaryDatabase dataNPC, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[]
            {
                new FlavorTextBestiaryInfoElement("Mods.MultidimensionMod.Bestiary.MoonMorpho")
            });
        }

        public override void HitEffect(NPC.HitInfo hit)
        {
            if (NPC.life <= 0)
            {
                int dust = ModContent.DustType<Dusts.BogwoodDust>();
                Dust.NewDust(new Vector2(NPC.position.X, NPC.position.Y), NPC.width, NPC.height, dust, 0f, 0f, 0);
                Dust.NewDust(new Vector2(NPC.position.X, NPC.position.Y), NPC.width, NPC.height, dust, 0f, 0f, 0);
                Dust.NewDust(new Vector2(NPC.position.X, NPC.position.Y), NPC.width, NPC.height, dust, 0f, 0f, 0);
            }
            Dust.NewDust(NPC.position + NPC.velocity, NPC.width, NPC.height, DustID.t_Slime, NPC.velocity.X * 0.5f, NPC.velocity.Y * 0.5f);
        }

        public override void AI()
        {
            if (NPC.velocity.X < -0.1)
            {
                NPC.spriteDirection = -1;
            }
            if (NPC.velocity.X > 0.1)
            {
                NPC.spriteDirection = 1;
            }
        }

        public override void FindFrame(int frameHeight)
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
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (spawnInfo.Player.InModBiome(ModContent.GetInstance<TheShroudedMire>()))
            {
                return 0.05f;
            }
            return base.SpawnChance(spawnInfo);
        }

        public override bool CanHitPlayer(Player target, ref int cooldownSlot)
        {
            return false;
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
        {
            Texture2D butter = ModContent.Request<Texture2D>(NPC.ModNPC.Texture).Value;
            Texture2D glow = ModContent.Request<Texture2D>(NPC.ModNPC.Texture + "_Glow").Value;
            SpriteEffects effects = NPC.spriteDirection == -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
            spriteBatch.Draw(butter, NPC.Center + new Vector2(0f, -5f) - screenPos, NPC.frame, drawColor, NPC.rotation, NPC.frame.Size() / 2, NPC.scale, effects, 0);
            spriteBatch.Draw(glow, NPC.Center + new Vector2(0f, -5f) - screenPos, NPC.frame, Color.White, NPC.rotation, NPC.frame.Size() / 2, NPC.scale, effects, 0);
            return false;
        }
    }
}