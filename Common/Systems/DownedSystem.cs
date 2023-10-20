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
        public static bool seenAether;
        public static bool downedSmiley;
        public static bool downedGrudge;
        public static bool metAdel;
        public static bool metVertrarius;
        public static bool listenedToNonsense;
        public static bool seenMushroom;
        public static bool downedMonarch;
        public static bool metDapper;

        public override void OnWorldLoad()
        {
            seenFU = false;
            seenHell = false;
            seenDungeon = false;
            seenTemple = false;
            seenAether = false;
            downedSmiley = false;
            downedGrudge = false;
            metAdel = false;
            metVertrarius = false;
            listenedToNonsense = false;
            seenMushroom = false;
            downedMonarch = false;
            metDapper = false;
        }

        public override void OnWorldUnload()
        {
            seenFU = false;
            seenHell = false;
            seenDungeon = false;
            seenTemple = false;
            seenAether = false;
            downedSmiley = false;
            downedGrudge = false;
            metAdel = false;
            metVertrarius = false;
            listenedToNonsense = false;
            seenMushroom = false;
            downedMonarch = false;
            metDapper = false;
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
            if (seenAether)
                downed.Add("seenAether");
            if (downedSmiley)
                downed.Add("downedSmiley");
            if (downedGrudge)
                downed.Add("downedGrudge");
            if (metAdel)
                downed.Add("metAdel");
            if (metVertrarius)
                downed.Add("metVertrarius");
            if (listenedToNonsense)
                downed.Add("listenedToNonsense");
            if (seenMushroom)
                downed.Add("seenMushroom");
            if (downedMonarch)
                downed.Add("downedMonarch");
            if (metDapper)
                downed.Add("metDapper");

            tag["downed"] = downed;
        }

        public override void LoadWorldData(TagCompound tag)
        {
            var downed = tag.GetList<string>("downed");

            seenFU = downed.Contains("seenFU");
            seenHell = downed.Contains("seenHell");
            seenDungeon = downed.Contains("seenDungeon");
            seenTemple = downed.Contains("seenTemple");
            seenAether = downed.Contains("seenAether");
            downedSmiley = downed.Contains("downedSmiley");
            downedGrudge = downed.Contains("downedGrudge");
            metAdel = downed.Contains("metAdel");
            metVertrarius = downed.Contains("metVertrarius");
            listenedToNonsense = downed.Contains("listenedToNonsense");
            seenMushroom = downed.Contains("seenMushroom");
            downedMonarch = downed.Contains("downedMonarch");
            metDapper = downed.Contains("metDapper");
        }

        public override void NetSend(BinaryWriter writer)
        {
            var flags = new BitsByte();
            flags[0] = seenFU;
            flags[1] = seenHell;
            flags[2] = seenDungeon;
            flags[3] = seenTemple;
            flags[4] = seenAether;
            flags[5] = downedSmiley;
            flags[6] = downedGrudge;
            flags[7] = metAdel;
            writer.Write(flags);

            var flags2 = new BitsByte();
            flags2[0] = metVertrarius;
            flags2[1] = listenedToNonsense;
            flags2[2] = seenMushroom;
            flags2[3] = downedMonarch;
            flags2[4] = metDapper;
            writer.Write(flags2);
        }

        public override void NetReceive(BinaryReader reader)
        {
            BitsByte flags = reader.ReadByte();
            seenFU = flags[0];
            seenHell = flags[1];
            seenDungeon = flags[2];
            seenTemple = flags[3];
            seenAether = flags[4];
            downedSmiley = flags[5];
            downedGrudge = flags[6];
            metAdel = flags[7];

            BitsByte flags2 = reader.ReadByte();
            metVertrarius = flags2[0];
            listenedToNonsense = flags2[1];
            seenMushroom = flags2[2];
            downedMonarch = flags2[3];
            metDapper = flags2[4];
        }
    }
}
