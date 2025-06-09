using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace MultidimensionMod.Tiles.Biomes.Void
{
    public class Doomgrass : ModTile
    {


        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            TileID.Sets.Conversion.Grass[Type] = true;
            Main.tileBlendAll[Type] = true;
            TileID.Sets.NeedsGrassFraming[Type] = true;
            TileID.Sets.CanBeDugByShovel[Type] = true;
            Main.tileMergeDirt[Type] = true;
            TileID.Sets.Conversion.MergesWithDirtInASpecialWay[Type] = true;
            Main.tileBlockLight[Type] = true;
            TileID.Sets.Grass[Type] = true;
            TileID.Sets.DoesntPlaceWithTileReplacement[Type] = true;
            DustType = ModContent.DustType<Dusts.DoomDust>();
            AddMapEntry(new Color(50, 50, 50));
        }

        public override void KillTile(int i, int j, ref bool fail, ref bool effectOnly, ref bool noItem)
        {
            if (!fail)
            {
                fail = true;
                Framing.GetTileSafely(i, j).TileType = (ushort)TileID.Dirt;
            }
        }
    }
}