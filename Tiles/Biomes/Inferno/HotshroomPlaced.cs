using MultidimensionMod.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace MultidimensionMod.Tiles.Biomes.Inferno
{
    public class HotshroomPlaced : ModTile
	{
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileCut[Type] = true;

            Main.tileMergeDirt[Type] = true;
            Main.tileLighted[Type] = false;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
            TileObjectData.newTile.RandomStyleRange = 4;
            TileObjectData.addTile(Type);
            RegisterItemDrop(ModContent.ItemType<Hotshroom>());
            RegisterItemDrop(ModContent.ItemType<Hotshroom>(), 1);
            RegisterItemDrop(ModContent.ItemType<Hotshroom>(), 2);
            RegisterItemDrop(ModContent.ItemType<Hotshroom>(), 3);
        }

        public override bool CreateDust(int i, int j, ref int type)
        {
            return false;
        }
        
        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = 10;
        }
    }

}