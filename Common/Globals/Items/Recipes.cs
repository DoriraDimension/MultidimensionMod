using MultidimensionMod.Items.Materials;
using MultidimensionMod.Items.Placeables.Biomes.ShroomForest;
using MultidimensionMod.Items.Placeables.Biomes.Mire;
using MultidimensionMod.Items.Placeables.Biomes.Inferno;
using MultidimensionMod.Items.Potions;
using MultidimensionMod.Items.Mushrooms;
using Terraria.ModLoader;
using Terraria;
using Terraria.Localization;
using Terraria.ID;

namespace MultidimensionMod.Common.Globals.Items
{
	internal class Recipes : ModSystem
	{
		public override void AddRecipes()
        {
			#region Accessories
			Recipe aglet = Recipe.Create(ItemID.Aglet); 
			aglet.AddRecipeGroup(RecipeGroupID.IronBar, 5);
            aglet.AddRecipeGroup(GoldPlatinum, 2);
            aglet.AddTile(TileID.Anvils);
			aglet.Register();

			Recipe anklet = Recipe.Create(ItemID.AnkletoftheWind);
			anklet.AddIngredient(ItemID.Vine, 2);
			anklet.AddIngredient(ItemID.JungleSpores, 10);
			anklet.AddIngredient(ItemID.Cloud, 12);
			anklet.AddIngredient(ItemID.BeeWax, 3);
			anklet.AddTile(TileID.LivingLoom);
			anklet.Register();

			Recipe blizzard = Recipe.Create(ItemID.BlizzardinaBottle);
			blizzard.AddIngredient(ItemID.Bottle);
			blizzard.AddIngredient(ItemID.SnowBlock, 10);
			blizzard.AddIngredient(ModContent.ItemType<FrostScale>(), 6);
			blizzard.AddIngredient(ItemID.FlinxFur, 3);
			blizzard.AddTile(TileID.Bottles);
			blizzard.Register();

			Recipe sandstorm = Recipe.Create(ItemID.SandstorminaBottle);
			sandstorm.AddIngredient(ItemID.Bottle);
			sandstorm.AddRecipeGroup(RecipeGroupID.Sand, 25);
			sandstorm.AddIngredient(ModContent.ItemType<ManaInfusedSandstone>(), 6);
			sandstorm.AddIngredient(ItemID.AntlionMandible, 3);
			sandstorm.AddTile(TileID.Bottles);
			sandstorm.Register();

			Recipe cloud = Recipe.Create(ItemID.CloudinaBottle);
			cloud.AddIngredient(ItemID.Bottle);
			cloud.AddIngredient(ItemID.Cloud, 25);
			cloud.AddIngredient(ItemID.Feather, 3);
			cloud.AddTile(TileID.Bottles);
			cloud.Register();

			Recipe climbClaw = Recipe.Create(ItemID.ClimbingClaws); 
			climbClaw.AddRecipeGroup(RecipeGroupID.IronBar, 10);
			climbClaw.AddIngredient(ItemID.Spike, 3);
			climbClaw.AddTile(TileID.Anvils);
			climbClaw.Register();

			Recipe spikes = Recipe.Create(ItemID.ShoeSpikes);
			spikes.AddRecipeGroup(RecipeGroupID.IronBar, 10);
			spikes.AddIngredient(ItemID.Spike, 5);
			spikes.AddTile(TileID.Anvils);
			spikes.Register();

			Recipe carpet = Recipe.Create(ItemID.FlyingCarpet); 
			carpet.AddIngredient(ItemID.Silk, 15);
			carpet.AddIngredient(ItemID.Cloud, 5);
			carpet.AddIngredient(ModContent.ItemType<ManaInfusedSandstone>(), 3);
			carpet.AddTile(TileID.Loom);
			carpet.Register();

			Recipe hermes = Recipe.Create(ItemID.HermesBoots); 
			hermes.AddIngredient(ItemID.Leather, 5);
            hermes.AddIngredient(ItemID.Silk, 10);
            hermes.AddIngredient(ItemID.SwiftnessPotion, 2);
			hermes.AddTile(TileID.TinkerersWorkbench);
			hermes.Register();

			Recipe skates = Recipe.Create(ItemID.IceSkates); 
			skates.AddIngredient(ItemID.Leather, 8);
			skates.AddIngredient(ModContent.ItemType<VikingRelic>(), 3);
			skates.AddTile(TileID.WorkBenches);
			skates.Register();

			Recipe waterwalk = Recipe.Create(ItemID.WaterWalkingBoots); 
			waterwalk.AddIngredient(ItemID.Leather, 5);
			waterwalk.AddIngredient(ItemID.WaterWalkingPotion, 6);
			waterwalk.AddIngredient(ItemID.Starfish, 5);
            waterwalk.AddIngredient(ModContent.ItemType<AbyssiumBar>(), 4);
            waterwalk.AddTile(TileID.TinkerersWorkbench);
			waterwalk.Register();

			Recipe lava = Recipe.Create(ItemID.LavaCharm);
			lava.AddIngredient(ItemID.LavaBucket, 2);
			lava.AddIngredient(ItemID.Fireblossom, 3);
			lava.AddIngredient(ItemID.Obsidian, 15);
			lava.AddIngredient(ItemID.Hellstone, 25);
			lava.AddTile(TileID.Hellforge);
			lava.Register();

			Recipe horseSneakers = Recipe.Create(ItemID.LuckyHorseshoe);
			horseSneakers.AddRecipeGroup(GoldPlatinum, 10);
			horseSneakers.AddIngredient(ItemID.SunplateBlock, 5);
			horseSneakers.AddTile(TileID.SkyMill);
			horseSneakers.Register();

			Recipe balloon = Recipe.Create(ItemID.ShinyRedBalloon);
			balloon.AddIngredient(ItemID.Gel, 25);
			balloon.AddIngredient(ItemID.Cloud, 10);
			balloon.AddIngredient(ItemID.WhiteString);
			balloon.AddTile(TileID.SkyMill);
			balloon.Register();

			Recipe starband = Recipe.Create(ItemID.BandofStarpower);
			starband.AddIngredient(ItemID.ManaCrystal);
			starband.AddRecipeGroup(EvilSample, 5);
			starband.AddTile(TileID.DemonAltar);
			starband.Register();

			Recipe panic = Recipe.Create(ItemID.PanicNecklace);
			panic.AddIngredient(ItemID.LifeCrystal);
			panic.AddRecipeGroup(EvilSample, 5);
			panic.AddTile(TileID.DemonAltar);
			panic.Register();

			Recipe potionStone = Recipe.Create(ItemID.PhilosophersStone);
			potionStone.AddIngredient(ItemID.LifeFruit);
			potionStone.AddIngredient(ModContent.ItemType<Mushmatter>(), 3);
			potionStone.AddIngredient(ItemID.GreaterHealingPotion, 5);
			potionStone.AddIngredient(ItemID.SoulofLight ,10);
			potionStone.AddTile(TileID.CrystalBall);
			potionStone.Register();

			Recipe longImmune = Recipe.Create(ItemID.CrossNecklace);
			longImmune.AddIngredient(ItemID.HallowedBar, 8);
			longImmune.AddIngredient(ItemID.Chain);
			longImmune.AddIngredient(ItemID.UnicornHorn);
			longImmune.AddIngredient(ItemID.SoulofLight, 3);
			longImmune.AddTile(TileID.CrystalBall);
			longImmune.Register();

			Recipe rose = Recipe.Create(ItemID.ObsidianRose);
			rose.AddIngredient(ItemID.JungleRose);
			rose.AddIngredient(ItemID.Obsidian, 20);
            rose.AddIngredient(ModContent.ItemType<Incinerite>(), 12);
            rose.AddTile(TileID.Hellforge);
			rose.Register();

			Recipe cloak = Recipe.Create(ItemID.StarCloak);
			cloak.AddIngredient(ItemID.FallenStar, 8);
			cloak.AddIngredient(ModContent.ItemType<DevilSilk>(), 8);
			cloak.AddIngredient(ItemID.SoulofLight, 3);
            cloak.AddIngredient(ItemID.SoulofMight, 2);
            cloak.AddTile(TileID.Loom);
			cloak.Register();

            Recipe dive = Recipe.Create(ItemID.DivingHelmet);
            dive.AddIngredient(ModContent.ItemType<AbyssiumBar>(), 14);
            dive.AddIngredient(ModContent.ItemType<AbyssalHellstoneBar>(), 20);
            dive.AddIngredient(ItemID.GillsPotion, 5);
            dive.AddTile(TileID.MythrilAnvil);
            dive.Register();
            #endregion

            #region Ankh Charm Mats
            Recipe bandage = Recipe.Create(ItemID.AdhesiveBandage);
			bandage.AddIngredient(ItemID.Silk,10);
			bandage.AddIngredient(ItemID.Gel, 5);
            bandage.AddIngredient(ItemID.ButterflyDust);
            bandage.AddTile(TileID.WorkBenches);
			bandage.Register();

			Recipe polish = Recipe.Create(ItemID.ArmorPolish);
			polish.AddIngredient(ItemID.Bone, 46);
			polish.AddIngredient(ItemID.BeeWax , 14);
			polish.AddIngredient(ItemID.Ectoplasm, 4);
			polish.AddTile(TileID.Bottles);
			polish.Register();

			Recipe bezoar = Recipe.Create(ItemID.Bezoar);
			bezoar.AddIngredient(ItemID.Stinger, 3);
			bezoar.AddIngredient(ItemID.Moonglow, 2);
			bezoar.AddIngredient(ItemID.BeeWax, 9);
			bezoar.AddTile(TileID.Bottles);
			bezoar.Register();

			Recipe blind = Recipe.Create(ItemID.Blindfold);
			blind.AddIngredient(ModContent.ItemType<DevilSilk>(), 6);
			blind.AddIngredient(ItemID.SoulofNight, 2);
			blind.AddTile(TileID.Loom);
			blind.Register();

			Recipe clock = Recipe.Create(ItemID.FastClock);
			clock.AddIngredient(ItemID.Glass, 5);
			clock.AddIngredient(ItemID.PearlstoneBlock, 25);
            clock.AddIngredient(ItemID.HallowedBar, 4);
            clock.AddIngredient(ItemID.PixieDust, 50);
			clock.AddTile(TileID.WorkBenches);
			clock.Register();

			Recipe scream = Recipe.Create(ItemID.Megaphone);
			scream.AddRecipeGroup(Adamantitanium, 7);
			scream.AddIngredient(ItemID.PixieDust, 35);
			scream.AddIngredient(ItemID.Wire, 14);
			scream.AddTile(TileID.MythrilAnvil);
			scream.Register();

			Recipe nazar = Recipe.Create(ItemID.Nazar);
			nazar.AddIngredient(ItemID.Lens, 2);
			nazar.AddIngredient(ItemID.SoulofNight, 10);
			nazar.AddIngredient(ModContent.ItemType<DarkMatterClump>(), 8);
            nazar.AddIngredient(ItemID.DarkShard, 2);
            nazar.AddTile(TileID.DemonAltar);
			nazar.Register();

			Recipe map = Recipe.Create(ItemID.TrifoldMap);
			map.AddIngredient(ItemID.Silk, 10);
			map.AddIngredient(ItemID.AncientCloth);
			map.AddIngredient(ModContent.ItemType<CerebroAlloy>(), 2);
			map.AddTile(TileID.WorkBenches);
			map.Register();

			Recipe vitamins = Recipe.Create(ItemID.Vitamins);
			vitamins.AddIngredient(ItemID.Hive, 5);
			vitamins.AddIngredient(ItemID.Gel, 10);
			vitamins.AddIngredient(ItemID.Waterleaf, 2);
			vitamins.AddIngredient(ItemID.HallowedSeeds, 4);
			vitamins.AddTile(TileID.Bottles);
			vitamins.Register();
            #endregion

			#region Cell Phone Mats
			Recipe radar = Recipe.Create(ItemID.Radar);
			radar.AddRecipeGroup(RecipeGroupID.IronBar, 10);
			radar.AddIngredient(ItemID.Wire, 5);
			radar.AddIngredient(ItemID.Glass, 5);
			radar.AddTile(TileID.Anvils);
			radar.Register();

			Recipe compass = Recipe.Create(ItemID.Compass);
			compass.AddIngredient(ModContent.ItemType<VikingRelic>(), 6);
			compass.AddRecipeGroup(CopperTin);
			compass.AddTile(TileID.TinkerersWorkbench);
			compass.Register();

			Recipe deep = Recipe.Create(ItemID.DepthMeter);
			deep.AddRecipeGroup(RecipeGroupID.IronBar, 8);
			deep.AddIngredient(ItemID.Obsidian, 20);
            deep.AddIngredient(ItemID.Diamond, 3);
            deep.AddTile(TileID.Anvils);
			deep.Register();

			Recipe anal = Recipe.Create(ItemID.LifeformAnalyzer); //The kids will shit themself from laughter when they find this
			anal.AddRecipeGroup(RecipeGroupID.IronBar, 12);
			anal.AddIngredient(ItemID.Gel, 30);
			anal.AddIngredient(ItemID.GardenGnome);
			anal.AddTile(TileID.Anvils);
			anal.Register();

			Recipe watch = Recipe.Create(ItemID.Stopwatch);
			watch.AddIngredient(ItemID.Timer1Second);
			watch.AddIngredient(ItemID.AntlionMandible, 3);
			watch.AddRecipeGroup(CopperTin, 8);
			watch.AddTile(TileID.TinkerersWorkbench);
			watch.Register();

			Recipe tally = Recipe.Create(ItemID.TallyCounter);
			tally.AddRecipeGroup(GoldPlatinum, 5);
			tally.AddIngredient(ItemID.Bone, 16);
			tally.AddTile(TileID.Anvils);
			tally.Register();

			Recipe detect = Recipe.Create(ItemID.MetalDetector);
			detect.AddIngredient(ItemID.HallowedBar, 8);
			detect.AddIngredient(ItemID.Wire, 15);
			detect.AddTile(TileID.MythrilAnvil);
			detect.Register();

			Recipe dps = Recipe.Create(ItemID.DPSMeter);
			dps.AddRecipeGroup(CopperTin, 6);
			dps.AddIngredient(ItemID.Wire, 8);
			dps.AddTile(TileID.Anvils);
			dps.Register();

			Recipe sex = Recipe.Create(ItemID.Sextant);
			sex.AddRecipeGroup(GoldPlatinum, 8);
			sex.AddIngredient(ItemID.Lens);
            sex.AddIngredient(ItemID.SharkFin, 2);
            sex.AddTile(TileID.Anvils);
			sex.Register();

			Recipe radio = Recipe.Create(ItemID.WeatherRadio);
			radio.AddRecipeGroup(RecipeGroupID.IronBar, 10);
			radio.AddIngredient(ItemID.Cloud, 5);
			radio.AddIngredient(ItemID.RainCloud, 10);
            radio.AddIngredient(ItemID.Wire, 10);
            radio.AddTile(TileID.Anvils);
			radio.Register();

			Recipe fish = Recipe.Create(ItemID.FishermansGuide);
			fish.AddIngredient(ItemID.Silk, 5);
			fish.AddIngredient(ItemID.Bass, 2);
			fish.AddIngredient(ItemID.Tuna, 2);
			fish.AddIngredient(ItemID.Trout, 2);
			fish.AddTile(TileID.WorkBenches);
			fish.Register();
			#endregion

			#region Weapons
			Recipe fury = Recipe.Create(ItemID.Starfury);
			fury.AddIngredient(ItemID.FallenStar, 10);
			fury.AddRecipeGroup(GoldPlatinum, 15);
            fury.AddRecipeGroup(EvilSample, 8);
            fury.AddTile(TileID.SkyMill);
			fury.Register();

			Recipe enchant = Recipe.Create(ItemID.EnchantedSword);
			enchant.AddIngredient(ItemID.GoldBroadsword);
			enchant.AddIngredient(ItemID.FallenStar, 5);
			enchant.AddRecipeGroup(EvilSample, 7);
			enchant.AddTile(TileID.Anvils);
			enchant.Register();

			Recipe enchant2 = Recipe.Create(ItemID.EnchantedSword);
			enchant2.AddIngredient(ItemID.PlatinumBroadsword);
			enchant2.AddIngredient(ItemID.FallenStar, 8);
			enchant2.AddRecipeGroup(EvilSample, 7);
			enchant2.AddTile(TileID.Anvils);
			enchant2.Register();

			Recipe woodmerang = Recipe.Create(ItemID.WoodenBoomerang); //Ich und mein Holz, Holzi Holzi Holz
			woodmerang.AddRecipeGroup(RecipeGroupID.Wood, 20);
			woodmerang.AddTile(TileID.WorkBenches);
			woodmerang.Register();

			Recipe icemerang = Recipe.Create(ItemID.IceBoomerang);
			icemerang.AddIngredient(ItemID.WoodenBoomerang);
			icemerang.AddRecipeGroup(Ice, 30);
			icemerang.AddIngredient(ModContent.ItemType<VikingRelic>(), 2);
			icemerang.AddIngredient(ModContent.ItemType<FrostScale>(), 4);
			icemerang.AddTile(TileID.Anvils);
			icemerang.Register();

			Recipe weeb = Recipe.Create(ItemID.Katana);
			weeb.AddRecipeGroup(RecipeGroupID.IronBar, 7);
			weeb.AddRecipeGroup(CopperTin, 7);
			weeb.AddCondition(Condition.NearLava);
			weeb.Register();

			Recipe muramura = Recipe.Create(ItemID.Muramasa);
			muramura.AddIngredient(ItemID.Katana);
			muramura.AddIngredient(ModContent.ItemType<DarkMatterClump>(), 12);
			muramura.AddTile(TileID.DemonAltar);
			muramura.Register();

			Recipe sparky = Recipe.Create(ItemID.WandofSparking);
			sparky.AddRecipeGroup(RecipeGroupID.Wood, 10);
			sparky.AddIngredient(ItemID.Torch, 12);
			sparky.AddTile(TileID.WorkBenches);
			sparky.Register();

			Recipe mushrang = Recipe.Create(ItemID.Shroomerang);
			mushrang.AddIngredient(ItemID.WoodenBoomerang);
			mushrang.AddIngredient(ModContent.ItemType<GlowingMushmatter>(), 5);
			mushrang.AddTile(TileID.WorkBenches);
            mushrang.Register();
			#endregion

			#region Tools
			Recipe mirror2 = Recipe.Create(ItemID.IceMirror);
			mirror2.AddIngredient(ModContent.ItemType<VikingRelic>(), 3);
			mirror2.AddIngredient(ItemID.FallenStar, 3);
			mirror2.AddIngredient(ItemID.Glass, 3);
			mirror2.AddIngredient(ItemID.RecallPotion, 5);
			mirror2.AddTile(TileID.Anvils);
			mirror2.Register();

			Recipe discord = Recipe.Create(ItemID.RodofDiscord);
			discord.AddIngredient(ItemID.UnicornHorn, 2);
			discord.AddIngredient(ItemID.PixieDust, 100);
			discord.AddIngredient(ItemID.ChaosFish, 3);
            discord.AddIngredient(ItemID.SoulofLight, 24);
            discord.AddIngredient(ModContent.ItemType<Prismatine>(), 10);
            discord.AddTile(TileID.MythrilAnvil);
			discord.Register();

			Recipe bucket = Recipe.Create(ItemID.BottomlessBucket);
			bucket.AddIngredient(ItemID.WaterBucket);
			bucket.AddIngredient(ModContent.ItemType<AbyssalHellstoneBar>(), 16);
			bucket.AddIngredient(ItemID.PinkPearl);
			bucket.AddTile(TileID.MythrilAnvil);
			bucket.Register();

            Recipe bucketH = Recipe.Create(ItemID.BottomlessHoneyBucket);
            bucketH.AddIngredient(ItemID.HoneyBucket);
            bucketH.AddRecipeGroup(Adamantitanium, 16);
            bucketH.AddIngredient(ItemID.PinkPearl);
            bucketH.AddTile(TileID.MythrilAnvil);
            bucketH.Register();

            Recipe bucketL = Recipe.Create(ItemID.BottomlessLavaBucket);
            bucketL.AddIngredient(ItemID.LavaBucket);
            bucketL.AddIngredient(ItemID.HellstoneBar, 16);
            bucketL.AddIngredient(ItemID.PinkPearl);
            bucketL.AddTile(TileID.MythrilAnvil);
            bucketL.Register();

            Recipe spongebob = Recipe.Create(ItemID.SuperAbsorbantSponge);
			spongebob.AddIngredient(ItemID.Silk, 12);
            spongebob.AddIngredient(ItemID.AncientCloth);
            spongebob.AddIngredient(ModContent.ItemType<AbyssalHellstoneBar>(), 16);
            spongebob.AddIngredient(ItemID.PinkPearl);
			spongebob.AddTile(TileID.WorkBenches);
			spongebob.Register();

            Recipe spongebobH = Recipe.Create(ItemID.HoneyAbsorbantSponge);
            spongebobH.AddIngredient(ItemID.Silk, 12);
            spongebobH.AddIngredient(ItemID.AncientCloth);
            spongebobH.AddRecipeGroup(Adamantitanium, 16);
            spongebobH.AddIngredient(ItemID.PinkPearl);
            spongebobH.AddTile(TileID.WorkBenches);
            spongebobH.Register();

            Recipe spongebobL = Recipe.Create(ItemID.LavaAbsorbantSponge);
            spongebobL.AddIngredient(ItemID.Silk, 12);
            spongebobL.AddIngredient(ItemID.AncientCloth);
            spongebobL.AddIngredient(ItemID.HellstoneBar, 16);
            spongebobL.AddIngredient(ItemID.PinkPearl);
            spongebobL.AddTile(TileID.WorkBenches);
            spongebobL.Register();

            Recipe conch = Recipe.Create(ItemID.MagicConch);
			conch.AddIngredient(ItemID.Seashell, 6);
			conch.AddIngredient(ItemID.WhitePearl);
			conch.Register();

			Recipe hellConch = Recipe.Create(ItemID.DemonConch);
			hellConch.AddIngredient(ItemID.Seashell, 6);
            hellConch.AddIngredient(ItemID.Bone, 14);
            hellConch.AddIngredient(ItemID.HellstoneBar, 10);
			hellConch.AddIngredient(ItemID.BlackPearl);
			hellConch.Register();

            Recipe hellLine = Recipe.Create(ItemID.HotlineFishingHook);
            hellLine.AddIngredient(ItemID.ReinforcedFishingPole);
            hellLine.AddIngredient(ItemID.HellstoneBar, 10);
            hellLine.AddIngredient(ModContent.ItemType<TidalQuartz>(), 4);
            hellLine.AddIngredient(ItemID.BlackPearl);
            hellLine.Register();
            #endregion

            #region Tiles
            Recipe milly = Recipe.Create(ItemID.SkyMill);
			milly.AddIngredient(ItemID.SunplateBlock, 30);
			milly.AddIngredient(ItemID.Cloud, 48);
			milly.AddTile(TileID.Anvils);
			milly.Register();

			Recipe sharp = Recipe.Create(ItemID.SharpeningStation);
			sharp.AddIngredient(ItemID.StoneBlock, 30);
			sharp.AddIngredient(620, 25); //Wood from the jungle where the lion sleep tomorrow night
			sharp.AddTile(TileID.HeavyWorkBench);
			sharp.Register();

			Recipe loom = Recipe.Create(ItemID.LivingLoom);
			loom.AddIngredient(ItemID.Vine, 5);
			loom.AddRecipeGroup(RecipeGroupID.Wood, 34);
			loom.AddTile(TileID.WorkBenches);
			loom.Register();
			#endregion

			#region Consumables
			Recipe worm = Recipe.Create(ItemID.TruffleWorm);
			worm.AddIngredient(ItemID.Worm);
			worm.AddIngredient(ItemID.GlowingMushroom, 20);
			worm.AddIngredient(ModContent.ItemType<GlowingMushmatter>(), 6);
			worm.AddTile(TileID.Autohammer);
			worm.Register();

			Recipe corrSolution = Recipe.Create(ItemID.PurpleSolution, 50);
			corrSolution.AddIngredient(ItemID.RedSolution, 50);
			corrSolution.AddIngredient(ItemID.SoulofNight);
			corrSolution.AddTile(TileID.AlchemyTable);
			corrSolution.Register();

			Recipe crimSolution = Recipe.Create(ItemID.RedSolution, 50);
			crimSolution.AddIngredient(ItemID.PurpleSolution, 50);
			crimSolution.AddIngredient(ItemID.SoulofNight);
			crimSolution.AddTile(TileID.AlchemyTable);
			crimSolution.Register();
			#endregion

			#region Materials
			Recipe leather = Recipe.Create(ItemID.Leather);
			leather.AddIngredient(ItemID.Vertebrae, 5);
			leather.AddTile(TileID.WorkBenches);
			leather.Register();
			#endregion

			#region Empress Drops
			Recipe nightglow = Recipe.Create(ItemID.FairyQueenMagicItem); //Nightglow
			nightglow.AddIngredient(ModContent.ItemType<Prismatine>(), 8);
			nightglow.AddIngredient(ItemID.FallenStar, 4);
			nightglow.AddTile(TileID.CrystalBall);
			nightglow.Register();

			Recipe starlight = Recipe.Create(4923);
			starlight.AddIngredient(ModContent.ItemType<Prismatine>(), 10);
			starlight.AddTile(TileID.CrystalBall);
			starlight.Register();

			Recipe eventide = Recipe.Create(ItemID.FairyQueenRangedItem);
			eventide.AddIngredient(ModContent.ItemType<Prismatine>(), 9);
			eventide.AddTile(TileID.CrystalBall);
			eventide.Register();

			Recipe kaleido = Recipe.Create(4914);
			kaleido.AddIngredient(ModContent.ItemType<Prismatine>(), 10);
			kaleido.AddTile(TileID.CrystalBall);
			kaleido.Register();

			Recipe prisma = Recipe.Create(ItemID.EmpressBlade);
			prisma.AddIngredient(ModContent.ItemType<Prismatine>(), 23);
			prisma.AddIngredient(ItemID.Smolstar); //Blade Staff
			prisma.AddIngredient(ItemID.CrystalShard, 35);
			prisma.AddIngredient(ItemID.FragmentStardust, 20);
			prisma.AddTile(TileID.CrystalBall);
			prisma.Register();
            #endregion

            #region Alchemical Mushroom potion recipes
            Recipe ammo = Recipe.Create(ItemID.AmmoReservationPotion, 3);
			ammo.AddIngredient(ItemID.BottledWater);
            ammo.AddIngredient(ModContent.ItemType<Gray>());
            ammo.AddIngredient(ItemID.Moonglow);
            ammo.AddTile(TileID.Bottles);
            ammo.Register();

            Recipe archery = Recipe.Create(ItemID.ArcheryPotion, 3);
            archery.AddIngredient(ItemID.BottledWater);
            archery.AddIngredient(ModContent.ItemType<Orange>());
            archery.AddIngredient(ItemID.Daybloom);
            archery.AddTile(TileID.Bottles);
            archery.Register();

            Recipe battle = Recipe.Create(ItemID.BattlePotion, 3);
            battle.AddIngredient(ItemID.BottledWater);
            battle.AddIngredient(ModContent.ItemType<Purple>());
            battle.AddIngredient(ItemID.Deathweed);
            battle.AddTile(TileID.Bottles);
            battle.Register();

            Recipe biome = Recipe.Create(ItemID.BiomeSightPotion, 3);
            biome.AddIngredient(ItemID.BottledWater);
            biome.AddIngredient(ModContent.ItemType<Pink>());
            biome.AddIngredient(ItemID.GrassSeeds, 15);
            biome.AddTile(TileID.Bottles);
            biome.Register();

            Recipe builder = Recipe.Create(ItemID.BuilderPotion, 3);
            builder.AddIngredient(ItemID.BottledWater);
            builder.AddIngredient(ModContent.ItemType<Brown>());
            builder.AddIngredient(ItemID.Blinkroot);
            builder.AddTile(TileID.Bottles);
            builder.Register();

            Recipe calming = Recipe.Create(ItemID.CalmingPotion, 3);
            calming.AddIngredient(ItemID.BottledWater);
            calming.AddIngredient(ModContent.ItemType<Blue>());
            calming.AddIngredient(ItemID.Daybloom);
            calming.AddTile(TileID.Bottles);
            calming.Register();

            Recipe crate = Recipe.Create(ItemID.CratePotion, 3);
            crate.AddIngredient(ItemID.BottledWater);
            crate.AddIngredient(ModContent.ItemType<Brown>());
            crate.AddIngredient(ItemID.Waterleaf);
            crate.AddTile(TileID.Bottles);
            crate.Register();

            Recipe danger = Recipe.Create(ItemID.TrapsightPotion, 3); //Dangersense
            danger.AddIngredient(ItemID.BottledWater);
            danger.AddIngredient(ModContent.ItemType<Orange>());
            danger.AddIngredient(ItemID.Shiverthorn);
            danger.AddTile(TileID.Bottles);
            danger.Register();

            Recipe endurance = Recipe.Create(ItemID.EndurancePotion, 3);
            endurance.AddIngredient(ItemID.BottledWater);
            endurance.AddIngredient(ModContent.ItemType<Gray>());
            endurance.AddIngredient(ItemID.Blinkroot);
            endurance.AddTile(TileID.Bottles);
            endurance.Register();

            Recipe featherfall = Recipe.Create(ItemID.FeatherfallPotion, 3);
            featherfall.AddIngredient(ItemID.BottledWater);
            featherfall.AddIngredient(ModContent.ItemType<Blue>());
            featherfall.AddIngredient(ItemID.Feather);
            featherfall.AddTile(TileID.Bottles);
            featherfall.Register();

            Recipe fishing = Recipe.Create(ItemID.FishingPotion, 3);
            fishing.AddIngredient(ItemID.BottledWater);
            fishing.AddIngredient(ModContent.ItemType<Green>());
            fishing.AddIngredient(ItemID.Waterleaf);
            fishing.AddTile(TileID.Bottles);
            fishing.Register();

            Recipe flipper = Recipe.Create(ItemID.FlipperPotion, 3);
            flipper.AddIngredient(ItemID.BottledWater);
            flipper.AddIngredient(ModContent.ItemType<Blue>());
            flipper.AddIngredient(ItemID.Waterleaf);
            flipper.AddTile(TileID.Bottles);
            flipper.Register();

            Recipe gills = Recipe.Create(ItemID.GillsPotion, 3);
            gills.AddIngredient(ItemID.BottledWater);
            gills.AddIngredient(ModContent.ItemType<Blue>());
            gills.AddIngredient(ItemID.Coral);
            gills.AddTile(TileID.Bottles);
            gills.Register();

            Recipe gravity = Recipe.Create(ItemID.GravitationPotion, 3);
            gravity.AddIngredient(ItemID.BottledWater);
            gravity.AddIngredient(ModContent.ItemType<Purple>());
            gravity.AddIngredient(ItemID.Feather);
            gravity.AddTile(TileID.Bottles);
            gravity.Register();

            Recipe bigLuck = Recipe.Create(ItemID.LuckPotionGreater, 3);
            bigLuck.AddIngredient(ItemID.BottledWater);
            bigLuck.AddIngredient(ModContent.ItemType<Pink>());
            bigLuck.AddIngredient(ItemID.LadyBug);
            bigLuck.AddTile(TileID.Bottles);
            bigLuck.Register();

            Recipe midLuck = Recipe.Create(ItemID.LuckPotion, 3);
            midLuck.AddIngredient(ItemID.BottledWater);
            midLuck.AddIngredient(ModContent.ItemType<Gray>());
            midLuck.AddIngredient(ItemID.LadyBug);
            midLuck.AddTile(TileID.Bottles);
            midLuck.Register();

            Recipe smallLuck = Recipe.Create(ItemID.LuckPotionLesser, 3);
            smallLuck.AddIngredient(ItemID.BottledWater);
            smallLuck.AddIngredient(ModContent.ItemType<Gray>());
            smallLuck.AddIngredient(ItemID.Waterleaf);
            smallLuck.AddTile(TileID.Bottles);
            smallLuck.Register();

            Recipe heart = Recipe.Create(ItemID.HeartreachPotion, 3);
            heart.AddIngredient(ItemID.BottledWater);
            heart.AddIngredient(ModContent.ItemType<Pink>());
            heart.AddIngredient(ItemID.Daybloom);
            heart.AddTile(TileID.Bottles);
            heart.Register();

            Recipe hunter = Recipe.Create(ItemID.HunterPotion, 3);
            hunter.AddIngredient(ItemID.BottledWater);
            hunter.AddIngredient(ModContent.ItemType<Orange>());
            hunter.AddIngredient(ItemID.Daybloom);
            hunter.AddTile(TileID.Bottles);
            hunter.Register();

            Recipe inferno = Recipe.Create(ItemID.InfernoPotion, 3);
            inferno.AddIngredient(ItemID.BottledWater);
            inferno.AddIngredient(ModContent.ItemType<Red>());
            inferno.AddIngredient(ItemID.Fireblossom);
            inferno.AddTile(TileID.Bottles);
            inferno.Register();

            Recipe gone = Recipe.Create(ItemID.InvisibilityPotion, 3);
            gone.AddIngredient(ItemID.BottledWater);
            gone.AddIngredient(ModContent.ItemType<Blue>());
            gone.AddIngredient(ItemID.Moonglow);
            gone.AddTile(TileID.Bottles);
            gone.Register();

            Recipe thereIsBugsUnderYourIronSkinTakeItOff = Recipe.Create(ItemID.IronskinPotion, 3);
            thereIsBugsUnderYourIronSkinTakeItOff.AddIngredient(ItemID.BottledWater);
            thereIsBugsUnderYourIronSkinTakeItOff.AddIngredient(ModContent.ItemType<Yellow>());
            thereIsBugsUnderYourIronSkinTakeItOff.AddIngredient(ItemID.IronOre, 3);
            thereIsBugsUnderYourIronSkinTakeItOff.AddTile(TileID.Bottles);
            thereIsBugsUnderYourIronSkinTakeItOff.Register();

            Recipe thereIsMoreBugsUnderYourIronSkinTakeItOff = Recipe.Create(ItemID.IronskinPotion, 3);
            thereIsMoreBugsUnderYourIronSkinTakeItOff.AddIngredient(ItemID.BottledWater);
            thereIsMoreBugsUnderYourIronSkinTakeItOff.AddIngredient(ModContent.ItemType<Yellow>());
            thereIsMoreBugsUnderYourIronSkinTakeItOff.AddIngredient(ItemID.LeadOre, 3);
            thereIsMoreBugsUnderYourIronSkinTakeItOff.AddTile(TileID.Bottles);
            thereIsMoreBugsUnderYourIronSkinTakeItOff.Register();

            Recipe life = Recipe.Create(ItemID.LifeforcePotion, 3);
            life.AddIngredient(ItemID.BottledWater);
            life.AddIngredient(ModContent.ItemType<Red>());
            life.AddIngredient(ItemID.Prismite);
            life.AddTile(TileID.Bottles);
            life.Register();

            Recipe Harry = Recipe.Create(ItemID.MagicPowerPotion, 3);
            Harry.AddIngredient(ItemID.BottledWater);
            Harry.AddIngredient(ModContent.ItemType<Purple>());
            Harry.AddIngredient(ItemID.FallenStar);
            Harry.AddTile(TileID.Bottles);
            Harry.Register();

            Recipe manaRegen = Recipe.Create(ItemID.ManaRegenerationPotion, 3);
            manaRegen.AddIngredient(ItemID.BottledWater);
            manaRegen.AddIngredient(ModContent.ItemType<Pink>());
            manaRegen.AddIngredient(ItemID.Moonglow);
            manaRegen.AddTile(TileID.Bottles);
            manaRegen.Register();

            Recipe aMINE = Recipe.Create(ItemID.MiningPotion, 3);
            aMINE.AddIngredient(ItemID.BottledWater);
            aMINE.AddIngredient(ModContent.ItemType<Gray>());
            aMINE.AddIngredient(ItemID.Blinkroot);
            aMINE.AddTile(TileID.Bottles);
            aMINE.Register();

            Recipe owl = Recipe.Create(ItemID.NightOwlPotion, 3);
            owl.AddIngredient(ItemID.BottledWater);
            owl.AddIngredient(ModContent.ItemType<Green>());
            owl.AddIngredient(ItemID.Daybloom);
            owl.AddTile(TileID.Bottles);
            owl.Register();

            Recipe thereIsBugsUnderYourObsidianSkinTakeItOff = Recipe.Create(ItemID.ObsidianSkinPotion, 3);
            thereIsBugsUnderYourObsidianSkinTakeItOff.AddIngredient(ItemID.BottledWater);
            thereIsBugsUnderYourObsidianSkinTakeItOff.AddIngredient(ModContent.ItemType<Purple>());
			thereIsBugsUnderYourObsidianSkinTakeItOff.AddIngredient(ItemID.Obsidian, 2);
            thereIsBugsUnderYourObsidianSkinTakeItOff.AddTile(TileID.Bottles);
            thereIsBugsUnderYourObsidianSkinTakeItOff.Register();

            Recipe rage = Recipe.Create(ItemID.RagePotion, 3);
            rage.AddIngredient(ItemID.BottledWater);
            rage.AddIngredient(ModContent.ItemType<Red>());
            rage.AddIngredient(ItemID.Deathweed);
            rage.AddTile(TileID.Bottles);
            rage.Register();

            Recipe regen = Recipe.Create(ItemID.RegenerationPotion, 3);
            regen.AddIngredient(ItemID.BottledWater);
            regen.AddIngredient(ModContent.ItemType<Pink>());
            regen.AddIngredient(ItemID.Mushroom, 3);
            regen.AddTile(TileID.Bottles);
            regen.Register();

            Recipe shine = Recipe.Create(ItemID.ShinePotion, 3);
            shine.AddIngredient(ItemID.BottledWater);
            shine.AddIngredient(ModContent.ItemType<Yellow>());
            shine.AddIngredient(ItemID.GlowingMushroom);
            shine.AddTile(TileID.Bottles);
            shine.Register();

            Recipe sonar = Recipe.Create(ItemID.SonarPotion, 3);
            sonar.AddIngredient(ItemID.BottledWater);
            sonar.AddIngredient(ModContent.ItemType<Green>());
            sonar.AddIngredient(ItemID.Coral);
            sonar.AddTile(TileID.Bottles);
            sonar.Register();

            Recipe spelunker = Recipe.Create(ItemID.SpelunkerPotion, 3);
            spelunker.AddIngredient(ItemID.BottledWater);
            spelunker.AddIngredient(ModContent.ItemType<Yellow>());
            spelunker.AddIngredient(ItemID.GoldOre, 3);
            spelunker.AddTile(TileID.Bottles);
            spelunker.Register();

            Recipe spelunker2 = Recipe.Create(ItemID.SpelunkerPotion, 3);
            spelunker2.AddIngredient(ItemID.BottledWater);
            spelunker2.AddIngredient(ModContent.ItemType<Yellow>());
            spelunker2.AddIngredient(ItemID.PlatinumOre, 3);
            spelunker2.AddTile(TileID.Bottles);
            spelunker2.Register();

            Recipe ew = Recipe.Create(ItemID.StinkPotion, 3);
            ew.AddIngredient(ItemID.BottledWater);
            ew.AddIngredient(ModContent.ItemType<Green>());
            ew.AddIngredient(ItemID.Stinkfish);
            ew.AddTile(TileID.Bottles);
            ew.Register();

            Recipe summon = Recipe.Create(ItemID.SummoningPotion, 3);
            summon.AddIngredient(ItemID.BottledWater);
            summon.AddIngredient(ModContent.ItemType<Green>());
            summon.AddIngredient(ItemID.Moonglow);
            summon.AddTile(TileID.Bottles);
            summon.Register();

            Recipe flash = Recipe.Create(ItemID.SwiftnessPotion, 3);
            flash.AddIngredient(ItemID.BottledWater);
            flash.AddIngredient(ModContent.ItemType<Green>());
            flash.AddIngredient(ItemID.Blinkroot);
            flash.AddTile(TileID.Bottles);
            flash.Register();

            Recipe stingy = Recipe.Create(ItemID.ThornsPotion, 3);
            stingy.AddIngredient(ItemID.BottledWater);
            stingy.AddIngredient(ModContent.ItemType<Green>());
            stingy.AddIngredient(ItemID.Cactus, 3);
            stingy.AddTile(TileID.Bottles);
            stingy.Register();

            Recipe titan = Recipe.Create(ItemID.TitanPotion, 3);
            titan.AddIngredient(ItemID.BottledWater);
            titan.AddIngredient(ModContent.ItemType<Green>());
            titan.AddIngredient(ItemID.Bone, 3);
            titan.AddTile(TileID.Bottles);
            titan.Register();

            Recipe warm = Recipe.Create(ItemID.WarmthPotion, 3);
            warm.AddIngredient(ItemID.BottledWater);
            warm.AddIngredient(ModContent.ItemType<Orange>());
            warm.AddIngredient(ItemID.FrostMinnow);
            warm.AddTile(TileID.Bottles);
            warm.Register();

            Recipe jesus = Recipe.Create(ItemID.WaterWalkingPotion, 3);
            jesus.AddIngredient(ItemID.BottledWater);
            jesus.AddIngredient(ModContent.ItemType<Blue>());
            jesus.AddIngredient(ItemID.Waterleaf);
            jesus.AddTile(TileID.Bottles);
            jesus.Register();

            Recipe wrath = Recipe.Create(ItemID.WrathPotion, 3);
            wrath.AddIngredient(ItemID.BottledWater);
            wrath.AddIngredient(ModContent.ItemType<Red>());
            wrath.AddIngredient(ItemID.Deathweed);
            wrath.AddTile(TileID.Bottles);
            wrath.Register();

            Recipe ImComingHome = Recipe.Create(ItemID.RecallPotion, 6);
            ImComingHome.AddIngredient(ItemID.BottledWater);
            ImComingHome.AddIngredient(ModContent.ItemType<Blue>());
            ImComingHome.AddIngredient(ItemID.SpecularFish);
            ImComingHome.AddTile(TileID.Bottles);
            ImComingHome.Register();

            Recipe ImComingHomeAndLeaveAgain = Recipe.Create(ItemID.PotionOfReturn, 3);
            ImComingHomeAndLeaveAgain.AddIngredient(ItemID.BottledWater);
            ImComingHomeAndLeaveAgain.AddIngredient(ModContent.ItemType<Purple>());
            ImComingHomeAndLeaveAgain.AddIngredient(ItemID.Obsidifish);
            ImComingHomeAndLeaveAgain.AddTile(TileID.Bottles);
            ImComingHomeAndLeaveAgain.Register();

            Recipe teleport = Recipe.Create(ItemID.TeleportationPotion, 3);
            teleport.AddIngredient(ItemID.BottledWater);
            teleport.AddIngredient(ModContent.ItemType<Purple>());
            teleport.AddIngredient(ItemID.ChaosFish);
            teleport.AddTile(TileID.Bottles);
            teleport.Register();

            Recipe wormBossHole = Recipe.Create(ItemID.WormholePotion, 6);
            wormBossHole.AddIngredient(ItemID.BottledWater);
            wormBossHole.AddIngredient(ModContent.ItemType<Blue>());
            wormBossHole.AddIngredient(ItemID.SpecularFish);
            wormBossHole.AddTile(TileID.Bottles);
            wormBossHole.Register();

            Recipe warrior = Recipe.Create(ModContent.ItemType<WarriorsThermos>(), 3);
            warrior.AddIngredient(ItemID.BottledWater);
            warrior.AddIngredient(ModContent.ItemType<Red>());
            warrior.AddIngredient(ItemID.Fireblossom);
            warrior.AddTile(TileID.Bottles);
            warrior.Register();
            #endregion

            #region Alchemical Rainbow Mushroom recipes
            Recipe ammoR = Recipe.Create(ItemID.AmmoReservationPotion, 3);
            ammoR.AddIngredient(ItemID.BottledWater);
            ammoR.AddIngredient(ModContent.ItemType<Rainbow>());
            ammoR.AddTile(TileID.Bottles);
            ammoR.Register();

            Recipe archeryR = Recipe.Create(ItemID.ArcheryPotion, 3);
            archeryR.AddIngredient(ItemID.BottledWater);
            archeryR.AddIngredient(ModContent.ItemType<Rainbow>());
            archeryR.AddTile(TileID.Bottles);
            archeryR.Register();

            Recipe battleR = Recipe.Create(ItemID.BattlePotion, 3);
            battleR.AddIngredient(ItemID.BottledWater);
            battleR.AddIngredient(ModContent.ItemType<Rainbow>());
            battleR.AddTile(TileID.Bottles);
            battleR.Register();

            Recipe biomeR = Recipe.Create(ItemID.BiomeSightPotion, 3);
            biomeR.AddIngredient(ItemID.BottledWater);
            biomeR.AddIngredient(ModContent.ItemType<Rainbow>());
            biomeR.AddTile(TileID.Bottles);
            biomeR.Register();

            Recipe builderR = Recipe.Create(ItemID.BuilderPotion, 3);
            builderR.AddIngredient(ItemID.BottledWater);
            builderR.AddIngredient(ModContent.ItemType<Rainbow>());
            builderR.AddTile(TileID.Bottles);
            builderR.Register();

            Recipe calmingR = Recipe.Create(ItemID.CalmingPotion, 3);
            calmingR.AddIngredient(ItemID.BottledWater);
            calmingR.AddIngredient(ModContent.ItemType<Rainbow>());
            calmingR.AddTile(TileID.Bottles);
            calmingR.Register();

            Recipe crateR = Recipe.Create(ItemID.CratePotion, 3);
            crateR.AddIngredient(ItemID.BottledWater);
            crateR.AddIngredient(ModContent.ItemType<Rainbow>());
            crateR.AddTile(TileID.Bottles);
            crateR.Register();

            Recipe dangerR = Recipe.Create(ItemID.TrapsightPotion, 3); //Dangersense
            dangerR.AddIngredient(ItemID.BottledWater);
            dangerR.AddIngredient(ModContent.ItemType<Rainbow>());
            dangerR.AddTile(TileID.Bottles);
            dangerR.Register();

            Recipe enduranceR = Recipe.Create(ItemID.EndurancePotion, 3);
            enduranceR.AddIngredient(ItemID.BottledWater);
            enduranceR.AddIngredient(ModContent.ItemType<Rainbow>());
            enduranceR.AddTile(TileID.Bottles);
            enduranceR.Register();

            Recipe featherfallR = Recipe.Create(ItemID.FeatherfallPotion, 3);
            featherfallR.AddIngredient(ItemID.BottledWater);
            featherfallR.AddIngredient(ModContent.ItemType<Rainbow>());
            featherfallR.AddTile(TileID.Bottles);
            featherfallR.Register();

            Recipe fishingR = Recipe.Create(ItemID.FishingPotion, 3);
            fishingR.AddIngredient(ItemID.BottledWater);
            fishingR.AddIngredient(ModContent.ItemType<Rainbow>());
            fishingR.AddTile(TileID.Bottles);
            fishingR.Register();

            Recipe flipperR = Recipe.Create(ItemID.FlipperPotion, 3);
            flipperR.AddIngredient(ItemID.BottledWater);
            flipperR.AddIngredient(ModContent.ItemType<Rainbow>());
            flipperR.AddTile(TileID.Bottles);
            flipperR.Register();

            Recipe gillsR = Recipe.Create(ItemID.GillsPotion, 3);
            gillsR.AddIngredient(ItemID.BottledWater);
            gillsR.AddIngredient(ModContent.ItemType<Rainbow>());
            gillsR.AddTile(TileID.Bottles);
            gillsR.Register();

            Recipe gravityR = Recipe.Create(ItemID.GravitationPotion, 3);
            gravityR.AddIngredient(ItemID.BottledWater);
            gravityR.AddIngredient(ModContent.ItemType<Rainbow>());
            gravityR.AddTile(TileID.Bottles);
            gravityR.Register();

            Recipe bigLuckR = Recipe.Create(ItemID.LuckPotionGreater, 3);
            bigLuckR.AddIngredient(ItemID.BottledWater);
            bigLuckR.AddIngredient(ModContent.ItemType<Rainbow>());
            bigLuckR.AddTile(TileID.Bottles);
            bigLuckR.Register();

            Recipe midLuckR = Recipe.Create(ItemID.LuckPotion, 3);
            midLuckR.AddIngredient(ItemID.BottledWater);
            midLuckR.AddIngredient(ModContent.ItemType<Rainbow>());
            midLuckR.AddTile(TileID.Bottles);
            midLuckR.Register();

            Recipe smallLuckR = Recipe.Create(ItemID.LuckPotionLesser, 3);
            smallLuckR.AddIngredient(ItemID.BottledWater);
            smallLuckR.AddIngredient(ModContent.ItemType<Rainbow>());
            smallLuckR.AddTile(TileID.Bottles);
            smallLuckR.Register();

            Recipe heartR = Recipe.Create(ItemID.HeartreachPotion, 3);
            heartR.AddIngredient(ItemID.BottledWater);
            heartR.AddIngredient(ModContent.ItemType<Rainbow>());
            heartR.AddTile(TileID.Bottles);
            heartR.Register();

            Recipe hunterR = Recipe.Create(ItemID.HunterPotion, 3);
            hunterR.AddIngredient(ItemID.BottledWater);
            hunterR.AddIngredient(ModContent.ItemType<Rainbow>());
            hunterR.AddTile(TileID.Bottles);
            hunterR.Register();

            Recipe infernoR = Recipe.Create(ItemID.InfernoPotion, 3);
            infernoR.AddIngredient(ItemID.BottledWater);
            infernoR.AddIngredient(ModContent.ItemType<Rainbow>());
            infernoR.AddTile(TileID.Bottles);
            infernoR.Register();

            Recipe goneR = Recipe.Create(ItemID.InvisibilityPotion, 3);
            goneR.AddIngredient(ItemID.BottledWater);
            goneR.AddIngredient(ModContent.ItemType<Rainbow>());
            goneR.AddTile(TileID.Bottles);
            goneR.Register();

            Recipe thereIsBugsUnderYourIronSkinTakeItOffR = Recipe.Create(ItemID.IronskinPotion, 3);
            thereIsBugsUnderYourIronSkinTakeItOffR.AddIngredient(ItemID.BottledWater);
            thereIsBugsUnderYourIronSkinTakeItOffR.AddIngredient(ModContent.ItemType<Rainbow>());
            thereIsBugsUnderYourIronSkinTakeItOffR.AddTile(TileID.Bottles);
            thereIsBugsUnderYourIronSkinTakeItOffR.Register();

            Recipe lifeR = Recipe.Create(ItemID.LifeforcePotion, 3);
            lifeR.AddIngredient(ItemID.BottledWater);
            lifeR.AddIngredient(ModContent.ItemType<Rainbow>());
            lifeR.AddTile(TileID.Bottles);
            lifeR.Register();

            Recipe HarryR = Recipe.Create(ItemID.MagicPowerPotion, 3);
            HarryR.AddIngredient(ItemID.BottledWater);
            HarryR.AddIngredient(ModContent.ItemType<Rainbow>());
            HarryR.AddTile(TileID.Bottles);
            HarryR.Register();

            Recipe manaRegenR = Recipe.Create(ItemID.ManaRegenerationPotion, 3);
            manaRegenR.AddIngredient(ItemID.BottledWater);
            manaRegenR.AddIngredient(ModContent.ItemType<Rainbow>());
            manaRegenR.AddTile(TileID.Bottles);
            manaRegenR.Register();

            Recipe aMINER = Recipe.Create(ItemID.MiningPotion, 3);
            aMINER.AddIngredient(ItemID.BottledWater);
            aMINER.AddIngredient(ModContent.ItemType<Rainbow>());
            aMINER.AddTile(TileID.Bottles);
            aMINER.Register();

            Recipe owlR = Recipe.Create(ItemID.NightOwlPotion, 3);
            owlR.AddIngredient(ItemID.BottledWater);
            owlR.AddIngredient(ModContent.ItemType<Rainbow>());
            owlR.AddTile(TileID.Bottles);
            owlR.Register();

            Recipe thereIsBugsUnderYourObsidianSkinTakeItOffR = Recipe.Create(ItemID.ObsidianSkinPotion, 3);
            thereIsBugsUnderYourObsidianSkinTakeItOffR.AddIngredient(ItemID.BottledWater);
            thereIsBugsUnderYourObsidianSkinTakeItOffR.AddIngredient(ModContent.ItemType<Rainbow>());
            thereIsBugsUnderYourObsidianSkinTakeItOffR.AddTile(TileID.Bottles);
            thereIsBugsUnderYourObsidianSkinTakeItOffR.Register();

            Recipe rageR = Recipe.Create(ItemID.RagePotion, 3);
            rageR.AddIngredient(ItemID.BottledWater);
            rageR.AddIngredient(ModContent.ItemType<Rainbow>());
            rageR.AddTile(TileID.Bottles);
            rageR.Register();

            Recipe regenR = Recipe.Create(ItemID.RegenerationPotion, 3);
            regenR.AddIngredient(ItemID.BottledWater);
            regenR.AddIngredient(ModContent.ItemType<Rainbow>());
            regenR.AddTile(TileID.Bottles);
            regenR.Register();

            Recipe shineR = Recipe.Create(ItemID.ShinePotion, 3);
            shineR.AddIngredient(ItemID.BottledWater);
            shineR.AddIngredient(ModContent.ItemType<Rainbow>());
            shineR.AddTile(TileID.Bottles);
            shineR.Register();

            Recipe sonarR = Recipe.Create(ItemID.SonarPotion, 3);
            sonarR.AddIngredient(ItemID.BottledWater);
            sonarR.AddIngredient(ModContent.ItemType<Rainbow>());
            sonarR.AddTile(TileID.Bottles);
            sonarR.Register();

            Recipe spelunkerR = Recipe.Create(ItemID.SpelunkerPotion, 3);
            spelunkerR.AddIngredient(ItemID.BottledWater);
            spelunkerR.AddIngredient(ModContent.ItemType<Rainbow>());
            spelunkerR.AddTile(TileID.Bottles);
            spelunkerR.Register();

            Recipe ewR = Recipe.Create(ItemID.StinkPotion, 3);
            ewR.AddIngredient(ItemID.BottledWater);
            ewR.AddIngredient(ModContent.ItemType<Rainbow>());
            ewR.AddTile(TileID.Bottles);
            ewR.Register();

            Recipe summonR = Recipe.Create(ItemID.SummoningPotion, 3);
            summonR.AddIngredient(ItemID.BottledWater);
            summonR.AddIngredient(ModContent.ItemType<Rainbow>());
            summonR.AddTile(TileID.Bottles);
            summonR.Register();

            Recipe flashR = Recipe.Create(ItemID.SwiftnessPotion, 3);
            flashR.AddIngredient(ItemID.BottledWater);
            flashR.AddIngredient(ModContent.ItemType<Rainbow>());
            flashR.AddTile(TileID.Bottles);
            flashR.Register();

            Recipe stingyR = Recipe.Create(ItemID.ThornsPotion, 3);
            stingyR.AddIngredient(ItemID.BottledWater);
            stingyR.AddIngredient(ModContent.ItemType<Rainbow>());
            stingyR.AddTile(TileID.Bottles);
            stingyR.Register();

            Recipe titanR = Recipe.Create(ItemID.TitanPotion, 3);
            titanR.AddIngredient(ItemID.BottledWater);
            titanR.AddIngredient(ModContent.ItemType<Rainbow>());
            titanR.AddTile(TileID.Bottles);
            titanR.Register();

            Recipe warmR = Recipe.Create(ItemID.WarmthPotion, 3);
            warmR.AddIngredient(ItemID.BottledWater);
            warmR.AddIngredient(ModContent.ItemType<Rainbow>());
            warmR.AddTile(TileID.Bottles);
            warmR.Register();

            Recipe jesusR = Recipe.Create(ItemID.WaterWalkingPotion, 3);
            jesusR.AddIngredient(ItemID.BottledWater);
            jesusR.AddIngredient(ModContent.ItemType<Rainbow>());
            jesusR.AddTile(TileID.Bottles);
            jesusR.Register();

            Recipe wrathR = Recipe.Create(ItemID.WrathPotion, 3);
            wrathR.AddIngredient(ItemID.BottledWater);
            wrathR.AddIngredient(ModContent.ItemType<Rainbow>());
            wrathR.AddTile(TileID.Bottles);
            wrathR.Register();

            Recipe ImComingHomeR = Recipe.Create(ItemID.RecallPotion, 6);
            ImComingHomeR.AddIngredient(ItemID.BottledWater);
            ImComingHomeR.AddIngredient(ModContent.ItemType<Rainbow>());
            ImComingHomeR.AddTile(TileID.Bottles);
            ImComingHomeR.Register();

            Recipe ImComingHomeAndLeaveAgainR = Recipe.Create(ItemID.PotionOfReturn, 3);
            ImComingHomeAndLeaveAgainR.AddIngredient(ItemID.BottledWater);
            ImComingHomeAndLeaveAgainR.AddIngredient(ModContent.ItemType<Rainbow>());
            ImComingHomeAndLeaveAgainR.AddTile(TileID.Bottles);
            ImComingHomeAndLeaveAgainR.Register();

            Recipe teleportR = Recipe.Create(ItemID.TeleportationPotion, 3);
            teleportR.AddIngredient(ItemID.BottledWater);
            teleportR.AddIngredient(ModContent.ItemType<Rainbow>());
            teleportR.AddTile(TileID.Bottles);
            teleportR.Register();

            Recipe wormBossHoleR = Recipe.Create(ItemID.WormholePotion, 6);
            wormBossHoleR.AddIngredient(ItemID.BottledWater);
            wormBossHoleR.AddIngredient(ModContent.ItemType<Rainbow>());
            wormBossHoleR.AddTile(TileID.Bottles);
            wormBossHoleR.Register();

            Recipe warriorR = Recipe.Create(ModContent.ItemType<WarriorsThermos>(), 3);
            warriorR.AddIngredient(ItemID.BottledWater);
            warriorR.AddIngredient(ModContent.ItemType<Rainbow>());
            warriorR.AddTile(TileID.Bottles);
            warriorR.Register();

            Recipe red = Recipe.Create(ItemID.RedPotion);
            red.AddIngredient(ItemID.BottledWater);
            red.AddIngredient(ModContent.ItemType<Rainbow>());
            red.AddIngredient(ModContent.ItemType<Red>(), 2);
            red.AddTile(TileID.Bottles);
            red.Register();
            #endregion

            #region Music Boxes
            Recipe box = Recipe.Create(ItemID.MusicBox);
            box.AddRecipeGroup(RecipeGroupID.Wood, 20);
            box.AddRecipeGroup(RecipeGroupID.IronBar, 7);
            box.AddTile(TileID.HeavyWorkBench);
            box.Register();


            #endregion
        }

