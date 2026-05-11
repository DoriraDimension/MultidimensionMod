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
    public class Hovercap : ModNPC
    {
        public override void SetStaticDefaults()
        {
            NPCID.Sets.CountsAsCritter[Type] = true;
            NPCID.Sets.DontDoHardmodeScaling[Type] = true;
            NPCID.Sets.TakesDamageFromHostilesWithoutBeingFriendly[Type] = true;
            NPCID.Sets.ShimmerTransformToNPC[NPC.type] = NPCID.Shimmerfly;
            Main.npcFrameCount[NPC.type] = 7;
        }

        public override void SetDefaults()
        {
            NPC.noGravity = true;
            NPC.width = 26;
            NPC.height = 26;
            NPC.defense = 0;
            NPC.lifeMax = 5;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.knockBackResist = 0.8f;
            NPC.value = 1000f;
            NPC.catchItem = (short)ModContent.ItemType<HovercapItem>();
            SpawnModBiomes = new int[1] { ModContent.GetInstance<ShroomForest>().Type };
        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[]
            {
                new FlavorTextBestiaryInfoElement("Mods.MultidimensionMod.Bestiary.Hovercap")
            });
        }

        public int RocketTimer = 0;
        public bool goRight = true;

        public override void OnSpawn(IEntitySource source)
        {
            int choice = Main.rand.Next(2);
            if (choice == 0)
            {
                goRight = true;
            }
            else if (choice == 1)
            {
                goRight = false;
            }
        }

        public override void AI()
        {
            if (RocketTimer < 30)
            {
                NPC.velocity.X = 0;
                RocketTimer++;
                NPC.velocity.Y = -6f;
            }
            else if (RocketTimer >= 30)
            {
                NPC.velocity.Y = 0;
                if (BaseAI.HitTileOnSide(NPC, 1))
                {
                    goRight = false;
                    NPC.netUpdate = true;
                }
                if (BaseAI.HitTileOnSide(NPC, 0))
                {
                    goRight = true;
                    NPC.netUpdate = true;
                }
                if (!goRight)
                {
                    NPC.velocity.X = -4f;
                }
                else if (goRight)
                {
                    NPC.velocity.X = 4f;
                }
                RocketTimer = 30;
            }
        }

        public override void FindFrame(int frameHeight)
        {
            NPC.frameCounter += 1.0;
            if (NPC.frameCounter >= 6.0)
            {
                NPC.frameCounter = 0.0;
                NPC.frame.Y += frameHeight;
                if (NPC.frame.Y >= 6 * frameHeight)
                {
                    NPC.frame.Y = 0 * frameHeight;
                }
            }
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (spawnInfo.Player.InModBiome(ModContent.GetInstance<ShroomForest>()))
            {
                return 0.15f;
            }
            return base.SpawnChance(spawnInfo);
        }

        public override bool CanHitPlayer(Player target, ref int cooldownSlot) => false;

        public override void HitEffect(NPC.HitInfo hit)
        {

            int dust1 = ModContent.DustType<MushroomDust>();
            if (NPC.life <= 0)
            {
                Dust.NewDust(new Vector2(NPC.position.X, NPC.position.Y), NPC.width, NPC.height, dust1, 0f, 0f, 0);
                Dust.NewDust(new Vector2(NPC.position.X, NPC.position.Y), NPC.width, NPC.height, dust1, 0f, 0f, 0);
                Dust.NewDust(new Vector2(NPC.position.X, NPC.position.Y), NPC.width, NPC.height, dust1, 0f, 0f, 0);
            }
        }
    }
}