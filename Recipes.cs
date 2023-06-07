using MultidimensionMod.Items.Materials;
using MultidimensionMod.Tiles;
using MultidimensionMod.Items.Potions;
using Terraria.ModLoader;
using Terraria;
using Terraria.Localization;
using Terraria.ID;

namespace MultidimensionMod
{
	internal class Recipes : ModSystem
	{
		public override void AddRecipes()
        {
			#region Accessories
			Recipe aglet = Recipe.Create(ItemID.Aglet); 
			aglet.AddRecipeGroup(RecipeGroupID.IronBar, 5);
			aglet.AddTile(TileID.Anvils);
			aglet.Register();

			Recipe anklet = Recipe.Create(ItemID.AnkletoftheWind);
			anklet.AddIngredient(ItemID.Vine, 2);
			anklet.AddIngredient(ItemID.JungleSpores, 10);
			anklet.AddIngredient(ItemID.Cloud, 12);
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
			hermes.AddIngredient(ItemID.SwiftnessPotion, 2);
			hermes.AddTile(TileID.WorkBenches);
			hermes.Register();

			Recipe skates = Recipe.Create(ItemID.IceSkates); 
			skates.AddIngredient(ItemID.Leather, 5);
			skates.AddIngredient(ModContent.ItemType<VikingRelic>(), 3);
			skates.AddTile(TileID.WorkBenches);
			skates.Register();

			Recipe waterwalk = Recipe.Create(ItemID.WaterWalkingBoots); 
			waterwalk.AddIngredient(ItemID.Leather, 5);
			waterwalk.AddIngredient(ItemID.WaterWalkingPotion, 3);
			waterwalk.AddTile(TileID.WorkBenches);
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

			Recipe magnet = Recipe.Create(ItemID.CelestialMagnet);
			magnet.AddIngredient(ItemID.FallenStar, 10);
			magnet.AddRecipeGroup(GoldPlatinum, 10);
			magnet.AddTile(TileID.SkyMill);
			magnet.Register();

			Recipe potionStone = Recipe.Create(ItemID.PhilosophersStone);
			potionStone.AddIngredient(ItemID.LifeCrystal, 2);
			potionStone.AddIngredient(ItemID.GreaterHealingPotion, 5);
			potionStone.AddIngredient(ModContent.ItemType<PotionofLife>());
			potionStone.AddIngredient(ItemID.SoulofLight ,10);
			potionStone.AddTile(TileID.CrystalBall);
			potionStone.Register();

			Recipe longImmune = Recipe.Create(ItemID.CrossNecklace);
			longImmune.AddRecipeGroup(GoldPlatinum, 8);
			longImmune.AddIngredient(ItemID.Chain);
			longImmune.AddIngredient(ItemID.UnicornHorn);
			longImmune.AddIngredient(ItemID.SoulofLight, 3);
			longImmune.AddTile(TileID.CrystalBall);
			longImmune.Register();

			Recipe rose = Recipe.Create(ItemID.ObsidianRose);
			rose.AddIngredient(ItemID.JungleRose);
			rose.AddIngredient(ItemID.Obsidian, 20);
			rose.AddTile(TileID.Hellforge);
			rose.Register();

			Recipe cloak = Recipe.Create(ItemID.StarCloak);
			cloak.AddIngredient(ItemID.FallenStar, 8);
			cloak.AddIngredient(ModContent.ItemType<DevilSilk>(), 8);
			cloak.AddIngredient(ItemID.SoulofLight, 3);
			cloak.AddTile(TileID.Loom);
			cloak.Register();
			#endregion

            #region Ankh Charm Mats
			Recipe bandage = Recipe.Create(ItemID.AdhesiveBandage);
			bandage.AddIngredient(ItemID.Silk,10);
			bandage.AddIngredient(ItemID.AncientCloth, 3);
			bandage.AddIngredient(ItemID.Gel, 5);
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
			bezoar.AddIngredient(ItemID.BeeWax, 5);
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
			clock.AddIngredient(ItemID.PixieDust, 40);
			clock.AddTile(TileID.WorkBenches);
			clock.Register();

			Recipe scream = Recipe.Create(ItemID.Megaphone);
			scream.AddRecipeGroup(Adamantitanium, 7);
			scream.AddIngredient(ItemID.PixieDust, 25);
			scream.AddIngredient(ItemID.Wire, 14);
			scream.AddTile(TileID.MythrilAnvil);
			scream.Register();

			Recipe nazar = Recipe.Create(ItemID.Nazar);
			nazar.AddIngredient(ItemID.Lens, 2);
			nazar.AddIngredient(ItemID.SoulofNight, 10);
			nazar.AddIngredient(ModContent.ItemType<DarkMatterClump>(), 8);
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
			compass.AddIngredient(ModContent.ItemType<VikingRelic>(), 3);
			compass.AddRecipeGroup(CopperTin);
			compass.AddTile(TileID.Anvils);
			compass.Register();

			Recipe deep = Recipe.Create(ItemID.DepthMeter);
			deep.AddRecipeGroup(RecipeGroupID.IronBar, 8);
			deep.AddIngredient(ItemID.Obsidian, 20);
			deep.AddTile(TileID.Anvils);
			deep.Register();

			Recipe anal = Recipe.Create(ItemID.LifeformAnalyzer); //People will shit themself from laughter when they find this
			anal.AddRecipeGroup(RecipeGroupID.IronBar, 12);
			anal.AddIngredient(ItemID.Gel, 30);
			anal.AddIngredient(ItemID.GardenGnome);
			anal.AddTile(TileID.Anvils);
			anal.Register();

			Recipe watch = Recipe.Create(ItemID.Stopwatch);
			watch.AddIngredient(ItemID.Timer1Second);
			watch.AddIngredient(ItemID.AntlionMandible, 3);
			watch.AddRecipeGroup(CopperTin, 8);
			watch.AddTile(TileID.Anvils);
			watch.Register();

			Recipe tally = Recipe.Create(ItemID.TallyCounter);
			tally.AddRecipeGroup(GoldPlatinum, 5);
			tally.AddIngredient(ItemID.Bone, 16);
			tally.AddTile(TileID.Anvils);
			tally.Register();

			Recipe detect = Recipe.Create(ItemID.MetalDetector);
			detect.AddRecipeGroup(Adamantitanium, 8);
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
			sex.AddTile(TileID.Anvils);
			sex.Register();

			Recipe radio = Recipe.Create(ItemID.WeatherRadio);
			radio.AddRecipeGroup(RecipeGroupID.IronBar, 10);
			radio.AddIngredient(ItemID.Cloud, 5);
			radio.AddIngredient(ItemID.RainCloud, 10);
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

			Recipe iceblade = Recipe.Create(ItemID.IceBlade);
			iceblade.AddRecipeGroup(Ice, 43);
			iceblade.AddIngredient(ModContent.ItemType<FrostScale>(), 4);
			iceblade.AddIngredient(ModContent.ItemType<VikingRelic>(), 2);
			iceblade.AddTile(TileID.Anvils);
			iceblade.Register();

			Recipe brand = Recipe.Create(ItemID.Frostbrand);
			brand.AddIngredient(ItemID.IceBlade);
			brand.AddIngredient(ModContent.ItemType<AbyssalHellstoneBar>(), 5);
			brand.AddTile(TileID.MythrilAnvil);
			brand.Register();

			Recipe weeb = Recipe.Create(ItemID.Katana);
			weeb.AddRecipeGroup(RecipeGroupID.IronBar, 7);
			weeb.AddRecipeGroup(CopperTin, 7);
			weeb.AddCondition(Condition.NearLava);
			weeb.Register();

			Recipe muramura = Recipe.Create(ItemID.Muramasa);
			muramura.AddIngredient(ItemID.Katana);
			muramura.AddIngredient(ModContent.ItemType<DarkMatterClump>(), 6);
			muramura.AddTile(TileID.DemonAltar);
			muramura.Register();

			Recipe sparky = Recipe.Create(ItemID.WandofSparking);
			sparky.AddRecipeGroup(RecipeGroupID.Wood, 10);
			sparky.AddIngredient(ItemID.Torch, 12);
			sparky.AddTile(TileID.WorkBenches);
			sparky.Register();

			Recipe slime = Recipe.Create(ItemID.SlimeStaff);
			slime.AddRecipeGroup(RecipeGroupID.Wood, 15);
			slime.AddIngredient(ItemID.Gel, 50);
			slime.AddIngredient(ItemID.PinkGel, 10);
			slime.AddTile(TileID.WorkBenches);
			slime.Register();

			Recipe boner = Recipe.Create(ItemID.BoneSword);
			boner.AddIngredient(ItemID.Bone, 33);
			boner.AddTile(TileID.BoneWelder);
			boner.Register();

			Recipe mushrang = Recipe.Create(ItemID.Shroomerang);
			mushrang.AddIngredient(ItemID.WoodenBoomerang);
			mushrang.AddIngredient(ModContent.ItemType<Mushmatter>(), 5);
			mushrang.AddTile(TileID.WorkBenches);
			#endregion

			#region Tools
			Recipe mirror = Recipe.Create(ItemID.MagicMirror);
			mirror.AddRecipeGroup(RecipeGroupID.IronBar, 3);
			mirror.AddIngredient(ItemID.FallenStar, 3);
			mirror.AddIngredient(ItemID.Glass, 5);
			mirror.AddIngredient(ItemID.RecallPotion, 5);
			mirror.AddTile(TileID.Anvils);
			mirror.Register();

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
			discord.AddIngredient(ItemID.SoulofLight, 24);
			discord.AddTile(TileID.MythrilAnvil);
			discord.Register();

			Recipe key = Recipe.Create(ItemID.ShadowKey);
			key.AddIngredient(ItemID.GoldenKey);
			key.AddIngredient(ModContent.ItemType<DarkMatterClump>(), 8);
			key.AddTile(TileID.DemonAltar);
			key.Register();

			Recipe bucket = Recipe.Create(ItemID.BottomlessBucket);
			bucket.AddIngredient(ItemID.WaterBucket);
			bucket.AddIngredient(ModContent.ItemType<DarkMatterClump>(), 5);
			bucket.AddIngredient(ItemID.PinkPearl);
			bucket.AddTile(TileID.Anvils);
			bucket.Register();

			Recipe spongebob = Recipe.Create(ItemID.SuperAbsorbantSponge);
			spongebob.AddIngredient(ItemID.Silk, 12);
			spongebob.AddIngredient(ModContent.ItemType<DarkMatterClump>(), 6);
			spongebob.AddIngredient(ItemID.PinkPearl);
			spongebob.AddTile(TileID.WorkBenches);
			spongebob.Register();

			Recipe conch = Recipe.Create(ItemID.MagicConch);
			conch.AddIngredient(ItemID.Seashell, 6);
			conch.AddIngredient(ItemID.WhitePearl);
			conch.Register();

			Recipe hellConch = Recipe.Create(ItemID.DemonConch);
			hellConch.AddIngredient(ItemID.Seashell, 6);
			hellConch.AddIngredient(ItemID.HellstoneBar, 10);
			hellConch.AddIngredient(ItemID.BlackPearl);
			hellConch.Register();
			#endregion

			#region Tiles
			Recipe milly = Recipe.Create(ItemID.SkyMill);
			milly.AddIngredient(ItemID.SunplateBlock, 30);
			milly.AddIngredient(ItemID.Cloud, 9);
			milly.AddTile(TileID.Anvils);
			milly.Register();

			Recipe sharp = Recipe.Create(ItemID.SharpeningStation);
			sharp.AddIngredient(ItemID.StoneBlock, 30);
			sharp.AddRecipeGroup(RecipeGroupID.Wood, 25);
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
			worm.AddIngredient(ModContent.ItemType<Mushmatter>(), 6);
			worm.AddTile(TileID.Autohammer);
			worm.Register();

			Recipe HP = Recipe.Create(ItemID.LifeCrystal);
			HP.AddIngredient(ItemID.BottledHoney);
			HP.AddIngredient(ItemID.Ruby, 2);
			HP.AddIngredient(ModContent.ItemType<Mushmatter>(), 3);
			HP.Register();

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
		}
	}
}