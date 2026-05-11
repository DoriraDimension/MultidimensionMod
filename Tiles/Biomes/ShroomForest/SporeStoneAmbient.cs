using MultidimensionMod.Tiles.Ores;
using MultidimensionMod.Dusts;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using System;
using Terraria.ObjectData;

namespace MultidimensionMod.Tiles.Biomes.ShroomForest
{
    public class SporeStoneAmbient : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = false;
            Main.tileNoAttach[Type] = true;
            Main.tileFrameImportant[Type] = true;
            Main.tileLavaDeath[Type] = true;
            Main.tileNoFail[Type] = true;
            TileID.Sets.BreakableWhenPlacing[Type] = true;

            DustType = ModContent.DustType<MushroomDust>();

            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x2);

            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.DrawYOffset = 2;
            TileObjectData.addTile(Type);

            TileID.Sets.DisableSmartCursor[Type] = true;
            AddMapEntry(new Color(179, 146, 131));        
            }
    }
}