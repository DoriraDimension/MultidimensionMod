using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MultidimensionMod.Items.Placeables.Biomes.Mire;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace MultidimensionMod.Tiles.Biomes.Mire
{
    public class MireSurfaceFoliage : ModTile
    {
        public static int _type;

        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileCut[Type] = true;
            TileID.Sets.SwaysInWindBasic[Type] = true;
            TileID.Sets.IgnoredByGrowingSaplings[Type] = true;
            TileObjectData.newTile.Width = 1;
            TileObjectData.newTile.Height = 2;
            TileObjectData.newTile.CoordinateHeights = new int[] { 18, 16 };
            TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile, TileObjectData.newTile.Width, 0);
            TileObjectData.newTile.UsesCustomCanPlace = true;
            TileObjectData.newTile.AnchorValidTiles = new int[] { ModContent.TileType<MireGrass>() };
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.RandomStyleRange = 23;
            TileObjectData.newTile.CoordinateWidth = 16;
            TileObjectData.newTile.CoordinatePadding = 2;
            TileObjectData.newTile.Origin = new Point16(0, 1);
            TileObjectData.addTile(Type);
            DustType = ModContent.DustType<Dusts.BogwoodDust>();
            HitSound = SoundID.Grass;
        }

        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = 2;
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            if (Main.rand.NextBool(50))
                Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 16, 32, ModContent.ItemType<MireSeeds>());
        }

        public override IEnumerable<Item> GetItemDrops(int i, int j)
        {
            Vector2 worldPosition = new Vector2(i, j).ToWorldCoordinates();
            Player nearestPlayer = Main.player[Player.FindClosest(worldPosition, 16, 16)];
            if (nearestPlayer.active)
            {
                if (nearestPlayer.HeldItem.type == ItemID.Sickle)
                {
                    yield return new Item(ItemID.Hay, Main.rand.Next(1, 2 + 1));
                }

                if (Main.rand.NextBool(20))
                {
                    yield return new Item(ModContent.ItemType<MireSeeds>());
                }
            }
        }

        public override void SetDrawPositions(int i, int j, ref int width, ref int offsetY, ref int height, ref short tileFrameX, ref short tileFrameY)
        {
            offsetY = -14;
            height = 38;
        }

        public override bool PreDraw(int i, int j, SpriteBatch spriteBatch)
        {
            Tile tile = Main.tile[i, j];
			Texture2D Texture = ModContent.Request<Texture2D>("MultidimensionMod/Tiles/Biomes/Mire/MireSurfaceFoliage").Value;
            Texture2D GlowTexture = ModContent.Request<Texture2D>("MultidimensionMod/Tiles/Biomes/Mire/MireSurfaceFoliage_Glow").Value;

            Vector2 zero = Main.drawToScreen ? Vector2.Zero : new Vector2(Main.offScreenRange, Main.offScreenRange);
            // Offset along the Y axis depending on the current frame

            // Make sure to draw with Color.White or at least a color that is fully opaque
            // Achieve opaqueness by increasing the alpha channel closer to 255. (lowering closer to 0 will achieve transparency)
            if (!Main.dayTime)
            {
                spriteBatch.Draw(GlowTexture, new Vector2(i * 16 - (int)Main.screenPosition.X, j * 16 - (int)Main.screenPosition.Y) + zero, new Rectangle(tile.TileFrameX, tile.TileFrameY, 16, 18), Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
            }
			else
				spriteBatch.Draw(Texture, new Vector2(i * 16 - (int)Main.screenPosition.X, j * 16 - (int)Main.screenPosition.Y) + zero, new Rectangle(tile.TileFrameX, tile.TileFrameY, 16, 18), Lighting.GetColor(i, j), 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);

            // Return false to stop vanilla draw
            return false;
        }

        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)   //light colors
        {
            r = 0;
            g = 0.05f;
            b = 0.15f;
        }
    }
}