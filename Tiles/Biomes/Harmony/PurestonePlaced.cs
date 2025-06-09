using MultidimensionMod.Tiles.Ores;
using MultidimensionMod.Dusts;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using System;

namespace MultidimensionMod.Tiles.Biomes.Harmony
{
    public class PurestonePlaced : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            Terraria.ID.TileID.Sets.Conversion.Stone[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileBlockLight[Type] = true;
            HitSound = SoundID.Tink;
            //DustType = ModContent.DustType<RazewoodDust>();
            AddMapEntry(new Color(7, 68, 80));
        }
    }
}