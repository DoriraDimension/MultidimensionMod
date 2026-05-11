using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.DataStructures;

namespace MultidimensionMod.NPCs.Bosses
{
	public class BossSpawning : GlobalNPC
	{
        // SpawnBoss(player, "MyBoss", true, 0, 0, "DerpyBoi", false);
        /*public static void SpawnBoss(Player player, string type, int overrideDirection = 0, int overrideDirectionY = 0)
        {
            Mod mod = MultidimensionMod.Instance;
            SpawnBoss(player, mod.NPCType(type), overrideDirection, overrideDirectionY);
        }

        // SpawnBoss(player, mod.NPCType("MyBoss"), true, 0, 0, "DerpyBoi 2", false);
        public static void SpawnBoss(Player player, int bossType, int overrideDirection = 0, int overrideDirectionY = 0)
        {
            if (overrideDirection == 0)
            {
                overrideDirection = Main.rand.NextBool(2)? -1 : 1;
            }

            if (overrideDirectionY == 0)
            {
                overrideDirectionY = -1;
            }

            Vector2 npcCenter = player.Center + new Vector2(MathHelper.Lerp(500f, 800f, (float)Main.rand.NextDouble()) * overrideDirection, 800f * overrideDirectionY);
            SpawnBoss(player, bossType, npcCenter);
        }

        // SpawnBoss(player, "MyBoss", true, player.Center + new Vector2(0, -800f), "DerpFromAbove", false);
        public static void SpawnBoss(Player player, int type, Vector2 npcCenter = default)
        {
            Mod mod = MultidimensionMod.Instance;
            SpawnBoss(player, mod.NPCType(type), npcCenter);
        }

        // SpawnBoss(player, mod.NPCType("MyBoss"), true, player.Center + new Vector2(0, 800f), "DerpFromBelow", false);
        public static void SpawnBoss(IEntitySource source, Player player, int bossType, Vector2 npcCenter = default)
        {
            if (npcCenter == default)
            {
                npcCenter = player.Center;
            }

            if (Main.netMode != 1)
            {
                if (NPC.AnyNPCs(bossType))
                {
                    return;
                }

                int npcID = NPC.NewNPC(source, (int)npcCenter.X, (int)npcCenter.Y, bossType);
                Main.npc[npcID].Center = npcCenter;
                Main.npc[npcID].netUpdate2 = true;
            }
        }*/
    }
}
