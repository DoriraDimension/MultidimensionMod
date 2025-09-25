using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Tiles.Biomes.Mire
{
    public class BigFlower : ModPalmTree
    {
        private Asset<Texture2D> texture;
        private Asset<Texture2D> oasisTopsTexture;
        private Asset<Texture2D> topsTexture;

        public override TreePaintingSettings TreeShaderSettings => new TreePaintingSettings
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
            texture = ModContent.Request<Texture2D>("MultidimensionMod/Tiles/Biomes/Mire/BigFlower");
            topsTexture = ModContent.Request<Texture2D>("MultidimensionMod/Tiles/Biomes/Mire/BigFlowerTops");
            oasisTopsTexture = ModContent.Request<Texture2D>("MultidimensionMod/Tiles/Biomes/Mire/BigFlowerTopsOasis");
        }

        public override Asset<Texture2D> GetTexture() => texture;

        public override int SaplingGrowthType(ref int style)
        {
            style = 0;
            return ModContent.TileType<BigFlowerSapling>();
        }

        public override int DropWood()
        {
            return ModContent.ItemType<Items.Placeables.Biomes.Mire.MireSeeds>();
        }

        public override Asset<Texture2D> GetOasisTopTextures() => oasisTopsTexture;

        // Palm Trees come in a Beach variant. The Top Textures for it:
        public override Asset<Texture2D> GetTopTextures() => topsTexture;
    }
}