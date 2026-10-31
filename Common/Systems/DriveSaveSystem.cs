using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace MultidimensionMod.Common.Systems
{
    public class DriveSaveSystem : ModSystem
    {
        public static bool DarkMatterDriveAnalysed;
        public static bool MadnessDriveAnalysed;

        public override void OnWorldLoad()
        {
            MadnessDriveAnalysed = false;
            DarkMatterDriveAnalysed = false;
            //VoidDriveAnalysed = false;
            //ShimmerDriveAnalysed = false;
            //CelestialDriveAnalysed = false;
        }

        public override void OnWorldUnload()
        {
            MadnessDriveAnalysed = false;
            DarkMatterDriveAnalysed = false;
        }

        public override void SaveWorldData(TagCompound tag)
        {
            var downed = new List<string>();

            if (MadnessDriveAnalysed)
                downed.Add("MadnessDriveAnalysed");
            if (DarkMatterDriveAnalysed)
                downed.Add("DarkMatterDriveAnalysed");

            tag["drives"] = downed;
        }

        public override void LoadWorldData(TagCompound tag)
        {
            var downed = tag.GetList<string>("downed");

            MadnessDriveAnalysed = downed.Contains("MadnessDriveAnalysed");
            DarkMatterDriveAnalysed = downed.Contains("DarkMatterDriveAnalysed");
        }

        public override void NetSend(BinaryWriter writer)
        {
            var flags = new BitsByte();
            flags[0] = MadnessDriveAnalysed;
            flags[1] = DarkMatterDriveAnalysed;
            writer.Write(flags);
        }

        public override void NetReceive(BinaryReader reader)
        {
            BitsByte flags = reader.ReadByte();
            MadnessDriveAnalysed = flags[0];
            DarkMatterDriveAnalysed = flags[1];
        }
    }
}
