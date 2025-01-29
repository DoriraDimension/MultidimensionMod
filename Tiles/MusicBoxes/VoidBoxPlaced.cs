using MultidimensionMod.Items.Placeables.MusicBoxes;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ObjectData;
using Terraria.DataStructures;
using Microsoft.Xna.Framework.Graphics;

namespace MultidimensionMod.Tiles.MusicBoxes
{
    class VoidBoxPlaced : ModTile
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
            DustType = ModContent.DustType<Dusts.DoomDust>();
            AddMapEntry(new Color(200, 200, 200), name);
		}

		public override void MouseOver(int i, int j)
		{
			Player player = Main.LocalPlayer;
			player.noThrow = 2;
            player.cursorItemIconEnabled = true;
            player.cursorItemIconID = ModContent.ItemType<VoidBox>();
        }

        public override void DrawEffects(int i, int j, SpriteBatch spriteBatch, ref TileDrawInfo drawData)
        {
            Tile tile = Main.tile[i, j];

            if (Main.gamePaused || !Main.instance.IsActive || Lighting.UpdateEveryFrame && !Main.rand.NextBool(4))
            {
                return;
            }

            if (tile.TileFrameX == 36 && tile.TileFrameY % 36 == 0 && (int)Main.timeForVisualEffects % 7 == 0 && Main.rand.NextBool(3))
            {
                int noteType = Main.rand.Next(570, 573);
                Vector2 position = new Vector2(i * 16 + 8, j * 16 - 8);
                Vector2 velocity = new Vector2(Main.WindForVisuals * 2f, -0.5f);
                velocity.X *= 1f + Main.rand.NextFloat(-0.5f, 0.5f);
                velocity.Y *= 1f + Main.rand.NextFloat(-0.5f, 0.5f);
                if (noteType == 572)
                {
                    position.X -= 8f;
                }
                if (noteType == 571)
                {
                    position.X -= 4f;
                }
                Gore.NewGore(new EntitySource_TileUpdate(i, j), position, velocity, noteType, 0.8f);
            }
        }
    }
}
