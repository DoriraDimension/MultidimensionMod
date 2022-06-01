using MultidimensionMod.Items.Accessories;
using MultidimensionMod.Items.Materials;
using MultidimensionMod.Items.Potions;
using MultidimensionMod.Items.Weapons.Melee.Swords;
using MultidimensionMod.Items.Weapons.Melee.Boomerangs;
using MultidimensionMod.Items.Weapons.Magic.Guns;
using MultidimensionMod.Items.Weapons.Ranged.Guns;
using MultidimensionMod.Items.Weapons.Ranged.Flamethrowers;
using MultidimensionMod.Items.Weapons.Magic.Tomes;
using MultidimensionMod.Items.Placeables;
using MultidimensionMod.Items.Bags;
using MultidimensionMod.Items.Souls;
using MultidimensionMod.Items.Summons;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.ItemDropRules;
using Terraria.ModLoader;

namespace MultidimensionMod
{
    class Drops : GlobalNPC
    {
        public override void ModifyNPCLoot(NPC npc, NPCLoot npcloot)
        {
            npcloot.Add(ItemDropRule.Common(ModContent.ItemType<Dimensium>(), 100));

            if (npc.type == NPCID.KingSlime)
            {
                npcloot.Add(ItemDropRule.Common(ModContent.ItemType<RoyalBelt>(), 3));
                npcloot.Add(ItemDropRule.Common(ModContent.ItemType<KingSlimeSoul>()));
            }

            if (npc.type == NPCID.EyeofCthulhu)
            {
                npcloot.Add(ItemDropRule.Common(ModContent.ItemType<Iris>(), 4));
                npcloot.Add(ItemDropRule.Common(ModContent.ItemType<EyeTendril>(), 1, 3, 5));
                npcloot.Add(ItemDropRule.Common(ModContent.ItemType<EyeSoul>()));
            }

            if ((npc.type == NPCID.DemonEye) || (npc.type == NPCID.DemonEye2) || (npc.type == NPCID.PurpleEye) || (npc.type == NPCID.PurpleEye2) || (npc.type == NPCID.GreenEye) || (npc.type == NPCID.GreenEye2) || (npc.type == NPCID.DialatedEye) || (npc.type == NPCID.DialatedEye2) || (npc.type == NPCID.CataractEye) || (npc.type == NPCID.CataractEye2) || (npc.type == NPCID.SleepyEye) || (npc.type == NPCID.SleepyEye2) || (npc.type == NPCID.DemonEyeOwl) || (npc.type == NPCID.DemonEyeSpaceship))
            {
                npcloot.Add(ItemDropRule.Common(ModContent.ItemType<EyeoftheNightwalker>(), 30));
            }

            if (npc.type == NPCID.ServantofCthulhu)
            {
                npcloot.Add(ItemDropRule.Common(ModContent.ItemType<EyeoftheNightwalker>(), 100));
            }

            if (System.Array.IndexOf(new int[] { NPCID.EaterofWorldsBody, NPCID.EaterofWorldsHead, NPCID.EaterofWorldsTail }, npc.type) > -1)
            {
                LeadingConditionRule leadingConditionRule = new(new Conditions.LegacyHack_IsABoss());
                leadingConditionRule.OnSuccess(npcloot.Add(ItemDropRule.Common(ModContent.ItemType<WormSoul>())));
                npcloot.Add(leadingConditionRule);
            }

            if (npc.type == NPCID.BrainofCthulhu)
            {
                npcloot.Add(ItemDropRule.Common(ModContent.ItemType<BrainSoul>()));
            }

            if (npc.type == NPCID.QueenBee)
            {
                npcloot.Add(ItemDropRule.Common(ModContent.ItemType<BeeSoul>()));
            }

            if (npc.type == NPCID.SkeletronHead)
            {
                npcloot.Add(ItemDropRule.Common(ItemID.BoneKey, 10000));
                npcloot.Add(ItemDropRule.Common(ItemID.Bone, 1, 25, 35));
                npcloot.Add(ItemDropRule.Common(ModContent.ItemType<SkeletonSoul>()));
            }

            if (npc.type == NPCID.WallofFlesh)
            {
                npcloot.Add(ItemDropRule.Common(ItemID.FleshBlock, 1, 40, 50));
                npcloot.Add(ItemDropRule.Common(ModContent.ItemType<WallSoul>()));
            }

            if (npc.type == NPCID.Retinazer || npc.type == NPCID.Spazmatism)
            {
                LeadingConditionRule leadingConditionRule = new LeadingConditionRule(new Conditions.MissingTwin());
                leadingConditionRule.OnSuccess(npcloot.Add(ItemDropRule.Common(ModContent.ItemType<Retilazor>(), 4)));
                leadingConditionRule.OnSuccess(npcloot.Add(ItemDropRule.Common(ModContent.ItemType<Spazmelter>(), 4)));
                leadingConditionRule.OnSuccess(npcloot.Add(ItemDropRule.Common(ModContent.ItemType<TwinSoul>())));
                npcloot.Add(leadingConditionRule);
            }

            if (npc.type == NPCID.TheDestroyer)
            {
                npcloot.Add(ItemDropRule.Common(ModContent.ItemType<MetalWormSoul>()));
            }

            if (npc.type == NPCID.SkeletronPrime)
            {
                npcloot.Add(ItemDropRule.Common(ModContent.ItemType<PrimeSoul>(), 4));
            }

            if (npc.type == NPCID.Plantera)
            {
                npcloot.Add(ItemDropRule.Common(ModContent.ItemType<BlackRoseScarf>(), 30));
                npcloot.Add(ItemDropRule.Common(ModContent.ItemType<PlantSoul>()));
            }

            if (npc.type == NPCID.Golem)
            {
                npcloot.Add(ItemDropRule.Common(ModContent.ItemType<GolemSoul>()));
            }

            if (npc.type == NPCID.DukeFishron)
            {
                npcloot.Add(ItemDropRule.Common(ModContent.ItemType<TidalQuartz>(), 1, 10, 15));
                npcloot.Add(ItemDropRule.Common(ModContent.ItemType<TyphoonDragon>(), 30));
                npcloot.Add(ItemDropRule.Common(ModContent.ItemType<DukeSoul>()));
            }

            if (npc.type == NPCID.CultistBoss)
            {
                npcloot.Add(ItemDropRule.Common(ModContent.ItemType<CultistSoul>()));
            }

            if (npc.type == NPCID.MoonLordCore)
            {
                npcloot.Add(ItemDropRule.Common(ModContent.ItemType<MoonSoul>()));
            }

            if (npc.type == NPCID.MartianSaucerCore)
            {
                npcloot.Add(ItemDropRule.Common(ItemID.CompanionCube, 100));
            }

            if (npc.type == NPCID.Penguin)
            {
                npcloot.Add(ItemDropRule.Common(ItemID.Fish, 20));
            }

            if (npc.type == NPCID.FlyingFish)
            {
                npcloot.Add(ItemDropRule.Common(ItemID.ZephyrFish, 30));
            }

            if (npc.type == NPCID.ZombieEskimo)
            {
                npcloot.Add(ItemDropRule.Common(ItemID.HandWarmer, 25));
            }

            if (npc.type == NPCID.SkeletonArcher)
            {
                npcloot.Add(ItemDropRule.Common(ItemID.EndlessQuiver, 50));
            }

            if (npc.type == NPCID.Shark)
            {
                npcloot.Add(ItemDropRule.Common(ItemID.SharkToothNecklace, 12));
            }

            if (npc.type == NPCID.UmbrellaSlime)
            {
                npcloot.Add(ItemDropRule.Common(ItemID.Umbrella, 30));
            }

            if (npc.type == NPCID.WyvernHead)
            {
                npcloot.Add(ItemDropRule.Common(ItemID.SkyFracture, 100));
            }

            if (npc.type == NPCID.SantaNK1)
            {
                ItemDropRule.OneFromOptions(1, ItemID.BluePresent, ItemID.YellowPresent, ItemID.GreenPresent);
            }

            if (npc.type == NPCID.Pumpking)
            {
                npcloot.Add(ItemDropRule.Common(ItemID.GoodieBag));
            }

            if (npc.type == NPCID.GreenSlime)
            {
                npcloot.Add(ItemDropRule.Common(ModContent.ItemType<Rambam>(), 100000));
            }

            if (npc.type == NPCID.CursedSkull)
            {
                npcloot.Add(ItemDropRule.Common(ModContent.ItemType<AncientDragonSkull>(), 20));
            }

            if ((npc.type == NPCID.CaveBat) || (npc.type == NPCID.GiantBat))
            {
                npcloot.Add(ItemDropRule.Common(ModContent.ItemType<EyeoftheExplorer>(), 30));
            }

            if ((npc.type == NPCID.EaterofSouls) || (npc.type == NPCID.LittleEater) || (npc.type == NPCID.BigEater) || (npc.type == NPCID.Crimera) || (npc.type == NPCID.LittleCrimera) || (npc.type == NPCID.BigCrimera))
            {
                npcloot.Add(ItemDropRule.Common(ModContent.ItemType<EyeoftheHunter>(), 20));
            }

            if (npc.type == NPCID.GoblinThief)
            {
                npcloot.Add(ItemDropRule.Common(ModContent.ItemType<EyeofDesire>(), 20));
            }

            if ((npc.type == NPCID.WallCreeper) || (npc.type == NPCID.WallCreeperWall))
            {
                npcloot.Add(ItemDropRule.Common(ModContent.ItemType<SpooderLexicon>(), 50));
            }

            if ((npc.type == NPCID.BlackRecluse) || (npc.type == NPCID.BlackRecluseWall))
            {
                npcloot.Add(ItemDropRule.Common(ModContent.ItemType<SpiderCurse>(), 20));
                npcloot.Add(ItemDropRule.Common(ModContent.ItemType<SpooderLexicon>(), 50));
            }

            if (npc.type == NPCID.Demon)
            {
                npcloot.Add(ItemDropRule.Common(ItemID.CrystalShard, 10000));
            }

            if (npc.type == NPCID.Vulture)
            {
                npcloot.Add(ItemDropRule.Common(ModContent.ItemType<KFC>(), 20));
                npcloot.Add(ItemDropRule.Common(ModContent.ItemType<DesertEagle>(), 20));
            }

            if ((npc.type == NPCID.BoneSerpentHead && NPC.downedBoss3) || (npc.type == NPCID.BigPantlessSkeleton && NPC.downedBoss3) || (npc.type == NPCID.SmallPantlessSkeleton && NPC.downedBoss3) || (npc.type == NPCID.PantlessSkeleton && NPC.downedBoss3) || (npc.type == NPCID.BigMisassembledSkeleton && NPC.downedBoss3) || (npc.type == NPCID.SmallMisassembledSkeleton && NPC.downedBoss3) || (npc.type == NPCID.MisassembledSkeleton && NPC.downedBoss3) || (npc.type == NPCID.BigSkeleton && NPC.downedBoss3) || (npc.type == NPCID.SmallSkeleton && NPC.downedBoss3) || (npc.type == NPCID.Skeleton && NPC.downedBoss3) || (npc.type == NPCID.Skeleton && NPC.downedBoss3) || (npc.type == NPCID.BigHeadacheSkeleton && NPC.downedBoss3) || (npc.type == NPCID.SmallHeadacheSkeleton && NPC.downedBoss3) || (npc.type == NPCID.HeadacheSkeleton && NPC.downedBoss3))
            {
                npcloot.Add(ItemDropRule.Common(ItemID.Bone, 1, 3, 6));
            }

            if ((npc.type == NPCID.TinyMossHornet) || (npc.type == NPCID.LittleMossHornet) || (npc.type == NPCID.BigMossHornet) || (npc.type == NPCID.GiantMossHornet) || (npc.type == NPCID.MossHornet))
            {
                npcloot.Add(ItemDropRule.Common(ItemID.Stinger, 2));
            }

            if (npc.type == NPCID.Reaper && NPC.downedMechBoss3)
            {
                npcloot.Add(ItemDropRule.Common(ModContent.ItemType<EclipseReaper>(), 30));
            }

            if (npc.type == NPCID.BigMimicHallow)
            {
                npcloot.Add(ItemDropRule.Common(ItemID.LightShard, 1, 1, 3));
            }

            if ((npc.type == NPCID.BigMimicCrimson) || (npc.type == NPCID.BigMimicCorruption))
            {
                npcloot.Add(ItemDropRule.Common(ItemID.DarkShard, 1, 1, 3));
            }

            if (Main.hardMode && (npc.type == NPCID.BlackSlime) || (npc.type == NPCID.MotherSlime) || (npc.type == NPCID.BabySlime) || (npc.type == NPCID.GiantWormHead) || (npc.type == NPCID.CaveBat) || (npc.type == NPCID.BlueJellyfish) || (npc.type == NPCID.Crawdad) || (npc.type == NPCID.GiantShelly) || (npc.type == NPCID.UndeadMiner) || (npc.type == NPCID.Tim))
            { 
                npcloot.Add(ItemDropRule.Common(ModContent.ItemType<Geode>(), 20));
            }

            if ((npc.type == NPCID.IceBat) || (npc.type == NPCID.SnowFlinx) || (npc.type == NPCID.SpikedIceSlime) || (npc.type == NPCID.UndeadViking) || (npc.type == NPCID.ArmoredViking) || (npc.type == NPCID.IceTortoise) || (npc.type == NPCID.IceElemental) || (npc.type == NPCID.IcyMerman) || (npc.type == NPCID.IceMimic) || (npc.type == NPCID.PigronCorruption) || (npc.type == NPCID.PigronCrimson) || (npc.type == NPCID.PigronHallow))
            {
                npcloot.Add(ItemDropRule.Common(ModContent.ItemType<FrozenGeode>(), 20));
            }

            if ((npc.type == NPCID.Hellbat) || (npc.type == NPCID.Demon) || (npc.type == NPCID.RedDevil) || (npc.type == NPCID.LavaSlime) || (npc.type == NPCID.FireImp) || (npc.type == NPCID.VoodooDemon) || (npc.type == NPCID.BoneSerpentHead) || (npc.type == NPCID.Lavabat))
            {
                npcloot.Add(ItemDropRule.Common(ModContent.ItemType<MagmaGeode>(), 20));
            }

            if ((npc.type == NPCID.BlackSlime) || (npc.type == NPCID.MotherSlime) || (npc.type == NPCID.BabySlime) || (npc.type == NPCID.GiantWormHead) || (npc.type == NPCID.CaveBat) || (npc.type == NPCID.BlueJellyfish) || (npc.type == NPCID.Crawdad) || (npc.type == NPCID.GiantShelly) || (npc.type == NPCID.UndeadMiner) || (npc.type == NPCID.Tim) || (npc.type == NPCID.ArmoredSkeleton) || (npc.type == NPCID.HeavySkeleton) || (npc.type == NPCID.DiggerHead) || (npc.type == NPCID.GiantBat) || (npc.type == NPCID.GreenJellyfish) || (npc.type == NPCID.RockGolem) || (npc.type == NPCID.SkeletonArcher) || (npc.type == NPCID.RuneWizard))
            {
                if (Main.hardMode)
                {
                    npcloot.Add(ItemDropRule.Common(ModContent.ItemType<OmniGeode>(), 20));
                }
            }

            if ((npc.type == NPCID.Antlion) || (npc.type == NPCID.WalkingAntlion) || (npc.type == NPCID.LarvaeAntlion) || (npc.type == NPCID.FlyingAntlion) || (npc.type == NPCID.GiantWalkingAntlion) || (npc.type == NPCID.GiantFlyingAntlion) || (npc.type == NPCID.TombCrawlerHead) || (npc.type == NPCID.DuneSplicerHead) || (npc.type == NPCID.DesertScorpionWalk) || (npc.type == NPCID.DesertScorpionWall) || (npc.type == NPCID.DesertLamiaLight) || (npc.type == NPCID.DesertLamiaDark) || (npc.type == NPCID.DesertBeast) || (npc.type == NPCID.DesertGhoul) || (npc.type == NPCID.DesertGhoulCorruption) || (npc.type == NPCID.DesertGhoulCrimson) || (npc.type == NPCID.DesertGhoulHallow))
            {
                npcloot.Add(ItemDropRule.Common(ModContent.ItemType<SandstoneGeode>(), 25));
            }

            if ((npc.type == NPCID.IlluminantSlime) || (npc.type == NPCID.IlluminantBat) || (npc.type == NPCID.ChaosElemental) || (npc.type == NPCID.EnchantedSword) || (npc.type == NPCID.BigMimicHallow) || (npc.type == NPCID.PigronHallow) || (npc.type == NPCID.DesertGhoulHallow))
            {
                npcloot.Add(ItemDropRule.Common(ModContent.ItemType<FairyGeode>(), 25));
            }

            if ((npc.type == NPCID.Clinger) || (npc.type == NPCID.PigronCorruption) || (npc.type == NPCID.CursedHammer) || (npc.type == NPCID.BigMimicCorruption) || (npc.type == NPCID.DesertGhoulCorruption))
            {
                npcloot.Add(ItemDropRule.Common(ModContent.ItemType<DecayGeode>(), 20));
            }

            if ((npc.type == NPCID.CrimsonAxe) || (npc.type == NPCID.BloodJelly) || (npc.type == NPCID.IchorSticker) || (npc.type == NPCID.FloatyGross) || (npc.type == NPCID.PigronCrimson))
            {
                npcloot.Add(ItemDropRule.Common(ModContent.ItemType<BloodGeode>(), 10));
            }

            if ((npc.type == NPCID.Hornet) || (npc.type == NPCID.HornetFatty) || (npc.type == NPCID.BigHornetFatty) || (npc.type == NPCID.LittleHornetFatty) || (npc.type == NPCID.HornetHoney) || (npc.type == NPCID.LittleHornetHoney) || (npc.type == NPCID.BigHornetHoney) || (npc.type == NPCID.HornetLeafy) || (npc.type == NPCID.BigHornetLeafy) || (npc.type == NPCID.LittleHornetLeafy) || (npc.type == NPCID.HornetSpikey) || (npc.type == NPCID.LittleHornetSpikey) || (npc.type == NPCID.BigHornetSpikey) || (npc.type == NPCID.HornetStingy) || (npc.type == NPCID.LittleHornetStingy) || (npc.type == NPCID.BigHornetStingy) || (npc.type == NPCID.TinyMossHornet) || (npc.type == NPCID.LittleMossHornet) || (npc.type == NPCID.BigMossHornet) || (npc.type == NPCID.GiantMossHornet) || (npc.type == NPCID.MossHornet) || (npc.type == NPCID.SpikedJungleSlime) || (npc.type == NPCID.ManEater) || (npc.type == NPCID.JungleCreeperWall) || (npc.type == NPCID.JungleCreeper) || (npc.type == NPCID.Moth) || (npc.type == NPCID.AngryTrapper))
            {
                if (NPC.downedMechBoss3)
                {
                    npcloot.Add(ItemDropRule.Common(ModContent.ItemType<MuddyGeode>(), 20));
                    npcloot.Add(ItemDropRule.Common(ModContent.ItemType<PlantMurderStarterSet>(), 100));
                }
            }

            if ((npc.type == NPCID.Harpy) || (npc.type == NPCID.WyvernHead))
            {
                npcloot.Add(ItemDropRule.Common(ModContent.ItemType<MoonGeode>(), 8));
            }

            if ((npc.type == NPCID.Shark) || (npc.type == NPCID.Crab) || (npc.type == NPCID.Squid) || (npc.type == NPCID.SeaSnail) || (npc.type == NPCID.Dolphin) || (npc.type == NPCID.SeaTurtle))
            {
                npcloot.Add(ItemDropRule.Common(ModContent.ItemType<TidalQuartz>(), 20));
            }

            if ((npc.type == NPCID.Antlion) || (npc.type == NPCID.WalkingAntlion) || (npc.type == NPCID.LarvaeAntlion) || (npc.type == NPCID.FlyingAntlion) || (npc.type == NPCID.GiantWalkingAntlion) || (npc.type == NPCID.GiantFlyingAntlion) || (npc.type == NPCID.TombCrawlerHead) || (npc.type == NPCID.DuneSplicerHead) || (npc.type == NPCID.DesertScorpionWalk) || (npc.type == NPCID.DesertScorpionWall) || (npc.type == NPCID.DesertLamiaLight) || (npc.type == NPCID.DesertLamiaDark) || (npc.type == NPCID.DesertBeast) || (npc.type == NPCID.DesertGhoul) || (npc.type == NPCID.DesertGhoulCorruption) || (npc.type == NPCID.DesertGhoulCrimson) || (npc.type == NPCID.DesertGhoulHallow))
            {
                npcloot.Add(ItemDropRule.Common(ModContent.ItemType<BrokenAncientDepictionItem>(), 100));
            }

            if ((npc.type == NPCID.AnomuraFungus) || (npc.type == NPCID.FungiBulb) || (npc.type == NPCID.MushiLadybug) || (npc.type == NPCID.SporeBat) || (npc.type == NPCID.SporeSkeleton) || (npc.type == NPCID.ZombieMushroom) || (npc.type == NPCID.ZombieMushroomHat) || (npc.type == NPCID.FungoFish) || (npc.type == NPCID.GiantFungiBulb) || (npc.type == NPCID.GlowingSnail) || (npc.type == NPCID.TruffleWorm))
            {
                npcloot.Add(ItemDropRule.Common(ModContent.ItemType<Mushmatter>(), 100));
            }

            if (npc.type == NPCID.SpikedJungleSlime)
            {
                npcloot.Add(ItemDropRule.Common(ModContent.ItemType<StinkyPaste>(), 12));
            }
        }
    }
}
