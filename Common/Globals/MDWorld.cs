using MultidimensionMod.Biomes;
using MultidimensionMod.Common.Systems;
using MultidimensionMod.NPCs.TownNPCs;
using MultidimensionMod.Walls;
using MultidimensionMod.Base;
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
using Terraria.Audio;
using ReLogic.Utilities;
using MultidimensionMod.Sounds;

namespace MultidimensionMod.Common.Globals
{
    public class MDWorld : ModSystem
    {
        public static bool MadnessMoon;
        public static int TposeTimer;
        public static int BoxTimer;
        private ActiveSound BlizzardSound;
        private SlotId BlizzardLoop;
        private ActiveSound DripSound;
        private SlotId DripLoop;
        public static bool Monday = false;
        public override void PostUpdateWorld()
        {
            #region Frozen Underworld ashstorm loop
            Player player = Main.LocalPlayer;
            if (Main.LocalPlayer.InModBiome(ModContent.GetInstance<FrozenUnderworld>()))
            {
                if (BlizzardSound == null)
                {
                    BlizzardLoop = SoundEngine.PlaySound(SoundID.BlizzardStrongLoop with { Volume = 0.50f }, player.Center);

                }
                if (SoundEngine.TryGetActiveSound(BlizzardLoop, out BlizzardSound))
                {
                    BlizzardSound.Position = player.Center;
                }
            }
            if (!Main.LocalPlayer.InModBiome(ModContent.GetInstance<FrozenUnderworld>()))
            {
                if (BlizzardSound != null)
                {
                    BlizzardSound.Stop();
                    BlizzardLoop = SlotId.Invalid;
                }
            }
            #endregion
            #region Lake Depths droplet ambience that I stole from Hollow Knight
            if (Main.LocalPlayer.InModBiome(ModContent.GetInstance<TheLakeDepths>()))
            {
                if (DripSound == null)
                {
                    DripLoop = SoundEngine.PlaySound(CustomSounds.LakeAmbience with { Volume = 2.00f }, player.Center);

                }
                if (SoundEngine.TryGetActiveSound(DripLoop, out DripSound))
                {
                    DripSound.Position = player.Center;
                }
            }
            if (!Main.LocalPlayer.InModBiome(ModContent.GetInstance<TheLakeDepths>()))
            {
                if (DripSound != null)
                {
                    DripSound.Stop();
                    DripLoop = SlotId.Invalid;
                }
            }
            #endregion
            #region Title cards
            if (ModContent.GetInstance<MDConfig>().ALTitleCards)
            {
                if (Main.LocalPlayer.InModBiome(ModContent.GetInstance<FrozenUnderworld>()) & !DownedSystem.seenFU)
                {
                    MDSystem.Instance.TitleCardUIElement.DisplayTitle(Language.GetTextValue("Mods.MultidimensionMod.TitleCards.Biomes.FU.Name"), 90, 120, 1.6f, 0, Color.LightGray, Language.GetTextValue("Mods.MultidimensionMod.TitleCards.Biomes.FU.Title"));
                    NPC.SetEventFlagCleared(ref DownedSystem.seenFU, -1);
                }
                if (Main.LocalPlayer.ZoneDungeon & !DownedSystem.seenDungeon)
                {
                    MDSystem.Instance.TitleCardUIElement.DisplayTitle(Language.GetTextValue("Mods.MultidimensionMod.TitleCards.Biomes.Dungeon.Name"), 90, 120, 1.6f, 0, Color.DarkGray, Language.GetTextValue("Mods.MultidimensionMod.TitleCards.Biomes.Dungeon.Title"));
                    NPC.SetEventFlagCleared(ref DownedSystem.seenDungeon, -1);
                }
                if (Main.LocalPlayer.ZoneLihzhardTemple & !DownedSystem.seenTemple)
                {
                    MDSystem.Instance.TitleCardUIElement.DisplayTitle(Language.GetTextValue("Mods.MultidimensionMod.TitleCards.Biomes.JungleTemple.Name"), 90, 120, 1.6f, 0, Color.Brown, Language.GetTextValue("Mods.MultidimensionMod.TitleCards.Biomes.JungleTemple.Title"));
                    NPC.SetEventFlagCleared(ref DownedSystem.seenTemple, -1);
                }
                if (Main.LocalPlayer.ZoneUnderworldHeight & !Main.LocalPlayer.InModBiome(ModContent.GetInstance<FrozenUnderworld>()) & !DownedSystem.seenHell)
                {
                    MDSystem.Instance.TitleCardUIElement.DisplayTitle(Language.GetTextValue("Mods.MultidimensionMod.TitleCards.Biomes.Underworld.Name"), 90, 120, 1.6f, 0, Color.OrangeRed, Language.GetTextValue("Mods.MultidimensionMod.TitleCards.Biomes.Underworld.Title"));
                    NPC.SetEventFlagCleared(ref DownedSystem.seenHell, -1);
                }
                if (Main.LocalPlayer.ZoneShimmer & !DownedSystem.seenAether)
                {
                    MDSystem.Instance.TitleCardUIElement.DisplayTitle(Language.GetTextValue("Mods.MultidimensionMod.TitleCards.Biomes.Aether.Name"), 90, 120, 1.6f, 0, Color.Pink, Language.GetTextValue("Mods.MultidimensionMod.TitleCards.Biomes.Aether.Title"));
                    NPC.SetEventFlagCleared(ref DownedSystem.seenAether, -1);
                }
                if (Main.LocalPlayer.InModBiome(ModContent.GetInstance<ShroomForest>()) & !DownedSystem.seenMushroom)
                {
                    MDSystem.Instance.TitleCardUIElement.DisplayTitle(Language.GetTextValue("Mods.MultidimensionMod.TitleCards.Biomes.ShroomForest.Name"), 90, 120, 1.6f, 0, Color.Red, Language.GetTextValue("Mods.MultidimensionMod.TitleCards.Biomes.ShroomForest.Title"));
                    NPC.SetEventFlagCleared(ref DownedSystem.seenMushroom, -1);
                }
                if (Main.LocalPlayer.InModBiome(ModContent.GetInstance<TheDragonHoard>()) & !DownedSystem.seenInferno)
                {
                    MDSystem.Instance.TitleCardUIElement.DisplayTitle(Language.GetTextValue("Mods.MultidimensionMod.TitleCards.Biomes.Inferno.Name"), 90, 120, 1.6f, 0, Color.OrangeRed, Language.GetTextValue("Mods.MultidimensionMod.TitleCards.Biomes.Inferno.Title"));
                    NPC.SetEventFlagCleared(ref DownedSystem.seenInferno, -1);
                }
                if (Main.LocalPlayer.InModBiome(ModContent.GetInstance<TheDragonBurrow>()) & Framing.GetTileSafely(player.Center.ToTileCoordinates()).WallType == ModContent.WallType<VolcanicRockWallPlaced>() & !DownedSystem.seenVolcano)
                {
                    MDSystem.Instance.TitleCardUIElement.DisplayTitle(Language.GetTextValue("Mods.MultidimensionMod.TitleCards.Biomes.InfernoUG.Name"), 90, 120, 1.6f, 0, Color.OrangeRed, Language.GetTextValue("Mods.MultidimensionMod.TitleCards.Biomes.InfernoUG.Title"));
                    NPC.SetEventFlagCleared(ref DownedSystem.seenVolcano, -1);
                }
                if (Main.LocalPlayer.InModBiome(ModContent.GetInstance<TheShroudedMire>()) & !DownedSystem.seenMire)
                {
                    MDSystem.Instance.TitleCardUIElement.DisplayTitle(Language.GetTextValue("Mods.MultidimensionMod.TitleCards.Biomes.Mire.Name"), 90, 120, 1.6f, 0, Color.CornflowerBlue, Language.GetTextValue("Mods.MultidimensionMod.TitleCards.Biomes.Mire.Title"));
                    NPC.SetEventFlagCleared(ref DownedSystem.seenMire, -1);
                }
                if (Main.LocalPlayer.InModBiome(ModContent.GetInstance<TheLakeDepths>()) & Framing.GetTileSafely(player.Center.ToTileCoordinates()).WallType == ModContent.WallType<DankDepthstoneWallPlaced>() & !DownedSystem.seenLake)
                {
                    MDSystem.Instance.TitleCardUIElement.DisplayTitle(Language.GetTextValue("Mods.MultidimensionMod.TitleCards.Biomes.MireUG.Name"), 90, 120, 1.6f, 0, Color.CornflowerBlue, Language.GetTextValue("Mods.MultidimensionMod.TitleCards.Biomes.MireUG.Title"));
                    NPC.SetEventFlagCleared(ref DownedSystem.seenLake, -1);
                }
            }
            #endregion
            #region Night of Madness
            if (!Main.fastForwardTimeToDawn && !Main.fastForwardTimeToDusk)
            {
                if (!Main.dayTime && Main.time == 0)
                {
                    if (Main.rand.NextBool(20))
                    {
                        if (Main.netMode != NetmodeID.MultiplayerClient)
                        {
                            if (!MadnessMoon && NPC.downedBoss2)
                            {
                                MadnessMoon = true;
                                if (!Main.dayTime)
                                {
                                    string status = Language.GetTextValue("Mods.MultidimensionMod.MiscText.MadnessStart");
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
            if (MadnessMoon && Main.dayTime)
            {
                MadnessMoon = false;
            }
            if (MadnessMoon && Main.dayTime && Main.hardMode)
            {
                //Drops Light Depreived Eye
            }
            #endregion
            if (Main.dayTime && Main.time == 0)
            {
                MDGlobalTownNPC.AngelerInt = 0;
            }
        }

        public override void PostUpdateNPCs()
        {
            if (Terraria.NPC.AnyNPCs(ModContent.NPCType<DoriraTpose>()))
                TposeTimer++;
            if (Terraria.NPC.AnyNPCs(ModContent.NPCType<Dapperbox>()))
                BoxTimer++;
        }

        public override void OnWorldLoad()
        {
            MadnessMoon = false;
        }

        public override void OnWorldUnload()
        {
            MadnessMoon = false;
        }

        public override void ClearWorld()
        {
            TposeTimer = 0;
            BoxTimer = 0;
        }

        public override void SaveWorldData(TagCompound tag)
        {
            var lists = new List<string>();

            if (MadnessMoon)
                lists.Add("MadnessMoon");

            tag["lists"] = lists;

            tag["tposeTimer"] = TposeTimer;
            tag["boxTimer"] = BoxTimer;
        }

        public override void LoadWorldData(TagCompound tag)
        {
            var lists = tag.GetList<string>("lists");
            MadnessMoon = lists.Contains("MadnessMoon");

            TposeTimer = tag.GetInt("tposeTimer");
            BoxTimer = tag.GetInt("boxTimer");
        }

        public override void NetSend(BinaryWriter writer)
        {
            var flags = new BitsByte();
            flags[0] = MadnessMoon;
            writer.Write(flags);

            writer.Write(TposeTimer);
            writer.Write(BoxTimer);
        }

        public override void NetReceive(BinaryReader reader)
        {
            BitsByte flags = reader.ReadByte();
            MadnessMoon = flags[0];

            TposeTimer = reader.ReadInt32();
            BoxTimer = reader.ReadInt32();
        }
    }
}