using MultidimensionMod.Items.Placeables.Furniture.VoidMatter;
using MultidimensionMod.Dusts;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Enums;
using Terraria.ObjectData;
using Terraria.DataStructures;

namespace MultidimensionMod.Tiles.Furniture.VoidMatter
{
    public class VoidMatterLanternPlaced : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileLighted[Type] = true;
            Main.tileFrameImportant[Type] = true;
            Main.tileLavaDeath[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style1x2Top);
            TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.addTile(Type);
            LocalizedText name = CreateMapEntryName();
            // name.SetDefault("Void Matter Lantern");
            AddMapEntry(new Color(25, 19, 39), name);
            DustType = ModContent.DustType<DarkDust>();
            AdjTiles = new int[] { TileID.HangingLanterns };
            AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTorch);
        }

        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = 1;
        }

        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            Tile tile = Framing.GetTileSafely(i, j);
            if (tile.TileFrameX < 36)
            {
                r = 0.6f;
                g = 0.3f;
                b = 0.7f;
            }
        }
    }
}