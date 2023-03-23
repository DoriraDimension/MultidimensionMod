using MultidimensionMod.Tiles.MusicBoxes;
using Terraria.ModLoader;
using Terraria.ID;

namespace MultidimensionMod.Items.Placeables.MusicBoxes
{
	public class MadnessBox : ModItem
	{
		public override void SetStaticDefaults()
		{
			MusicLoader.AddMusicBox(Mod, MusicLoader.GetMusicSlot(Mod, "Sounds/Music/Madness"), ModContent.ItemType<MadnessBox>(), ModContent.TileType<MadnessBoxPlaced>());
		}

		public override void SetDefaults()
		{
			Item.useStyle = ItemUseStyleID.Swing;
			Item.useTurn = true;
			Item.useAnimation = 15;
			Item.useTime = 10;
			Item.autoReuse = true;
			Item.consumable = true;
			Item.createTile = ModContent.TileType<MadnessBoxPlaced>();
			Item.width = 32;
			Item.height = 30;
			Item.rare = ItemRarityID.LightRed;
			Item.value = 0;
			Item.accessory = true;
		}
	}
}