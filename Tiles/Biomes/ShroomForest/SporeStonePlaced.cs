using MultidimensionMod.Tiles.Ores;
using MultidimensionMod.Dusts;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using System;

namespace MultidimensionMod.Tiles.Biomes.ShroomForest
{
    public class SporeStonePlaced : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMerge[Type][ModContent.TileType<MyceliumSandPlaced>()] = true;
            Main.tileMerge[Type][ModContent.TileType<MyceliumSandstonePlaced>()] = true;
            Main.tileMerge[Type][ModContent.TileType<MyceliumHardsandPlaced>()] = true;
            Main.tileMerge[Type][ModContent.TileType<Mycelium>()] = true;
            Main.tileMerge[Type][TileID.Stone] = true;
            Main.tileMerge[TileID.Stone][Type] = true;
            Main.tileMerge[Type][TileID.Mud] = true;
            Main.tileMerge[TileID.Mud][Type] = true;
            Terraria.ID.TileID.Sets.Conversion.Stone[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileBlockLight[Type] = true;
            HitSound = SoundID.Tink;
            DustType = ModContent.DustType<MushroomDust>();
            AddMapEntry(new Color(179, 146, 131));
            MinPick = 59;
        }
    }
}