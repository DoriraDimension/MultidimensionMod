using MultidimensionMod.Tiles;
using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria.ID;

namespace MultidimensionMod.Items.Placeables.Banners
{
	public class DarklingBanner : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Darkling Banner");
			Tooltip.SetDefault("Darklings are beings of pure dark matter, they hide inside the dungeon while their leader roams the land in search of someone.\nDarklings arent very strong alone and even kinda shy but can be threatening in groups.\nTheir original purpose is to spread darkness across the universe but they refuse to do so.");
		}
		public override void SetDefaults()
		{
			Item.width = 12;
			Item.height = 28;
			Item.maxStack = 99;
			Item.useTurn = true;
			Item.autoReuse = true;
			Item.useAnimation = 15;
			Item.useTime = 10;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.consumable = true;
			Item.rare = ItemRarityID.Blue;
			Item.value = Item.sellPrice(silver: 3);
			Item.createTile = ModContent.TileType<MonsterBanner>();
			Item.placeStyle = 0;
		}
	}
}
