using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Tiles.Ores
{
    public class IridulPlaced : ModTile
    {
        public const int StyleCount = 2;

        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileObsidianKill[Type] = true;
            Main.tileShine[Type] = 500;
            Main.tileShine2[Type] = true;
            Main.tileSpelunker[Type] = true;
            DustType = DustID.PinkCrystalShard;
            AddMapEntry(new Color(251, 126, 248));
        }

        public override bool TileFrame(int i, int j, ref bool resetFrame, ref bool noBreak)
        {
            var tile = Framing.GetTileSafely(i, j);
            var topTile = Framing.GetTileSafely(i, j - 1);
            var bottomTile = Framing.GetTileSafely(i, j + 1);
            var leftTile = Framing.GetTileSafely(i - 1, j);
            var rightTile = Framing.GetTileSafely(i + 1, j);
            var topType = -1;
            var bottomType = -1;
            var leftType = -1;
            var rightType = -1;
            if (topTile.HasTile && !topTile.BottomSlope)
                bottomType = topTile.TileType;
            if (bottomTile.HasTile && !bottomTile.IsHalfBlock && !bottomTile.TopSlope)
                topType = bottomTile.TileType;
            if (leftTile.HasTile)
                leftType = leftTile.TileType;
            if (rightTile.HasTile)
                rightType = rightTile.TileType;
            var variation = WorldGen.genRand.Next(3) * 18;
            if (topType >= 0 && Main.tileSolid[topType] && !Main.tileSolidTop[topType])
            {
                if (tile.TileFrameY < 0 || tile.TileFrameY > 36)
                    tile.TileFrameY = (short)variation;
            }
            else if (leftType >= 0 && Main.tileSolid[leftType] && !Main.tileSolidTop[leftType])
            {
                if (tile.TileFrameY < 108 || tile.TileFrameY > 54)
                    tile.TileFrameY = (short)(108 + variation);
            }
            else if (rightType >= 0 && Main.tileSolid[rightType] && !Main.tileSolidTop[rightType])
            {
                if (tile.TileFrameY < 162 || tile.TileFrameY > 198)
                    tile.TileFrameY = (short)(162 + variation);
            }
            else if (bottomType >= 0 && Main.tileSolid[bottomType] && !Main.tileSolidTop[bottomType])
            {
                if (tile.TileFrameY < 54 || tile.TileFrameY > 90)
                    tile.TileFrameY = (short)(54 + variation);
            }
            else
                WorldGen.KillTile(i, j);
            return true;
        }

        public override bool CanPlace(int i, int j)
        {
            if (!WorldGen.SolidTile(i - 1, j) && !WorldGen.SolidTile(i + 1, j) && !WorldGen.SolidTile(i, j - 1))
            {
                return WorldGen.SolidTile(i, j + 1);
            }
            return true;
        }

        public override void PlaceInWorld(int i, int j, Item item)
        {
            Main.tile[i, j].TileFrameX = (short)(item.placeStyle * 18);
            NetMessage.SendTileSquare(-1, i, j, 1);
        }

        public override void SetDrawPositions(int i, int j, ref int width, ref int offsetY, ref int height, ref short tileFrameX, ref short tileFrameY)
        {
            if (Main.tile[i, j].TileFrameY / 18 < 3)
            {
                offsetY = 2;
            }
        }
    }
}