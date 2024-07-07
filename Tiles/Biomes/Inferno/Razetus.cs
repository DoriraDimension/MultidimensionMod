using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria.ModLoader;

namespace MultidimensionMod.Tiles.Biomes.Inferno
{
    public class Razetus : ModCactus
	{
        private Asset<Texture2D> texture;

        public override void SetStaticDefaults()
        {
            // Makes Example Cactus grow on ExampleOre
            GrowsOnTileId = new int[1] { ModContent.TileType<TorchsandPlaced>() };
            texture = ModContent.Request<Texture2D>("MultidimensionMod/Tiles/Biomes/Inferno/Razetus");
        }

        public override Asset<Texture2D> GetTexture() => texture;

        // This would be where the Cactus Fruit Texture would go, if we had one.
        public override Asset<Texture2D> GetFruitTexture() => null;
    }
}