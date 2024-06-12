using Microsoft.Xna.Framework;
using MultidimensionMod.Tiles.Biomes.Inferno;
using MultidimensionMod.Tiles.Ores;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Tiles.Biomes.Mire
{
    public class DepthMoss : ModTile
    {
        public static int _type;

        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            TileID.Sets.Conversion.Grass[Type] = true;
            Main.tileMerge[Type][ModContent.TileType<AbyssiumOrePlaced>()] = true;
            Main.tileMerge[Type][ModContent.TileType<DepthsandPlaced>()] = true;
            Main.tileMerge[Type][ModContent.TileType<DepthsandstonePlaced>()] = true;
            Main.tileMerge[Type][ModContent.TileType<DepthsandHardenedPlaced>()] = true;
            Main.tileMerge[Type][ModContent.TileType<PermafrostPlaced>()] = true;
            Main.tileMerge[Type][ModContent.TileType<DepthIce>()] = true;
            Main.tileMerge[Type][ModContent.TileType<DepthstonePlaced>()] = true;
            Main.tileMerge[Type][ModContent.TileType<MireGrass>()] = true;
            Main.tileMerge[TileID.Mud][Type] = true;
            Main.tileMerge[Type][TileID.Mud] = true;
            Main.tileBlendAll[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileBlockLight[Type] = true;
            TileID.Sets.NeedsGrassFraming[Type] = true;
            TileID.Sets.JungleSpecial[Type] = true;
            DustType = ModContent.DustType<Dusts.AbyssiumDust>();
            HitSound = SoundID.Tink;
            AddMapEntry(new Color(0, 50, 140));
            MinPick = 210;
        }

        public override bool CanExplode(int i, int j)
        {
            return false;
        }

        public override void RandomUpdate(int i, int j)
        {
            Tile tile = Main.tile[i, j];
            Tile up = Main.tile[i, j - 1];
            Tile up2 = Main.tile[i, j - 2];
            if (Main.rand.NextBool(80) && !up.HasTile && !up2.HasTile && up.LiquidAmount <= 0 && up2.LiquidAmount <= 0 && !tile.LeftSlope && !tile.RightSlope && !tile.IsHalfBlock)
            {
                int style = Main.rand.Next(23);
                WorldGen.PlaceTile(i, j - 1, ModContent.TileType<MireFoliage>(), mute: true, style: Main.rand.Next(23));
                NetMessage.SendObjectPlacement(-1, i, j - 1, ModContent.TileType<MireFoliage>(), Main.rand.Next(23), 0, -1, -1);
            }
            if (Main.rand.NextBool(80) && !up.HasTile && !up2.HasTile && up.LiquidAmount > 0 && up2.LiquidAmount > 0 && !tile.LeftSlope && !tile.RightSlope && !tile.IsHalfBlock)
            {
                int style = Main.rand.Next(23);
                WorldGen.PlaceTile(i, j - 1, ModContent.TileType<LakeWaterFoliage>(), mute: true, style: Main.rand.Next(23));
                NetMessage.SendObjectPlacement(-1, i, j - 1, ModContent.TileType<LakeWaterFoliage>(), Main.rand.Next(23), 0, -1, -1);
            }
        }

        public override void KillTile(int i, int j, ref bool fail, ref bool effectOnly, ref bool noItem)
        {
            if (!fail)
            {
                fail = true;
                Framing.GetTileSafely(i, j).TileType = (ushort)ModContent.TileType<DankDepthstonePlaced>();
            }
        }

        public static bool PlaceObject(int x, int y, int type, bool mute = false, int style = 0, int random = -1, int direction = -1)
        {
            if (!TileObject.CanPlace(x, y, type, style, direction, out TileObject toBePlaced, false))
            {
                return false;
            }
            toBePlaced.random = random;
            if (TileObject.Place(toBePlaced) && !mute)
            {
                WorldGen.SquareTileFrame(x, y, true);
            }
            return false;
        }
    }
}