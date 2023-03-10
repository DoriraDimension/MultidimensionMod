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
    public class MDWorld : ModSystem
    {
        public static bool MadnessMoon;
        public override void PostUpdateWorld()
        {
            if (Main.LocalPlayer.InModBiome(ModContent.GetInstance<FrozenUnderworld>()) & !DownedSystem.seenFU)
            {
                MDSystem.Instance.TitleCardUIElement.DisplayTitle("The Frozen Underworld", 90, 120, 1.6f, 0, Color.LightGray, "Sinner's Wasteland");
                NPC.SetEventFlagCleared(ref DownedSystem.seenFU, -1);
            }
            #region Night of Madness
            if (!Main.fastForwardTimeToDawn && !Main.fastForwardTimeToDusk)
            {
                if (Main.time <= 1)
                {
                    if (Main.rand.NextBool(50))
                    {
                        if (!Main.dayTime && Main.time > 1)
                        {
                            if (Main.netMode != NetmodeID.MultiplayerClient)
                            {
                                if (!MadnessMoon && NPC.downedBoss2)
                                {
                                    MadnessMoon = true;
                                    if (!Main.dayTime)
                                    {
                                        string status = "You feel your mind pierced...";
                                        if (Main.netMode == NetmodeID.Server)
                                            ChatHelper.BroadcastChatMessage(NetworkText.FromLiteral(status), Color.Gold);
                                        else if (Main.netMode == NetmodeID.SinglePlayer)
                                            Main.NewText(Language.GetTextValue(status), Color.Gold);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            if (MadnessMoon && Main.dayTime)
            {
                MadnessMoon = false;
            }
            #endregion
        }

        public override void OnWorldLoad()
        {
            MadnessMoon = false;
        }

        public override void OnWorldUnload()
        {
            MadnessMoon = false;
        }

        public override void SaveWorldData(TagCompound tag)
        {
            var lists = new List<string>();

            if (MadnessMoon)
                lists.Add("MadnessMoon");

            tag["lists"] = lists;
        }

        public override void LoadWorldData(TagCompound tag)
        {
            var lists = tag.GetList<string>("lists");
            MadnessMoon = lists.Contains("MadnessMoon");
        }

        public override void NetSend(BinaryWriter writer)
        {
            var flags = new BitsByte();
            flags[0] = MadnessMoon;
            writer.Write(flags);
        }

        public override void NetReceive(BinaryReader reader)
        {
            BitsByte flags = reader.ReadByte();
            MadnessMoon = flags[2];
        }
    }
}