using Microsoft.Xna.Framework;
using MultidimensionMod.Tiles.Ores;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Tiles.Biomes.Mire
{
    public class DepthsandHardenedPlaced : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileBlendAll[Type] = true;
            Main.tileBlockLight[Type] = true;
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
            Terraria.ID.TileID.Sets.Conversion.HardenedSand[Type] = true;
            Main.tileLighted[Type] = false;
            DustType = ModContent.DustType<Dusts.AbyssiumDust>();  
            AddMapEntry(new Color(0, 0, 127));
        }
    }
}