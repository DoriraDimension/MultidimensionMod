using MultidimensionMod.Items.Placeables.Biomes.FrozenUnderworld;
using MultidimensionMod.Items.Materials;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using System;
using MultidimensionMod.Items.Placeables.Biomes.Mire;

namespace MultidimensionMod.Tiles.Biomes.Mire
{
    public enum PlantStage : byte
    {
        Planted,
        Growing,
        Grown
    }

    public class DreamLily : ModTile
    {
        private const int FrameWidth = 18;

        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileCut[Type] = true;
            Main.tileNoFail[Type] = true;
            DustType = DustID.BlueMoss;

            TileObjectData.newTile.CopyFrom(TileObjectData.StyleAlch);

            TileObjectData.newTile.AnchorValidTiles = new int[]
            {
                ModContent.TileType<MireGrass>()
            };

            TileObjectData.newTile.AnchorAlternateTiles = new int[]
            {
                TileID.ClayPot,
                TileID.PlanterBox
            };

            TileObjectData.addTile(Type);
        }

        public override void SetSpriteEffects(int i, int j, ref SpriteEffects spriteEffects)
        {
            if (i % 2 == 1)
                spriteEffects = SpriteEffects.FlipHorizontally;
        }

        public override bool CanDrop(int i, int j)
        {
            PlantStage stage = GetStage(i, j);

            if (stage == PlantStage.Planted)
            {
                // Do not drop anything when just planted
                return false;
            }

            Vector2 worldPosition = new Vector2(i, j).ToWorldCoordinates();
            Player nearestPlayer = Main.player[Player.FindClosest(worldPosition, 16, 16)];

            int herbItemType = ModContent.ItemType<DreamLilyItem>();
            int herbItemStack = 1;

            int seedItemType = ModContent.ItemType<DreamLilySeeds>();
            int seedItemStack = 1;

            if (nearestPlayer.active && nearestPlayer.HeldItem.type == ItemID.StaffofRegrowth)
            {
                // Increased yields with Staff of Regrowth, even when not fully grown
                herbItemStack = Main.rand.Next(1, 3);
                seedItemStack = Main.rand.Next(1, 6);
            }
            else if (stage == PlantStage.Grown)
            {
                // Default yields, only when fully grown
                herbItemStack = 1;
                seedItemStack = Main.rand.Next(1, 4);
            }

            var source = new EntitySource_TileBreak(i, j);

            if (herbItemType > 0 && herbItemStack > 0)
            {
                Item.NewItem(source, worldPosition, herbItemType, herbItemStack);
            }

            if (seedItemType > 0 && seedItemStack > 0)
            {
                Item.NewItem(source, worldPosition, seedItemType, seedItemStack);
            }

            // Custom drop code, so return false
            return false;
        }

        public override void NearbyEffects(int i, int j, bool closer)
        {
            Tile tile = Framing.GetTileSafely(i, j);
            PlantStage stage = GetStage(i, j);
            //Blooms between 10:30pm and 1:30am
            if (stage == PlantStage.Growing && Main.time > 10800 && !Main.dayTime && Main.time <= 21600)
            {
                tile.TileFrameX += FrameWidth;

                if (Main.netMode != NetmodeID.SinglePlayer)
                {
                    NetMessage.SendTileSquare(-1, i, j, 1);
                }
            }
            if (stage == PlantStage.Grown && !Main.dayTime && Main.time >= 21600) //16200 is midnight
            {
                tile.TileFrameX -= FrameWidth;

                if (Main.netMode != NetmodeID.SinglePlayer)
                {
                    NetMessage.SendTileSquare(-1, i, j, 1);
                }
            }
        }


        public override void RandomUpdate(int i, int j)
        {
            Tile tile = Framing.GetTileSafely(i, j);
            PlantStage stage = GetStage(i, j);
            if (stage == PlantStage.Planted)
            {
                tile.TileFrameX += FrameWidth;

                if (Main.netMode != NetmodeID.SinglePlayer)
                    NetMessage.SendTileSquare(-1, i, j, 1);
            }
        }

        private static PlantStage GetStage(int i, int j)
        {
            Tile tile = Framing.GetTileSafely(i, j);
            return (PlantStage)(tile.TileFrameX / FrameWidth);
        }

        public override bool IsTileSpelunkable(int i, int j)
        {
            PlantStage stage = GetStage(i, j);
            return stage == PlantStage.Grown;
        }
    }
}