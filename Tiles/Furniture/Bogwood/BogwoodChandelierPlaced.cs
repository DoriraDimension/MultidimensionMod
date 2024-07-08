using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Enums;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.DataStructures;
using Microsoft.Xna.Framework.Graphics;
using Terraria.Localization;

namespace MultidimensionMod.Tiles.Furniture.Bogwood
{
    public class BogwoodChandelierPlaced : ModTile
	{
		public override void SetStaticDefaults()
		{

            //Main.tileFlame[Type] = true;
            Main.tileLighted[Type] = true;
            Main.tileFrameImportant[Type] = true;
            Main.tileLavaDeath[Type] = true;
            
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
            TileObjectData.newTile.Origin = new Point16(1, 0);
            TileObjectData.newTile.AnchorTop = new AnchorData(AnchorType.SolidTile | AnchorType.SolidSide, 1, 1);
            TileObjectData.newTile.AnchorBottom = AnchorData.Empty;
            TileObjectData.newTile.LavaDeath = true;
            TileObjectData.newTile.StyleWrapLimit = 37;
            TileObjectData.newTile.StyleHorizontal = false;
            TileObjectData.newTile.StyleLineSkip = 2;
            TileObjectData.addTile(Type);
            LocalizedText name = CreateMapEntryName();
			//name.SetDefault("Bogwood Chandelier");
            AddMapEntry(new Color(12, 62, 205), name);
            DustType = ModContent.DustType<Dusts.BogwoodDust>();
            AdjTiles = new int[] { TileID.Chandeliers };
            AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTorch);

        }
        public override void HitWire(int i, int j)
        {
            int left = i - (Main.tile[i, j].TileFrameX / 18) % 3;
            int top = j - (Main.tile[i, j].TileFrameY / 18) % 3;
            for (int x = left; x < left + 3; x++)
            {
                for (int y = top; y < top + 3; y++)
                {

                    if (Main.tile[x, y].TileFrameX >= 54)
                    {
                        Main.tile[x, y].TileFrameX -= 54;
                    }
                    else
                    {
                        Main.tile[x, y].TileFrameX += 54;
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
