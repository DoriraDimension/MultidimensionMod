using MultidimensionMod.Items.Accessories;
using MultidimensionMod.Items.Materials;
using MultidimensionMod.Items.Weapons.Melee.Swords;
using MultidimensionMod.Items.Weapons.Magic.Guns;
using MultidimensionMod.Items.Weapons.Ranged;
using MultidimensionMod.Items.Souls;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod
{
    class Drops : GlobalNPC
    {
        public override void NPCLoot(NPC npc)
        {
            if (Main.rand.NextFloat() < .0200f)
                Item.NewItem(npc.getRect(), mod.ItemType("Dimensium"));

            if (npc.type == NPCID.KingSlime)
            {
                if (Main.rand.NextFloat() < .3300f)
                    Item.NewItem(npc.getRect(), mod.ItemType("RoyalBelt"));
                Item.NewItem(npc.getRect(), mod.ItemType("KingSlimeSoul"));
            }

            if (npc.type == NPCID.EyeofCthulhu)
            {
                if (Main.rand.NextFloat() < .2500f)
                    Item.NewItem(npc.getRect(), mod.ItemType("EyeoftheNightwalker"));
                if (Main.rand.NextFloat() < .2500f)
                    Item.NewItem(npc.getRect(), mod.ItemType("Iris"));
                Item.NewItem(npc.getRect(), mod.ItemType("EyeTendril"), Main.rand.Next(3, 6));
                Item.NewItem(npc.getRect(), mod.ItemType("EyeSoul"));
            }

            if (npc.type == NPCID.ServantofCthulhu)
            {
                if (Main.rand.NextFloat() < .0100f)
                    Item.NewItem(npc.getRect(), mod.ItemType("EyeoftheNightwalker"));
            }

            if (npc.type == NPCID.SkeletronHead)
            {
                if (Main.rand.NextFloat() < .0001f)
                    Item.NewItem(npc.getRect(), ItemID.BoneKey);
                Item.NewItem(npc.getRect(), ItemID.Bone, Main.rand.Next(25, 36));
            }

            if (npc.type == NPCID.WallofFlesh)
            {
                Item.NewItem(npc.getRect(), ItemID.FleshBlock, Main.rand.Next(40, 51));
            }

            if ((npc.type == NPCID.Retinazer && !NPC.AnyNPCs(NPCID.Spazmatism)) || (npc.type == NPCID.Spazmatism && !NPC.AnyNPCs(NPCID.Retinazer)))
            {
                if (Main.rand.NextFloat() < .2500f)
                    Item.NewItem(npc.getRect(), mod.ItemType("Retilazor"));
                if (Main.rand.NextFloat() < .2500f)
                    Item.NewItem(npc.getRect(), mod.ItemType("Spazmelter"));
            }

            if (npc.type == NPCID.Plantera)
            {
                if (Main.rand.NextFloat() < .0300f)
                    Item.NewItem(npc.getRect(), mod.ItemType("BlackRoseScarf"));
            }

            if (npc.type == NPCID.DukeFishron)
            {
                Item.NewItem(npc.getRect(), mod.ItemType("TidalQuartz"), Main.rand.Next(10, 16));
                if (Main.rand.NextFloat() < .0300f)
                    Item.NewItem(npc.getRect(), mod.ItemType("TyphoonDragon"));
            }

            if (npc.type == NPCID.MartianSaucerCore)
            {
                if (Main.rand.NextFloat() < .0100f)
                    Item.NewItem(npc.getRect(), ItemID.CompanionCube);
            }

            if (npc.type == NPCID.Penguin)
            {
                if (Main.rand.NextFloat() < .0500f)
                    Item.NewItem(npc.getRect(), ItemID.Fish);
            }

            if (npc.type == NPCID.FlyingFish)
            {
                if (Main.rand.NextFloat() < .0300f)
                    Item.NewItem(npc.getRect(), ItemID.ZephyrFish);
            }

            if (npc.type == NPCID.ZombieEskimo)
            {
                if (Main.rand.NextFloat() < .0400f)
                    Item.NewItem(npc.getRect(), ItemID.HandWarmer);
            }

            if (npc.type == NPCID.SkeletonArcher)
            {

                if (Main.rand.NextFloat() < .0200f)
                    Item.NewItem(npc.getRect(), ItemID.EndlessQuiver);
            }

            if (npc.type == NPCID.Shark)
            {

                if (Main.rand.NextFloat() < .0800f)
                    Item.NewItem(npc.getRect(), ItemID.SharkToothNecklace);
            }

            if (npc.type == NPCID.UmbrellaSlime)
            {

                if (Main.rand.NextFloat() < .0300f)
                    Item.NewItem(npc.getRect(), ItemID.Umbrella);
            }

            if (npc.type == NPCID.WyvernHead)
            {

                if (Main.rand.NextFloat() < .0100f)
                    Item.NewItem(npc.getRect(), ItemID.SkyFracture);
            }
            if (npc.type == NPCID.SantaNK1)
            {

                if (Main.rand.NextFloat() < .3300f)
                    Item.NewItem(npc.getRect(), ItemID.BluePresent);
                if (Main.rand.NextFloat() < .3300f)
                    Item.NewItem(npc.getRect(), ItemID.YellowPresent);
                if (Main.rand.NextFloat() < .3300f)
                    Item.NewItem(npc.getRect(), ItemID.GreenPresent);
            }

            if (npc.type == NPCID.Pumpking)
            {

                if (Main.rand.NextFloat() < .7500f)
                    Item.NewItem(npc.getRect(), ItemID.GoodieBag, 2);
            }

            if (npc.type == NPCID.GreenSlime)
            {

                if (Main.rand.NextFloat() < .0001f)
                    Item.NewItem(npc.getRect(), ItemID.LastPrism);
                if (Main.rand.NextFloat() < .0001f)
                    Item.NewItem(npc.getRect(), ItemID.SoulofFright, 7);
                if (Main.rand.NextFloat() < .00001f)
                    Item.NewItem(npc.getRect(), mod.ItemType("Rambam"));
            }

            if (npc.type == NPCID.CursedSkull)
            {
                if (Main.rand.NextFloat() < .0500f)
                    Item.NewItem(npc.getRect(), mod.ItemType("AncientDragonSkull"));
            }

            if (npc.type == NPCID.CaveBat)
            {
                if (Main.rand.NextFloat() < .0300f)
                    Item.NewItem(npc.getRect(), mod.ItemType("EyeoftheExplorer"));
            }

            if (npc.type == NPCID.GiantBat)
            {
                if (Main.rand.NextFloat() < .0300f)
                    Item.NewItem(npc.getRect(), mod.ItemType("EyeoftheExplorer"));
            }

            if (npc.type == NPCID.EaterofSouls)
            {
                if (Main.rand.NextFloat() < .0500f)
                    Item.NewItem(npc.getRect(), mod.ItemType("EyeoftheHunter"));
            }

            if (npc.type == NPCID.LittleEater)
            {
                if (Main.rand.NextFloat() < .0500f)
                    Item.NewItem(npc.getRect(), mod.ItemType("EyeoftheHunter"));
            }

            if (npc.type == NPCID.BigEater)
            {
                if (Main.rand.NextFloat() < .0500f)
                    Item.NewItem(npc.getRect(), mod.ItemType("EyeoftheHunter"));
            }

            if (npc.type == NPCID.Crimera)
            {
                if (Main.rand.NextFloat() < .0500f)
                    Item.NewItem(npc.getRect(), mod.ItemType("EyeoftheHunter"));
            }

            if (npc.type == NPCID.LittleCrimera)
            {
                if (Main.rand.NextFloat() < .0500f)
                    Item.NewItem(npc.getRect(), mod.ItemType("EyeoftheHunter"));
            }

            if (npc.type == NPCID.BigCrimera)
            {
                if (Main.rand.NextFloat() < .0500f)
                    Item.NewItem(npc.getRect(), mod.ItemType("EyeoftheHunter"));
            }

            if (npc.type == NPCID.GoblinThief)
            {
                if (Main.rand.NextFloat() < .0500f)
                    Item.NewItem(npc.getRect(), mod.ItemType("EyeofDesire"));
            }

            if (npc.type == NPCID.BlackRecluse)
            {
                if (Main.rand.NextFloat() < .0500f)
                    Item.NewItem(npc.getRect(), mod.ItemType("SpiderCurse"));
            }

            if (npc.type == NPCID.BlackRecluseWall)
            {
                if (Main.rand.NextFloat() < .0500f)
                    Item.NewItem(npc.getRect(), mod.ItemType("SpiderCurse"));
            }

            if (npc.type == NPCID.Demon)
            {
                if (Main.rand.NextFloat() < .0010f)
                    Item.NewItem(npc.getRect(), ItemID.CrystalShard);
            }

            if (npc.type == NPCID.Vulture)
            {
                if (Main.rand.NextFloat() < .1000f)
                    Item.NewItem(npc.getRect(), mod.ItemType("KFC"));
                if (Main.rand.NextFloat() < .0500f)
                    Item.NewItem(npc.getRect(), mod.ItemType("DesertEagle"));
            }

            if (npc.type == NPCID.BoneSerpentHead && NPC.downedBoss3)
            {
                Item.NewItem(npc.getRect(), ItemID.Bone, Main.rand.Next(3, 7));
            }

            if (npc.type == NPCID.BigPantlessSkeleton && NPC.downedBoss3)
            {
                Item.NewItem(npc.getRect(), ItemID.Bone, Main.rand.Next(1, 4));
            }

            if (npc.type == NPCID.SmallPantlessSkeleton && NPC.downedBoss3)
            {
                Item.NewItem(npc.getRect(), ItemID.Bone, Main.rand.Next(1, 4));
            }

            if (npc.type == NPCID.PantlessSkeleton && NPC.downedBoss3)
            {
                Item.NewItem(npc.getRect(), ItemID.Bone, Main.rand.Next(1, 4));
            }

            if (npc.type == NPCID.BigMisassembledSkeleton && NPC.downedBoss3)
            {
                Item.NewItem(npc.getRect(), ItemID.Bone, Main.rand.Next(1, 4));
            }

            if (npc.type == NPCID.SmallMisassembledSkeleton && NPC.downedBoss3)
            {
                Item.NewItem(npc.getRect(), ItemID.Bone, Main.rand.Next(1, 4));
            }

            if (npc.type == NPCID.MisassembledSkeleton && NPC.downedBoss3)
            {
                Item.NewItem(npc.getRect(), ItemID.Bone, Main.rand.Next(1, 4));
            }

            if (npc.type == NPCID.BigSkeleton && NPC.downedBoss3)
            {
                Item.NewItem(npc.getRect(), ItemID.Bone, Main.rand.Next(1, 4));
            }

            if (npc.type == NPCID.SmallSkeleton && NPC.downedBoss3)
            {
                Item.NewItem(npc.getRect(), ItemID.Bone, Main.rand.Next(1, 4));
            }

            if (npc.type == NPCID.Skeleton && NPC.downedBoss3)
            {
                Item.NewItem(npc.getRect(), ItemID.Bone, Main.rand.Next(1, 4));
            }

            if (npc.type == NPCID.Skeleton && NPC.downedBoss3)
            {
                Item.NewItem(npc.getRect(), ItemID.Bone, Main.rand.Next(1, 4));
            }

            if (npc.type == NPCID.BigHeadacheSkeleton && NPC.downedBoss3)
            {
                Item.NewItem(npc.getRect(), ItemID.Bone, Main.rand.Next(1, 4));
            }

            if (npc.type == NPCID.SmallHeadacheSkeleton && NPC.downedBoss3)
            {
                Item.NewItem(npc.getRect(), ItemID.Bone, Main.rand.Next(1, 4));
            }

            if (npc.type == NPCID.HeadacheSkeleton && NPC.downedBoss3)
            {
                Item.NewItem(npc.getRect(), ItemID.Bone, Main.rand.Next(1, 4));
            }

            if (npc.type == NPCID.TinyMossHornet)
            {
                if (Main.rand.NextFloat() < .6600f)
                    Item.NewItem(npc.getRect(), ItemID.Stinger);
            }

            if (npc.type == NPCID.LittleMossHornet)
            {
                if (Main.rand.NextFloat() < .6600f)
                    Item.NewItem(npc.getRect(), ItemID.Stinger);
            }

            if (npc.type == NPCID.BigMossHornet)
            {
                if (Main.rand.NextFloat() < .6600f)
                    Item.NewItem(npc.getRect(), ItemID.Stinger);
            }

            if (npc.type == NPCID.GiantMossHornet)
            {
                if (Main.rand.NextFloat() < .6600f)
                    Item.NewItem(npc.getRect(), ItemID.Stinger);
            }

            if (npc.type == NPCID.MossHornet)
            {
                if (Main.rand.NextFloat() < .6600f)
                    Item.NewItem(npc.getRect(), ItemID.Stinger);
            }

            if (npc.type == NPCID.Mothron && NPC.downedPlantBoss)
            {
                if (Main.rand.NextFloat() < .0500f)
                    Item.NewItem(npc.getRect(), mod.ItemType("EclipseReaper"));
            }

            if (npc.type == NPCID.PossessedArmor)
            {
                if (Main.rand.NextFloat() < .0500f)
                    Item.NewItem(npc.getRect(), mod.ItemType("Shinorian"));
            }

            if (!npc.boss && npc.lifeMax > 1 && npc.damage > 0 && !npc.friendly && npc.position.Y > Main.rockLayer * 16.0 && npc.value > 0f)
            {
                if (Main.player[Player.FindClosest(npc.position, npc.width, npc.height)].ZoneRockLayerHeight)
                {
                    if (Main.rand.NextFloat() < .0400f)
                        Item.NewItem(npc.getRect(), mod.ItemType("Geode"));
                }
            }

            if (!npc.boss && npc.lifeMax > 1 && npc.damage > 0 && !npc.friendly && npc.position.Y > Main.rockLayer * 16.0 && npc.value > 0f)
            {
                if (Main.player[Player.FindClosest(npc.position, npc.width, npc.height)].ZoneSnow)
                {
                    if (Main.rand.NextFloat() < .0400f)
                        Item.NewItem(npc.getRect(), mod.ItemType("FrozenGeode"));
                }
            }

            if (NPC.downedBoss2 && !npc.boss && npc.lifeMax > 1 && npc.damage > 0 && !npc.friendly && npc.position.Y > Main.rockLayer * 16.0 && npc.value > 0f)
            {
                if (Main.player[Player.FindClosest(npc.position, npc.width, npc.height)].ZoneUnderworldHeight)
                {
                    if (Main.rand.NextFloat() < .0400f)
                        Item.NewItem(npc.getRect(), mod.ItemType("MagmaGeode"));
                }
            }

            if (Main.hardMode && !npc.boss && npc.lifeMax > 1 && npc.damage > 0 && !npc.friendly && npc.position.Y > Main.rockLayer * 16.0 && npc.value > 0f)
            {
                if (Main.player[Player.FindClosest(npc.position, npc.width, npc.height)].ZoneRockLayerHeight)
                {
                    if (Main.rand.NextFloat() < .0400f)
                        Item.NewItem(npc.getRect(), mod.ItemType("OmniGeode"));
                }
            }

            if (!npc.boss && npc.lifeMax > 1 && npc.damage > 0 && !npc.friendly && npc.position.Y > Main.rockLayer * 16.0 && npc.value > 0f)
            {
                if (Main.player[Player.FindClosest(npc.position, npc.width, npc.height)].ZoneDesert)
                {
                    if (Main.rand.NextFloat() < .0400f)
                        Item.NewItem(npc.getRect(), mod.ItemType("SandstoneGeode"));
                }
            }

            if (Main.hardMode && !npc.boss && npc.lifeMax > 1 && npc.damage > 0 && !npc.friendly && npc.position.Y > Main.rockLayer * 16.0 && npc.value > 0f)
            {
                if (Main.player[Player.FindClosest(npc.position, npc.width, npc.height)].ZoneHoly)
                {
                    if (Main.rand.NextFloat() < .0400f)
                        Item.NewItem(npc.getRect(), mod.ItemType("FairyGeode"));
                }
            }

            if (!npc.boss && npc.lifeMax > 1 && npc.damage > 0 && !npc.friendly && npc.position.Y > Main.rockLayer * 16.0 && npc.value > 0f)
            {
                if (Main.player[Player.FindClosest(npc.position, npc.width, npc.height)].ZoneCorrupt)
                {
                    if (Main.rand.NextFloat() < .0400f)
                        Item.NewItem(npc.getRect(), mod.ItemType("DecayGeode"));
                }
            }

            if (!npc.boss && npc.lifeMax > 1 && npc.damage > 0 && !npc.friendly && npc.position.Y > Main.rockLayer * 16.0 && npc.value > 0f)
            {
                if (Main.player[Player.FindClosest(npc.position, npc.width, npc.height)].ZoneCrimson)
                {
                    if (Main.rand.NextFloat() < .0400f)
                        Item.NewItem(npc.getRect(), mod.ItemType("BloodGeode"));
                }
            }

            if (NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3 && !npc.boss && npc.lifeMax > 1 && npc.damage > 0 && !npc.friendly && npc.position.Y > Main.rockLayer * 16.0 && npc.value > 0f)
            {
                if (Main.player[Player.FindClosest(npc.position, npc.width, npc.height)].ZoneJungle)
                {
                    if (Main.rand.NextFloat() < .0400f)
                        Item.NewItem(npc.getRect(), mod.ItemType("MuddyGeode"));
                }

                if (Main.player[Player.FindClosest(npc.position, npc.width, npc.height)].ZoneJungle)
                {
                    if (Main.rand.NextFloat() < .0100f)
                        Item.NewItem(npc.getRect(), mod.ItemType("PlantMurderStarterSet"));
                }
            }

            if (NPC.downedMoonlord && !npc.boss && npc.lifeMax > 1 && npc.damage > 0 && !npc.friendly && npc.position.Y > Main.worldSurface * 0.35 && npc.value > 0f)
            {
                if (Main.player[Player.FindClosest(npc.position, npc.width, npc.height)].ZoneSkyHeight)
                {
                    if (Main.rand.NextFloat() < .0700f)
                        Item.NewItem(npc.getRect(), mod.ItemType("MoonGeode"));
                }
            }

            if (NPC.downedGolemBoss && !npc.boss && npc.lifeMax > 1 && npc.damage > 0 && !npc.friendly && npc.position.Y > Main.worldSurface * 0.35 && npc.value > 0f)
            {
                if (Main.player[Player.FindClosest(npc.position, npc.width, npc.height)].ZoneBeach)
                {
                    if (Main.rand.NextFloat() < .0400f)
                        Item.NewItem(npc.getRect(), mod.ItemType("TidalQuartz"));
                }
            }

            if (!npc.boss && npc.lifeMax > 1 && npc.damage > 0 && !npc.friendly && npc.position.Y > Main.rockLayer * 16.0 && npc.value > 0f)
            {
                if (Main.player[Player.FindClosest(npc.position, npc.width, npc.height)].ZoneDesert)
                {
                    if (Main.rand.NextFloat() < .0100f)
                        Item.NewItem(npc.getRect(), mod.ItemType("BrokenAncientDepictionItem"));
                }
            }

            if (NPC.downedBoss1 && !npc.boss && npc.lifeMax > 1 && npc.damage > 0 && !npc.friendly)
            {
                if (Main.player[Player.FindClosest(npc.position, npc.width, npc.height)].ZoneGlowshroom)
                {
                    if (Main.rand.NextFloat() < .5000f)
                        Item.NewItem(npc.getRect(), mod.ItemType("Mushmatter"));
                }
            }
        }
    }
}
