using MultidimensionMod.Items.Materials;
using MultidimensionMod.Dusts;
using MultidimensionMod.Biomes;
using MultidimensionMod.Base;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;
using Terraria.GameContent.ItemDropRules;
using Terraria.GameContent.Bestiary;

namespace MultidimensionMod.NPCs.Madness
{
    public class MadnessBat2 : ModNPC
    {
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[NPC.type] = 4;
        }
        public override void SetDefaults()
        {
            NPC.width = 30;
            NPC.height = 30;
            NPC.damage = 5;
            NPC.defense = 10;
            NPC.lifeMax = 300;
            NPC.noGravity = true;
            NPC.noTileCollide = false;
            NPC.knockBackResist = 0.5f;
            NPC.value = Item.sellPrice(0, 0, 8, 30);
            NPC.lavaImmune = true;
            NPC.netAlways = true;
            NPC.aiStyle = 14;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[]
            {
                new FlavorTextBestiaryInfoElement("Ohhhh shit, a bat.")
            });
        }

        public override void AI()
        {
            BaseAI.AIFlier(NPC, ref NPC.ai, true, 0.1f, 0.04f, 4f, 1.5f, true, 300);
            Player player = Main.player[NPC.target];

            if (player.Center.X > NPC.Center.X)
            {
                NPC.spriteDirection = -1;
            }
            else
            {
                NPC.spriteDirection = 1;
            }

        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (spawnInfo.Player.InModBiome(ModContent.GetInstance<MadnessMoon>()) && Main.hardMode)
            {
                return SpawnCondition.OverworldNightMonster.Chance * 0.1f;
            }
            return 0f;
        }

        public override void FindFrame(int frameHeight)
        {
            NPC.rotation = NPC.velocity.X * 0.05f;
            NPC.frameCounter += 1.0;
            if (NPC.frameCounter >= 7.0)
            {
                NPC.frameCounter = 0.0;
                NPC.frame.Y += frameHeight;
                if (NPC.frame.Y >= Main.npcFrameCount[NPC.type] * frameHeight)
                {
                    NPC.frame.Y = 0;
                }
            }
        }

        public override void HitEffect(NPC.HitInfo hit)
        {
            for (int k = 0; k < 3; k++)
            {
                Dust.NewDust(NPC.position, NPC.width, NPC.height, Main.rand.NextBool(2) ? ModContent.DustType<MadnessP>() : ModContent.DustType<MadnessB>(), hit.HitDirection, -1f, 0);
            }
            if (NPC.life <= 0)
            {
                for (int k = 0; k < 15; k++)
                {
                    Dust.NewDust(NPC.position, NPC.width, NPC.height, Main.rand.NextBool(2) ? ModContent.DustType<MadnessP>() : ModContent.DustType<MadnessB>(), hit.HitDirection, -1f, 0);
                }
            }
        }

        public override void ModifyNPCLoot(NPCLoot NPCloot)
        {
            if (Main.rand.NextBool(3))
            {
                NPCloot.Add(ItemDropRule.Common(ModContent.ItemType<MadnessFragment>(), 1, 1, 2));
            }
        }
    }
}