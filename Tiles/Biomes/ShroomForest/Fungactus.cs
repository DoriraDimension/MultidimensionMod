using MultidimensionMod.Tiles.Biomes.ShroomForest;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria.ModLoader;

namespace MultidimensionMod.Tiles.Biomes.ShroomForest
{
    public class Fungactus : ModCactus
    {
        public override void SetStaticDefaults()
        {
            GrowsOnTileId = new int[1] { ModContent.TileType<MyceliumSandPlaced>() };
        }

        public override Asset<Texture2D> GetTexture()
        {
            return ModContent.Request<Texture2D>("MultidimensionMod/Tiles/Biomes/ShroomForest/Fungactus");
        }

        public override Asset<Texture2D> GetFruitTexture()
        {
            return null;
        }
    }
}