using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace MultidimensionMod.Tiles.Biomes.Inferno
{
    public class ScorchedShinglesS : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
			Main.tileMergeDirt[Type] = false;
            Main.tileBlockLight[Type] = true;  
            AddMapEntry(new Color(153, 50, 0));
        }
        public override bool CanKillTile(int i, int j, ref bool blockDamaged)
        {
            if (Main.hardMode/*AAWorld.downedShen*/)
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