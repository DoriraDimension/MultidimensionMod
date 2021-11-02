using MultidimensionMod.Items.Materials;
using MultidimensionMod.Tiles;
using System;
using System.Linq;
using Terraria;
using Terraria.ModLoader;

namespace MultidimensionMod
{
	internal class Recipes
	{
		private static ModRecipe GetNewRecipe()
		{
			return new ModRecipe(ModContent.GetInstance<MultidimensionMod>());
		}

		public static void AddAccessorieRecipes(Mod mod)
        {
			ModRecipe recipe = new ModRecipe(mod); //Aglet
			recipe.AddRecipeGroup("IronBar", 5);
			recipe.SetResult(285);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod); //Anklet of the Wind
			recipe.AddIngredient(331, 10);
			recipe.AddIngredient(210, 2);
			recipe.AddTile(16);
			recipe.SetResult(212);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod); //Blizzard in a Bottle
			recipe.AddIngredient(593, 25);
			recipe.AddIngredient(31);
			recipe.AddIngredient(320, 3);
			recipe.AddIngredient(ModContent.ItemType<FrostScale>(), 6);
			recipe.AddTile(16);
			recipe.SetResult(987);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod); //Sandstorm in a Bottle
			recipe.AddRecipeGroup("SandBlocks", 25);
			recipe.AddIngredient(31);
			recipe.AddIngredient(320, 3);
			recipe.AddIngredient(ModContent.ItemType<ManaInfusedSandstone>(), 6);
			recipe.AddTile(16);
			recipe.SetResult(857);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod); //Cloud in a Bottle
			recipe.AddIngredient(751, 25);
			recipe.AddIngredient(31);
			recipe.AddIngredient(320, 3);
			recipe.AddTile(16);
			recipe.SetResult(53);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod); //Climbing Claws
			recipe.AddRecipeGroup("IronBar", 10);
			recipe.AddIngredient(147, 3);
			recipe.AddTile(16);
			recipe.SetResult(953);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod); //Shoe Spikes
			recipe.AddRecipeGroup("IronBar", 10);
			recipe.AddIngredient(147, 3);
			recipe.AddTile(16);
			recipe.SetResult(975);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod); //FlyingCarpet
			recipe.AddIngredient(3794, 10);
			recipe.AddIngredient(575, 5);
			recipe.AddIngredient(ModContent.ItemType<ManaInfusedSandstone>(), 3);
			recipe.AddTile(16);
			recipe.SetResult(934);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod); //Hermes Boots
			recipe.AddIngredient(259, 5);
			recipe.AddIngredient(290, 2);
			recipe.AddTile(18);
			recipe.SetResult(54);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod); //Ice Skates
			recipe.AddIngredient(259, 10);
			recipe.AddRecipeGroup("IronBar", 5);
			recipe.AddTile(16);
			recipe.SetResult(950);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod); //Water Walking Boots
			recipe.AddIngredient(259, 10);
			recipe.AddIngredient(302, 3);
			recipe.AddTile(18);
			recipe.SetResult(863);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod); //Lava Charm
			recipe.AddIngredient(207, 2);
			recipe.AddIngredient(318, 3);
			recipe.AddIngredient(173, 15);
			recipe.AddTile(18);
			recipe.SetResult(906);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod); //Lucky Horseshoe
			recipe.AddRecipeGroup("GoldBars", 10);
			recipe.AddIngredient(824, 5);
			recipe.AddTile(305);
			recipe.SetResult(158);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod); //It's Balloon
			recipe.AddIngredient(23, 25);
			recipe.AddIngredient(751, 10);
			recipe.AddIngredient(3306);
			recipe.AddTile(305);
			recipe.SetResult(159);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod); //Starband
			recipe.AddIngredient(109);
			recipe.AddIngredient(86, 5);
			recipe.AddTile(26);
			recipe.SetResult(111);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod); //Panic Necklace
			recipe.AddIngredient(29);
			recipe.AddIngredient(1329, 5);
			recipe.AddTile(26);
			recipe.SetResult(1290);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod); //Celestial Magnet
			recipe.AddIngredient(109, 3);
			recipe.AddRecipeGroup("IronBar", 10);
			recipe.AddIngredient(154, 15);
			recipe.AddTile(16);
			recipe.SetResult(2219);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod); //Potion Stone
			recipe.AddIngredient(29, 2);
			recipe.AddIngredient(520, 10);
			recipe.AddTile(134);
			recipe.SetResult(535);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod); //Cross Necklace
			recipe.AddRecipeGroup("GoldBars", 8);
			recipe.AddIngredient(85);
			recipe.AddIngredient(520, 3);
			recipe.AddTile(134);
			recipe.SetResult(554);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod); //Obsidian Rose
			recipe.AddIngredient(208);
			recipe.AddIngredient(173, 20);
			recipe.AddTile(16);
			recipe.SetResult(1323);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod); //Star Cloak
			recipe.AddIngredient(75, 8);
			recipe.AddIngredient(225, 20);
			recipe.AddTile(134);
			recipe.SetResult(532);
			recipe.AddRecipe();
		}

		public static void AddAnkhCharmMatsRecipes(Mod mod)
        {
			ModRecipe recipe = new ModRecipe(mod); //Pflaster
			recipe.AddIngredient(225, 10);
			recipe.AddIngredient(23, 5);
			recipe.AddTile(134);
			recipe.SetResult(885);
			recipe.AddRecipe();

		    recipe = new ModRecipe(mod); //Armor Polish
			recipe.AddIngredient(154, 10);
			recipe.AddTile(134);
			recipe.SetResult(886);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod); //Bezoar
			recipe.AddIngredient(209, 3);
			recipe.AddIngredient(2431, 5);
			recipe.AddTile(16);
			recipe.SetResult(887);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod); //Blindfold
			recipe.AddIngredient(225, 10);
			recipe.AddTile(134);
			recipe.SetResult(888);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod); //Cobalt Shield
			recipe.AddRecipeGroup("CobaltBars", 15);
			recipe.AddTile(16);
			recipe.SetResult(156);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod); //Fast Cock :3
			recipe.AddRecipeGroup("IronBar", 10);
			recipe.AddIngredient(501, 20);
			recipe.AddTile(134);
			recipe.SetResult(889);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod); //Megaphone
			recipe.AddIngredient(391, 5);
			recipe.AddIngredient(501, 10);
			recipe.AddTile(134);
			recipe.SetResult(890);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod); //Megaphone 2
			recipe.AddIngredient(1198, 5);
			recipe.AddIngredient(501, 10);
			recipe.AddTile(134);
			recipe.SetResult(890);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod); //Nazar
			recipe.AddIngredient(521, 10);
			recipe.AddIngredient(ModContent.ItemType<DarkMatterClump>(), 5);
			recipe.AddIngredient(38, 3);
			recipe.AddTile(134);
			recipe.SetResult(891);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod); //Trifold Map
			recipe.AddIngredient(225, 10);
			recipe.AddTile(134);
			recipe.SetResult(893);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod); //Vitamine
			recipe.AddIngredient(1134, 5);
			recipe.AddIngredient(23, 10);
			recipe.AddIngredient(317, 2);
			recipe.AddTile(134);
			recipe.SetResult(892);
			recipe.AddRecipe();
		}

		public static void AddCellPhoneMatsRecipes(Mod mod)
        {
			ModRecipe recipe = new ModRecipe(mod); //Radar
			recipe.AddRecipeGroup("IronBar", 10);
			recipe.AddIngredient(170, 5);
			recipe.AddTile(16);
			recipe.SetResult(3084);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod); //Compass
			recipe.AddRecipeGroup("IronBar", 7);
			recipe.AddTile(16);
			recipe.SetResult(393);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod); //Depth Meter
			recipe.AddRecipeGroup("IronBar", 8);
			recipe.AddIngredient(173, 5);
			recipe.AddTile(16);
			recipe.SetResult(18);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod); //Lifeform Analyser
			recipe.AddRecipeGroup("IronBar", 12);
			recipe.AddIngredient(23, 30);
			recipe.AddTile(16);
			recipe.SetResult(3118);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod); //Stop Watch
			recipe.AddRecipeGroup("IronBar", 5);
			recipe.AddIngredient(16);
			recipe.AddTile(16);
			recipe.SetResult(3099);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod); //Stop Watch 2
			recipe.AddRecipeGroup("IronBar", 5);
			recipe.AddIngredient(708);
			recipe.AddTile(16);
			recipe.SetResult(3099);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod); //Tally Counter
			recipe.AddRecipeGroup("IronBar", 5);
			recipe.AddIngredient(154, 5);
			recipe.AddTile(16);
			recipe.SetResult(3095);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod); //Metal Detector
			recipe.AddRecipeGroup("IronBar", 15);
			recipe.AddIngredient(530, 8);
			recipe.AddTile(16);
			recipe.SetResult(3102);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod); //Dps Meter
			recipe.AddRecipeGroup("IronBar", 6);
			recipe.AddIngredient(178);
			recipe.AddTile(16);
			recipe.SetResult(3119);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod); //Sextant
			recipe.AddRecipeGroup("GoldBars", 8);
			recipe.AddIngredient(38);
			recipe.AddTile(16);
			recipe.SetResult(3096);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod); //Weather Radio
			recipe.AddRecipeGroup("IronBar", 10);
			recipe.AddIngredient(751, 5);
			recipe.AddTile(16);
			recipe.SetResult(3037);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod); //Fisch Kalender
			recipe.AddIngredient(225, 5);
			recipe.AddTile(16);
			recipe.SetResult(3120);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod); //Flesh Knuckles from Sonic haha yes 
			recipe.AddIngredient(1330, 5);
			recipe.AddIngredient(1257, 8);
			recipe.AddIngredient(1329, 10);
			recipe.AddIngredient(521, 3);
			recipe.AddTile(26);
			recipe.SetResult(3016);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod); //Putrid Scent, sniff sniff, aaaahhhhh UwU
			recipe.AddIngredient(68, 12);
			recipe.AddIngredient(57, 4);
			recipe.AddIngredient(86, 8);
			recipe.AddIngredient(521, 6);
			recipe.AddTile(26);
			recipe.SetResult(3015);
			recipe.AddRecipe();
		}

		public static void AddWeaponRecipes(Mod mod)
		{
			ModRecipe recipe = new ModRecipe(mod); //Starfury
			recipe.AddIngredient(75, 10);
			recipe.AddRecipeGroup("GoldBars", 15);
			recipe.AddTile(305);
			recipe.SetResult(65);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod); //Enchanted Sword
			recipe.AddIngredient(3520);
			recipe.AddIngredient(109, 2);
			recipe.AddRecipeGroup("EvilSample", 5);
			recipe.AddTile(16);
			recipe.SetResult(989);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod); //Enchanted Sword 2
			recipe.AddIngredient(3484);
			recipe.AddIngredient(109, 2);
			recipe.AddRecipeGroup("EvilSample", 5);
			recipe.AddTile(16);
			recipe.SetResult(989);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod); //Wood Boomerang
			recipe.AddRecipeGroup("Wood", 20);
			recipe.AddTile(18);
			recipe.SetResult(284);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod); //Ice Boomerang
			recipe.AddIngredient(284);
			recipe.AddRecipeGroup("IceBlocks", 30);
			recipe.AddIngredient(ModContent.ItemType<FrostScale>(), 4);
			recipe.AddTile(16);
			recipe.SetResult(670);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod); //Ice Blade
			recipe.AddIngredient(3520);
			recipe.AddIngredient(2358, 2);
			recipe.AddIngredient(ModContent.ItemType<FrostScale>(), 4);
			recipe.AddTile(16);
			recipe.SetResult(724);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod); //Ice Blade 2
			recipe.AddIngredient(3484);
			recipe.AddIngredient(2358, 2);
			recipe.AddIngredient(ModContent.ItemType<FrostScale>(), 4);
			recipe.AddTile(16);
			recipe.SetResult(724);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod); //Frostbrand
			recipe.AddIngredient(724);
			recipe.AddIngredient(2161);
			recipe.AddRecipeGroup("AdamantiteBars", 5);
			recipe.AddTile(134);
			recipe.SetResult(676);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod); //Katana
			recipe.AddRecipeGroup("IronBar", 10);
			recipe.AddIngredient(207, 3);
			recipe.AddTile(16);
			recipe.SetResult(2273);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod); //Muramasa
			recipe.AddIngredient(2273);
			recipe.AddIngredient(ModContent.ItemType<DarkMatterClump>(), 5);
			recipe.AddTile(16);
			recipe.SetResult(155);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod); //Spark Wand
			recipe.AddRecipeGroup("Wood", 10);
			recipe.AddIngredient(8, 5);
			recipe.AddTile(18);
			recipe.SetResult(3069);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod); //Slime Staff~
			recipe.AddRecipeGroup("Wood", 15);
			recipe.AddIngredient(23, 50);
			recipe.AddTile(18);
			recipe.SetResult(1309);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod); //Bladetongue
			recipe.AddIngredient(2319);
			recipe.AddIngredient(1329, 15);
			recipe.AddIngredient(1257, 5);
			recipe.AddIngredient(1332, 5);
			recipe.AddIngredient(521, 3);
			recipe.AddTile(26);
			recipe.SetResult(3211);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod); //Fetid Bagnakkaka
			recipe.AddIngredient(1329, 20);
			recipe.AddIngredient(1257, 12);
			recipe.AddIngredient(521, 6);
			recipe.AddTile(26);
			recipe.SetResult(3013);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod); //Life Drain
			recipe.AddIngredient(154, 26);
			recipe.AddIngredient(1329, 16);
			recipe.AddIngredient(1257, 7);
			recipe.AddIngredient(521, 8);
			recipe.AddTile(26);
			recipe.SetResult(3006);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod); //Toxicarp
			recipe.AddIngredient(2318);
			recipe.AddIngredient(86, 15);
			recipe.AddIngredient(57, 5);
			recipe.AddIngredient(521, 3);
			recipe.AddTile(26);
			recipe.SetResult(3210);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod); //Chain Guillotina
			recipe.AddIngredient(85, 6);
			recipe.AddRecipeGroup("IronBar", 10);
			recipe.AddIngredient(57, 7);
			recipe.AddIngredient(521, 10);
			recipe.AddTile(26);
			recipe.SetResult(3012);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod); //Clinger Staff
			recipe.AddIngredient(86, 18);
			recipe.AddIngredient(57, 8);
			recipe.AddIngredient(522, 12);
			recipe.AddIngredient(521, 7);
			recipe.AddTile(26);
			recipe.SetResult(3014);
			recipe.AddRecipe();
		}

		public static void AddToolRecipes(Mod mod)
        {
			ModRecipe recipe = new ModRecipe(mod); //Magic Mirror
			recipe.AddRecipeGroup("IronBar", 10);
			recipe.AddIngredient(75, 3);
			recipe.AddIngredient(170, 5);
			recipe.AddTile(16);
			recipe.SetResult(50);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod); //Ice Mirror
			recipe.AddIngredient(ModContent.ItemType<FrostScale>(), 3);
			recipe.AddIngredient(75, 3);
			recipe.AddIngredient(170, 5);
			recipe.AddTile(16);
			recipe.SetResult(3199);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod); //Rod of Discord
			recipe.AddIngredient(526, 2);
			recipe.AddIngredient(501, 65);
			recipe.AddIngredient(520, 25);
			recipe.AddTile(134);
			recipe.SetResult(1326);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod); //Shadow Key
			recipe.AddIngredient(327);
			recipe.AddIngredient(ModContent.ItemType<DarkMatterClump>(), 10);
			recipe.AddTile(134);
			recipe.SetResult(329);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod); //Bottomless Bucket
			recipe.AddIngredient(206);
			recipe.AddIngredient(520, 5);
			recipe.AddIngredient(521, 5);
			recipe.AddIngredient(ModContent.ItemType<Blight2>(), 3);
			recipe.AddTile(134);
			recipe.SetResult(3031);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod); //Spongebob
			recipe.AddIngredient(3794, 5);
			recipe.AddIngredient(520, 5);
			recipe.AddIngredient(521, 5);
			recipe.AddIngredient(ModContent.ItemType<Blight2>(), 3);
			recipe.AddTile(134);
			recipe.SetResult(3032);
			recipe.AddRecipe();
		}

		public static void AddTileRecipes(Mod mod)
        {
			ModRecipe recipe = new ModRecipe(mod); //Sky Mill
			recipe.AddIngredient(824, 30);
			recipe.AddIngredient(751, 5);
			recipe.AddTile(16);
			recipe.SetResult(2197);
			recipe.AddRecipe();

		    recipe = new ModRecipe(mod); //Sharpening Station
			recipe.AddIngredient(3, 30);
			recipe.AddRecipeGroup("Wood", 25);
			recipe.AddTile(283);
			recipe.SetResult(3198);
			recipe.AddRecipe();
		}

		public static void AddConsumablesRecipes(Mod mod)
        {
			ModRecipe recipe = new ModRecipe(mod); //Truffle Worm
			recipe.AddIngredient(2002);
			recipe.AddIngredient(183, 20);
			recipe.AddTile(16);
			recipe.SetResult(2673);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod); //Heart Crystal
			recipe.AddIngredient(1134);
			recipe.AddIngredient(178, 2);
			recipe.AddRecipeGroup("EvilSample", 3);
			recipe.AddTile(16);
			recipe.SetResult(29);
			recipe.AddRecipe();
		}

		public static void AddMaterialRecipes(Mod mod)
        {
			ModRecipe recipe = new ModRecipe(mod); //Leather
			recipe.AddIngredient(1330, 5);
			recipe.AddTile(18);
			recipe.SetResult(259);
			recipe.AddRecipe();
		}

		public static void AddTransmutationRecipes(Mod mod)
        {
			ModRecipe recipe = new ModRecipe(mod); //Copper
			recipe.AddIngredient(703);
			recipe.AddIngredient(ModContent.ItemType<Dimensium>());
			recipe.AddTile(ModContent.TileType<DimensionalForge>());
			recipe.SetResult(20);
			recipe.AddRecipe();

            recipe = new ModRecipe(mod); //Tin
			recipe.AddIngredient(20);
			recipe.AddIngredient(ModContent.ItemType<Dimensium>());
			recipe.AddTile(ModContent.TileType<DimensionalForge>());
			recipe.SetResult(703);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod); //Iron
			recipe.AddIngredient(704);
			recipe.AddIngredient(ModContent.ItemType<Dimensium>());
			recipe.AddTile(ModContent.TileType<DimensionalForge>());
			recipe.SetResult(22);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod); //Lead
			recipe.AddIngredient(22);
			recipe.AddIngredient(ModContent.ItemType<Dimensium>());
			recipe.AddTile(ModContent.TileType<DimensionalForge>());
			recipe.SetResult(704);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod); //Silver
			recipe.AddIngredient(705);
			recipe.AddIngredient(ModContent.ItemType<Dimensium>());
			recipe.AddTile(ModContent.TileType<DimensionalForge>());
			recipe.SetResult(21);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod); //Tungsten
			recipe.AddIngredient(21);
			recipe.AddIngredient(ModContent.ItemType<Dimensium>());
			recipe.AddTile(ModContent.TileType<DimensionalForge>());
			recipe.SetResult(705);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod); //Gold
			recipe.AddIngredient(706);
			recipe.AddIngredient(ModContent.ItemType<Dimensium>());
			recipe.AddTile(ModContent.TileType<DimensionalForge>());
			recipe.SetResult(19);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod); //Platinum
			recipe.AddIngredient(19);
			recipe.AddIngredient(ModContent.ItemType<Dimensium>());
			recipe.AddTile(ModContent.TileType<DimensionalForge>());
			recipe.SetResult(706);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod); //Crimtane
			recipe.AddIngredient(57);
			recipe.AddIngredient(ModContent.ItemType<Dimensium>());
			recipe.AddTile(ModContent.TileType<DimensionalForge>());
			recipe.SetResult(1257);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod); //Demonite
			recipe.AddIngredient(1257);
			recipe.AddIngredient(ModContent.ItemType<Dimensium>());
			recipe.AddTile(ModContent.TileType<DimensionalForge>());
			recipe.SetResult(57);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod); //Tissue Sample
			recipe.AddIngredient(86);
			recipe.AddIngredient(ModContent.ItemType<Dimensium>());
			recipe.AddTile(ModContent.TileType<DimensionalForge>());
			recipe.SetResult(1329);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod); //Shadow Scale
			recipe.AddIngredient(1329);
			recipe.AddIngredient(ModContent.ItemType<Dimensium>());
			recipe.AddTile(ModContent.TileType<DimensionalForge>());
			recipe.SetResult(86);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod); //Cobalt
			recipe.AddIngredient(1184);
			recipe.AddIngredient(ModContent.ItemType<Dimensium>());
			recipe.AddTile(ModContent.TileType<DimensionalForge>());
			recipe.SetResult(381);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod); //Palladium
			recipe.AddIngredient(381);
			recipe.AddIngredient(ModContent.ItemType<Dimensium>());
			recipe.AddTile(ModContent.TileType<DimensionalForge>());
			recipe.SetResult(1184);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod); //Mythril
			recipe.AddIngredient(1191);
			recipe.AddIngredient(ModContent.ItemType<Dimensium>());
			recipe.AddTile(ModContent.TileType<DimensionalForge>());
			recipe.SetResult(382);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod); //Ori Cum
			recipe.AddIngredient(382);
			recipe.AddIngredient(ModContent.ItemType<Dimensium>());
			recipe.AddTile(ModContent.TileType<DimensionalForge>());
			recipe.SetResult(1191);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod); //Adam
			recipe.AddIngredient(1198);
			recipe.AddIngredient(ModContent.ItemType<Dimensium>());
			recipe.AddTile(ModContent.TileType<DimensionalForge>());
			recipe.SetResult(391);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod); //Titstanium
			recipe.AddIngredient(391);
			recipe.AddIngredient(ModContent.ItemType<Dimensium>());
			recipe.AddTile(ModContent.TileType<DimensionalForge>());
			recipe.SetResult(1198);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod); //Rotten Chunk
			recipe.AddIngredient(1330);
			recipe.AddIngredient(ModContent.ItemType<Dimensium>());
			recipe.AddTile(ModContent.TileType<DimensionalForge>());
			recipe.SetResult(68);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod); //Vertebra
			recipe.AddIngredient(68);
			recipe.AddIngredient(ModContent.ItemType<Dimensium>());
			recipe.AddTile(ModContent.TileType<DimensionalForge>());
			recipe.SetResult(1330);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod); //Soul of dont look in the sun
			recipe.AddIngredient(521);
			recipe.AddIngredient(ModContent.ItemType<Dimensium>());
			recipe.AddTile(ModContent.TileType<DimensionalForge>());
			recipe.SetResult(520);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod); //Soul of I cant hear you its too dark
			recipe.AddIngredient(520);
			recipe.AddIngredient(ModContent.ItemType<Dimensium>());
			recipe.AddTile(ModContent.TileType<DimensionalForge>());
			recipe.SetResult(521);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod); //God Blood
			recipe.AddIngredient(522);
			recipe.AddIngredient(ModContent.ItemType<Dimensium>());
			recipe.AddTile(ModContent.TileType<DimensionalForge>());
			recipe.SetResult(1332);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod); //Green Fire
			recipe.AddIngredient(1332);
			recipe.AddIngredient(ModContent.ItemType<Dimensium>());
			recipe.AddTile(ModContent.TileType<DimensionalForge>());
			recipe.SetResult(522);
			recipe.AddRecipe();
		}
	}
}