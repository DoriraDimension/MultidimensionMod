using MultidimensionMod.Items.Placeables.Furniture.VoidMatter;
using MultidimensionMod.Dusts;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace MultidimensionMod.Tiles.Furniture.VoidMatter
{
    public class VoidMatterPlatformPlaced : ModTile
    {
        public override void SetStaticDefaults()
        {
            // Properties
            Main.tileLighted[Type] = true;
            Main.tileFrameImportant[Type] = true;
            Main.tileSolidTop[Type] = true;
            Main.tileSolid[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileTable[Type] = true;
            Main.tileLavaDeath[Type] = true;
            TileObjectData.newTile.CoordinateHeights = new[] { 16 };
            TileObjectData.newTile.CoordinateWidth = 16;
            TileObjectData.newTile.CoordinatePadding = 2;
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.StyleMultiplier = 27;
            TileObjectData.newTile.StyleWrapLimit = 27;
            TileObjectData.newTile.UsesCustomCanPlace = false;
            TileObjectData.addTile(Type);
            TileID.Sets.Platforms[Type] = true;
            TileID.Sets.DisableSmartCursor[Type] = true;
            AddMapEntry(new Color(25, 19, 39));
            AddToArray(ref TileID.Sets.RoomNeeds.CountsAsDoor);
            ItemDrop = ModContent.ItemType<VoidMatterPlatform>();
            AdjTiles = new int[] { TileID.Platforms };
            DustType = ModContent.DustType<DarkDust>();
        }

        public override void PostSetDefaults() => Main.tileNoSunLight[Type] = false;

        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = 1;
        }
    }
}