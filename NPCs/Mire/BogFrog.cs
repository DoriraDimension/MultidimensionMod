using MultidimensionMod.Biomes;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria.GameContent.Bestiary;
using MultidimensionMod.Items.Critters;
using System;

namespace MultidimensionMod.NPCs.Mire
{
    public class BogFrog : ModNPC
    {
        public override void SetStaticDefaults()
        {
            NPCID.Sets.CountsAsCritter[Type] = true;
            NPCID.Sets.DontDoHardmodeScaling[Type] = true;
            NPCID.Sets.TakesDamageFromHostilesWithoutBeingFriendly[Type] = true;
            NPCID.Sets.ShimmerTransformToNPC[NPC.type] = NPCID.Shimmerfly;
            Main.npcFrameCount[NPC.type] = 13;
        }
        public override void SetDefaults()
        {
            NPCID.Sets.TownCritter[NPC.type] = true;
            NPC.width = 26;
            NPC.height = 20;
            NPC.defense = 0;
            NPC.lifeMax = 5;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.knockBackResist = 0.5f;
            NPC.aiStyle = 7;
            AIType = NPCID.Frog;
            AnimationType = NPCID.Frog;
            NPC.dontTakeDamageFromHostiles = false;
            NPC.catchItem = (short)ModContent.ItemType<BogFrogItem>();
            SpawnModBiomes = new int[1] { ModContent.GetInstance<TheShroudedMire>().Type };
        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[]
            {
                new FlavorTextBestiaryInfoElement("Mods.MultidimensionMod.Bestiary.BogFrog")
            });
        }

        public override void HitEffect(NPC.HitInfo hit)
        {
            if (NPC.life <= 0)
            {
                Gore.NewGore(NPC.GetSource_FromThis(), NPC.position, NPC.velocity, ModContent.Find<ModGore>("MultidimensionMod/BogFrogGore1").Type, 1);
                Gore.NewGore(NPC.GetSource_FromThis(), NPC.position, NPC.velocity, ModContent.Find<ModGore>("MultidimensionMod/BogFrogGore2").Type, 1);
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
    }
}