using MultidimensionMod.Dusts;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Terraria.Localization;
using System;
using Terraria.Utilities;
using MultidimensionMod.NPCs.MushBiomes;

namespace MultidimensionMod.Tiles.Biomes.ShroomForest
{
    public class MushroomPalmTree : ModPalmTree
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
            GrowsOnTileId = new int[2] { ModContent.TileType<MyceliumSandPlaced>(),ModContent.TileType<MyceliumHardsandPlaced>()};
        }

        public override bool Shake(int x, int y, ref bool createLeaves) => false;

        public override Asset<Texture2D> GetTexture()
        {
            return ModContent.Request<Texture2D>("MultidimensionMod/Tiles/Biomes/ShroomForest/MushroomPalmTree");
        }

        public override int SaplingGrowthType(ref int style)
        {
            style = 0;
            return ModContent.TileType<MushPalmSapling>();
        }

        public override Asset<Texture2D> GetTopTextures()
        {
            return ModContent.Request<Texture2D>("MultidimensionMod/Tiles/Biomes/ShroomForest/MushroomPalmTree_OasisTops");
        }
        public override Asset<Texture2D> GetOasisTopTextures()
        {
            return ModContent.Request<Texture2D>("MultidimensionMod/Tiles/Biomes/ShroomForest/MushroomPalmTree_OasisTops");
        }
        public override int DropWood()
        {
            return ItemID.Mushroom;
        }
        public override int CreateDust() => ModContent.DustType<MushroomDust>();
    }
}
