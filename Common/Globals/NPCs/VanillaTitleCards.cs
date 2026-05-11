using MultidimensionMod.NPCs.Tundra;
using MultidimensionMod.NPCs.FU;
using MultidimensionMod.Biomes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Reflection;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria.ModLoader.IO;

namespace MultidimensionMod.Common.Globals.NPCs
{
	public class VanillaTitleCards : GlobalNPC
	{
        public static bool KingTitleCard = false;
        public static bool EyeTitleCard = false;
        public static bool WormTitleCard = false;
        public static bool BrainTitleCard = false;
        public static bool BeeTitleCard = false;
        public static bool SkeletonTitleCard = false;
        public static bool DeerTitleCard = false;
        public static bool WallTitleCard = false;
        public static bool QueenTitleCard = false;
        public static bool TwinTitleCard = false;
        public static bool MetalWormTitleCard = false;
        public static bool PrimeTitleCard = false;
        public static bool PlantTitleCard = false;
        public static bool GolemTitleCard = false;
        public static bool EmpressTitleCard = false;
        public static bool DukeTitleCard = false;
        public static bool CultistTitleCard = false;
        public static bool MoonTitleCard = false;
        public static bool TorchTitleCard = false;

        public override void AI(NPC npc)
        {
            if (ModContent.GetInstance<MDConfig>().ALTitleCards)
            {
                if (npc.type == NPCID.KingSlime)
                {
                    if (!KingTitleCard)
                    {
                        if (!Main.dedServ)
                        {
                            MDSystem.Instance.TitleCardUIElement.DisplayTitle(Language.GetTextValue("Mods.MultidimensionMod.TitleCards.Bosses.KingSlime.Name"), 60, 90, 1.0f, 0, MDColors.KingSlimeBlue, Language.GetTextValue("Mods.MultidimensionMod.TitleCards.Bosses.KingSlime.Title"));
                            KingTitleCard = true;
                        }
                    }
                }
                if (!NPC.AnyNPCs(NPCID.KingSlime))
                {
                    KingTitleCard = false;
                }
                if (npc.type == NPCID.EyeofCthulhu)
                {
                    if (!EyeTitleCard)
                    {
                        if (!Main.dedServ)
                        {
                            MDSystem.Instance.TitleCardUIElement.DisplayTitle(Language.GetTextValue("Mods.MultidimensionMod.TitleCards.Bosses.Eye.Name"), 60, 90, 1.0f, 0, Color.White, Language.GetTextValue("Mods.MultidimensionMod.TitleCards.Bosses.Eye.Title"));
                            EyeTitleCard = true;
                        }
                    }
                }
                if (!NPC.AnyNPCs(NPCID.EyeofCthulhu))
                {
                    EyeTitleCard = false;
                }
                if (npc.type == NPCID.EaterofWorldsBody)
                {
                    if (!WormTitleCard)
                    {
                        if (!Main.dedServ)
                        {
                            MDSystem.Instance.TitleCardUIElement.DisplayTitle(Language.GetTextValue("Mods.MultidimensionMod.TitleCards.Bosses.Eater.Name"), 60, 90, 1.0f, 0, Color.Green, Language.GetTextValue("Mods.MultidimensionMod.TitleCards.Bosses.Eater.Title"));
                            WormTitleCard = true;
                        }
                    }
                }
                if (!NPC.AnyNPCs(NPCID.EaterofWorldsBody))
                {
                    WormTitleCard = false;
                }
                if (npc.type == NPCID.BrainofCthulhu)
                {
                    if (!BrainTitleCard)
                    {
                        if (!Main.dedServ)
                        {
                            MDSystem.Instance.TitleCardUIElement.DisplayTitle(Language.GetTextValue("Mods.MultidimensionMod.TitleCards.Bosses.Brain.Name"), 60, 90, 1.0f, 0, Color.Pink, Language.GetTextValue("Mods.MultidimensionMod.TitleCards.Bosses.Brain.Title"));
                            BrainTitleCard = true;
                        }
                    }
                }
                if (!NPC.AnyNPCs(NPCID.BrainofCthulhu))
                {
                    BrainTitleCard = false;
                }
                if (npc.type == NPCID.QueenBee)
                {
                    if (!BeeTitleCard)
                    {
                        if (!Main.dedServ)
                        {
                            MDSystem.Instance.TitleCardUIElement.DisplayTitle(Language.GetTextValue("Mods.MultidimensionMod.TitleCards.Bosses.Bee.Name"), 60, 90, 1.0f, 0, Color.Yellow, Language.GetTextValue("Mods.MultidimensionMod.TitleCards.Bosses.Bee.Title"));
                            BeeTitleCard = true;
                        }
                    }
                }
                if (!NPC.AnyNPCs(NPCID.QueenBee))
                {
                    BeeTitleCard = false;
                }
                if (npc.type == NPCID.SkeletronHead)
                {
                    if (!SkeletonTitleCard)
                    {
                        if (!Main.dedServ)
                        {
                            MDSystem.Instance.TitleCardUIElement.DisplayTitle(Language.GetTextValue("Mods.MultidimensionMod.TitleCards.Bosses.Skeletron.Name"), 60, 90, 1.0f, 0, Color.Magenta, Language.GetTextValue("Mods.MultidimensionMod.TitleCards.Bosses.Skeletron.Title"));
                            SkeletonTitleCard = true;
                        }
                    }
                }
                if (!NPC.AnyNPCs(NPCID.SkeletronHead))
                {
                    SkeletonTitleCard = false;
                }
                if (npc.type == NPCID.Deerclops)
                {
                    if (!DeerTitleCard)
                    {
                        if (!Main.dedServ)
                        {
                            MDSystem.Instance.TitleCardUIElement.DisplayTitle(Language.GetTextValue("Mods.MultidimensionMod.TitleCards.Bosses.Deer.Name"), 60, 90, 1.0f, 0, Color.White, Language.GetTextValue("Mods.MultidimensionMod.TitleCards.Bosses.Deer.Title"));
                            DeerTitleCard = true;
                        }
                    }
                }
                if (!NPC.AnyNPCs(NPCID.Deerclops))
                {
                    DeerTitleCard = false;
                }
                if (npc.type == NPCID.WallofFlesh)
                {
                    if (!WallTitleCard)
                    {
                        if (!Main.dedServ)
                        {
                            MDSystem.Instance.TitleCardUIElement.DisplayTitle(Language.GetTextValue("Mods.MultidimensionMod.TitleCards.Bosses.Wall.Name"), 60, 90, 1.0f, 0, Color.Red, Language.GetTextValue("Mods.MultidimensionMod.TitleCards.Bosses.Wall.Title"));
                            WallTitleCard = true;
                        }
                    }
                }
                if (!NPC.AnyNPCs(NPCID.WallofFlesh))
                {
                    WallTitleCard = false;
                }
                if (npc.type == NPCID.QueenSlimeBoss)
                {
                    if (!QueenTitleCard)
                    {
                        if (!Main.dedServ)
                        {
                            MDSystem.Instance.TitleCardUIElement.DisplayTitle(Language.GetTextValue("Mods.MultidimensionMod.TitleCards.Bosses.QueenSlime.Name"), 60, 90, 1.0f, 0, Color.Pink, Language.GetTextValue("Mods.MultidimensionMod.TitleCards.Bosses.QueenSlime.Title"));
                            QueenTitleCard = true;
                        }
                    }
                }
                if (!NPC.AnyNPCs(NPCID.QueenSlimeBoss))
                {
                    QueenTitleCard = false;
                }
                if (npc.type == NPCID.Spazmatism)
                {
                    if (!TwinTitleCard)
                    {
                        if (!Main.dedServ)
                        {
                            MDSystem.Instance.TitleCardUIElement.DisplayTitle(Language.GetTextValue("Mods.MultidimensionMod.TitleCards.Bosses.Twins.Name"), 60, 90, 1.0f, 0, Color.DarkOliveGreen, Language.GetTextValue("Mods.MultidimensionMod.TitleCards.Bosses.Twins.Title"));
                            TwinTitleCard = true;
                        }
                    }
                }
                if (!NPC.AnyNPCs(NPCID.Spazmatism))
                {
                    TwinTitleCard = false;
                }
                if (npc.type == NPCID.TheDestroyer)
                {
                    if (!MetalWormTitleCard)
                    {
                        if (!Main.dedServ)
                        {
                            MDSystem.Instance.TitleCardUIElement.DisplayTitle(Language.GetTextValue("Mods.MultidimensionMod.TitleCards.Bosses.Destroyer.Name"), 60, 90, 1.0f, 0, Color.LightBlue, Language.GetTextValue("Mods.MultidimensionMod.TitleCards.Bosses.Destroyer.Title"));
                            MetalWormTitleCard = true;
                        }
                    }
                }
                if (!NPC.AnyNPCs(NPCID.TheDestroyer))
                {
                    MetalWormTitleCard = false;
                }
                if (npc.type == NPCID.SkeletronPrime)
                {
                    if (!PrimeTitleCard)
                    {
                        if (!Main.dedServ)
                        {
                            MDSystem.Instance.TitleCardUIElement.DisplayTitle(Language.GetTextValue("Mods.MultidimensionMod.TitleCards.Bosses.Prime.Name"), 60, 90, 1.0f, 0, Color.OrangeRed, Language.GetTextValue("Mods.MultidimensionMod.TitleCards.Bosses.Prime.Title"));
                            PrimeTitleCard = true;
                        }
                    }
                }
                if (!NPC.AnyNPCs(NPCID.SkeletronPrime))
                {
                    PrimeTitleCard = false;
                }
                if (npc.type == NPCID.Plantera)
                {
                    if (!PlantTitleCard)
                    {
                        if (!Main.dedServ)
                        {
                            MDSystem.Instance.TitleCardUIElement.DisplayTitle(Language.GetTextValue("Mods.MultidimensionMod.TitleCards.Bosses.Plant.Name"), 60, 90, 1.0f, 0, Color.LimeGreen, Language.GetTextValue("Mods.MultidimensionMod.TitleCards.Bosses.Plant.Title"));
                            PlantTitleCard = true;
                        }
                    }
                }
                if (!NPC.AnyNPCs(NPCID.Plantera))
                {
                    PlantTitleCard = false;
                }
                if (npc.type == NPCID.Golem)
                {
                    if (!GolemTitleCard)
                    {
                        if (!Main.dedServ)
                        {
                            MDSystem.Instance.TitleCardUIElement.DisplayTitle(Language.GetTextValue("Mods.MultidimensionMod.TitleCards.Bosses.Golem.Name"), 60, 90, 1.0f, 0, Color.Gold, Language.GetTextValue("Mods.MultidimensionMod.TitleCards.Bosses.Golem.Title"));
                            GolemTitleCard = true;
                        }
                    }
                }
                if (!NPC.AnyNPCs(NPCID.Golem))
                {
                    GolemTitleCard = false;
                }
                if (npc.type == NPCID.HallowBoss)
                {
                    if (!EmpressTitleCard)
                    {
                        if (!Main.dedServ)
                        {
                            if (!Main.dayTime)
                            {
                                MDSystem.Instance.TitleCardUIElement.DisplayTitle(Language.GetTextValue("Mods.MultidimensionMod.TitleCards.Bosses.Empress.Name"), 60, 90, 1.0f, 0, Color.Pink, Language.GetTextValue("Mods.MultidimensionMod.TitleCards.Bosses.Empress.Title"));
                                EmpressTitleCard = true;
                            }
                            else if (Main.dayTime)
                            {
                                MDSystem.Instance.TitleCardUIElement.DisplayTitle(Language.GetTextValue("Mods.MultidimensionMod.TitleCards.Bosses.Empress.Name"), 60, 90, 1.0f, 0, Color.Yellow, Language.GetTextValue("Mods.MultidimensionMod.TitleCards.Bosses.Empress.Title2"));
                                EmpressTitleCard = true;
                            }
                        }
                    }
                }
                if (!NPC.AnyNPCs(NPCID.HallowBoss))
                {
                    EmpressTitleCard = false;
                }
                if (npc.type == NPCID.DukeFishron)
                {
                    if (!DukeTitleCard)
                    {
                        if (!Main.dedServ)
                        {
                            MDSystem.Instance.TitleCardUIElement.DisplayTitle(Language.GetTextValue("Mods.MultidimensionMod.TitleCards.Bosses.Duke.Name"), 60, 90, 1.0f, 0, Color.SeaGreen, Language.GetTextValue("Mods.MultidimensionMod.TitleCards.Bosses.Duke.Title"));
                            DukeTitleCard = true;
                        }
                    }
                }
                if (!NPC.AnyNPCs(NPCID.DukeFishron))
                {
                    DukeTitleCard = false;
                }
                if (npc.type == NPCID.CultistBoss)
                {
                    if (!CultistTitleCard)
                    {
                        if (!Main.dedServ)
                        {
                            MDSystem.Instance.TitleCardUIElement.DisplayTitle(Language.GetTextValue("Mods.MultidimensionMod.TitleCards.Bosses.Cultist.Name"), 60, 90, 1.0f, 0, Color.DarkSeaGreen, Language.GetTextValue("Mods.MultidimensionMod.TitleCards.Bosses.Cultist.Title"));
                            CultistTitleCard = true;
                        }
                    }
                }
                if (!NPC.AnyNPCs(NPCID.CultistBoss))
                {
                    CultistTitleCard = false;
                }
                if (npc.type == NPCID.MoonLordCore)
                {
                    if (!MoonTitleCard)
                    {
                        if (!Main.dedServ)
                        {
                            if (!NPC.downedMoonlord)
                            {
                                MDSystem.Instance.TitleCardUIElement.DisplayTitle(Language.GetTextValue("Mods.MultidimensionMod.TitleCards.Bosses.Moon.Name"), 60, 90, 1.0f, 0, Color.DarkSeaGreen, Language.GetTextValue("Mods.MultidimensionMod.TitleCards.Bosses.Moon.Title"));
                                MoonTitleCard = true;
                            }
                            else
                                MDSystem.Instance.TitleCardUIElement.DisplayTitle(Language.GetTextValue("Mods.MultidimensionMod.TitleCards.Bosses.Moon.Name"), 60, 90, 1.0f, 0, Color.DarkSeaGreen, Language.GetTextValue("Mods.MultidimensionMod.TitleCards.Bosses.Moon.Title2"));
                            MoonTitleCard = true;
                        }
                    }
                }
                if (!NPC.AnyNPCs(NPCID.MoonLordCore))
                {
                    MoonTitleCard = false;
                }
                if (npc.type == NPCID.TorchGod)
                {
                    if (!TorchTitleCard)
                    {
                        if (!Main.dedServ)
                        {
                            MDSystem.Instance.TitleCardUIElement.DisplayTitle("The Torch God", 60, 90, 1.0f, 0, Color.Orange, "Primordial Torch Overlord");
                            TorchTitleCard = true;
                        }
                    }
                }
                if (!NPC.AnyNPCs(NPCID.TorchGod))
                {
                    TorchTitleCard = false;
                }
            }
        }
	}
}