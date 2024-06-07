using MultidimensionMod.Tiles.Ores;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;

namespace MultidimensionMod.Tiles.Biomes.Mire
{
    public class DankDepthstonePlaced : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMerge[Type][ModContent.TileType<AbyssiumOrePlaced>()] = true;
            Main.tileMerge[Type][ModContent.TileType<DepthsandPlaced>()] = true;
            Main.tileMerge[Type][ModContent.TileType<DepthsandstonePlaced>()] = true;
            Main.tileMerge[Type][ModContent.TileType<DepthsandHardenedPlaced>()] = true;
            Main.tileMerge[Type][ModContent.TileType<PermafrostPlaced>()] = true;
            Main.tileMerge[Type][ModContent.TileType<DepthIce>()] = true;
            Main.tileMerge[Type][ModContent.TileType<DepthstonePlaced>()] = true;
            Main.tileMerge[Type][ModContent.TileType<MireGrass>()] = true;
            Main.tileMerge[Type][ModContent.TileType<BogwoodPlaced>()] = true;
            Main.tileMerge[Type][ModContent.TileType<DarkmudPlaced>()] = true;
            Main.tileMerge[Type][ModContent.TileType<DenseBiomatterPlaced>()] = true;
            Main.tileMerge[TileID.Mud][Type] = true;
            Main.tileMerge[Type][TileID.Mud] = true;
            Main.tileMergeDirt[Type] = true;
            TileID.Sets.Conversion.Stone[Type] = true;
            Main.tileBlendAll[Type] = false;
            Main.tileLighted[Type] = false;
            Main.tileBlockLight[Type] = true;
            HitSound = SoundID.Tink;
            TileID.Sets.JungleSpecial[Type] = true;
            DustType = ModContent.DustType<Dusts.AbyssiumDust>();
            AddMapEntry(new Color(27, 19, 50));
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

            if (Main.rand.NextBool(80) && !up.HasTile && !up2.HasTile && up.LiquidAmount > 0 && up2.LiquidAmount > 0 && !tile.LeftSlope && !tile.RightSlope && !tile.IsHalfBlock)
            {
                int style = Main.rand.Next(23);
                WorldGen.PlaceTile(i, j - 1, ModContent.TileType<LakeWaterFoliage>(), mute: true, style: Main.rand.Next(23));
                NetMessage.SendObjectPlacement(-1, i, j - 1, ModContent.TileType<LakeWaterFoliage>(), Main.rand.Next(23), 0, -1, -1);
            }
        }
    }
}
