using MultidimensionMod.Tiles.Furniture.RedMush;
using MultidimensionMod.Dusts;
using Microsoft.Xna.Framework;
using Terraria.Localization;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace MultidimensionMod.Tiles.Furniture.RedMush
{
    public class RedMushPianoPlaced : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileLavaDeath[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x2);
            TileObjectData.newTile.Origin = new Point16(1, 1);
            TileObjectData.newTile.DrawYOffset = 2;
            TileObjectData.addTile(Type);

            LocalizedText name = CreateMapEntryName();
            AddMapEntry(new Color(120, 90, 0), name);

            AdjTiles = new int[] { TileID.Pianos };
            DustType = ModContent.DustType<MushroomDust>();
        }
        public override void NumDust(int i, int j, bool fail, ref int num) => num = fail ? 1 : 3;
    }
}