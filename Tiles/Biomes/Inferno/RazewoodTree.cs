using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using MultidimensionMod.Tiles.Biomes.ShroomForest;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using ReLogic.Content;
using Terraria.DataStructures;
using MultidimensionMod.Items.Potions.Food;
using MultidimensionMod.Items.Placeables.Biomes.Inferno;


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
            GrowsOnTileId = new int[2] { ModContent.TileType<InfernoGrass>(), ModContent.TileType<TorchAshPlaced>() };
        }

        public override int DropWood()
        {
            return ModContent.ItemType<Items.Placeables.Biomes.Inferno.Razewood>();
        }

        public override bool Shake(int x, int y, ref bool createLeaves)
        {
            if (Main.rand.NextBool(120))
            {
                if (Main.rand.NextBool(2))
                    Item.NewItem(new EntitySource_ShakeTree(x, y), x * 16, y * 16, 16, 16, ModContent.ItemType<AshgrayDurian>());
                else
                    Item.NewItem(new EntitySource_ShakeTree(x, y), x * 16, y * 16, 16, 16, ModContent.ItemType<FlimmerLychee>());
            }
            if (Main.rand.NextBool(70))
            {
                Item.NewItem(new EntitySource_ShakeTree(x, y), x * 16, y * 16, 16, 16, ModContent.ItemType<Razewood>(), Main.rand.Next(6, 8));
            }
            return false;
        }

        public override void SetTreeFoliageSettings(Tile tile, ref int xoffset, ref int treeFrame, ref int floorY, ref int topTextureFrameWidth, ref int topTextureFrameHeight)
        {

        }

        public override int SaplingGrowthType(ref int style)
        {
            style = 0;
            return ModContent.TileType<RazewoodSapling>();
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