        public override void PostAddRecipes()
        {
            for (int i = 0; i < Recipe.numRecipes; i++)
            {
                Recipe recipe = Main.recipe[i];

                if (recipe.HasResult(ItemID.TerrasparkBoots))
                    recipe.AddIngredient(ModContent.ItemType<PaleMatter>(), 3);
				    //recipe.AddIngredient(ModContent.ItemType<TerraShard>(), 10);
                if (recipe.HasResult(ItemID.PhoenixBlaster))
                {
                    recipe.AddIngredient(ItemID.Bone, 23);
                }
            }
        }

        public static RecipeGroup EvilPowder;
		public static RecipeGroup EvilSample;
		public static RecipeGroup GoldPlatinum;
		public static RecipeGroup Ice;
		public static RecipeGroup Adamantitanium;
		public static RecipeGroup CopperTin;

		public override void Unload()
		{
			EvilPowder = null;
			EvilSample = null;
			GoldPlatinum = null;
			Ice = null;
			Adamantitanium = null;
			CopperTin = null;
		}
		public override void AddRecipeGroups()
        {
            //New recipe groups
			EvilPowder = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ItemID.VilePowder)}",
	        ItemID.VilePowder, ItemID.ViciousPowder);
			RecipeGroup.RegisterGroup("MultidimensionMod:VilePowder", EvilPowder);

			EvilSample = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ItemID.ShadowScale)}",
            ItemID.ShadowScale, ItemID.TissueSample);
			RecipeGroup.RegisterGroup("MultidimensionMod:ShadowScale", EvilSample);

			GoldPlatinum = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ItemID.GoldBar)}",
            ItemID.GoldBar, ItemID.PlatinumBar);
			RecipeGroup.RegisterGroup("MultidimensionMod:GoldBar", GoldPlatinum);

			Ice = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ItemID.IceBlock)}",
            ItemID.IceBlock, ItemID.PurpleIceBlock, ItemID.PinkIceBlock, ItemID.RedIceBlock);
			RecipeGroup.RegisterGroup("MultidimensionMod:IceBlock", Ice);

			Adamantitanium = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ItemID.AdamantiteBar)}",
            ItemID.AdamantiteBar, ItemID.TitaniumBar);
			RecipeGroup.RegisterGroup("MultidimensionMod:AdamantiteBar", Adamantitanium);

			CopperTin = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ItemID.CopperBar)}",
			ItemID.CopperBar, ItemID.TinBar);
			RecipeGroup.RegisterGroup("MultidimensionMod:CopperBar", CopperTin);

            //Vanilla recipe group additions
            //Sand
            RecipeGroup.recipeGroups[RecipeGroupID.Sand].ValidItems.Add(ModContent.ItemType<MyceliumSand>());
            RecipeGroup.recipeGroups[RecipeGroupID.Sand].ValidItems.Add(ModContent.ItemType<Torchsand>());
            RecipeGroup.recipeGroups[RecipeGroupID.Sand].ValidItems.Add(ModContent.ItemType<Depthsand>());
            //RecipeGroup.recipeGroups[RecipeGroupID.Sand].ValidItems.Add(ModContent.ItemType<VoidSand>());
            //Wood
            RecipeGroup.recipeGroups[RecipeGroupID.Wood].ValidItems.Add(ModContent.ItemType<Razewood>());
            RecipeGroup.recipeGroups[RecipeGroupID.Wood].ValidItems.Add(ModContent.ItemType<Bogwood>());
            //RecipeGroup.recipeGroups[RecipeGroupID.Wood].ValidItems.Add(ModContent.ItemType<OroborosWood>());
            //RecipeGroup.recipeGroups[RecipeGroupID.Wood].ValidItems.Add(ModContent.ItemType<FrigidAshWood>());
        }
	}
}