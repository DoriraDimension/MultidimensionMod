using MultidimensionMod.Items.Placeables.Biomes.FrozenUnderworld;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;
using MultidimensionMod.Dusts;

namespace MultidimensionMod.Tiles.Ores
{
    public class DimensiumBrickPlaced : ModTile
    {
        public static readonly SoundStyle MineSound = new SoundStyle("MultidimensionMod/Sounds/Tiles/DimensiumMine", 3);
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileBlockLight[Type] = true;
            AddMapEntry(new Color(56, 156, 251));
            HitSound = DimensiumPlaced.MineSound;
            DustType = ModContent.DustType<DimensionDust1>();
        }

        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = fail ? 1 : 3;
        }
    }
}