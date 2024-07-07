﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MultidimensionMod.Dusts;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace MultidimensionMod.Tiles.Biomes.Mire
{
    public class LakeWaterFoliage : ModTile
    {
        public static int _type;

        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileCut[Type] = true;
            Main.tileSolid[Type] = false;
            Main.tileMergeDirt[Type] = true;
            Main.tileLighted[Type] = true;

            DustType = ModContent.DustType<BogwoodDust>();
            HitSound = SoundID.Grass;

            TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
            TileObjectData.newTile.LavaDeath = true;
            TileObjectData.newTile.WaterDeath = false;

            TileObjectData.newTile.CoordinatePadding = 2;
            TileObjectData.newTile.CoordinateWidth = 16;
            TileObjectData.newTile.CoordinateHeights = new int[]
            {
                20
            };
            TileObjectData.newTile.DrawYOffset = -2;
            TileObjectData.newTile.Style = 0;
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.UsesCustomCanPlace = true;

            for (int i = 0; i < 23; i++)
            {
                TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
                TileObjectData.addSubTile(TileObjectData.newSubTile.Style);
            }
            TileObjectData.addTile(Type);
        }

        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = 2;
        }

        public override bool PreDraw(int i, int j, SpriteBatch spriteBatch)
        {
            Tile tile = Main.tile[i, j];
            Texture2D GlowTexture = ModContent.Request<Texture2D>("MultidimensionMod/Tiles/Biomes/Mire/LakeWaterFoliage_Glow").Value;

            Vector2 zero = Main.drawToScreen ? Vector2.Zero : new Vector2(Main.offScreenRange);

            int height = tile.TileFrameY == 66 ? 18 : 16;
            // Offset along the Y axis depending on the current frame
            int frameYOffset = Main.tileFrame[Type];

            // Make sure to draw with Color.White or at least a color that is fully opaque
            spriteBatch.Draw(GlowTexture, new Vector2(i * 16 - (int)Main.screenPosition.X, j * 16 - (int)Main.screenPosition.Y) + zero, new Rectangle(tile.TileFrameX, tile.TileFrameY + frameYOffset, 16, height), Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);

            // Return false to stop vanilla draw
            return true;
        }

        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)   //light colors
        {
            r = 0.40f;
            g = 0.30f;
            b = 0.02f;
        }
    }
}