using MultidimensionMod.Dusts;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace MultidimensionMod.Tiles.Biomes.Inferno
{
    public class TorchsandHardenedPlaced : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            Terraria.ID.TileID.Sets.Conversion.HardenedSand[Type] = true;
            Main.tileBlendAll[Type] = true;
            Main.tileBlockLight[Type] = true;
            DustType = ModContent.DustType<RazewoodDust>();  
            AddMapEntry(new Color(50, 30, 17));
            MinPick = 65;
        }
    }
}