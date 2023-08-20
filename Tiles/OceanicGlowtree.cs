using MultidimensionMod.Items.Placeables;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace MultidimensionMod.Tiles
{
	public class OceanicGlowtree : ModTile
	{
		public override void SetStaticDefaults()
		{
			Main.tileFrameImportant[Type] = true;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style2xX);
			TileObjectData.newTile.LavaDeath = true;
			TileObjectData.newTile.Height = 4;
			TileObjectData.newTile.Width = 2;
			TileObjectData.newTile.CoordinateHeights = new[] { 16, 16, 16, 18 };
			TileObjectData.newTile.CoordinateWidth = 16;
			TileObjectData.newTile.CoordinatePadding = 2;
			TileObjectData.newTile.RandomStyleRange = 3;
            TileID.Sets.DisableSmartCursor[Type] = true;
			TileObjectData.addTile(Type);
			LocalizedText name = CreateMapEntryName();
			AddMapEntry(new Color(31, 22, 45), name);
			DustType = 68;
            RegisterItemDrop(ModContent.ItemType<Glowseed>(), 1);
            RegisterItemDrop(ModContent.ItemType<Glowseed>(), 2);
        }

		public override bool PreDraw(int i, int j, SpriteBatch spriteBatch)
		{
			Tile tile = Main.tile[i, j];
			Texture2D texture = ModContent.Request<Texture2D>("MultidimensionMod/Tiles/OceanicGlowtree").Value;
			Texture2D GlowTexture = ModContent.Request<Texture2D>("MultidimensionMod/Tiles/OceanicGlowtree_Glow").Value;

			Vector2 zero = Main.drawToScreen ? Vector2.Zero : new Vector2(Main.offScreenRange);

			int height = tile.TileFrameY == 66 ? 18 : 16;
			// Offset along the Y axis depending on the current frame
			int frameYOffset = Main.tileFrame[Type];

			spriteBatch.Draw(
	            texture,
	            new Vector2(i * 16 - (int)Main.screenPosition.X, j * 16 - (int)Main.screenPosition.Y) + zero,
	            new Rectangle(tile.TileFrameX, tile.TileFrameY + frameYOffset, 16, height),
	            Lighting.GetColor(i, j), 0f, default, 1f, SpriteEffects.None, 0f);

			// Make sure to draw with Color.White or at least a color that is fully opaque
			// Achieve opaqueness by increasing the alpha channel closer to 255. (lowering closer to 0 will achieve transparency)
			spriteBatch.Draw(
				GlowTexture,
				new Vector2(i * 16 - (int)Main.screenPosition.X, j * 16 - (int)Main.screenPosition.Y) + zero,
				new Rectangle(tile.TileFrameX, tile.TileFrameY + frameYOffset, 16, height),
				Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);

			// Return false to stop vanilla draw
			return false;
		}
	}
}