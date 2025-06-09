using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Tiles.Biomes.Void
{
    public class OroborosWoodPlaced : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
			Main.tileMergeDirt[Type] = true;
            //true for block to emit light
            HitSound = SoundID.Tink;
            Main.tileBlockLight[Type] = true;  
            DustType = ModContent.DustType<Dusts.DoomDust>();
            AddMapEntry(new Color(60, 60, 60));
        }
    }
}