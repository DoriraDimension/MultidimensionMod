using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MultidimensionMod.Items.Placeables.Biomes.Mire;
using MultidimensionMod.Items.Placeables.Biomes.Void;
using MultidimensionMod.Items.Potions.Food;
using MultidimensionMod.NPCs.Mire;
using MultidimensionMod.Tiles.Biomes.Mire;
using ReLogic.Content;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.ModLoader;

namespace MultidimensionMod.Tiles.Biomes.Void
{
    class OroborosTree : ModTree
    {
        public override TreePaintingSettings TreeShaderSettings => new()
        {
            UseSpecialGroups = true,
            SpecialGroupMinimalHueValue = 11f / 72f,
            SpecialGroupMaximumHueValue = 0.25f,
            SpecialGroupMinimumSaturationValue = 0.88f,
            SpecialGroupMaximumSaturationValue = 1f
        };

        public override void SetStaticDefaults()
        {
            GrowsOnTileId = new int[2] { ModContent.TileType<Doomgrass>(), ModContent.TileType<DoomstonePlaced>() };
        }

        public override int DropWood()
        {
            return ModContent.ItemType<OroborosWood>();
        }

        public override bool Shake(int x, int y, ref bool createLeaves)
        {
            if (Main.rand.NextBool(120))
            {
                if (Main.rand.NextBool(2))
                    Item.NewItem(new EntitySource_ShakeTree(x, y), x * 16, y * 16, 16, 16, ModContent.ItemType<BinaryStarFruit>());
                else
                    Item.NewItem(new EntitySource_ShakeTree(x, y), x * 16, y * 16, 16, 16, ModContent.ItemType<VoidenMangosteen>());
            }
            if (Main.rand.NextBool(70))
            {
                Item.NewItem(new EntitySource_ShakeTree(x, y), x * 16, y * 16, 16, 16, ModContent.ItemType<OroborosWood>(), Main.rand.Next(6, 8));
            }
            return false;
        }

        public override void SetTreeFoliageSettings(Tile tile, ref int xoffset, ref int treeFrame, ref int floorY, ref int topTextureFrameWidth, ref int topTextureFrameHeight)
        {

        }

        public override Asset<Texture2D> GetTexture()
        {
            return ModContent.Request<Texture2D>("MultidimensionMod/Tiles/Biomes/Void/OroborosTree");
        }

        public override Asset<Texture2D> GetBranchTextures()
        {
            return ModContent.Request<Texture2D>("MultidimensionMod/Tiles/Biomes/Void/OroborosBranches");
        }

        public override Asset<Texture2D> GetTopTextures()
        {
            return ModContent.Request<Texture2D>("MultidimensionMod/Tiles/Biomes/Void/OroborosTreeTop");
        }

        public override int CreateDust() => ModContent.DustType<Dusts.DoomDust>();
    }
}
