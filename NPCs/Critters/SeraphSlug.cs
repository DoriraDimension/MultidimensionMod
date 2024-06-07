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
using Terraria.ModLoader.Utilities;

namespace MultidimensionMod.NPCs.Critters
{
    public class SeraphSlug : ModNPC
    {
        public override void SetStaticDefaults()
        {
            NPCID.Sets.CountsAsCritter[Type] = true;
            NPCID.Sets.DontDoHardmodeScaling[Type] = true;
            NPCID.Sets.TakesDamageFromHostilesWithoutBeingFriendly[Type] = true;
            Main.npcFrameCount[NPC.type] = 9;
        }

        public override void SetDefaults()
        {
            NPC.noGravity = true;
            NPC.width = 62;
            NPC.height = 46;
            NPC.defense = 4;
            NPC.lifeMax = 20;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.knockBackResist = 0.8f;
            NPC.value = 1000f;
        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[]
            {
                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Sky,
                new FlavorTextBestiaryInfoElement("Mods.MultidimensionMod.Bestiary.SkySlug")
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
                NPC.spriteDirection = 1;
            }
            else if (choice == 1)
            {
                goRight = false;
                NPC.spriteDirection = 0;
            }
        }

        public override void AI()
        {
            if (RocketTimer < 15)
            {
                NPC.velocity.X = 0;
                RocketTimer++;
                NPC.velocity.Y = -6f;
            }
            else if (RocketTimer >= 15)
            {
                NPC.velocity.Y = 0;
                if (BaseAI.HitTileOnSide(NPC, 1))
                {
                    goRight = false;
                    NPC.netUpdate = true;
                    NPC.spriteDirection = 0;
                }
                if (BaseAI.HitTileOnSide(NPC, 0))
                {
                    goRight = true;
                    NPC.netUpdate = true;
                    NPC.spriteDirection = 1;
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
                if (NPC.frame.Y >= 8 * frameHeight)
                {
                    NPC.frame.Y = 0 * frameHeight;
                }
            }
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (spawnInfo.Sky)
            {
                return SpawnCondition.Sky.Chance * 0.15f;
            }
            return base.SpawnChance(spawnInfo);
        }

        public override bool CanHitPlayer(Player target, ref int cooldownSlot) => false;

        public override void HitEffect(NPC.HitInfo hit)
        {

            int dust1 = DustID.SlimeBunny;
            if (NPC.life <= 0)
            {
                Dust.NewDust(new Vector2(NPC.position.X, NPC.position.Y), NPC.width, NPC.height, dust1, 0f, 0f, 0);
                Dust.NewDust(new Vector2(NPC.position.X, NPC.position.Y), NPC.width, NPC.height, dust1, 0f, 0f, 0);
                Dust.NewDust(new Vector2(NPC.position.X, NPC.position.Y), NPC.width, NPC.height, dust1, 0f, 0f, 0);
            }
        }
    }
}