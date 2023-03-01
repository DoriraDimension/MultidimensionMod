using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace MultidimensionMod.Common.Systems
{
    public class DownedSystem : ModSystem
    {
        public static bool seenFU;

        public override void OnWorldLoad()
        {
            seenFU = false;
        }

        public override void OnWorldUnload()
        {
            seenFU = false;
        }

        public override void SaveWorldData(TagCompound tag)
        {
            var downed = new List<string>();

            if (seenFU)
                downed.Add("seenFU");

            tag["downed"] = downed;
        }

        public override void LoadWorldData(TagCompound tag)
        {
            var downed = tag.GetList<string>("downed");

            seenFU = downed.Contains("seenFU");
        }

        public override void NetSend(BinaryWriter writer)
        {
            var flags = new BitsByte();
            flags[0] = seenFU;
            writer.Write(flags);
        }

        public override void NetReceive(BinaryReader reader)
        {
            BitsByte flags = reader.ReadByte();
            seenFU = flags[0];
        }
    }
}
