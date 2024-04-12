using MultidimensionMod.Dusts;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace MultidimensionMod.Tiles.Biomes.Inferno
{
    public class TorchsandstonePlaced : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            Terraria.ID.TileID.Sets.Conversion.Sandstone[Type] = true;
            Main.tileBlendAll[Type] = true;
            Main.tileBlockLight[Type] = true;
            DustType = ModContent.DustType<RazewoodDust>();  
            AddMapEntry(new Color(50, 40, 40));
            MinPick = 65;
        }
    }
}