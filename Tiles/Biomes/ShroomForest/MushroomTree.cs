using MultidimensionMod.Dusts;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Tiles.Biomes.ShroomForest
{
    public class MushroomTree : ModTree
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
            GrowsOnTileId = new int[1] { ModContent.TileType<Mycelium>() };
        }
        public override Asset<Texture2D> GetTexture()
        {
            return ModContent.Request<Texture2D>("MultidimensionMod/Tiles/Biomes/ShroomForest/MushroomTree");
        }

        public override int SaplingGrowthType(ref int style)
        {
            style = 0;
            return ModContent.TileType<YoungMushroom>();
        }

        public override bool Shake(int x, int y, ref bool createLeaves)
        {
            Item.NewItem(WorldGen.GetItemSource_FromTreeShake(x, y), new Vector2(x, y) * 16, ItemID.Mushroom);
            return false;
        }

        public override void SetTreeFoliageSettings(Tile tile, ref int xoffset, ref int treeFrame, ref int floorY, ref int topTextureFrameWidth, ref int topTextureFrameHeight)
        {

        }

        public override Asset<Texture2D> GetBranchTextures()
        {
            return ModContent.Request<Texture2D>("MultidimensionMod/Tiles/Biomes/ShroomForest/MushroomTree_Branches");
        }

        public override Asset<Texture2D> GetTopTextures()
        {
            return ModContent.Request<Texture2D>("MultidimensionMod/Tiles/Biomes/ShroomForest/MushroomTree_Tops");
        }
        public override int DropWood()
        {
            return ItemID.Mushroom;
        }
        public override int CreateDust() => ModContent.DustType<MushroomDust>();
    }
}