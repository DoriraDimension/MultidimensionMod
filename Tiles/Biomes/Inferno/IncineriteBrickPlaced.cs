using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace MultidimensionMod.Tiles.Biomes.Inferno
{
    class IncineriteBrickPlaced : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileLighted[Type] = true;
            Main.tileBlockLight[Type] = true; 
            AddMapEntry(new Color(80, 60, 20));
            DustType = ModContent.DustType<Dusts.IncineriteDust>();
        }
    }
}
