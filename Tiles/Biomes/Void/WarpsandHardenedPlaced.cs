using Microsoft.Xna.Framework;
using MultidimensionMod.Tiles.Ores;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Tiles.Biomes.Void
{
    public class WarpsandHardenedPlaced : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileBlendAll[Type] = true;
            Main.tileBlockLight[Type] = true;
            Main.tileMerge[TileID.Mud][Type] = true;
            Main.tileMerge[Type][TileID.Mud] = true;
            Terraria.ID.TileID.Sets.Conversion.HardenedSand[Type] = true;
            Main.tileLighted[Type] = false;
            DustType = ModContent.DustType<Dusts.DoomDust>();
            AddMapEntry(new Color(0, 0, 127));
        }
    }
}