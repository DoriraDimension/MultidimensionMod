using MultidimensionMod.Dusts;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using MultidimensionMod.Tiles.Ores;

namespace MultidimensionMod.Tiles.Biomes.Mire
{
    public class MireGrass : ModTile
    {
        private Asset<Texture2D> glowTexture;

        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            TileID.Sets.Conversion.Grass[Type] = true;
            Main.tileBlendAll[Type] = true;
            Main.tileMergeDirt[Type] = true;
            TileID.Sets.Grass[Type] = true;
            Main.tileBlockLight[Type] = true;
            TileID.Sets.CanBeDugByShovel[Type] = true;
            Main.tileMerge[Type][ModContent.TileType<AbyssiumOrePlaced>()] = true;
            Main.tileMerge[Type][ModContent.TileType<DepthsandPlaced>()] = true;
            Main.tileMerge[Type][ModContent.TileType<DepthsandstonePlaced>()] = true;
            Main.tileMerge[Type][ModContent.TileType<DepthsandHardenedPlaced>()] = true;
            Main.tileMerge[Type][ModContent.TileType<PermafrostPlaced>()] = true;
            Main.tileMerge[Type][ModContent.TileType<DepthIce>()] = true;
            Main.tileMerge[Type][ModContent.TileType<DepthstonePlaced>()] = true;
            Main.tileMerge[Type][ModContent.TileType<MireGrass>()] = true;
            Main.tileMerge[TileID.Mud][Type] = true;
            Main.tileMerge[Type][TileID.Mud] = true;
            Main.tileLighted[Type] = true;
            TileID.Sets.DoesntPlaceWithTileReplacement[Type] = true;
            TileID.Sets.NeedsGrassFraming[Type] = true;
            TileID.Sets.Conversion.MergesWithDirtInASpecialWay[Type] = true;
            TileID.Sets.JungleSpecial[Type] = true;
            DustType = Main.dayTime ? DustID.JungleGrass : DustID.BlueTorch;
            AddMapEntry(new Color(0, 50, 140));
            if (!Main.dedServ)
                glowTexture = ModContent.Request<Texture2D>(Texture + "_Glow");
        }

        public override void RandomUpdate(int i, int j)
        {
            Tile tileAbove = Framing.GetTileSafely(i, j - 1);
            Tile tileAbove2 = Framing.GetTileSafely(i + 1, j - 1);
            Tile tileAbove3 = Framing.GetTileSafely(i + 2, j - 1);
            WorldGen.SpreadGrass(i + Main.rand.Next(-1, 1), j + Main.rand.Next(-1, 1), TileID.Mud, Type, false);
            if (Main.rand.NextBool(80))
            {
                int style = Main.rand.Next(23);
                WorldGen.PlaceTile(i, j - 1, ModContent.TileType<MireSurfaceFoliage>(), mute: true, style: Main.rand.Next(23));
                NetMessage.SendObjectPlacement(-1, i, j - 1, ModContent.TileType<MireSurfaceFoliage>(), Main.rand.Next(23), 0, -1, -1);
            }
            if (!tileAbove.HasTile && !tileAbove2.HasTile && Main.tile[i, j].HasTile && Main.rand.NextBool(120))
            {
                WorldGen.PlaceObject(i, j - 1, ModContent.TileType<MireFoliageMedium>(), true, Main.rand.Next(12));
                NetMessage.SendObjectPlacement(-1, i, j - 1, ModContent.TileType<MireFoliageMedium>(), Main.rand.Next(12), 0, -1, -1);
            }
            if (!tileAbove.HasTile && !tileAbove2.HasTile && !tileAbove3.HasTile && Main.tile[i, j].HasTile && Main.rand.NextBool(120))
            {
                WorldGen.PlaceObject(i, j - 1, ModContent.TileType<MireFoliageBig>(), true, Main.rand.Next(9));
                NetMessage.SendObjectPlacement(-1, i, j - 1, ModContent.TileType<MireFoliageBig>(), Main.rand.Next(9), 0, -1, -1);
            }
            if (Main.rand.NextBool(1500))
            {
                WorldGen.PlaceTile(i, j - 1, ModContent.TileType<DarkshroomPlaced>(), mute: true, style: Main.rand.Next(4));
                NetMessage.SendObjectPlacement(-1, i, j - 1, ModContent.TileType<DarkshroomPlaced>(), Main.rand.Next(4), 0, -1, -1);

            }
            /*if (Main.rand.NextBool(1500))
            {
                WorldGen.PlaceTile(i, j - 1, ModContent.TileType<BlackLotusPlaced>(), mute: true);
                NetMessage.SendObjectPlacement(-1, i, j - 1, ModContent.TileType<BlackLotusPlaced>(), 0, 0, -1, -1);

            }*/
            if (Main.rand.NextBool(4))
                WorldGen.SpreadGrass(i + Main.rand.Next(-1, 1), j + Main.rand.Next(-1, 1), ModContent.TileType<DarkmudPlaced>(), Type, false);
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
            g = 0.10f;
            b = 0.21f;
        }
    }
}