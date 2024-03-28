using MultidimensionMod.Biomes;
using MultidimensionMod.NPCs.Ocean;
using MultidimensionMod.Tiles.Biomes.ShroomForest;
using MultidimensionMod.Common.Globals;
using MultidimensionMod.Items.Summons;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace MultidimensionMod.NPCs.Bosses.MushroomMonarch
{
    public class MonarchSlep : ModNPC
    {
        public bool Monday = false;
        public int Patience = 0;
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Very Large Mushroom");
            Main.npcFrameCount[NPC.type] = 15;
        }

        public override void SetDefaults()
        {
            NPC.lifeMax = 200;
            NPC.defense = 0;
            NPC.damage = 0;
            NPC.width = 74;
            NPC.height = 70;
            NPC.aiStyle = -1;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.knockBackResist = 0f;
            NPC.noTileCollide = false;
            NPC.noGravity = false;
            NPC.value = 0;
            NPC.rarity = 1;
            NPC.dontTakeDamage = true;
        }

        public override void AI()
        {
            if (MDWorld.Monday)
            {
                Patience++;
                if (Patience < 120)
                {
                    NPC.frame.Y = 108;
                }
                else if (Patience >= 120 && Patience < 180)
                {
                    NPC.frame.Y = 108 * 1;
                }
                else if (Patience >= 180 && Patience < 240)
                {
                    NPC.frame.Y = 108 * 2;
                }
                else if (Patience >= 240 && Patience < 360)
                {
                    NPC.frameCounter++;
                    if (NPC.frameCounter >= 5)
                    {
                        NPC.frameCounter = 0;
                        NPC.frame.Y += 108;
                        if (NPC.frame.Y > (108 * 14))
                        {
                            NPC.frameCounter = 0;
                            NPC.frame.Y = 108 * 14;
                        }
                    }
                }
                else if (Patience == 360)
                {
                    int mosh = NPC.NewNPC(NPC.GetSource_FromAI(), (int)NPC.Center.X, (int)NPC.Center.Y + 40, ModContent.NPCType<MushroomMonarch>(), 0);
                    Main.npc[mosh].netUpdate = true;
                    NPC.active = false;
                    MDWorld.Monday = false;
                }
            }
        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (spawnInfo.Player.FindItem(ModContent.ItemType<IntimidatingMushroom>()) > 0)
                return (Main.tile[spawnInfo.SpawnTileX, spawnInfo.SpawnTileY].TileType == ModContent.TileType<MyceliumSandPlaced>() || Main.tile[spawnInfo.SpawnTileX, spawnInfo.SpawnTileY].TileType == ModContent.TileType<Mycelium>()) && !NPC.AnyNPCs(ModContent.NPCType<MonarchSlep>()) && !NPC.AnyNPCs(ModContent.NPCType<MushroomMonarch>()) && spawnInfo.Player.InModBiome(ModContent.GetInstance<ShroomForest>()) ? 0.40f : 0f;
            else
                return (Main.tile[spawnInfo.SpawnTileX, spawnInfo.SpawnTileY].TileType == ModContent.TileType<MyceliumSandPlaced>() || Main.tile[spawnInfo.SpawnTileX, spawnInfo.SpawnTileY].TileType == ModContent.TileType<Mycelium>()) && !NPC.AnyNPCs(ModContent.NPCType<MonarchSlep>()) && !NPC.AnyNPCs(ModContent.NPCType<MushroomMonarch>()) && spawnInfo.Player.InModBiome(ModContent.GetInstance<ShroomForest>()) ? 0.25f : 0f;
        }
    }
}
