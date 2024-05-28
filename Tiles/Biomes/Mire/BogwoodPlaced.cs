using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace MultidimensionMod.Tiles.Biomes.Mire
{
    class BogwoodPlaced : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileLighted[Type] = true;
            Main.tileBlockLight[Type] = true; 
            AddMapEntry(new Color(0, 0, 51));
            DustType = ModContent.DustType<Dusts.BogwoodDust>();
        }
    }
}
