using MultidimensionMod.Tiles.Ores;
using MultidimensionMod.Dusts;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using System;

namespace MultidimensionMod.Tiles.Biomes.Inferno
{
    public class VolcanicRockPlaced : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMerge[Type][ModContent.TileType<IncineriteOre>()] = true;
            Main.tileMerge[Type][ModContent.TileType<VolcanicRockDensePlaced>()] = true;
            Main.tileMerge[Type][ModContent.TileType<TorchstonePlaced>()] = true;
            Main.tileMerge[Type][ModContent.TileType<AwakenedRockPlaced>()] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileBlockLight[Type] = true;
            HitSound = SoundID.Tink;
            DustType = ModContent.DustType<RazewoodDust>();
            AddMapEntry(new Color(50, 25, 12));
            MinPick = 59;
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