using MultidimensionMod.Tiles.MusicBoxes;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;

namespace MultidimensionMod.Items.Placeables.MusicBoxes
{
	public class MadnessBox : ModItem
	{
		public override void SetStaticDefaults()
		{
			MusicLoader.AddMusicBox(Mod, MusicLoader.GetMusicSlot(Mod, "Sounds/Music/Madness"), ModContent.ItemType<MadnessBox>(), ModContent.TileType<MadnessBoxPlaced>());
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
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
			Item.accessory = true;
		}
	}
}