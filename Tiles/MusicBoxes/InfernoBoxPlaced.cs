using MultidimensionMod.Items.Placeables.MusicBoxes;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.DataStructures;
using Terraria.Localization;
using Terraria.ID;

namespace MultidimensionMod.Tiles.MusicBoxes
{
    class InfernoBoxPlaced : ModTile
	{
		public override void SetStaticDefaults()
		{
			Main.tileFrameImportant[Type] = true;
			Main.tileObsidianKill[Type] = true;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
			TileObjectData.newTile.Origin = new Point16(0, 1);
			TileObjectData.newTile.LavaDeath = false;
			TileObjectData.newTile.DrawYOffset = 2;
			TileObjectData.addTile(Type);
            TileID.Sets.DisableSmartCursor[Type] = true;
            LocalizedText name = CreateMapEntryName();
            DustType = ModContent.DustType<Dusts.RazewoodDust>();
            AddMapEntry(new Color(200, 200, 200), name);
            RegisterItemDrop(ModContent.ItemType<InfernoBox>(), 1);
        }

		public override void MouseOver(int i, int j)
		{
			Player player = Main.LocalPlayer;
			player.noThrow = 2;
			player.cursorItemIconEnabled = true;
            player.cursorItemIconID = ModContent.ItemType<InfernoBox>();
        }
	}
}
