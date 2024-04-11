using MultidimensionMod.Items.Critters;
using MultidimensionMod.Dusts;
using MultidimensionMod.Biomes;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Bestiary;

namespace MultidimensionMod.NPCs.MushBiomes
{
    public class MushbugBaby : ModNPC
    {
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[Type] = 4;
            NPCID.Sets.CountsAsCritter[Type] = true;
            NPCID.Sets.DontDoHardmodeScaling[Type] = true;
            NPCID.Sets.TakesDamageFromHostilesWithoutBeingFriendly[Type] = true;
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
            NPC.catchItem = (short)ModContent.ItemType<MushbugBabyItem>();
            SpawnModBiomes = new int[1] { ModContent.GetInstance<ShroomForest>().Type };
        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[]
            {
                new FlavorTextBestiaryInfoElement("Mods.MultidimensionMod.Bestiary.MyceliLarva")
            });
        }

        public override bool CanHitPlayer(Player target, ref int cooldownSlot) => false;

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (spawnInfo.Player.InModBiome(ModContent.GetInstance<ShroomForest>()))
            {
                return 0.20f;
            }
            return base.SpawnChance(spawnInfo);
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


        public override void HitEffect(NPC.HitInfo hit)
        {
            if (NPC.life <= 0)
            {
                int dust = ModContent.DustType<MushroomDust>();
                Dust.NewDust(new Vector2(NPC.position.X, NPC.position.Y), NPC.width, NPC.height, dust, 0f, 0f, 0);
                Dust.NewDust(new Vector2(NPC.position.X, NPC.position.Y), NPC.width, NPC.height, dust, 0f, 0f, 0);
                Dust.NewDust(new Vector2(NPC.position.X, NPC.position.Y), NPC.width, NPC.height, dust, 0f, 0f, 0);
            }

            Dust.NewDust(NPC.position + NPC.velocity, NPC.width, NPC.height, DustID.t_Slime, NPC.velocity.X * 0.5f,
                NPC.velocity.Y * 0.5f);
        }
    }
}