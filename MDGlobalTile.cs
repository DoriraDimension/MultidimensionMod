using MultidimensionMod.Tiles.FrozenUnderworld; 
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod
{
    public class MDGlobalTile : GlobalTile
    {
        public override void RandomUpdate(int i, int j, int type)
        {
            if (type == ModContent.TileType<ColdAsh>() && Main.rand.Next(1000) == 0)
            {
                WorldGen.PlaceTile(i, j - 1, ModContent.TileType<Iceblossom>(), mute: true);
            }
        }
    }
}