using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using MultidimensionMod.Items.Placeables.Biomes.Mire;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using ReLogic.Content;
using MultidimensionMod.Tiles.Biomes.ShroomForest;


namespace MultidimensionMod.Tiles.Biomes.Mire
{
    class BogwoodTree : ModTree
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
            GrowsOnTileId = new int[1] { ModContent.TileType<MireGrass>() };
        }

        public override int DropWood()
        {
            return ModContent.ItemType<Bogwood>();
        }

        public override int SaplingGrowthType(ref int style)
        {
            style = 0;
            return ModContent.TileType<BogwoodSapling>();
        }

        public override bool Shake(int x, int y, ref bool createLeaves)
        {
            Item.NewItem(WorldGen.GetItemSource_FromTreeShake(x, y), new Vector2(x, y) * 16, ModContent.ItemType<Bogwood>());
            return false;
        }

        public override void SetTreeFoliageSettings(Tile tile, ref int xoffset, ref int treeFrame, ref int floorY, ref int topTextureFrameWidth, ref int topTextureFrameHeight)
        {

        }

        public override Asset<Texture2D> GetTexture()
        {
            return ModContent.Request<Texture2D>("MultidimensionMod/Tiles/Biomes/Mire/BogwoodTree");
        }

        public override Asset<Texture2D> GetBranchTextures()
        {
            return ModContent.Request<Texture2D>("MultidimensionMod/Tiles/Biomes/Mire/BogwoodBranches");
        }

        public override Asset<Texture2D> GetTopTextures()
        {
            return ModContent.Request<Texture2D>("MultidimensionMod/Tiles/Biomes/Mire/BogwoodTreeTop");
        }

        public override int CreateDust() => ModContent.DustType<Dusts.BogwoodDust>();
    }
}
