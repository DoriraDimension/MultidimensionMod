using MultidimensionMod.Biomes;
using MultidimensionMod.Common.Systems;
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

namespace MultidimensionMod.Common.Globals
{
    public class MDQuests : ModSystem
    {
        public static int DoriraQuests = 0;
        public static int ShadeQuests = 0;
        public static bool CassieQuest;

        public override void OnWorldLoad()
        {
            CassieQuest = false;
        }

        public override void OnWorldUnload()
        {
            CassieQuest = false;
        }

        public override void SaveWorldData(TagCompound tag)
        {
            var quests = new List<string>();
            //Dorira's quests
            if (CassieQuest)
                quests.Add("CassieQuest");
            tag["quests"] = quests;
        }

		public override void LoadWorldData(TagCompound tag)
		{
			var quests = tag.GetList<string>("quests");
			CassieQuest = quests.Contains("CassieQuest");
		}

		public override void NetSend(BinaryWriter writer)
		{
			BitsByte questFlags = default(BitsByte);
			questFlags[0] = CassieQuest;
            writer.Write(questFlags);
        }

		public override void NetReceive(BinaryReader reader)
		{
			BitsByte questFlags = reader.ReadByte();
			CassieQuest = questFlags[0];
		}
	}
}