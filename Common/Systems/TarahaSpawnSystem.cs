using MultidimensionMod.NPCs.TownNPCs;
using System;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace MultidimensionMod.Common.Systems;

public class TarahaSpawnSystem : ModSystem
{
    public override void PreUpdateWorld()
    {
        Taraha.UpdateTravelingMerchant();
    }

    public override void SaveWorldData(TagCompound tag)
    {
        if (Taraha.spawnTime != double.MaxValue)
        {
            tag["TarahaSpawnTime"] = Taraha.spawnTime;
        }
    }

    public override void LoadWorldData(TagCompound tag)
    {
        if (!tag.TryGet("TarahaSpawnTime", out Taraha.spawnTime))
        {
            Taraha.spawnTime = double.MaxValue;
        }
    }
}