using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace MultidimensionMod.Tiles.Biomes.Inferno
{
    public class ScorchedDynastyWoodS : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
			Main.tileMergeDirt[Type] = true;
			Main.tileBlendAll[Type] = false;
            Main.tileBlockLight[Type] = true;  
            AddMapEntry(new Color(153, 100, 0));
        }
        public override bool CanKillTile(int i, int j, ref bool blockDamaged)
        {
            if (Main.hardMode/*DownedSystem.downedShen*/)
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