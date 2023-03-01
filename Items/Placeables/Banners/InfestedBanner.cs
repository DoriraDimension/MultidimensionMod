using MultidimensionMod.Tiles;
using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria.ID;

namespace MultidimensionMod.Items.Placeables.Banners
{
	public class InfestedBanner : ModItem
	{

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Infested Abomination Banner");
			// Tooltip.SetDefault("It was possibly once human but is now just a disgusting thing, these weird creatures are hosts to a local species of rot loving flies.\nThey drip green stinky goo everywhere they walk and spit disgusting liquid with every movement of their mouth.");
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
			Item.placeStyle = 1;
		}
	}
}
