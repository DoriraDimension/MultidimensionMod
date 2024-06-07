using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria.ModLoader;

namespace MultidimensionMod.Tiles.Biomes.Mire
{
    public class Bogtus : ModCactus
    {
        private Asset<Texture2D> texture;

        public override void SetStaticDefaults()
        {
            // Makes Example Cactus grow on ExampleOre
            GrowsOnTileId = new int[1] { ModContent.TileType<DepthsandPlaced>() };
            texture = ModContent.Request<Texture2D>("MultidimensionMod/Tiles/Biomes/Mire/Bogtus");
        }

        public override Asset<Texture2D> GetTexture() => texture;

        // This would be where the Cactus Fruit Texture would go, if we had one.
        public override Asset<Texture2D> GetFruitTexture() => null;
    }
}