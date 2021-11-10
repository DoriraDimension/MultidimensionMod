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
			DisplayName.AddTranslation(GameCulture.German, "Smiley Trophäe");
			Tooltip.AddTranslation(GameCulture.German, "Ein stück von dunkler Materie das von Smileys Körper produziert wird.");
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
			item.value = Item.sellPrice(gold: 1);
			item.createTile = ModContent.TileType<BossTrophy>();
			item.placeStyle = 0;
		}
	}
}
