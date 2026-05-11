using MultidimensionMod.Base;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Bestiary;
using MultidimensionMod.Biomes;

namespace MultidimensionMod.NPCs.Bosses.MushroomMonarch
{
    public class RedMushling : ModNPC
    {

        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Mushling");
            Main.npcFrameCount[NPC.type] = 7;
            NPCID.Sets.DontDoHardmodeScaling[Type] = true;
            NPCID.Sets.CantTakeLunchMoney[Type] = true;
        }

        public override void SetDefaults()
        {
            NPC.lifeMax = 25;
            NPC.damage = 6;
            NPC.defense = 4;
            NPC.knockBackResist = 1f;
            NPC.value = Item.sellPrice(0, 0, 0, 0);
            NPC.aiStyle = -1;
            NPC.width = 30;
            NPC.height = 40;
            NPC.npcSlots = 0f;
            NPC.netAlways = true;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            SpawnModBiomes = new int[2] { ModContent.GetInstance<ShroomForest>().Type, ModContent.GetInstance<MushStoryBiome>().Type };
            NPC.AL().CantHurtDapper = true;
        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.UIInfoProvider = new CommonEnemyUICollectionInfoProvider(ContentSamples.NpcBestiaryCreditIdsByNpcNetIds[ModContent.NPCType<MushroomMonarch>()], quickUnlock: true);
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[]
            {
                new FlavorTextBestiaryInfoElement("Mods.MultidimensionMod.Bestiary.RedMushling")
            });
        }

        public override void AI()
        {
            Player target = Main.player[NPC.target];
            NPC.TargetClosest();
            if (target == null)
            {
                NPC.TargetClosest();
            }
            if (target.Center.X > NPC.Center.X)
            {
                NPC.spriteDirection = -1;
            }
            else
            {
                NPC.spriteDirection = 1;
            }
            float speedUp = 0.06f;
            float maxVel = 2.5f;
            if (NPC.Center.X > target.Center.X)
            {
                NPC.velocity.X -= speedUp;
                if (NPC.velocity.X > 0f)
                {
                    NPC.velocity.X -= speedUp;
                }
                if (NPC.velocity.X < 0f - maxVel)
                {
                    NPC.velocity.X = 0f - maxVel;
                }
            }
            if (NPC.Center.X < target.Center.X)
            {
                NPC.velocity.X += speedUp;
                if (NPC.velocity.X < 0f)
                {
                    NPC.velocity.X += speedUp;
                }
                if (NPC.velocity.X > maxVel)
                {
                    NPC.velocity.X = maxVel;
                }
            }
            BaseAI.WalkupHalfBricks(NPC);
            if (Math.Abs(NPC.velocity.X) == NPC.ai[1])
                NPC.velocity.X = NPC.ai[1] * NPC.spriteDirection;
            if (BaseAI.HitTileOnSide(NPC, 3))
            {
                if (NPC.velocity.X < 0f && NPC.direction == -1 || NPC.velocity.X > 0f && NPC.direction == 1)
                {
                    Vector2 newVec = BaseAI.AttemptJump(NPC.position, NPC.velocity, NPC.width, NPC.height, NPC.direction, NPC.directionY, 6, 10, 4, true);
                    if (NPC.velocity != newVec) { NPC.velocity = newVec; NPC.netUpdate = true; }
                }
            }

            if (NPC.velocity.Y == 0)
            {
                NPC.frameCounter++;
                if (NPC.frameCounter > 8)
                {
                    NPC.frameCounter = 0;
                    NPC.frame.Y += 42;
                }
                if (NPC.frame.Y > 42 * 6)
                {
                    NPC.frame.Y = 0;
                }
            }
            else
            {
                NPC.frame.Y = 42 * 6;
            }
        }

        public override void HitEffect(NPC.HitInfo hit)
        {
            if (NPC.life <= 0)
            {
                Gore.NewGore(NPC.GetSource_FromThis(), NPC.position, NPC.velocity, ModContent.Find<ModGore>("MultidimensionMod/RedMushGore1").Type, 1);
                Gore.NewGore(NPC.GetSource_FromThis(), NPC.position, NPC.velocity, ModContent.Find<ModGore>("MultidimensionMod/RedMushGore2").Type, 1);
                Gore.NewGore(NPC.GetSource_FromThis(), NPC.position, NPC.velocity, ModContent.Find<ModGore>("MultidimensionMod/RedMushGore3").Type, 1);
            }
        }
    }
}