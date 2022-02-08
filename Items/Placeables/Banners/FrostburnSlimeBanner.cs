using MultidimensionMod.Tiles;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace MultidimensionMod.Items.Placeables.Banners
{
	public class FrostburnSlimeBanner : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Frostburn Slime Banner");
			Tooltip.SetDefault("Flying slimes that mastered the power of frostburn, anyone who touches them will be in immense pain." +
                "\nDrops:\nSlime Staff 0.01%\nFrost Core 2%\nFrostburn Wings 2%");
			DisplayName.AddTranslation(GameCulture.German, "Frostbrand Schleim Banner");
			Tooltip.AddTranslation(GameCulture.German, "Fliegende Schleime die die Kraft des Frostbrandes gemeistert haben, jeder der sie berührt wird große Schmerzen erleiden.");
		}

		public override void SetDefaults()
		{
			item.width = 12;
			item.height = 28;
			item.maxStack = 99;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.consumable = true;
			item.rare = ItemRarityID.Blue;
			item.value = Item.sellPrice(silver: 3);
			item.createTile = ModContent.TileType<MonsterBanner>();
			item.placeStyle = 8;
		}
	}
}
