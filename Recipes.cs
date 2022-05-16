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
			Recipe aglet = Mod.CreateRecipe(ItemID.Aglet); 
			aglet.AddRecipeGroup("IronBar", 5);
			aglet.AddTile(TileID.Anvils);
			aglet.Register();

			Recipe anklet = Mod.CreateRecipe(ItemID.AnkletoftheWind); 
			anklet.AddIngredient(ItemID.JungleSpores, 10);
			anklet.AddIngredient(ItemID.Vine, 2);
			anklet.AddTile(TileID.LivingLoom);
			anklet.Register();

			Recipe blizzard = Mod.CreateRecipe(ItemID.BlizzardinaBottle);
			blizzard.AddIngredient(ItemID.SnowBlock, 10);
			blizzard.AddIngredient(ItemID.Bottle);
			blizzard.AddIngredient(ItemID.Feather, 3);
			blizzard.AddIngredient(ModContent.ItemType<FrostScale>(), 6);
			blizzard.AddTile(TileID.Anvils);
			blizzard.Register();

			Recipe sandstorm = Mod.CreateRecipe(ItemID.SandstorminaBottle);
			sandstorm.AddRecipeGroup("SandBlocks", 25);
			sandstorm.AddIngredient(ItemID.Bottle);
			sandstorm.AddIngredient(ItemID.Feather, 3);
			sandstorm.AddIngredient(ModContent.ItemType<ManaInfusedSandstone>(), 6);
			sandstorm.AddTile(TileID.Anvils);
			sandstorm.Register();

			Recipe cloud = Mod.CreateRecipe(ItemID.CloudinaBottle);
			cloud.AddIngredient(ItemID.Cloud, 25);
			cloud.AddIngredient(ItemID.Bottle);
			cloud.AddIngredient(ItemID.Feather, 3);
			cloud.AddTile(TileID.Anvils);
			cloud.Register();

			Recipe climbClaw = Mod.CreateRecipe(ItemID.ClimbingClaws); 
			climbClaw.AddRecipeGroup("IronBar", 10);
			climbClaw.AddIngredient(ItemID.Spike, 3);
			climbClaw.AddTile(TileID.Anvils);
			climbClaw.Register();

			Recipe spikes = Mod.CreateRecipe(ItemID.ShoeSpikes);
			spikes.AddRecipeGroup("IronBar", 10);
			spikes.AddIngredient(ItemID.Spike, 3);
			spikes.AddTile(TileID.Anvils);
			spikes.Register();

			Recipe carpet = Mod.CreateRecipe(ItemID.FlyingCarpet); 
			carpet.AddIngredient(ItemID.Silk, 15);
			carpet.AddIngredient(ItemID.Cloud, 5);
			carpet.AddIngredient(ModContent.ItemType<ManaInfusedSandstone>(), 3);
			carpet.AddTile(TileID.Loom);
			carpet.Register();

			Recipe hermes = Mod.CreateRecipe(ItemID.HermesBoots); 
			hermes.AddIngredient(ItemID.Leather, 5);
			hermes.AddIngredient(ItemID.SwiftnessPotion, 2);
			hermes.AddTile(TileID.WorkBenches);
			hermes.Register();

			Recipe skates = Mod.CreateRecipe(ItemID.IceSkates); 
			skates.AddIngredient(ItemID.Leather, 5);
			skates.AddRecipeGroup("IronBar", 5);
			skates.AddTile(TileID.WorkBenches);
			skates.Register();

			Recipe waterwalk = Mod.CreateRecipe(ItemID.WaterWalkingBoots); 
			waterwalk.AddIngredient(ItemID.Leather, 5);
			waterwalk.AddIngredient(ItemID.WaterWalkingPotion, 3);
			waterwalk.AddTile(TileID.WorkBenches);
			waterwalk.Register();

			Recipe lava = Mod.CreateRecipe(ItemID.LavaCharm);
			lava.AddIngredient(ItemID.LavaBucket, 2);
			lava.AddIngredient(ItemID.Fireblossom, 3);
			lava.AddIngredient(ItemID.Obsidian, 15);
			lava.AddCondition(Recipe.Condition.NearLava);
			lava.Register();

			Recipe horseSneakers = Mod.CreateRecipe(ItemID.LuckyHorseshoe);
			horseSneakers.AddRecipeGroup("GoldBars", 10);
			horseSneakers.AddIngredient(ItemID.SunplateBlock, 5);
			horseSneakers.AddTile(TileID.SkyMill);
			horseSneakers.Register();

			Recipe balloon = Mod.CreateRecipe(ItemID.ShinyRedBalloon);
			balloon.AddIngredient(ItemID.Gel, 25);
			balloon.AddIngredient(ItemID.Cloud, 10);
			balloon.AddIngredient(ItemID.WhiteString);
			balloon.AddTile(TileID.SkyMill);
			balloon.Register();

			Recipe starband = Mod.CreateRecipe(ItemID.BandofStarpower);
			starband.AddIngredient(ItemID.ManaCrystal);
			starband.AddIngredient(ItemID.ShadowScale, 5);
			starband.AddTile(TileID.DemonAltar);
			starband.Register();

			Recipe panic = Mod.CreateRecipe(ItemID.PanicNecklace);
			panic.AddIngredient(ItemID.LifeCrystal);
			panic.AddIngredient(ItemID.TissueSample, 5);
			panic.AddTile(TileID.DemonAltar);
			panic.Register();

			Recipe magnet = Mod.CreateRecipe(ItemID.CelestialMagnet);
			magnet.AddIngredient(ItemID.FallenStar, 10);
			magnet.AddRecipeGroup("IronBar", 10);
			magnet.AddIngredient(ItemID.Bone, 15);
			magnet.AddTile(TileID.Anvils);
			magnet.Register();

			Recipe potionStone = Mod.CreateRecipe(ItemID.PhilosophersStone);
			potionStone.AddIngredient(ItemID.LifeCrystal, 2);
			potionStone.AddIngredient(ItemID.GreaterHealingPotion, 5);
			potionStone.AddIngredient(ItemID.SoulofLight ,10);
			potionStone.AddTile(TileID.MythrilAnvil);
			potionStone.Register();

			Recipe longImmune = Mod.CreateRecipe(ItemID.CrossNecklace);
			longImmune.AddRecipeGroup("GoldBars", 8);
			longImmune.AddIngredient(ItemID.Chain);
			longImmune.AddIngredient(ItemID.SoulofLight, 3);
			longImmune.AddTile(TileID.MythrilAnvil);
			longImmune.Register();

			Recipe rose = Mod.CreateRecipe(ItemID.ObsidianRose);
			rose.AddIngredient(ItemID.JungleRose);
			rose.AddIngredient(ItemID.Obsidian, 20);
			rose.AddCondition(Recipe.Condition.NearLava);
			rose.Register();

			Recipe cloak = Mod.CreateRecipe(ItemID.StarCloak);
			cloak.AddIngredient(ItemID.FallenStar, 8);
			cloak.AddIngredient(ItemID.Silk, 20);
			cloak.AddTile(TileID.MythrilAnvil);
			cloak.Register();
			#endregion

            #region Ankh Charm Mats
			Recipe bandage = Mod.CreateRecipe(ItemID.AdhesiveBandage);
			bandage.AddIngredient(ItemID.Silk,10);
			bandage.AddIngredient(ItemID.Gel, 5);
			bandage.AddTile(TileID.MythrilAnvil);
			bandage.Register();

			Recipe polish = Mod.CreateRecipe(ItemID.ArmorPolish);
			polish.AddIngredient(ItemID.Bone, 6);
			polish.AddIngredient(ItemID.BeeWax ,10);
			polish.AddTile(TileID.MythrilAnvil);
			polish.Register();

			Recipe bezoar = Mod.CreateRecipe(ItemID.Bezoar);
			bezoar.AddIngredient(ItemID.Stinger, 3);
			bezoar.AddIngredient(ItemID.BeeWax, 5);
			bezoar.AddTile(TileID.MythrilAnvil);
			bezoar.Register();

			Recipe blind = Mod.CreateRecipe(ItemID.Blindfold);
			blind.AddIngredient(ItemID.Silk, 10);
			blind.AddIngredient(ItemID.SoulofNight, 2);
			blind.AddTile(TileID.Loom);
			blind.Register();

			Recipe shield = Mod.CreateRecipe(ItemID.CobaltShield);
			shield.AddRecipeGroup("CobaltBars", 15);
			shield.AddTile(TileID.Anvils);
			shield.Register();

			Recipe clock = Mod.CreateRecipe(ItemID.FastClock);
			clock.AddRecipeGroup("IronBar", 10);
			clock.AddIngredient(ItemID.PixieDust, 10);
			clock.AddTile(TileID.MythrilAnvil);
			clock.Register();

			Recipe scream = Mod.CreateRecipe(ItemID.Megaphone);
			scream.AddRecipeGroup("AdamantiteBars", 5);
			scream.AddIngredient(ItemID.PixieDust, 10);
			scream.AddTile(TileID.MythrilAnvil);
			scream.Register();

			Recipe nazar = Mod.CreateRecipe(ItemID.Nazar);
			nazar.AddIngredient(ItemID.SoulofNight, 10);
			nazar.AddIngredient(ModContent.ItemType<DarkMatterClump>(), 5);
			nazar.AddIngredient(ItemID.Lens, 2);
			nazar.AddTile(TileID.DemonAltar);
			nazar.Register();

			Recipe map = Mod.CreateRecipe(ItemID.TrifoldMap);
			map.AddIngredient(ItemID.Silk, 10);
			map.AddTile(TileID.MythrilAnvil);
			map.Register();

			Recipe vitamins = Mod.CreateRecipe(ItemID.Vitamins);
			vitamins.AddIngredient(ItemID.Hive, 5);
			vitamins.AddIngredient(ItemID.Gel, 10);
			vitamins.AddIngredient(ItemID.Waterleaf, 2);
			vitamins.AddIngredient(ItemID.HallowedSeeds, 4);
			vitamins.AddTile(TileID.MythrilAnvil);
			vitamins.Register();
            #endregion

			#region Cell Phone Mats
			Recipe radar = Mod.CreateRecipe(ItemID.Radar);
			radar.AddRecipeGroup("IronBar", 10);
			radar.AddIngredient(ItemID.Glass, 5);
			radar.AddTile(TileID.Anvils);
			radar.Register();

			Recipe compass = Mod.CreateRecipe(ItemID.Compass);
			compass.AddRecipeGroup("IronBar", 7);
			compass.AddTile(TileID.Anvils);
			compass.Register();

			Recipe deep = Mod.CreateRecipe(ItemID.DepthMeter);
			deep.AddRecipeGroup("IronBar", 8);
			deep.AddIngredient(ItemID.Obsidian, 20);
			deep.AddTile(TileID.Anvils);
			deep.Register();

			Recipe anal = Mod.CreateRecipe(ItemID.LifeformAnalyzer);
			anal.AddRecipeGroup("IronBar", 12);
			anal.AddIngredient(ItemID.Gel, 30);
			anal.AddTile(TileID.Anvils);
			anal.Register();

			Recipe watch = Mod.CreateRecipe(ItemID.Stopwatch);
			watch.AddRecipeGroup("IronBar", 5);
			watch.AddIngredient(ItemID.SilverWatch);
			watch.AddTile(TileID.Anvils);
			watch.Register();

			Recipe watch2 = Mod.CreateRecipe(ItemID.Stopwatch);
			watch2.AddRecipeGroup("IronBar", 5);
			watch2.AddIngredient(ItemID.TungstenWatch);
			watch2.AddTile(TileID.Anvils);
			watch2.Register();

			Recipe tally = Mod.CreateRecipe(ItemID.TallyCounter);
			tally.AddRecipeGroup("IronBar", 5);
			tally.AddIngredient(ItemID.Bone, 16);
			tally.AddTile(TileID.Anvils);
			tally.Register();

			Recipe detect = Mod.CreateRecipe(ItemID.MetalDetector);
			detect.AddRecipeGroup("IronBar", 15);
			detect.AddIngredient(ItemID.Wire, 8);
			detect.AddTile(TileID.MythrilAnvil);
			detect.Register();

			Recipe dps = Mod.CreateRecipe(ItemID.DPSMeter);
			dps.AddRecipeGroup("IronBar", 6);
			dps.AddIngredient(ItemID.Ruby);
			dps.AddTile(TileID.Anvils);
			dps.Register();

			Recipe sex = Mod.CreateRecipe(ItemID.Sextant);
			sex.AddRecipeGroup("GoldBars", 8);
			sex.AddIngredient(ItemID.Lens);
			sex.AddTile(TileID.Anvils);
			sex.Register();

			Recipe radio = Mod.CreateRecipe(ItemID.WeatherRadio);
			radio.AddRecipeGroup("IronBar", 10);
			radio.AddIngredient(ItemID.Cloud, 5);
			radio.AddIngredient(ItemID.RainCloud, 10);
			radio.AddTile(TileID.Anvils);
			radio.Register();

			Recipe fish = Mod.CreateRecipe(ItemID.FishermansGuide);
			fish.AddIngredient(ItemID.Silk, 5);
			fish.AddIngredient(ItemID.Bass, 2);
			fish.AddIngredient(ItemID.Tuna, 2);
			fish.AddIngredient(ItemID.Trout, 2);
			fish.AddTile(TileID.WorkBenches);
			fish.Register();
			#endregion

			#region Weapons
			Recipe fury = Mod.CreateRecipe(ItemID.Starfury);
			fury.AddIngredient(ItemID.FallenStar, 10);
			fury.AddRecipeGroup("GoldBars", 15);
			fury.AddTile(TileID.SkyMill);
			fury.Register();

			Recipe enchant = Mod.CreateRecipe(ItemID.EnchantedSword);
			enchant.AddIngredient(ItemID.GoldBroadsword);
			enchant.AddIngredient(ItemID.FallenStar, 8);
			enchant.AddRecipeGroup("EvilSample", 7);
			enchant.AddTile(TileID.Anvils);
			enchant.Register();

			Recipe enchant2 = Mod.CreateRecipe(ItemID.EnchantedSword);
			enchant2.AddIngredient(ItemID.PlatinumBroadsword);
			enchant2.AddIngredient(ItemID.FallenStar, 8);
			enchant2.AddRecipeGroup("EvilSample", 7);
			enchant2.AddTile(TileID.Anvils);
			enchant2.Register();

			Recipe woodmerang = Mod.CreateRecipe(ItemID.WoodenBoomerang);
			woodmerang.AddRecipeGroup("Wood", 20);
			woodmerang.AddTile(TileID.WorkBenches);
			woodmerang.Register();

			Recipe icemerang = Mod.CreateRecipe(ItemID.IceBoomerang);
			icemerang.AddIngredient(ItemID.WoodenBoomerang);
			icemerang.AddRecipeGroup("IceBlocks", 30);
			icemerang.AddIngredient(ModContent.ItemType<FrostScale>(), 4);
			icemerang.AddTile(TileID.Anvils);
			icemerang.Register();

			Recipe iceblade = Mod.CreateRecipe(ItemID.IceBlade);
			iceblade.AddRecipeGroup("IceBlocks", 43);
			iceblade.AddIngredient(ItemID.Shiverthorn, 2);
			iceblade.AddIngredient(ModContent.ItemType<FrostScale>(), 4);
			iceblade.AddTile(TileID.Anvils);
			iceblade.Register();

			Recipe brand = Mod.CreateRecipe(ItemID.Frostbrand);
			brand.AddIngredient(ItemID.IceBlade);
			brand.AddIngredient(ItemID.FrostCore);
			brand.AddRecipeGroup("AdamantiteBars", 5);
			brand.AddTile(TileID.MythrilAnvil);
			brand.Register();

			Recipe weeb = Mod.CreateRecipe(ItemID.Katana);
			weeb.AddRecipeGroup("IronBar", 10);
			weeb.AddIngredient(ItemID.LavaBucket, 3);
			weeb.AddTile(TileID.Anvils);
			weeb.Register();

			Recipe muramura = Mod.CreateRecipe(ItemID.Muramasa);
			muramura.AddIngredient(ItemID.Katana);
			muramura.AddIngredient(ModContent.ItemType<DarkMatterClump>(), 5);
			muramura.AddTile(TileID.Anvils);
			muramura.Register();

			Recipe sparky = Mod.CreateRecipe(ItemID.WandofSparking);
			sparky.AddRecipeGroup("Wood", 10);
			sparky.AddIngredient(ItemID.Torch, 12);
			sparky.AddTile(TileID.WorkBenches);
			sparky.Register();

			Recipe slime = Mod.CreateRecipe(ItemID.SlimeStaff);
			slime.AddRecipeGroup("Wood", 15);
			slime.AddIngredient(ItemID.Gel, 50);
			slime.AddTile(TileID.WorkBenches);
			slime.Register();

			Recipe boner = Mod.CreateRecipe(ItemID.BoneSword);
			boner.AddIngredient(ItemID.Bone, 46);
			boner.AddTile(TileID.BoneWelder);
			boner.Register();
			#endregion

			#region Tools
			Recipe mirror = Mod.CreateRecipe(ItemID.MagicMirror);
			mirror.AddRecipeGroup("IronBar");
			mirror.AddIngredient(ItemID.FallenStar, 3);
			mirror.AddIngredient(ItemID.Glass, 5);
			mirror.AddTile(TileID.Anvils);
			mirror.Register();

			Recipe mirror2 = Mod.CreateRecipe(ItemID.IceMirror);
			mirror2.AddIngredient(ModContent.ItemType<FrostScale>(), 3);
			mirror2.AddIngredient(ItemID.FallenStar, 3);
			mirror2.AddIngredient(ItemID.Glass, 3);
			mirror2.AddTile(TileID.Anvils);
			mirror2.Register();

			Recipe discord = Mod.CreateRecipe(ItemID.RodofDiscord);
			discord.AddIngredient(ItemID.UnicornHorn, 2);
			discord.AddIngredient(ItemID.PixieDust, 65);
			discord.AddIngredient(ItemID.SoulofLight, 14);
			discord.AddTile(TileID.MythrilAnvil);
			discord.Register();

			Recipe key = Mod.CreateRecipe(ItemID.ShadowKey);
			key.AddIngredient(ItemID.GoldenKey);
			key.AddIngredient(ModContent.ItemType<DarkMatterClump>(), 10);
			key.AddTile(TileID.DemonAltar);
			key.Register();

			Recipe bucket = Mod.CreateRecipe(ItemID.BottomlessBucket);
			bucket.AddIngredient(ItemID.WaterBucket);
			bucket.AddIngredient(ItemID.SoulofLight, 5);
			bucket.AddIngredient(ItemID.SoulofNight, 5);
			bucket.AddIngredient(ModContent.ItemType<Blight2>(), 3);
			bucket.AddTile(TileID.MythrilAnvil);
			bucket.Register();

			Recipe spongebob = Mod.CreateRecipe(ItemID.SuperAbsorbantSponge);
			spongebob.AddIngredient(ItemID.AncientCloth, 3);
			spongebob.AddIngredient(ItemID.SoulofLight, 5);
			spongebob.AddIngredient(ItemID.SoulofNight, 5);
			spongebob.AddIngredient(ModContent.ItemType<Blight2>(), 3);
			spongebob.AddTile(TileID.WorkBenches);
			spongebob.Register();
			#endregion

			#region Tiles
			Recipe milly = Mod.CreateRecipe(ItemID.SkyMill);
			milly.AddIngredient(ItemID.SunplateBlock, 30);
			milly.AddIngredient(ItemID.Cloud, 9);
			milly.AddTile(TileID.Anvils);
			milly.Register();

			Recipe sharp = Mod.CreateRecipe(ItemID.SharpeningStation);
			sharp.AddIngredient(ItemID.StoneBlock, 30);
			sharp.AddRecipeGroup("Wood", 25);
			sharp.AddTile(TileID.HeavyWorkBench);
			sharp.Register();

			Recipe loom = Mod.CreateRecipe(ItemID.LivingLoom);
			loom.AddIngredient(ItemID.Vine, 5);
			loom.AddRecipeGroup("Wood", 34);
			loom.AddTile(TileID.WorkBenches);
			loom.Register();
			#endregion

			#region Consumables
			Recipe worm = Mod.CreateRecipe(ItemID.TruffleWorm);
			worm.AddIngredient(ItemID.Worm);
			worm.AddIngredient(ItemID.GlowingMushroom, 20);
			worm.AddIngredient(ModContent.ItemType<Mushmatter>(), 7);
			worm.AddTile(TileID.Autohammer);
			worm.Register();

			Recipe HP = Mod.CreateRecipe(ItemID.LifeCrystal);
			HP.AddIngredient(ItemID.BottledHoney);
			HP.AddIngredient(ItemID.Ruby, 2);
			HP.AddIngredient(ModContent.ItemType<Mushmatter>(), 3);
			HP.Register();
			#endregion

			#region Materials
			Recipe leather = Mod.CreateRecipe(ItemID.Leather);
			leather.AddIngredient(ItemID.Vertebrae, 5);
			leather.AddTile(TileID.WorkBenches);
			leather.Register();
			#endregion

			#region Transmutation
			Recipe copper = Mod.CreateRecipe(ItemID.CopperBar);
			copper.AddIngredient(ItemID.TinBar);
			copper.AddIngredient(ModContent.ItemType<Dimensium>());
			copper.AddTile(ModContent.TileType<DimensionalForge>());
			copper.Register();

			Recipe tin = Mod.CreateRecipe(ItemID.TinBar);
			tin.AddIngredient(ItemID.CopperBar);
			tin.AddIngredient(ModContent.ItemType<Dimensium>());
			tin.AddTile(ModContent.TileType<DimensionalForge>());
			tin.Register();

			Recipe iron = Mod.CreateRecipe(ItemID.IronBar);
			iron.AddIngredient(ItemID.LeadBar);
			iron.AddIngredient(ModContent.ItemType<Dimensium>());
			iron.AddTile(ModContent.TileType<DimensionalForge>());
			iron.Register();

			Recipe lead = Mod.CreateRecipe(ItemID.LeadBar);
			lead.AddIngredient(ItemID.IronBar);
			lead.AddIngredient(ModContent.ItemType<Dimensium>());
			lead.AddTile(ModContent.TileType<DimensionalForge>());
			lead.Register();

			Recipe silver = Mod.CreateRecipe(ItemID.SilverBar);
			silver.AddIngredient(ItemID.TungstenBar);
			silver.AddIngredient(ModContent.ItemType<Dimensium>());
			silver.AddTile(ModContent.TileType<DimensionalForge>());
			silver.Register();

			Recipe tongue = Mod.CreateRecipe(ItemID.TungstenBar);
			tongue.AddIngredient(ItemID.SilverBar);
			tongue.AddIngredient(ModContent.ItemType<Dimensium>());
			tongue.AddTile(ModContent.TileType<DimensionalForge>());
			tongue.Register();

			Recipe gold = Mod.CreateRecipe(ItemID.GoldBar);
			gold.AddIngredient(ItemID.PlatinumBar);
			gold.AddIngredient(ModContent.ItemType<Dimensium>());
			gold.AddTile(ModContent.TileType<DimensionalForge>());
			gold.Register();

			Recipe platinum = Mod.CreateRecipe(ItemID.PlatinumBar);
			platinum.AddIngredient(ItemID.GoldBar);
			platinum.AddIngredient(ModContent.ItemType<Dimensium>());
			platinum.AddTile(ModContent.TileType<DimensionalForge>());
			platinum.Register();

			Recipe demon = Mod.CreateRecipe(ItemID.DemoniteBar);
			demon.AddIngredient(ItemID.CrimtaneBar);
			demon.AddIngredient(ModContent.ItemType<Dimensium>());
			demon.AddTile(ModContent.TileType<DimensionalForge>());
			demon.Register();

			Recipe crim = Mod.CreateRecipe(ItemID.CrimtaneBar);
			crim.AddIngredient(ItemID.DemoniteBar);
			crim.AddIngredient(ModContent.ItemType<Dimensium>());
			crim.AddTile(ModContent.TileType<DimensionalForge>());
			crim.Register();

			Recipe scale = Mod.CreateRecipe(ItemID.ShadowScale);
			scale.AddIngredient(ItemID.TissueSample);
			scale.AddIngredient(ModContent.ItemType<Dimensium>());
			scale.AddTile(ModContent.TileType<DimensionalForge>());
			scale.Register();

			Recipe sample = Mod.CreateRecipe(ItemID.TissueSample);
			sample.AddIngredient(ItemID.ShadowScale);
			sample.AddIngredient(ModContent.ItemType<Dimensium>());
			sample.AddTile(ModContent.TileType<DimensionalForge>());
			sample.Register();

			Recipe kobold = Mod.CreateRecipe(ItemID.CobaltBar);
			kobold.AddIngredient(ItemID.PalladiumBar);
			kobold.AddIngredient(ModContent.ItemType<Dimensium>());
			kobold.AddTile(ModContent.TileType<DimensionalForge>());
			kobold.Register();

			Recipe palle = Mod.CreateRecipe(ItemID.PalladiumBar);
			palle.AddIngredient(ItemID.CobaltBar);
			palle.AddIngredient(ModContent.ItemType<Dimensium>());
			palle.AddTile(ModContent.TileType<DimensionalForge>());
			palle.Register();

			Recipe myth = Mod.CreateRecipe(ItemID.MythrilBar);
			myth.AddIngredient(ItemID.OrichalcumBar);
		    myth.AddIngredient(ModContent.ItemType<Dimensium>());
			myth.AddTile(ModContent.TileType<DimensionalForge>());
			myth.Register();

			Recipe cum = Mod.CreateRecipe(ItemID.OrichalcumBar);
			cum.AddIngredient(ItemID.MythrilBar);
			cum.AddIngredient(ModContent.ItemType<Dimensium>());
			cum.AddTile(ModContent.TileType<DimensionalForge>());
			cum.Register();

			Recipe adam = Mod.CreateRecipe(ItemID.AdamantiteBar);
			adam.AddIngredient(ItemID.TitaniumBar);
			adam.AddIngredient(ModContent.ItemType<Dimensium>());
			adam.AddTile(ModContent.TileType<DimensionalForge>());
			adam.Register();

			Recipe tits = Mod.CreateRecipe(ItemID.TitaniumBar);
			tits.AddIngredient(ItemID.AdamantiteBar);
			tits.AddIngredient(ModContent.ItemType<Dimensium>());
			tits.AddTile(ModContent.TileType<DimensionalForge>());
			tits.Register();

			Recipe rot = Mod.CreateRecipe(ItemID.RottenChunk);
			rot.AddIngredient(ItemID.Vertebrae);
			rot.AddIngredient(ModContent.ItemType<Dimensium>());
			rot.AddTile(ModContent.TileType<DimensionalForge>());
			rot.Register();

			Recipe vert = Mod.CreateRecipe(ItemID.Vertebrae);
			vert.AddIngredient(ItemID.RottenChunk);
			vert.AddIngredient(ModContent.ItemType<Dimensium>());
			vert.AddTile(ModContent.TileType<DimensionalForge>());
			vert.Register();

			Recipe light = Mod.CreateRecipe(ItemID.SoulofLight);
			light.AddIngredient(ItemID.SoulofNight);
			light.AddIngredient(ModContent.ItemType<Dimensium>());
			light.AddTile(ModContent.TileType<DimensionalForge>());
			light.Register();

			Recipe night = Mod.CreateRecipe(ItemID.SoulofNight);
			night.AddIngredient(ItemID.SoulofLight);
			night.AddIngredient(ModContent.ItemType<Dimensium>());
			night.AddTile(ModContent.TileType<DimensionalForge>());
			night.Register();

			Recipe curse = Mod.CreateRecipe(ItemID.CursedFlame);
			curse.AddIngredient(ItemID.Ichor);
			curse.AddIngredient(ModContent.ItemType<Dimensium>());
			curse.AddTile(ModContent.TileType<DimensionalForge>());
			curse.Register();

			Recipe ichor = Mod.CreateRecipe(ItemID.Ichor);
			ichor.AddIngredient(ItemID.CursedFlame);
			ichor.AddIngredient(ModContent.ItemType<Dimensium>());
			ichor.AddTile(ModContent.TileType<DimensionalForge>());
			ichor.Register();

			Recipe ebon = Mod.CreateRecipe(ItemID.EbonstoneBlock);
			ebon.AddIngredient(ItemID.CrimstoneBlock);
			ebon.AddIngredient(ModContent.ItemType<Dimensium>());
			ebon.AddTile(ModContent.TileType<DimensionalForge>());
			ebon.Register();

			Recipe redrock = Mod.CreateRecipe(ItemID.CrimstoneBlock);
			redrock.AddIngredient(ItemID.EbonstoneBlock);
			redrock.AddIngredient(ModContent.ItemType<Dimensium>());
			redrock.AddTile(ModContent.TileType<DimensionalForge>());
			redrock.Register();

			Recipe rotseed = Mod.CreateRecipe(ItemID.CorruptSeeds);
			rotseed.AddIngredient(ItemID.CrimsonSeeds);
			rotseed.AddIngredient(ModContent.ItemType<Dimensium>());
			rotseed.AddTile(ModContent.TileType<DimensionalForge>());
			rotseed.Register();

			Recipe redseed = Mod.CreateRecipe(ItemID.CrimsonSeeds);
			redseed.AddIngredient(ItemID.CorruptSeeds);
			redseed.AddIngredient(ModContent.ItemType<Dimensium>());
			redseed.AddTile(ModContent.TileType<DimensionalForge>());
			redseed.Register();
			#endregion
		}
	}
}