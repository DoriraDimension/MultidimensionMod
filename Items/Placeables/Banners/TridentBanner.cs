using MultidimensionMod.Tiles;
using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria.ID;

namespace MultidimensionMod.Items.Placeables.Banners
{
	public class TridentBanner : ModItem
	{

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Magic Trident Banner");
			Tooltip.SetDefault("A trident that moves on its own, basically a remnant of the old Sea civilisation.\nNow that their owners are gone they aimlessly roam the ocean with no purpose.");
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
			Item.placeStyle = 2;
		}
	}
}
