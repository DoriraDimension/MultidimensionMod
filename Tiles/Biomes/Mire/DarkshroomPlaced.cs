using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MultidimensionMod.Items.Materials;
using Terraria;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace MultidimensionMod.Tiles.Biomes.Mire
{
    public class DarkshroomPlaced : ModTile
	{
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileCut[Type] = true;

            Main.tileMergeDirt[Type] = true;
            //Main.tileBlockLight[Type] = true;
            Main.tileLighted[Type] = false;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
            TileObjectData.newTile.RandomStyleRange = 4;
            TileObjectData.addTile(Type);
            RegisterItemDrop(ModContent.ItemType<Darkshroom>());
            RegisterItemDrop(ModContent.ItemType<Darkshroom>(), 1);
            RegisterItemDrop(ModContent.ItemType<Darkshroom>(), 2);
            RegisterItemDrop(ModContent.ItemType<Darkshroom>(), 3);
        }

        public override bool CreateDust(int i, int j, ref int type)
        {
            return false;
        }


        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = 10;
        }

        public override bool PreDraw(int i, int j, SpriteBatch spriteBatch)
        {
            Tile tile = Main.tile[i, j];
            Texture2D texture = ModContent.Request<Texture2D>("MultidimensionMod/Tiles/Biomes/Mire/DarkshroomPlaced").Value;
            Texture2D GlowTexture = ModContent.Request<Texture2D>("MultidimensionMod/Tiles/Biomes/Mire/DarkshroomPlaced_Glow").Value;

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
            if (!Main.dayTime)
            {
                spriteBatch.Draw(
                GlowTexture,
                new Vector2(i * 16 - (int)Main.screenPosition.X, j * 16 - (int)Main.screenPosition.Y) + zero,
                new Rectangle(tile.TileFrameX, tile.TileFrameY + frameYOffset, 16, height),
                Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
            }

            // Return false to stop vanilla draw
            return false;
        }
    }

}