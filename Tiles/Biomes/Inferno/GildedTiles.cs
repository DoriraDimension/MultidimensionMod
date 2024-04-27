using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace MultidimensionMod.Tiles.Biomes.Inferno
{
    public class GildedTiles : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
			Main.tileMergeDirt[Type] = false;
            Main.tileBlockLight[Type] = true;
            Main.tileMerge[Type][ModContent.TileType<PagodaColumnPlaced>()] = true;
            Main.tileMerge[Type][ModContent.TileType<PagodaBrickPlaced>()] = true;
            AddMapEntry(new Color(153, 50, 0));
        }
        public override bool CanKillTile(int i, int j, ref bool blockDamaged)
        {
            if (NPC.downedMoonlord/*AAWorld.downedShen*/)
            {
                return true;
            }
            return false;
        }

        public override bool CanExplode(int i, int j)
        {
            return false;
        }
    }
}