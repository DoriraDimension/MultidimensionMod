using MultidimensionMod.Tiles;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace MultidimensionMod.Items.Placeables.Banners
{
	public class DarklingBanner : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Darkling Banner");
			Tooltip.SetDefault("Darklings are beings of pure dark matter, they hide inside the dungeon while their leader roams the land in search of someone.\nDarklings arent very strong alone and even kinda shy but can be threatening in groups.\nTheir original purpose is to spread darkness across the universe but they refuse to do so." +
                "\nDrops:\nDark Matter Clump 1-3 75%");
			DisplayName.AddTranslation(GameCulture.German, "Dunkelling Banner");
			Tooltip.AddTranslation(GameCulture.German, "Dunkellinge sind Wesen aus purer dunkler Materie, sie verstecken sich im Verlies während ihr Anfühere das Land durchstreift auf der suche nach jemanden.\nDunkellinge sind nicht wirklich stark alleine und sogar ein bischen schüchtern können aber gefährlich werden in Gruppen.\nIhr eigentlicher zweck is Dunkelheit im Universum zu verbreiten aber sie weigern sich.");
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
			item.placeStyle = 0;
		}
	}
}
