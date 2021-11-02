using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Placeables
{
	public class AncientDragonSkull : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ancient Dragon Skull");
			Tooltip.SetDefault("A dragon skull from old times, it is no longer cursed.");
			DisplayName.AddTranslation(GameCulture.German, "Uralter Drachenschädel");
			Tooltip.AddTranslation(GameCulture.German, "Ein Drachenschädel aus alten Zeiten, er ist nicht mehr verflucht.");
		}

		public override void SetDefaults()
		{
			item.width = 36;
			item.height = 20;
			item.maxStack = 999;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.consumable = true;
			item.rare = ItemRarityID.Orange;
			item.value = Item.sellPrice(gold: 1);
			item.createTile = ModContent.TileType<Tiles.AncientDragonSkullPlaced>();
		}
	}
}