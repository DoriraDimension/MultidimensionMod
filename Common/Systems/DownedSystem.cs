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
        public static bool seenHell;
        public static bool seenDungeon;
        public static bool seenTemple;

        public override void OnWorldLoad()
        {
            seenFU = false;
            seenHell = false;
            seenDungeon = false;
            seenTemple = false;
        }

        public override void OnWorldUnload()
        {
            seenFU = false;
            seenHell = false;
            seenDungeon = false;
            seenTemple = false;
        }

        public override void SaveWorldData(TagCompound tag)
        {
            var downed = new List<string>();

            if (seenFU)
                downed.Add("seenFU");
            if (seenHell)
                downed.Add("seenHell");
            if (seenDungeon)
                downed.Add("seenDungeon");
            if (seenTemple)
                downed.Add("seenTemple");

            tag["downed"] = downed;
        }

        public override void LoadWorldData(TagCompound tag)
        {
            var downed = tag.GetList<string>("downed");

            seenFU = downed.Contains("seenFU");
            seenHell = downed.Contains("seenHell");
            seenDungeon = downed.Contains("seenDungeon");
            seenTemple = downed.Contains("seenTemple");
        }

        public override void NetSend(BinaryWriter writer)
        {
            var flags = new BitsByte();
            flags[0] = seenFU;
            flags[1] = seenHell;
            flags[2] = seenDungeon;
            flags[3] = seenTemple;
            writer.Write(flags);
        }

        public override void NetReceive(BinaryReader reader)
        {
            BitsByte flags = reader.ReadByte();
            seenFU = flags[0];
            seenHell = flags[1];
            seenDungeon = flags[2];
            seenTemple = flags[3];
        }
    }
}
