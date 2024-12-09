using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace MultidimensionMod.Tiles.Furniture.Bogwood
{
    public class BogwoodCandelabraPlaced : ModTile
	{
		public override void SetStaticDefaults()
		{
			Main.tileFrameImportant[Type] = true;
			Main.tileNoAttach[Type] = true;
            Main.tileLighted[Type] = true;
            Main.tileLavaDeath[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
            TileObjectData.newTile.Origin = new Point16(1, 1);
            TileObjectData.newTile.DrawYOffset = 2;
            TileObjectData.addTile(Type);
			LocalizedText name = CreateMapEntryName();
			//name.SetDefault("Bogwood Candelabra");
            AddMapEntry(new Color(12, 62, 205), name);
            DustType = ModContent.DustType<Dusts.BogwoodDust>();
            AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTorch);
            AdjTiles = new int[]{ TileID.Candelabras };
		}

        public override void HitWire(int i, int j)
        {
            int left = i - (Main.tile[i, j].TileFrameX / 18) % 2;
            int top = j - (Main.tile[i, j].TileFrameX / 18) % 2;
            for (int x = left; x < left + 2; x++)
            {
                for (int y = top; y < top + 2; y++)
                {

                    if (Main.tile[x, y].TileFrameX >= 36)
                    {
                        Main.tile[x, y].TileFrameX -= 36;
                    }
                    else
                    {
                        Main.tile[x, y].TileFrameX += 36;
                    }
                }
            }
            if (Wiring.running)
            {
                Wiring.SkipWire(left, top);
                Wiring.SkipWire(left, top + 1);
                Wiring.SkipWire(left + 1, top);
                Wiring.SkipWire(left + 1, top + 1);
            }
            NetMessage.SendTileSquare(-1, left, top + 1, 2);

        }
        public override void NumDust(int i, int j, bool fail, ref int num)
		{
			num = fail ? 1 : 3;
		}
        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            Tile tile = Main.tile[i, j];
            if (tile.TileFrameX < 36)
            {
                r = 0.9f;
                g = 0.9f;
                b = 0.9f;
            }
        }
    }
}