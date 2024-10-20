﻿using MultidimensionMod.Items.Placeables.Biomes.Mire;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Metadata;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.Enums;
using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace MultidimensionMod.Tiles.Biomes.Mire
{
    public class MireFoliageBig : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileCut[Type] = false;
            Main.tileSolid[Type] = false;
            TileObjectData.newTile.Width = 3;
            TileObjectData.newTile.Height = 2;
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16 };
            TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile, TileObjectData.newTile.Width, 0);
            TileObjectData.newTile.UsesCustomCanPlace = true;
            TileObjectData.newTile.AnchorValidTiles = new int[] { ModContent.TileType<MireGrass>() };
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.RandomStyleRange = 9;
            TileObjectData.newTile.CoordinateWidth = 48;
            TileObjectData.newTile.CoordinatePadding = 2;
            TileObjectData.newTile.Origin = new Point16(0, 1);
            TileObjectData.addTile(Type);
            DustType = ModContent.DustType<Dusts.BogwoodDust>();
            HitSound = SoundID.Grass;
        }
        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = 10;
        }
        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            if (Main.rand.NextBool(50))
                Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 32, 32, ModContent.ItemType<MireSeeds>());
        }
        public override void SetDrawPositions(int i, int j, ref int width, ref int offsetY, ref int height, ref short tileFrameX, ref short tileFrameY)
        {
            offsetY = 2;
        }

        public override bool PreDraw(int i, int j, SpriteBatch spriteBatch)
        {
            Tile tile = Main.tile[i, j];
            Texture2D texture = ModContent.Request<Texture2D>("MultidimensionMod/Tiles/Biomes/Mire/MireFoliageBig").Value;
            Texture2D GlowTexture = ModContent.Request<Texture2D>("MultidimensionMod/Tiles/Biomes/Mire/MireFoliageBig_Glow").Value;

            Vector2 zero = Main.drawToScreen ? Vector2.Zero : new Vector2(Main.offScreenRange);

            int height = tile.TileFrameY == 66 ? 18 : 32;
            // Offset along the Y axis depending on the current frame
            int frameYOffset = Main.tileFrame[Type];

            spriteBatch.Draw(
                texture,
                new Vector2(i * 16 - (int)Main.screenPosition.X, j * 16 - (int)Main.screenPosition.Y) + zero,
                new Rectangle(tile.TileFrameX, tile.TileFrameY + frameYOffset, 24, 16),
                Lighting.GetColor(i, j), 0f, default, 1f, SpriteEffects.None, 0f);

            // Make sure to draw with Color.White or at least a color that is fully opaque
            // Achieve opaqueness by increasing the alpha channel closer to 255. (lowering closer to 0 will achieve transparency)
            if (!Main.dayTime)
            {
                spriteBatch.Draw(
                   GlowTexture,
                   new Vector2(i * 16 - (int)Main.screenPosition.X, j * 16 - (int)Main.screenPosition.Y) + zero,
                   new Rectangle(tile.TileFrameX, tile.TileFrameY + frameYOffset, 24, 16),
                   Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
            }

            // Return false to stop vanilla draw
            return false;
        }
    }
}