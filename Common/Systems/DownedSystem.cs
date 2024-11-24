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
        public static bool downedFungus;
        public static bool sawUmosTransition;
        public static bool seenInferno;
        public static bool seenVolcano;
        public static bool downedGrips;
        public static bool seenMire;
        public static bool seenLake;
        public static bool seenFeudalIntro;

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
            downedFungus = false;
            sawUmosTransition = false;
            seenInferno = false;
            seenVolcano = false;
            downedGrips = false;
            seenMire = false;
            seenLake = false;
            seenFeudalIntro = false;
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
            downedFungus = false;
            sawUmosTransition = false;
            seenInferno = false;
            seenVolcano = false;
            downedGrips = false;
            seenMire = false;
            seenLake = false;
            seenFeudalIntro = false;
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
            if (downedFungus)
                downed.Add("downedFungus");
            if (sawUmosTransition)
                downed.Add("sawUmosTransition");
            if (seenInferno)
                downed.Add("seenInferno");
            if (seenVolcano)
                downed.Add("seenVolcano");
            if (downedGrips)
                downed.Add("downedGrips");
            if (seenMire)
                downed.Add("seenMire");
            if (seenLake)
                downed.Add("seenLake");
            if (seenFeudalIntro)
                downed.Add("seenFeudalIntro");

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
            downedFungus = downed.Contains("downedFungus");
            sawUmosTransition = downed.Contains("sawUmosTransition");
            seenInferno = downed.Contains("seenInferno");
            seenVolcano = downed.Contains("seenVolcano");
            downedGrips = downed.Contains("downedGrips");
            seenMire = downed.Contains("seenMire");
            seenLake = downed.Contains("seenLake");
            seenFeudalIntro = downed.Contains("seenFeudalIntro");
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
            flags2[5] = downedFungus;
            flags2[6] = sawUmosTransition;
            flags2[7] = seenInferno;
            writer.Write(flags2);

            var flags3 = new BitsByte();
            flags3[0] = seenVolcano;
            flags3[1] = downedGrips;
            flags3[2] = seenMire;
            flags3[3] = seenLake;
            flags3[4] = seenFeudalIntro;
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
            downedFungus = flags2[5];
            sawUmosTransition = flags2[6];
            seenInferno = flags2[7];

            BitsByte flags3 = reader.ReadByte();
            seenVolcano = flags3[0];
            downedGrips = flags3[1];
            seenMire = flags3[2];
            seenLake = flags3[3];
            seenFeudalIntro = flags3[4];
        }
    }

    public class MemorySystem : ModSystem
    {
        public static bool seenMemory;
        public static bool summonedMoonSword;

        public override void OnWorldLoad()
        {
            seenMemory = false;
            summonedMoonSword = false;
        }

        public override void OnWorldUnload()
        {
            seenMemory = false;
            summonedMoonSword = false;
        }

        public override void SaveWorldData(TagCompound tag)
        {
            var downed = new List<string>();

            if (seenMemory)
                downed.Add("seenMemory");
            if (summonedMoonSword)
                downed.Add("summonedMoonSword");

            tag["memory"] = downed;
        }

        public override void LoadWorldData(TagCompound tag)
        {
            var downed = tag.GetList<string>("memory");

            seenMemory = downed.Contains("seenMemory");
            summonedMoonSword = downed.Contains("summonedMoonSword");
        }

        public override void NetSend(BinaryWriter writer)
        {
            var flags = new BitsByte();
            flags[0] = seenMemory;
            flags[1] = summonedMoonSword;
            writer.Write(flags);
        }

        public override void NetReceive(BinaryReader reader)
        {
            BitsByte flags = reader.ReadByte();
            seenMemory = flags[0];
            summonedMoonSword = flags[1];
        }
    }
}
