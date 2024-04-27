using MultidimensionMod.Items.Materials;
using MultidimensionMod.Dusts;
using MultidimensionMod.Items.Summons;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.Localization;

namespace MultidimensionMod.Tiles.Biomes.ShroomForest
{
    public class KingsCapPlaced : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileCut[Type] = true;
            Main.tileSolid[Type] = false;
            Main.tileLighted[Type] = false;
            Main.tileNoAttach[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
            TileObjectData.newTile.CoordinateHeights = new[] { 16, 18 };
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.DrawYOffset = 0;
            TileObjectData.newTile.AnchorValidTiles = new int[]
            {
               ModContent.TileType<Mycelium>()
            };
            TileObjectData.addTile(Type);
            HitSound = SoundID.Grass;
            DustType = ModContent.DustType<MushroomDust>();
            RegisterItemDrop(ModContent.ItemType<IntimidatingMushroom>());
            LocalizedText name = CreateMapEntryName();
            AddMapEntry(new Color(237, 160, 69), name);
        }
        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = fail ? 1 : 3;
        }
        public override void AnimateIndividualTile(int type, int i, int j, ref int TileFrameXOffset, ref int TileFrameYOffset)
        {
            TileFrameXOffset = i % 1 * 18;
        }
    }
}