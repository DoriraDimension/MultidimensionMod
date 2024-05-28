using MultidimensionMod.Dusts;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace MultidimensionMod.Tiles.Biomes.Mire
{
    public class MireFoliage : ModTile
	{
		public static int _type;

		public override void SetStaticDefaults()
		{
			Main.tileFrameImportant[Type] = true;
			Main.tileCut[Type] = true;
			Main.tileSolid[Type] = false;
			Main.tileMergeDirt[Type] = true;
			Main.tileLighted[Type] = false;

			DustType = ModContent.DustType<BogwoodDust>();
            HitSound = SoundID.Grass;

            TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
			TileObjectData.newTile.LavaDeath = true;
			TileObjectData.newTile.WaterDeath = false;

			TileObjectData.newTile.CoordinatePadding = 2;
			TileObjectData.newTile.CoordinateWidth = 16;
			TileObjectData.newTile.CoordinateHeights = new int[]
			{
				20
			};
			TileObjectData.newTile.DrawYOffset = -2;
			TileObjectData.newTile.Style = 0;
			TileObjectData.newTile.StyleHorizontal = true;
			TileObjectData.newTile.UsesCustomCanPlace = true;

			for (int i = 0; i < 23; i++)
			{
				TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
				TileObjectData.addSubTile(TileObjectData.newSubTile.Style);
			}
			TileObjectData.addTile(Type);
		}

		public override void NumDust(int i, int j, bool fail, ref int num)
		{
			num = 2;
		}
	}
}