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
        public override void ModifyNPCLoot(NPC NPC, NPCLoot npcLoot)
        {
            if (!(NPC.type == NPCID.BurningSphere) || !(NPC.type == NPCID.ChaosBall) || !(NPC.type == NPCID.WaterSphere) || !(NPC.type == NPCID.DetonatingBubble) || !(NPC.type == NPCID.ForceBubble) || !(NPC.type == NPCID.DeadlySphere) || !(NPC.type == NPCID.SolarFlare) || !(NPC.type == NPCID.SolarGoop) || !(NPC.type == NPCID.AncientLight) || !(NPC.type == NPCID.AncientDoom) || !(NPC.type == NPCID.WindyBalloon) || !(NPC.type == NPCID.ChaosBallTim) || !(NPC.type == NPCID.VileSpit) || !(NPC.type == NPCID.VileSpitEaterOfWorlds))
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Dimensium>(), 100));
            }

            if (NPC.type == NPCID.KingSlime)
            {
                SlimeCondition slemsoul = new SlimeCondition();
                IItemDropRule conditionalRule = new LeadingConditionRule(slemsoul);
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<RoyalBelt>(), 3));
                conditionalRule.OnSuccess(npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<KingSlimeSoul>())));
                npcLoot.Add(conditionalRule);
            }

            if (NPC.type == NPCID.EyeofCthulhu)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Iris>(), 4));
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<EyeTendril>(), 1, 3, 5));
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<EyeSoul>()));

            }

            if ((NPC.type == NPCID.DemonEye) || (NPC.type == NPCID.DemonEye2) || (NPC.type == NPCID.PurpleEye) || (NPC.type == NPCID.PurpleEye2) || (NPC.type == NPCID.GreenEye) || (NPC.type == NPCID.GreenEye2) || (NPC.type == NPCID.DialatedEye) || (NPC.type == NPCID.DialatedEye2) || (NPC.type == NPCID.CataractEye) || (NPC.type == NPCID.CataractEye2) || (NPC.type == NPCID.SleepyEye) || (NPC.type == NPCID.SleepyEye2) || (NPC.type == NPCID.DemonEyeOwl) || (NPC.type == NPCID.DemonEyeSpaceship))
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<EyeoftheNightwalker>(), 30));
            }

            if (NPC.type == NPCID.ServantofCthulhu)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<EyeoftheNightwalker>(), 100));
            }

            if (System.Array.IndexOf(new int[] { NPCID.EaterofWorldsBody, NPCID.EaterofWorldsHead, NPCID.EaterofWorldsTail }, NPC.type) > -1)
            {
                LeadingConditionRule leadingConditionRule = new(new Conditions.LegacyHack_IsABoss());
                leadingConditionRule.OnSuccess(npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<WormSoul>())));
                npcLoot.Add(leadingConditionRule);
            }

            if (NPC.type == NPCID.BrainofCthulhu)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<BrainSoul>()));
            }

            if (NPC.type == NPCID.QueenBee)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<BeeSoul>()));
            }

            if (NPC.type == NPCID.SkeletronHead)
            {
                npcLoot.Add(ItemDropRule.Common(ItemID.BoneKey, 10000));
                npcLoot.Add(ItemDropRule.Common(ItemID.Bone, 1, 25, 35));
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<SkeletonSoul>()));
            }

            if (NPC.type == NPCID.Deerclops)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<DeerSoul>()));
            }

            if (NPC.type == NPCID.WallofFlesh)
            {
                npcLoot.Add(ItemDropRule.Common(ItemID.FleshBlock, 1, 40, 50));
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<WallSoul>()));
            }

            if (NPC.type == NPCID.QueenSlimeBoss)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<QueenBelt>(), 3));
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<WomanSlimeSoul>()));
            }

            if (NPC.type == NPCID.Retinazer || NPC.type == NPCID.Spazmatism)
            {
                LeadingConditionRule leadingConditionRule = new LeadingConditionRule(new Conditions.MissingTwin());
                leadingConditionRule.OnSuccess(npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Retilazor>(), 4)));
                leadingConditionRule.OnSuccess(npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Spazmelter>(), 4)));
                leadingConditionRule.OnSuccess(npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<TwinSoul>())));
                npcLoot.Add(leadingConditionRule);
            }

            if (NPC.type == NPCID.TheDestroyer)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<MetalWormSoul>()));
            }

            if (NPC.type == NPCID.SkeletronPrime)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<PrimeSoul>(), 4));
            }

            if (NPC.type == NPCID.Plantera)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<BlackRoseScarf>(), 30));
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<PlantSoul>()));
            }

            if (NPC.type == NPCID.Golem)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<GolemSoul>()));
            }

            if (NPC.type == NPCID.DukeFishron)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<TidalQuartz>(), 1, 10, 15));
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<TyphoonDragon>(), 30));
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<DukeSoul>()));
            }

            if (NPC.type == NPCID.CultistBoss)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<CultistSoul>()));
            }

            if (NPC.type == NPCID.MoonLordCore)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<MoonSoul>()));
            }

            if (NPC.type == NPCID.MartianSaucerCore)
            {
                npcLoot.Add(ItemDropRule.Common(ItemID.CompanionCube, 100));
            }

            if (NPC.type == NPCID.Penguin)
            {
                npcLoot.Add(ItemDropRule.Common(ItemID.Fish, 20));
            }

            if (NPC.type == NPCID.FlyingFish)
            {
                npcLoot.Add(ItemDropRule.Common(ItemID.ZephyrFish, 30));
            }

            if (NPC.type == NPCID.ZombieEskimo)
            {
                npcLoot.Add(ItemDropRule.Common(ItemID.HandWarmer, 25));
            }

            if (NPC.type == NPCID.SkeletonArcher)
            {
                npcLoot.Add(ItemDropRule.Common(ItemID.EndlessQuiver, 50));
            }

            if (NPC.type == NPCID.Shark)
            {
                npcLoot.Add(ItemDropRule.Common(ItemID.SharkToothNecklace, 12));
            }

            if (NPC.type == NPCID.UmbrellaSlime)
            {
                npcLoot.Add(ItemDropRule.Common(ItemID.Umbrella, 30));
            }

            if (NPC.type == NPCID.WyvernHead)
            {
                npcLoot.Add(ItemDropRule.Common(ItemID.SkyFracture, 100));
            }

            if (NPC.type == NPCID.SantaNK1)
            {
                ItemDropRule.OneFromOptions(1, ItemID.BluePresent, ItemID.YellowPresent, ItemID.GreenPresent, 1);
            }

            if (NPC.type == NPCID.Pumpking)
            {
                npcLoot.Add(ItemDropRule.Common(ItemID.GoodieBag));
            }

            if (NPC.type == NPCID.GreenSlime)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Rambam>(), 100000));
            }

            if (NPC.type == NPCID.CursedSkull)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<AncientDragonSkull>(), 20));
            }

            if ((NPC.type == NPCID.CaveBat) || (NPC.type == NPCID.GiantBat))
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<EyeoftheExplorer>(), 30));
            }

            if ((NPC.type == NPCID.EaterofSouls) || (NPC.type == NPCID.LittleEater) || (NPC.type == NPCID.BigEater) || (NPC.type == NPCID.Crimera) || (NPC.type == NPCID.LittleCrimera) || (NPC.type == NPCID.BigCrimera))
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<EyeoftheHunter>(), 20));
            }

            if (NPC.type == NPCID.GoblinThief)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<EyeofDesire>(), 20));
            }

            if ((NPC.type == NPCID.WallCreeper) || (NPC.type == NPCID.WallCreeperWall))
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<SpooderLexicon>(), 50));
            }

            if ((NPC.type == NPCID.BlackRecluse) || (NPC.type == NPCID.BlackRecluseWall))
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<SpiderCurse>(), 20));
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<SpooderLexicon>(), 50));
            }

            if (NPC.type == NPCID.Demon)
            {
                npcLoot.Add(ItemDropRule.Common(ItemID.CrystalShard, 10000));
            }

            if (NPC.type == NPCID.Vulture)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<KFC>(), 20));
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<DesertEagle>(), 20));
            }

            if ((NPC.type == NPCID.BoneSerpentHead && NPC.downedBoss3) || (NPC.type == NPCID.BigPantlessSkeleton && NPC.downedBoss3) || (NPC.type == NPCID.SmallPantlessSkeleton && NPC.downedBoss3) || (NPC.type == NPCID.PantlessSkeleton && NPC.downedBoss3) || (NPC.type == NPCID.BigMisassembledSkeleton && NPC.downedBoss3) || (NPC.type == NPCID.SmallMisassembledSkeleton && NPC.downedBoss3) || (NPC.type == NPCID.MisassembledSkeleton && NPC.downedBoss3) || (NPC.type == NPCID.BigSkeleton && NPC.downedBoss3) || (NPC.type == NPCID.SmallSkeleton && NPC.downedBoss3) || (NPC.type == NPCID.Skeleton && NPC.downedBoss3) || (NPC.type == NPCID.Skeleton && NPC.downedBoss3) || (NPC.type == NPCID.BigHeadacheSkeleton && NPC.downedBoss3) || (NPC.type == NPCID.SmallHeadacheSkeleton && NPC.downedBoss3) || (NPC.type == NPCID.HeadacheSkeleton && NPC.downedBoss3))
            {
                npcLoot.Add(ItemDropRule.Common(ItemID.Bone, 1, 3, 6));
            }

            if ((NPC.type == NPCID.TinyMossHornet) || (NPC.type == NPCID.LittleMossHornet) || (NPC.type == NPCID.BigMossHornet) || (NPC.type == NPCID.GiantMossHornet) || (NPC.type == NPCID.MossHornet))
            {
                npcLoot.Add(ItemDropRule.Common(ItemID.Stinger, 2));
            }

            if (NPC.type == NPCID.Reaper && NPC.downedMechBoss3)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<EclipseReaper>(), 30));
            }

            if (NPC.type == NPCID.BigMimicHallow)
            {
                npcLoot.Add(ItemDropRule.Common(ItemID.LightShard, 1, 1, 3));
            }

            if ((NPC.type == NPCID.BigMimicCrimson) || (NPC.type == NPCID.BigMimicCorruption))
            {
                npcLoot.Add(ItemDropRule.Common(ItemID.DarkShard, 1, 1, 3));
            }

            if (Main.hardMode && (NPC.type == NPCID.BlackSlime) || (NPC.type == NPCID.MotherSlime) || (NPC.type == NPCID.BabySlime) || (NPC.type == NPCID.GiantWormHead) || (NPC.type == NPCID.CaveBat) || (NPC.type == NPCID.BlueJellyfish) || (NPC.type == NPCID.Crawdad) || (NPC.type == NPCID.GiantShelly) || (NPC.type == NPCID.UndeadMiner) || (NPC.type == NPCID.Tim))
            { 
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Geode>(), 20));
            }

            if ((NPC.type == NPCID.IceBat) || (NPC.type == NPCID.SnowFlinx) || (NPC.type == NPCID.SpikedIceSlime) || (NPC.type == NPCID.UndeadViking) || (NPC.type == NPCID.ArmoredViking) || (NPC.type == NPCID.IceTortoise) || (NPC.type == NPCID.IceElemental) || (NPC.type == NPCID.IcyMerman) || (NPC.type == NPCID.IceMimic) || (NPC.type == NPCID.PigronCorruption) || (NPC.type == NPCID.PigronCrimson) || (NPC.type == NPCID.PigronHallow))
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<FrozenGeode>(), 20));
            }

            if ((NPC.type == NPCID.Hellbat) || (NPC.type == NPCID.Demon) || (NPC.type == NPCID.RedDevil) || (NPC.type == NPCID.LavaSlime) || (NPC.type == NPCID.FireImp) || (NPC.type == NPCID.VoodooDemon) || (NPC.type == NPCID.BoneSerpentHead) || (NPC.type == NPCID.Lavabat))
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<MagmaGeode>(), 20));
            }

            if (Main.hardMode && (NPC.type == NPCID.BlackSlime) || (NPC.type == NPCID.MotherSlime) || (NPC.type == NPCID.BabySlime) || (NPC.type == NPCID.GiantWormHead) || (NPC.type == NPCID.CaveBat) || (NPC.type == NPCID.BlueJellyfish) || (NPC.type == NPCID.Crawdad) || (NPC.type == NPCID.GiantShelly) || (NPC.type == NPCID.UndeadMiner) || (NPC.type == NPCID.Tim) || (NPC.type == NPCID.ArmoredSkeleton) || (NPC.type == NPCID.HeavySkeleton) || (NPC.type == NPCID.DiggerHead) || (NPC.type == NPCID.GiantBat) || (NPC.type == NPCID.GreenJellyfish) || (NPC.type == NPCID.RockGolem) || (NPC.type == NPCID.SkeletonArcher) || (NPC.type == NPCID.RuneWizard))
            {
                if (Main.hardMode)
                {
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<OmniGeode>(), 20));
                }
            }

            if ((NPC.type == NPCID.Antlion) || (NPC.type == NPCID.WalkingAntlion) || (NPC.type == NPCID.LarvaeAntlion) || (NPC.type == NPCID.FlyingAntlion) || (NPC.type == NPCID.GiantWalkingAntlion) || (NPC.type == NPCID.GiantFlyingAntlion) || (NPC.type == NPCID.TombCrawlerHead) || (NPC.type == NPCID.DuneSplicerHead) || (NPC.type == NPCID.DesertScorpionWalk) || (NPC.type == NPCID.DesertScorpionWall) || (NPC.type == NPCID.DesertLamiaLight) || (NPC.type == NPCID.DesertLamiaDark) || (NPC.type == NPCID.DesertBeast) || (NPC.type == NPCID.DesertGhoul) || (NPC.type == NPCID.DesertGhoulCorruption) || (NPC.type == NPCID.DesertGhoulCrimson) || (NPC.type == NPCID.DesertGhoulHallow))
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<SandstoneGeode>(), 25));
            }

            if ((NPC.type == NPCID.IlluminantSlime) || (NPC.type == NPCID.IlluminantBat) || (NPC.type == NPCID.ChaosElemental) || (NPC.type == NPCID.EnchantedSword) || (NPC.type == NPCID.BigMimicHallow) || (NPC.type == NPCID.PigronHallow) || (NPC.type == NPCID.DesertGhoulHallow))
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<FairyGeode>(), 25));
            }

            if ((NPC.type == NPCID.Clinger) || (NPC.type == NPCID.PigronCorruption) || (NPC.type == NPCID.CursedHammer) || (NPC.type == NPCID.BigMimicCorruption) || (NPC.type == NPCID.DesertGhoulCorruption))
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<DecayGeode>(), 20));
            }

            if ((NPC.type == NPCID.CrimsonAxe) || (NPC.type == NPCID.BloodJelly) || (NPC.type == NPCID.IchorSticker) || (NPC.type == NPCID.FloatyGross) || (NPC.type == NPCID.PigronCrimson))
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<BloodGeode>(), 10));
            }

            if (NPC.downedMechBoss3 && (NPC.type == NPCID.Hornet) || (NPC.type == NPCID.HornetFatty) || (NPC.type == NPCID.BigHornetFatty) || (NPC.type == NPCID.LittleHornetFatty) || (NPC.type == NPCID.HornetHoney) || (NPC.type == NPCID.LittleHornetHoney) || (NPC.type == NPCID.BigHornetHoney) || (NPC.type == NPCID.HornetLeafy) || (NPC.type == NPCID.BigHornetLeafy) || (NPC.type == NPCID.LittleHornetLeafy) || (NPC.type == NPCID.HornetSpikey) || (NPC.type == NPCID.LittleHornetSpikey) || (NPC.type == NPCID.BigHornetSpikey) || (NPC.type == NPCID.HornetStingy) || (NPC.type == NPCID.LittleHornetStingy) || (NPC.type == NPCID.BigHornetStingy) || (NPC.type == NPCID.TinyMossHornet) || (NPC.type == NPCID.LittleMossHornet) || (NPC.type == NPCID.BigMossHornet) || (NPC.type == NPCID.GiantMossHornet) || (NPC.type == NPCID.MossHornet) || (NPC.type == NPCID.SpikedJungleSlime) || (NPC.type == NPCID.ManEater) || (NPC.type == NPCID.JungleCreeperWall) || (NPC.type == NPCID.JungleCreeper) || (NPC.type == NPCID.Moth) || (NPC.type == NPCID.AngryTrapper))
            {
                if (NPC.downedMechBoss3)
                {
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<MuddyGeode>(), 20));
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<PlantMurderStarterSet>(), 100));
                }
            }

            if (NPC.downedMoonlord && (NPC.type == NPCID.Harpy) || (NPC.type == NPCID.WyvernHead))
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<MoonGeode>(), 8));
            }

            if (NPC.downedGolemBoss && (NPC.type == NPCID.Shark) || (NPC.type == NPCID.Crab) || (NPC.type == NPCID.Squid) || (NPC.type == NPCID.SeaSnail) || (NPC.type == NPCID.Dolphin) || (NPC.type == NPCID.SeaTurtle))
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<TidalQuartz>(), 20));
            }

            if ((NPC.type == NPCID.Antlion) || (NPC.type == NPCID.WalkingAntlion) || (NPC.type == NPCID.LarvaeAntlion) || (NPC.type == NPCID.FlyingAntlion) || (NPC.type == NPCID.GiantWalkingAntlion) || (NPC.type == NPCID.GiantFlyingAntlion) || (NPC.type == NPCID.TombCrawlerHead) || (NPC.type == NPCID.DuneSplicerHead) || (NPC.type == NPCID.DesertScorpionWalk) || (NPC.type == NPCID.DesertScorpionWall) || (NPC.type == NPCID.DesertLamiaLight) || (NPC.type == NPCID.DesertLamiaDark) || (NPC.type == NPCID.DesertBeast) || (NPC.type == NPCID.DesertGhoul) || (NPC.type == NPCID.DesertGhoulCorruption) || (NPC.type == NPCID.DesertGhoulCrimson) || (NPC.type == NPCID.DesertGhoulHallow))
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<BrokenAncientDepictionItem>(), 100));
            }

            if ((NPC.type == NPCID.AnomuraFungus) || (NPC.type == NPCID.FungiBulb) || (NPC.type == NPCID.MushiLadybug) || (NPC.type == NPCID.SporeBat) || (NPC.type == NPCID.SporeSkeleton) || (NPC.type == NPCID.ZombieMushroom) || (NPC.type == NPCID.ZombieMushroomHat) || (NPC.type == NPCID.FungoFish) || (NPC.type == NPCID.GiantFungiBulb) || (NPC.type == NPCID.GlowingSnail) || (NPC.type == NPCID.TruffleWorm))
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Mushmatter>(), 100));
            }

            if (NPC.type == NPCID.SpikedJungleSlime)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<StinkyPaste>(), 12));
            }
        }
    }
}
