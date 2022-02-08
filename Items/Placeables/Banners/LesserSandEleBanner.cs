using MultidimensionMod.Tiles;
using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria.ID;

namespace MultidimensionMod.Items.Placeables.Banners
{
	public class LesserSandEleBanner : ModItem
	{

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Lesser Sand Elemental Banner");
			Tooltip.SetDefault("They are actually crystalized mana surrounded by sand, it's unclear yet if they were brought to life naturally or through magic experiments.\nThey will react hostile against every human that enters a desert.\nDuring sandstorms they become even more active and travel to the surface, sometimes following Sand Elementals." +
                "\nDrops:\nMana Sandstone 1-2 100%\nSand Bun 3%");
			DisplayName.AddTranslation(GameCulture.German, "Niederer Sand Elementer Banner");
			Tooltip.AddTranslation(GameCulture.German, "Sie sind eigentlich kristallisiertes Mana umgeben von Sand, es ist unklar ob sie natürlich enstanden sind oder durch magische Experimente.\nSie reagieren feindlich gegenüber jedem Menschen der eine Wüste betritt.\nWährend eines Sandsturms werden sie besonders aktiv und wandern zur oberfläche, manchmal folgen sie dann Sand Elementaren.");
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
			item.placeStyle = 9;
		}
	}
}
