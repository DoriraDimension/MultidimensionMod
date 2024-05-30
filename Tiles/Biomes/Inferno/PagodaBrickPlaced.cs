using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace MultidimensionMod.Tiles.Biomes.Inferno
{
    public class PagodaBrickPlaced : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
			Main.tileMergeDirt[Type] = true;
            Main.tileMerge[Type][ModContent.TileType<VolcanicRockPlaced>()] = true;
            Main.tileMerge[Type][ModContent.TileType<PagodaColumnPlaced>()] = true;
            Main.tileMerge[Type][ModContent.TileType<PagodaFloorPlaced>()] = true;
            Main.tileMerge[Type][ModContent.TileType<GildedTiles>()] = true;
            Main.tileBlendAll[Type] = false;
            Main.tileBlockLight[Type] = true;  
            AddMapEntry(new Color(153, 100, 0));
            MinPick = 210;
        }

        public override bool CanExplode(int i, int j)
        {
            return false;
        }
    }
}