using MultidimensionMod.Dusts;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using MultidimensionMod.Tiles.Biomes.Inferno;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;

namespace MultidimensionMod.Tiles.Biomes.Mire
{
    public class MireGrass : ModTile
    {
        public static int _type;
        private Asset<Texture2D> glowTexture;

        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            TileID.Sets.Conversion.Grass[Type] = true;
            Main.tileBlendAll[Type] = true;
            Main.tileMergeDirt[Type] = true;
            TileID.Sets.Grass[Type] = true;
            Main.tileBlockLight[Type] = true;
            TileID.Sets.DoesntPlaceWithTileReplacement[Type] = true;
            TileID.Sets.NeedsGrassFraming[Type] = true;
            TileID.Sets.JungleSpecial[Type] = true;
            DustType = ModContent.DustType<AbyssiumDust>();
            AddMapEntry(new Color(0, 50, 140));
            if (!Main.dedServ)
                glowTexture = ModContent.Request<Texture2D>(Texture + "_Glow");
        }

        public override void RandomUpdate(int i, int j)
        {
            WorldGen.SpreadGrass(i + Main.rand.Next(-1, 1), j + Main.rand.Next(-1, 1), TileID.Mud, Type, false);
            if (Main.rand.NextBool(80))
            {
                int style = Main.rand.Next(23);
                WorldGen.PlaceTile(i, j - 1, ModContent.TileType<MireFoliage>(), mute: true, style: Main.rand.Next(23));
                NetMessage.SendObjectPlacement(-1, i, j - 1, ModContent.TileType<MireFoliage>(), Main.rand.Next(23), 0, -1, -1);
            }
            if (Main.rand.NextBool(1500))
            {
                WorldGen.PlaceTile(i, j - 1, ModContent.TileType<HotshroomPlaced>(), mute: true);
                NetMessage.SendObjectPlacement(-1, i, j - 1, ModContent.TileType<HotshroomPlaced>(), 0, 0, -1, -1);

            }
            /*if (Main.rand.NextBool(1500))
            {
                WorldGen.PlaceTile(i, j - 1, ModContent.TileType<BlackLotusPlaced>(), mute: true);
                NetMessage.SendObjectPlacement(-1, i, j - 1, ModContent.TileType<BlackLotusPlaced>(), 0, 0, -1, -1);

            }*/
        }
        public override void KillTile(int i, int j, ref bool fail, ref bool effectOnly, ref bool noItem)
        {
            if (!fail)
            {
                fail = true;
                Framing.GetTileSafely(i, j).TileType = (ushort)ModContent.TileType<DarkmudPlaced>();
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

        public override void PostDraw(int i, int j, SpriteBatch spriteBatch)
        {
            Tile tile = Main.tile[i, j];
            Vector2 zero = new Vector2(Main.offScreenRange, Main.offScreenRange);
            if (Main.drawToScreen)
            {
                zero = Vector2.Zero;
            }
            int height = tile.TileFrameY == 36 ? 18 : 16;
            if (!Main.dayTime)
            {
                Main.spriteBatch.Draw(glowTexture.Value, new Vector2((i * 16) - (int)Main.screenPosition.X, (j * 16) - (int)Main.screenPosition.Y) + zero, new Rectangle(tile.TileFrameX, tile.TileFrameY, 16, height), Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
            }
        }

        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)   //light colors
        {
            r = 0;
            g = 0.05f;
            b = 0.15f;
        }
    }
}