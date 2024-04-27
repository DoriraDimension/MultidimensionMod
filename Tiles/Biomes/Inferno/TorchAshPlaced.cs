using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Tiles.Biomes.Inferno
{
    public class TorchAshPlaced : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileBlendAll[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileBlockLight[Type] = true;
            TileID.Sets.Snow[Type] = true;
            DustType = ModContent.DustType<Dusts.AshRain>();
            AddMapEntry(new Color(30, 30, 30));
            MineResist = 2;
        }

        public override void RandomUpdate(int i, int j)
        {
            if (Main.rand.NextBool(1500))
            {
                WorldGen.PlaceTile(i, j - 1, ModContent.TileType<HotshroomPlaced>(), mute: true);
                NetMessage.SendObjectPlacement(-1, i, j - 1, ModContent.TileType<HotshroomPlaced>(), 0, 0, -1, -1);
            }
        }

        public static bool PlaceObject(int x, int y, int type, bool mute = false, int style = 0, int random = -1, int direction = -1)
        {
            if (!TileObject.CanPlace(x, y, type, style, direction, out TileObject toBePlaced, false))
            {
                return false;
            }
            toBePlaced.random = random;
            if (TileObject.Place(toBePlaced) && !mute)
            {
                WorldGen.SquareTileFrame(x, y, true);
            }
            return false;
        }
    }
}