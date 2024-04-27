using MultidimensionMod.Tiles.Ores;
using MultidimensionMod.Dusts;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using System;

namespace MultidimensionMod.Tiles.Biomes.Inferno
{
    public class VolcanicRockDensePlaced : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMerge[Type][ModContent.TileType<IncineriteOre>()] = true;
            Main.tileMerge[Type][ModContent.TileType<AwakenedRockPlaced>()] = true;
            Main.tileMerge[Type][ModContent.TileType<TorchstonePlaced>()] = true;
            Main.tileMerge[Type][ModContent.TileType<VolcanicRockPlaced>()] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileBlockLight[Type] = true;
            HitSound = SoundID.Tink;
            //DustType = ModContent.DustType<RazewoodDust>();
            AddMapEntry(new Color(91, 58, 96));
            MinPick = 200;
            MineResist = 3;
        }

        public override bool CanExplode(int i, int j)
        {
            return false;
        }
    }
}