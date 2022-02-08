using MultidimensionMod.Tiles;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace MultidimensionMod.Items.Placeables.Banners
{
	public class BbyDrakeBanner : ModItem
	{

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ice Drake Juvenile Banner");
			Tooltip.SetDefault("Despite being young, these babies are very aggressive, they attack everything that enters their nesting grounds in the icy caves.\nDuring blizzards they will fly outside and start hunting" +
                "\nDrops:\nFrost Scale 1-2 100%\nDrake Crystal 3%");
			DisplayName.AddTranslation(GameCulture.German, "Eis Draken Jungtier Banner");
			Tooltip.AddTranslation(GameCulture.German, "Obwohl sie jung sind, diese Jungen sind sehr aggressiv, sie attackieren alles was ihre Nistplätze in den eisigen höhlen betritt.\nSie gehen während Blizzards nach draußen um zu jagen.");
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
			item.placeStyle = 7;
		}
	}
}
