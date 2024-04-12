using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using MultidimensionMod.Tiles.Biomes.ShroomForest;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using ReLogic.Content;


namespace MultidimensionMod.Tiles.Biomes.Inferno
{
    class RazewoodTree : ModTree
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
            GrowsOnTileId = new int[1] { ModContent.TileType<InfernoGrass>() };
            GrowsOnTileId = new int[1] { ModContent.TileType<TorchAshPlaced>() };
        }

        public override int DropWood()
        {
            return ModContent.ItemType<Items.Placeables.Biomes.Inferno.Razewood>();
        }

        public override bool Shake(int x, int y, ref bool createLeaves)
        {
            Item.NewItem(WorldGen.GetItemSource_FromTreeShake(x, y), new Vector2(x, y) * 16, ModContent.ItemType<Items.Placeables.Biomes.Inferno.Razewood>());
            return false;
        }

        public override void SetTreeFoliageSettings(Tile tile, ref int xoffset, ref int treeFrame, ref int floorY, ref int topTextureFrameWidth, ref int topTextureFrameHeight)
        {

        }

        public override Asset<Texture2D> GetTexture()
        {
            return ModContent.Request<Texture2D>("MultidimensionMod/Tiles/Biomes/Inferno/RazewoodTree");
        }

        public override Asset<Texture2D> GetBranchTextures()
        {
            return ModContent.Request<Texture2D>("MultidimensionMod/Tiles/Biomes/Inferno/RazewoodBranches");
        }

        public override Asset<Texture2D> GetTopTextures()
        {
            return ModContent.Request<Texture2D>("MultidimensionMod/Tiles/Biomes/Inferno/RazewoodTreetop");
        }

        public override int CreateDust() => ModContent.DustType<Dusts.RazewoodDust>();
    }
}
