using MultidimensionMod.Tiles.MusicBoxes;
using Terraria.ModLoader;
using Terraria.ID;

namespace MultidimensionMod.Items.Placeables.MusicBoxes
{
	public class ColdHellBox : ModItem
	{
		public override void SetStaticDefaults()
		{
			MusicLoader.AddMusicBox(Mod, MusicLoader.GetMusicSlot(Mod, "Sounds/Music/FrozenUnderworld"), ModContent.ItemType<ColdHellBox>(), ModContent.TileType<ColdHellBoxPlaced>());
		}

		public override void SetDefaults()
		{
			Item.useStyle = ItemUseStyleID.Swing;
			Item.useTurn = true;
			Item.useAnimation = 15;
			Item.useTime = 10;
			Item.autoReuse = true;
			Item.consumable = true;
			Item.createTile = ModContent.TileType<ColdHellBoxPlaced>();
			Item.width = 32;
			Item.height = 30;
			Item.rare = ItemRarityID.LightRed;
			Item.value = 0;
			Item.accessory = true;
		}
	}
}