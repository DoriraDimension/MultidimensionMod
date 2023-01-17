using MultidimensionMod.Items.Materials;
using MultidimensionMod.Tiles;
using Terraria.ModLoader;
using Terraria;
using Terraria.ID;

namespace MultidimensionMod
{
	internal class Recipes : ModSystem
	{
		public override void AddRecipes()
        {
			#region Accessories
			Recipe aglet = Recipe.Create(ItemID.Aglet); 
			aglet.AddRecipeGroup("IronBar", 5);
			aglet.AddTile(TileID.Anvils);
			aglet.Register();

			Recipe anklet = Recipe.Create(ItemID.AnkletoftheWind);
			anklet.AddIngredient(ItemID.Vine, 2);
			anklet.AddIngredient(ItemID.JungleSpores, 10);
			anklet.AddTile(TileID.LivingLoom);
			anklet.Register();

			Recipe blizzard = Recipe.Create(ItemID.BlizzardinaBottle);
			blizzard.AddIngredient(ItemID.Bottle);
			blizzard.AddIngredient(ItemID.SnowBlock, 10);
			blizzard.AddIngredient(ItemID.Feather, 3);
			blizzard.AddIngredient(ModContent.ItemType<FrostScale>(), 6);
			blizzard.AddTile(TileID.Bottles);
			blizzard.Register();

			Recipe sandstorm = Recipe.Create(ItemID.SandstorminaBottle);
			sandstorm.AddIngredient(ItemID.Bottle);
			sandstorm.AddRecipeGroup("SandBlocks", 25);
			sandstorm.AddIngredient(ItemID.Feather, 3);
			sandstorm.AddIngredient(ModContent.ItemType<ManaInfusedSandstone>(), 6);
			sandstorm.AddTile(TileID.Bottles);
			sandstorm.Register();

			Recipe cloud = Recipe.Create(ItemID.CloudinaBottle);
			cloud.AddIngredient(ItemID.Bottle);
			cloud.AddIngredient(ItemID.Cloud, 25);
			cloud.AddIngredient(ItemID.Feather, 3);
			cloud.AddTile(TileID.Bottles);
			cloud.Register();

			Recipe climbClaw = Recipe.Create(ItemID.ClimbingClaws); 
			climbClaw.AddRecipeGroup("IronBar", 10);
			climbClaw.AddIngredient(ItemID.Spike, 3);
			climbClaw.AddTile(TileID.Anvils);
			climbClaw.Register();

			Recipe spikes = Recipe.Create(ItemID.ShoeSpikes);
			spikes.AddRecipeGroup("IronBar", 10);
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
			skates.AddRecipeGroup("IronBar", 5);
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
			lava.AddCondition(Recipe.Condition.NearLava);
			lava.Register();

			Recipe horseSneakers = Recipe.Create(ItemID.LuckyHorseshoe);
			horseSneakers.AddRecipeGroup("GoldBars", 10);
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
			starband.AddIngredient(ItemID.ShadowScale, 5);
			starband.AddTile(TileID.DemonAltar);
			starband.Register();

			Recipe panic = Recipe.Create(ItemID.PanicNecklace);
			panic.AddIngredient(ItemID.LifeCrystal);
			panic.AddIngredient(ItemID.TissueSample, 5);
			panic.AddTile(TileID.DemonAltar);
			panic.Register();

			Recipe magnet = Recipe.Create(ItemID.CelestialMagnet);
			magnet.AddIngredient(ItemID.FallenStar, 10);
			magnet.AddRecipeGroup("GoldBars", 10);
			magnet.AddIngredient(ItemID.Bone, 15);
			magnet.AddTile(TileID.Anvils);
			magnet.Register();

			Recipe potionStone = Recipe.Create(ItemID.PhilosophersStone);
			potionStone.AddIngredient(ItemID.LifeCrystal, 2);
			potionStone.AddIngredient(ItemID.GreaterHealingPotion, 5);
			potionStone.AddIngredient(ItemID.SoulofLight ,10);
			potionStone.AddTile(TileID.CrystalBall);
			potionStone.Register();

			Recipe longImmune = Recipe.Create(ItemID.CrossNecklace);
			longImmune.AddRecipeGroup("GoldBars", 8);
			longImmune.AddIngredient(ItemID.Chain);
			longImmune.AddIngredient(ItemID.UnicornHorn);
			longImmune.AddIngredient(ItemID.SoulofLight, 3);
			longImmune.AddTile(TileID.CrystalBall);
			longImmune.Register();

			Recipe rose = Recipe.Create(ItemID.ObsidianRose);
			rose.AddIngredient(ItemID.JungleRose);
			rose.AddIngredient(ItemID.Obsidian, 20);
			rose.AddCondition(Recipe.Condition.NearLava);
			rose.Register();

			Recipe cloak = Recipe.Create(ItemID.StarCloak);
			cloak.AddIngredient(ItemID.FallenStar, 8);
			cloak.AddIngredient(ItemID.Silk, 20);
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
			polish.AddIngredient(ItemID.Bone, 14);
			polish.AddIngredient(ItemID.BeeWax ,10);
			polish.AddTile(TileID.Bottles);
			polish.Register();

			Recipe bezoar = Recipe.Create(ItemID.Bezoar);
			bezoar.AddIngredient(ItemID.Stinger, 3);
			bezoar.AddIngredient(ItemID.Moonglow, 2);
			bezoar.AddIngredient(ItemID.BeeWax, 5);
			bezoar.AddTile(TileID.Bottles);
			bezoar.Register();

			Recipe blind = Recipe.Create(ItemID.Blindfold);
			blind.AddIngredient(ItemID.Silk, 10);
			blind.AddIngredient(ItemID.SoulofNight, 2);
			blind.AddTile(TileID.Loom);
			blind.Register();

			Recipe shield = Recipe.Create(ItemID.CobaltShield);
			shield.AddRecipeGroup("CobaltBars", 15);
			shield.AddTile(TileID.Anvils);
			shield.Register();

			Recipe clock = Recipe.Create(ItemID.FastClock);
			clock.AddIngredient(ItemID.PearlstoneBlock, 25);
			clock.AddIngredient(ItemID.PixieDust, 20);
			clock.AddTile(TileID.WorkBenches);
			clock.Register();

			Recipe scream = Recipe.Create(ItemID.Megaphone);
			scream.AddRecipeGroup("AdamantiteBars", 7);
			scream.AddIngredient(ItemID.PixieDust, 25);
			scream.AddTile(TileID.MythrilAnvil);
			scream.Register();

			Recipe nazar = Recipe.Create(ItemID.Nazar);
			nazar.AddIngredient(ItemID.SoulofNight, 10);
			nazar.AddIngredient(ModContent.ItemType<DarkMatterClump>(), 8);
			nazar.AddIngredient(ItemID.Lens, 2);
			nazar.AddTile(TileID.DemonAltar);
			nazar.Register();

			Recipe map = Recipe.Create(ItemID.TrifoldMap);
			map.AddIngredient(ItemID.Silk, 10);
			map.AddIngredient(ItemID.AncientCloth);
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
			radar.AddRecipeGroup("IronBar", 10);
			radar.AddIngredient(ItemID.Wire, 5);
			radar.AddIngredient(ItemID.Glass, 5);
			radar.AddTile(TileID.Anvils);
			radar.Register();

			Recipe compass = Recipe.Create(ItemID.Compass);
			compass.AddRecipeGroup("IronBar", 7);
			compass.AddTile(TileID.Anvils);
			compass.Register();

			Recipe deep = Recipe.Create(ItemID.DepthMeter);
			deep.AddRecipeGroup("IronBar", 8);
			deep.AddIngredient(ItemID.Obsidian, 20);
			deep.AddTile(TileID.Anvils);
			deep.Register();

			Recipe anal = Recipe.Create(ItemID.LifeformAnalyzer); //:)
			anal.AddRecipeGroup("IronBar", 12);
			anal.AddIngredient(ItemID.Gel, 30);
			anal.AddIngredient(ItemID.GardenGnome);
			anal.AddTile(TileID.Anvils);
			anal.Register();

			Recipe watch = Recipe.Create(ItemID.Stopwatch);
			watch.AddRecipeGroup("IronBar", 5);
			watch.AddIngredient(ItemID.SilverWatch);
			watch.AddTile(TileID.Anvils);
			watch.Register();

			Recipe watch2 = Recipe.Create(ItemID.Stopwatch);
			watch2.AddRecipeGroup("IronBar", 5);
			watch2.AddIngredient(ItemID.TungstenWatch);
			watch2.AddTile(TileID.Anvils);
			watch2.Register();

			Recipe tally = Recipe.Create(ItemID.TallyCounter);
			tally.AddRecipeGroup("IronBar", 5);
			tally.AddIngredient(ItemID.Bone, 16);
			tally.AddTile(TileID.Anvils);
			tally.Register();

			Recipe detect = Recipe.Create(ItemID.MetalDetector);
			detect.AddRecipeGroup("AdamantiteBars", 8);
			detect.AddIngredient(ItemID.Wire, 15);
			detect.AddTile(TileID.MythrilAnvil);
			detect.Register();

			Recipe dps = Recipe.Create(ItemID.DPSMeter);
			dps.AddRecipeGroup("IronBar", 6);
			dps.AddIngredient(ItemID.Wire, 8);
			dps.AddTile(TileID.Anvils);
			dps.Register();

			Recipe sex = Recipe.Create(ItemID.Sextant);
			sex.AddRecipeGroup("GoldBars", 8);
			sex.AddIngredient(ItemID.Lens);
			sex.AddTile(TileID.Anvils);
			sex.Register();

			Recipe radio = Recipe.Create(ItemID.WeatherRadio);
			radio.AddRecipeGroup("IronBar", 10);
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
			fury.AddRecipeGroup("GoldBars", 15);
			fury.AddTile(TileID.SkyMill);
			fury.Register();

			Recipe enchant = Recipe.Create(ItemID.EnchantedSword);
			enchant.AddIngredient(ItemID.GoldBroadsword);
			enchant.AddIngredient(ItemID.FallenStar, 8);
			enchant.AddRecipeGroup("EvilSample", 7);
			enchant.AddTile(TileID.Anvils);
			enchant.Register();

			Recipe enchant2 = Recipe.Create(ItemID.EnchantedSword);
			enchant2.AddIngredient(ItemID.PlatinumBroadsword);
			enchant2.AddIngredient(ItemID.FallenStar, 8);
			enchant2.AddRecipeGroup("EvilSample", 7);
			enchant2.AddTile(TileID.Anvils);
			enchant2.Register();

			Recipe woodmerang = Recipe.Create(ItemID.WoodenBoomerang); //Ich und mein Holz, Holzi Holzi Holz
			woodmerang.AddRecipeGroup("Wood", 20);
			woodmerang.AddTile(TileID.WorkBenches);
			woodmerang.Register();

			Recipe icemerang = Recipe.Create(ItemID.IceBoomerang);
			icemerang.AddIngredient(ItemID.WoodenBoomerang);
			icemerang.AddRecipeGroup("IceBlocks", 30);
			icemerang.AddIngredient(ModContent.ItemType<FrostScale>(), 4);
			icemerang.AddTile(TileID.Anvils);
			icemerang.Register();

			Recipe iceblade = Recipe.Create(ItemID.IceBlade);
			iceblade.AddRecipeGroup("IceBlocks", 43);
			iceblade.AddIngredient(ModContent.ItemType<FrostScale>(), 4);
			iceblade.AddIngredient(ModContent.ItemType<VikingRelic>(), 2);
			iceblade.AddTile(TileID.Anvils);
			iceblade.Register();

			Recipe brand = Recipe.Create(ItemID.Frostbrand);
			brand.AddIngredient(ItemID.IceBlade);
			brand.AddIngredient(ItemID.FrostCore);
			brand.AddRecipeGroup("AdamantiteBars", 5);
			brand.AddTile(TileID.MythrilAnvil);
			brand.Register();

			Recipe weeb = Recipe.Create(ItemID.Katana);
			weeb.AddRecipeGroup("IronBar", 10);
			weeb.AddIngredient(ItemID.LavaBucket, 2);
			weeb.AddTile(TileID.Anvils);
			weeb.Register();

			Recipe muramura = Recipe.Create(ItemID.Muramasa);
			muramura.AddIngredient(ItemID.Katana);
			muramura.AddIngredient(ModContent.ItemType<DarkMatterClump>(), 6);
			muramura.AddTile(TileID.DemonAltar);
			muramura.Register();

			Recipe sparky = Recipe.Create(ItemID.WandofSparking);
			sparky.AddRecipeGroup("Wood", 10);
			sparky.AddIngredient(ItemID.Torch, 12);
			sparky.AddTile(TileID.WorkBenches);
			sparky.Register();

			Recipe slime = Recipe.Create(ItemID.SlimeStaff);
			slime.AddRecipeGroup("Wood", 15);
			slime.AddIngredient(ItemID.Gel, 50);
			slime.AddTile(TileID.WorkBenches);
			slime.Register();

			Recipe boner = Recipe.Create(ItemID.BoneSword);
			boner.AddIngredient(ItemID.Bone, 33);
			boner.AddTile(TileID.BoneWelder);
			boner.Register();
			#endregion

			#region Tools
			Recipe mirror = Recipe.Create(ItemID.MagicMirror);
			mirror.AddRecipeGroup("IronBar");
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
			discord.AddIngredient(ItemID.PixieDust, 65);
			discord.AddIngredient(ItemID.SoulofLight, 14);
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
			bucket.AddIngredient(ModContent.ItemType<Dimensium>(), 6);
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
			sharp.AddRecipeGroup("Wood", 25);
			sharp.AddTile(TileID.HeavyWorkBench);
			sharp.Register();

			Recipe loom = Recipe.Create(ItemID.LivingLoom);
			loom.AddIngredient(ItemID.Vine, 5);
			loom.AddRecipeGroup("Wood", 34);
			loom.AddTile(TileID.WorkBenches);
			loom.Register();
			#endregion

			#region Consumables
			Recipe worm = Recipe.Create(ItemID.TruffleWorm);
			worm.AddIngredient(ItemID.Worm);
			worm.AddIngredient(ItemID.GlowingMushroom, 20);
			worm.AddIngredient(ModContent.ItemType<Mushmatter>(), 7);
			worm.AddTile(TileID.Autohammer);
			worm.Register();

			Recipe HP = Recipe.Create(ItemID.LifeCrystal);
			HP.AddIngredient(ItemID.BottledHoney);
			HP.AddIngredient(ItemID.Ruby, 2);
			HP.AddIngredient(ModContent.ItemType<Mushmatter>(), 3);
			HP.Register();
			#endregion

			#region Materials
			Recipe leather = Recipe.Create(ItemID.Leather);
			leather.AddIngredient(ItemID.Vertebrae, 5);
			leather.AddTile(TileID.WorkBenches);
			leather.Register();
			#endregion

			#region Transmutation
			Recipe copper = Recipe.Create(ItemID.CopperBar);
			copper.AddIngredient(ItemID.TinBar);
			copper.AddIngredient(ModContent.ItemType<Dimensium>());
			copper.AddTile(ModContent.TileType<DimensionalForge>());
			copper.Register();

			Recipe tin = Recipe.Create(ItemID.TinBar);
			tin.AddIngredient(ItemID.CopperBar);
			tin.AddIngredient(ModContent.ItemType<Dimensium>());
			tin.AddTile(ModContent.TileType<DimensionalForge>());
			tin.Register();

			Recipe iron = Recipe.Create(ItemID.IronBar);
			iron.AddIngredient(ItemID.LeadBar);
			iron.AddIngredient(ModContent.ItemType<Dimensium>());
			iron.AddTile(ModContent.TileType<DimensionalForge>());
			iron.Register();

			Recipe lead = Recipe.Create(ItemID.LeadBar);
			lead.AddIngredient(ItemID.IronBar);
			lead.AddIngredient(ModContent.ItemType<Dimensium>());
			lead.AddTile(ModContent.TileType<DimensionalForge>());
			lead.Register();

			Recipe silver = Recipe.Create(ItemID.SilverBar);
			silver.AddIngredient(ItemID.TungstenBar);
			silver.AddIngredient(ModContent.ItemType<Dimensium>());
			silver.AddTile(ModContent.TileType<DimensionalForge>());
			silver.Register();

			Recipe tongue = Recipe.Create(ItemID.TungstenBar);
			tongue.AddIngredient(ItemID.SilverBar);
			tongue.AddIngredient(ModContent.ItemType<Dimensium>());
			tongue.AddTile(ModContent.TileType<DimensionalForge>());
			tongue.Register();

			Recipe gold = Recipe.Create(ItemID.GoldBar);
			gold.AddIngredient(ItemID.PlatinumBar);
			gold.AddIngredient(ModContent.ItemType<Dimensium>());
			gold.AddTile(ModContent.TileType<DimensionalForge>());
			gold.Register();

			Recipe platinum = Recipe.Create(ItemID.PlatinumBar);
			platinum.AddIngredient(ItemID.GoldBar);
			platinum.AddIngredient(ModContent.ItemType<Dimensium>());
			platinum.AddTile(ModContent.TileType<DimensionalForge>());
			platinum.Register();

			Recipe demon = Recipe.Create(ItemID.DemoniteBar);
			demon.AddIngredient(ItemID.CrimtaneBar);
			demon.AddIngredient(ModContent.ItemType<Dimensium>());
			demon.AddTile(ModContent.TileType<DimensionalForge>());
			demon.Register();

			Recipe crim = Recipe.Create(ItemID.CrimtaneBar);
			crim.AddIngredient(ItemID.DemoniteBar);
			crim.AddIngredient(ModContent.ItemType<Dimensium>());
			crim.AddTile(ModContent.TileType<DimensionalForge>());
			crim.Register();

			Recipe scale = Recipe.Create(ItemID.ShadowScale);
			scale.AddIngredient(ItemID.TissueSample);
			scale.AddIngredient(ModContent.ItemType<Dimensium>());
			scale.AddTile(ModContent.TileType<DimensionalForge>());
			scale.Register();

			Recipe sample = Recipe.Create(ItemID.TissueSample);
			sample.AddIngredient(ItemID.ShadowScale);
			sample.AddIngredient(ModContent.ItemType<Dimensium>());
			sample.AddTile(ModContent.TileType<DimensionalForge>());
			sample.Register();

			Recipe kobold = Recipe.Create(ItemID.CobaltBar);
			kobold.AddIngredient(ItemID.PalladiumBar);
			kobold.AddIngredient(ModContent.ItemType<Dimensium>());
			kobold.AddTile(ModContent.TileType<DimensionalForge>());
			kobold.Register();

			Recipe palle = Recipe.Create(ItemID.PalladiumBar);
			palle.AddIngredient(ItemID.CobaltBar);
			palle.AddIngredient(ModContent.ItemType<Dimensium>());
			palle.AddTile(ModContent.TileType<DimensionalForge>());
			palle.Register();

			Recipe myth = Recipe.Create(ItemID.MythrilBar);
			myth.AddIngredient(ItemID.OrichalcumBar);
		    myth.AddIngredient(ModContent.ItemType<Dimensium>());
			myth.AddTile(ModContent.TileType<DimensionalForge>());
			myth.Register();

			Recipe cum = Recipe.Create(ItemID.OrichalcumBar);
			cum.AddIngredient(ItemID.MythrilBar);
			cum.AddIngredient(ModContent.ItemType<Dimensium>());
			cum.AddTile(ModContent.TileType<DimensionalForge>());
			cum.Register();

			Recipe adam = Recipe.Create(ItemID.AdamantiteBar);
			adam.AddIngredient(ItemID.TitaniumBar);
			adam.AddIngredient(ModContent.ItemType<Dimensium>());
			adam.AddTile(ModContent.TileType<DimensionalForge>());
			adam.Register();

			Recipe tits = Recipe.Create(ItemID.TitaniumBar);
			tits.AddIngredient(ItemID.AdamantiteBar);
			tits.AddIngredient(ModContent.ItemType<Dimensium>());
			tits.AddTile(ModContent.TileType<DimensionalForge>());
			tits.Register();

			Recipe rot = Recipe.Create(ItemID.RottenChunk);
			rot.AddIngredient(ItemID.Vertebrae);
			rot.AddIngredient(ModContent.ItemType<Dimensium>());
			rot.AddTile(ModContent.TileType<DimensionalForge>());
			rot.Register();

			Recipe vert = Recipe.Create(ItemID.Vertebrae);
			vert.AddIngredient(ItemID.RottenChunk);
			vert.AddIngredient(ModContent.ItemType<Dimensium>());
			vert.AddTile(ModContent.TileType<DimensionalForge>());
			vert.Register();

			Recipe light = Recipe.Create(ItemID.SoulofLight);
			light.AddIngredient(ItemID.SoulofNight);
			light.AddIngredient(ModContent.ItemType<Dimensium>());
			light.AddTile(ModContent.TileType<DimensionalForge>());
			light.Register();

			Recipe night = Recipe.Create(ItemID.SoulofNight);
			night.AddIngredient(ItemID.SoulofLight);
			night.AddIngredient(ModContent.ItemType<Dimensium>());
			night.AddTile(ModContent.TileType<DimensionalForge>());
			night.Register();

			Recipe curse = Recipe.Create(ItemID.CursedFlame);
			curse.AddIngredient(ItemID.Ichor);
			curse.AddIngredient(ModContent.ItemType<Dimensium>());
			curse.AddTile(ModContent.TileType<DimensionalForge>());
			curse.Register();

			Recipe ichor = Recipe.Create(ItemID.Ichor);
			ichor.AddIngredient(ItemID.CursedFlame);
			ichor.AddIngredient(ModContent.ItemType<Dimensium>());
			ichor.AddTile(ModContent.TileType<DimensionalForge>());
			ichor.Register();

			Recipe ebon = Recipe.Create(ItemID.EbonstoneBlock);
			ebon.AddIngredient(ItemID.CrimstoneBlock);
			ebon.AddIngredient(ModContent.ItemType<Dimensium>());
			ebon.AddTile(ModContent.TileType<DimensionalForge>());
			ebon.Register();

			Recipe redrock = Recipe.Create(ItemID.CrimstoneBlock);
			redrock.AddIngredient(ItemID.EbonstoneBlock);
			redrock.AddIngredient(ModContent.ItemType<Dimensium>());
			redrock.AddTile(ModContent.TileType<DimensionalForge>());
			redrock.Register();

			Recipe rotseed = Recipe.Create(ItemID.CorruptSeeds);
			rotseed.AddIngredient(ItemID.CrimsonSeeds);
			rotseed.AddIngredient(ModContent.ItemType<Dimensium>());
			rotseed.AddTile(ModContent.TileType<DimensionalForge>());
			rotseed.Register();

			Recipe redseed = Recipe.Create(ItemID.CrimsonSeeds);
			redseed.AddIngredient(ItemID.CorruptSeeds);
			redseed.AddIngredient(ModContent.ItemType<Dimensium>());
			redseed.AddTile(ModContent.TileType<DimensionalForge>());
			redseed.Register();
			#endregion
		}
	}
}