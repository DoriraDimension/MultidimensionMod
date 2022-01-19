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
            if (type == ModContent.TileType<ColdAsh>() && Main.tile[i, j - 1].type == 0 && Main.tile[i, j].active() && Main.tile[i, j - 1].liquid == 0 && Main.tile[i, j - 1].wall == 0 && Main.rand.Next(400) == 0)
            {
                WorldGen.PlaceTile(i, j - 1, ModContent.TileType<Iceblossom>(), mute: true);
            }
        }
    }
}