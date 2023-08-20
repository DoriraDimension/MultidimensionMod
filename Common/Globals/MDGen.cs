using MultidimensionMod.Biomes;
using MultidimensionMod.Common.Systems;
using MultidimensionMod.Tiles.Ores;
using System;
using System.IO;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Chat;
using Terraria.Localization;
using Terraria.ModLoader.IO;
using Mono.Cecil;
using MultidimensionMod.Items.Materials;
using Terraria.GameContent.Generation;
using Terraria.WorldBuilding;
using Terraria.IO;
using static tModPorter.ProgressUpdate;

namespace MultidimensionMod.Common.Globals
{
    public class MDGen : ModSystem
    {
        public override void ModifyWorldGenTasks(List<GenPass> tasks, ref double totalWeight)
        {
            int ShiniesIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Shinies"));
            if (ShiniesIndex != -1)
            {
                tasks.Insert(ShiniesIndex + 1, new PassLegacy("Creating Chaos Ores", DimensiumGen));
            }
        }

        private void DimensiumGen(GenerationProgress progress, GameConfiguration configuration)
        {
            progress.Message = "Generating Chaotic minerals";

            for (int k = 0; k < (int)(Main.maxTilesX * Main.maxTilesY * 0.00006); k++)
            {
                int x = WorldGen.genRand.Next(0, Main.maxTilesX);
                int y = WorldGen.genRand.Next((int)Main.rockLayer, Main.maxTilesY);

                Tile tile = Framing.GetTileSafely(x, y);
                if (tile.HasTile && tile.TileType == TileID.Stone)
                {
                    WorldGen.TileRunner(x, y, WorldGen.genRand.Next(4, 8), WorldGen.genRand.Next(3, 7), ModContent.TileType<DimensiumPlaced>());
                }
            }
        }
    }
}