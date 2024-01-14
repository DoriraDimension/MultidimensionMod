using MultidimensionMod.Items.Accessories;
using MultidimensionMod.Items.Materials;
using MultidimensionMod.Items.Potions;
using MultidimensionMod.Items.Bags;
using MultidimensionMod.Items.Weapons.Magic.Others;
using MultidimensionMod.Items.Weapons.Ranged.Guns;
using MultidimensionMod.Items.Weapons.Ranged.Others;
using MultidimensionMod.Items.Weapons.Magic.Tomes;
using MultidimensionMod.Items.Placeables;
using MultidimensionMod.Items.Weapons.Typeless;
using MultidimensionMod.Items.Weapons.Summon;
using MultidimensionMod.Items.Weapons.Ranged.RocketLaunchers;
using MultidimensionMod.Items.Souls;
using MultidimensionMod.Items.Vanity;
using MultidimensionMod.Items.Weapons.Melee.Swords;
using MultidimensionMod.Items.Weapons.Magic.Staffs;
using MultidimensionMod.Common.ItemDropRules.DropConditions;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.ItemDropRules;
using Terraria.ModLoader;
using Terraria.GameContent;

namespace MultidimensionMod.Common.Globals.NPCs
{
    class Drops : GlobalNPC
    {
        public override void ModifyNPCLoot(NPC NPC, NPCLoot npcLoot)
        {
            if (!(NPC.type == NPCID.BurningSphere) || !(NPC.type == NPCID.ChaosBall) || !(NPC.type == NPCID.WaterSphere) || !(NPC.type == NPCID.DetonatingBubble) || !(NPC.type == NPCID.ForceBubble) || !(NPC.type == NPCID.DeadlySphere) || !(NPC.type == NPCID.SolarFlare) || !(NPC.type == NPCID.SolarGoop) || !(NPC.type == NPCID.AncientLight) || !(NPC.type == NPCID.AncientDoom) || !(NPC.type == NPCID.WindyBalloon) || !(NPC.type == NPCID.ChaosBallTim) || !(NPC.type == NPCID.VileSpit) || !(NPC.type == NPCID.VileSpitEaterOfWorlds))
            {
                npcLoot.Add(ItemDropRule.ByCondition(new DimensiumCondition(), ModContent.ItemType<Dimensium>(), 100));
            }

            if (NPC.type == NPCID.KingSlime)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<RoyalBelt>(), 3));
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<KingSlimeSoul>()));
            }

            if (NPC.type == NPCID.EyeofCthulhu)
            {
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
                leadingConditionRule.OnSuccess(ItemDropRule.Common(ModContent.ItemType<WormSoul>()));
                npcLoot.Add(leadingConditionRule);
            }

            if (NPC.type == NPCID.BrainofCthulhu)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<BrainSoul>()));
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<NeuralWaves>(), 5));
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Comprehension>(), 5));
            }

            if (NPC.type == NPCID.QueenBee)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<BeeSoul>()));
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<TerrorNest>(), 10));
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
                npcLoot.Add(ItemDropRule.Common(ItemID.PinkGel, 1, 10, 25));
            }

            if (NPC.type == NPCID.Retinazer || NPC.type == NPCID.Spazmatism)
            {
                LeadingConditionRule leadingConditionRule = new LeadingConditionRule(new Conditions.MissingTwin());
                leadingConditionRule.OnSuccess(ItemDropRule.Common(ModContent.ItemType<TwinSoul>()));
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
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<PlantSoul>()));
            }

            if (NPC.type == NPCID.Golem)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<GolemSoul>()));
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<IdolMask>(), 3));
            }

            if (NPC.type == NPCID.HallowBoss) //Empress
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Prismatine>(), 1, 10, 15));
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<EmpressSoul>()));
            }

            if (NPC.type == NPCID.DukeFishron)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<TidalQuartz>(), 1, 10, 15));
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<DukeSoul>()));
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<OldSeaCrown>(), 20));
            }

            if (NPC.type == NPCID.CultistBoss)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<CultistSoul>()));
            }

            if (NPC.type == NPCID.MoonLordCore)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<MoonSoul>()));
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Tentacle>(), 3));
            }

            if (NPC.type == NPCID.MartianSaucerCore)
            {
                npcLoot.Add(ItemDropRule.Common(ItemID.CompanionCube, 20));
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
                npcLoot.Add(ItemDropRule.OneFromOptions(1, ItemID.BluePresent, ItemID.YellowPresent, ItemID.GreenPresent));
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

            if (NPC.type == NPCID.BoneSerpentHead || NPC.type == NPCID.BigPantlessSkeleton || NPC.type == NPCID.SmallPantlessSkeleton || NPC.type == NPCID.PantlessSkeleton || NPC.type == NPCID.BigMisassembledSkeleton || NPC.type == NPCID.SmallMisassembledSkeleton || NPC.type == NPCID.MisassembledSkeleton || NPC.type == NPCID.BigSkeleton || NPC.type == NPCID.SmallSkeleton || NPC.type == NPCID.Skeleton || NPC.type == NPCID.Skeleton || NPC.type == NPCID.BigHeadacheSkeleton || NPC.type == NPCID.SmallHeadacheSkeleton || NPC.type == NPCID.HeadacheSkeleton)
            {
                npcLoot.Add(ItemDropRule.ByCondition(new DownedSkeletronCondition(), ItemID.Bone, 1, 3, 6));
            }

            if (NPC.type == NPCID.BigMimicHallow)
            {
                npcLoot.Add(ItemDropRule.Common(ItemID.LightShard, 1, 1, 3));
            }

            if ((NPC.type == NPCID.BigMimicCrimson) || (NPC.type == NPCID.BigMimicCorruption))
            {
                npcLoot.Add(ItemDropRule.Common(ItemID.DarkShard, 1, 1, 3));
            }

            if (NPC.downedMoonlord && (NPC.type == NPCID.Harpy) || (NPC.type == NPCID.WyvernHead))
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<MoonGeode>(), 8));
            }

            if (NPC.type == NPCID.SpikedJungleSlime)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<StinkyPaste>(), 12));
            }

            if (NPC.type == NPCID.UndeadViking || NPC.type == NPCID.ArmoredViking)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<VikingRelic>(), 1, 2, 3));
            }

            if (NPC.type == NPCID.DarkCaster)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Cursemark>(), 50));
            }

            if (NPC.type == NPCID.SeekerHead)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<StarvingLarva>(), 25));
            }

            if (NPC.type == NPCID.Corruptor)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<RotSpit>(), 25));
            }

            if (NPC.type == NPCID.Drippler)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Watchers>(), 40));
            }

            if (NPC.type == NPCID.FireImp)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<ImpBag>(), 100));
            }

            if (NPC.type == NPCID.BloodZombie)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<BloodyMary>(), 1));
            }

            if (NPC.type == NPCID.Crab)
            {
                LeadingConditionRule leadingConditionRule = new LeadingConditionRule(new Conditions.IsHardmode());
                leadingConditionRule.OnSuccess(ItemDropRule.Common(ModContent.ItemType<YtriumStaff>(), 20));
                npcLoot.Add(leadingConditionRule);
            }
        }
    }
}
