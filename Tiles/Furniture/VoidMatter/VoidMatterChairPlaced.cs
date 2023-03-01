using MultidimensionMod.Items.Placeables.Furniture.VoidMatter;
using MultidimensionMod.Dusts;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Enums;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.DataStructures;
using Terraria.GameContent.ObjectInteractions;
using Terraria.GameContent;

namespace MultidimensionMod.Tiles.Furniture.VoidMatter
{
	public class VoidMatterChairPlaced : ModTile
	{
		public override void SetStaticDefaults()
		{
			Main.tileFrameImportant[Type] = true;
			Main.tileNoAttach[Type] = true;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style1x2);
			TileObjectData.newTile.CoordinateHeights = new[] { 16, 18 };
			TileObjectData.newTile.Direction = TileObjectDirection.PlaceLeft;
			TileObjectData.newTile.StyleWrapLimit = 2;
			TileObjectData.newTile.StyleMultiplier = 2;
			TileObjectData.newTile.StyleHorizontal = true;
			TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
			TileObjectData.newAlternate.Direction = TileObjectDirection.PlaceRight;
			TileObjectData.addAlternate(1);
			TileObjectData.addTile(Type);
			TileID.Sets.DisableSmartCursor[Type] = true;
			TileID.Sets.HasOutlines[Type] = true;
			TileID.Sets.CanBeSatOnForNPCs[Type] = true;
			TileID.Sets.CanBeSatOnForPlayers[Type] = true;
			AddToArray(ref TileID.Sets.RoomNeeds.CountsAsChair);
			AdjTiles = new int[] { TileID.Chairs };
			LocalizedText name = CreateMapEntryName();
			// name.SetDefault("Void Fabricator");
			AddMapEntry(new Color(25, 19, 39), name);
			DustType = ModContent.DustType<DarkDust>();
		}

		public override void NumDust(int i, int j, bool fail, ref int num)
		{
			num = 1;
		}

		public override void KillMultiTile(int i, int j, int frameX, int frameY) => Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 16, 32, ModContent.ItemType<VoidMatterChair>());
	}
}