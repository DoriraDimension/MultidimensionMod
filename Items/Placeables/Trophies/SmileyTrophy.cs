using MultidimensionMod.Tiles;
using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria.ID;

namespace MultidimensionMod.Items.Placeables.Trophies
{
	public class SmileyTrophy : ModItem
	{
		public override void SetStaticDefaults()
        {
			DisplayName.SetDefault("SmileyTrophy");
			Tooltip.SetDefault("A chunk of dark matter that is produced by Smiley's body.");
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
			Item.value = Item.sellPrice(gold: 1);
			Item.createTile = ModContent.TileType<BossTrophy>();
			Item.placeStyle = 0;
		}
	}
}
