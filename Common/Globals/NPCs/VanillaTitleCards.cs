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
			if (npc.type == NPCID.KingSlime)
            {
                if (!KingTitleCard)
                {
                    if (!Main.dedServ)
                    {
                       MDSystem.Instance.TitleCardUIElement.DisplayTitle("King Slime", 60, 90, 1.0f, 0, Color.SkyBlue, "Geletic Ruler");
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
                        MDSystem.Instance.TitleCardUIElement.DisplayTitle("The Eye of Cthulhu", 60, 90, 1.0f, 0, Color.White, "Godspawned Gazer");
                        EyeTitleCard = true;
                    }
                }
            }
            if (!NPC.AnyNPCs(NPCID.EyeofCthulhu))
            {
                EyeTitleCard = false;
            }
            if (npc.type == NPCID.EaterofWorldsHead)
            {
                if (!WormTitleCard)
                {
                    if (!Main.dedServ)
                    {
                        MDSystem.Instance.TitleCardUIElement.DisplayTitle("The Eater of Worlds", 60, 90, 1.0f, 0, Color.Green, "Corruption Crawler");
                        WormTitleCard = true;
                    }
                }
            }
            if (!NPC.AnyNPCs(NPCID.EaterofWorldsHead))
            {
                WormTitleCard = false;
            }
            if (npc.type == NPCID.BrainofCthulhu)
            {
                if (!BrainTitleCard)
                {
                    if (!Main.dedServ)
                    {
                        MDSystem.Instance.TitleCardUIElement.DisplayTitle("The Brain of Cthulhu", 60, 90, 1.0f, 0, Color.Pink, "Soulless Mind");
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
                        MDSystem.Instance.TitleCardUIElement.DisplayTitle("Queen Bee", 60, 90, 1.0f, 0, Color.Yellow, "Giant Insect");
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
                        MDSystem.Instance.TitleCardUIElement.DisplayTitle("Skeletron", 60, 90, 1.0f, 0, Color.Magenta, "Curse Incarnation");
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
                        MDSystem.Instance.TitleCardUIElement.DisplayTitle("Deerclops", 60, 90, 1.0f, 0, Color.White, "Winter Strider");
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
                        MDSystem.Instance.TitleCardUIElement.DisplayTitle("The Wall of Flesh", 60, 90, 1.0f, 0, Color.Red, "Soul Prison");
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
                        MDSystem.Instance.TitleCardUIElement.DisplayTitle("Queen Slime", 60, 90, 1.0f, 0, Color.Pink, "The Hallowed Angel");
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
                        MDSystem.Instance.TitleCardUIElement.DisplayTitle("The Twins", 60, 90, 1.0f, 0, Color.DarkOliveGreen, "Terror Scouts");
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
                        MDSystem.Instance.TitleCardUIElement.DisplayTitle("The Destroyer", 60, 90, 1.0f, 0, Color.Blue, "Tectonic Tunneler");
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
                        MDSystem.Instance.TitleCardUIElement.DisplayTitle("Skeletron Prime", 60, 90, 1.0f, 0, Color.OrangeRed, "Cursemarked Machine");
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
                        MDSystem.Instance.TitleCardUIElement.DisplayTitle("Plantera", 60, 90, 1.0f, 0, Color.LimeGreen, "Jungle Guardian");
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
                        MDSystem.Instance.TitleCardUIElement.DisplayTitle("Golem", 60, 90, 1.0f, 0, Color.Gold, "Sun Idol");
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
                            MDSystem.Instance.TitleCardUIElement.DisplayTitle("The Empress of Light", 60, 90, 1.0f, 0, Color.Pink, "Twilight Dame");
                            EmpressTitleCard = true;
                        }
                        else if (Main.dayTime)
                        {
                            MDSystem.Instance.TitleCardUIElement.DisplayTitle("The Empress of Light", 60, 90, 1.0f, 0, Color.Yellow, "The Radiant Mistress");
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
                        MDSystem.Instance.TitleCardUIElement.DisplayTitle("Duke Fishron", 60, 90, 1.0f, 0, Color.SeaGreen, "Shorelurker");
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
                        MDSystem.Instance.TitleCardUIElement.DisplayTitle("The Lunatic Cultist", 60, 90, 1.0f, 0, Color.DarkSeaGreen, "Godseeker");
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
                            MDSystem.Instance.TitleCardUIElement.DisplayTitle("The Moon Lord", 60, 90, 1.0f, 0, Color.DarkSeaGreen, "Reincarnated Cthulhu");
                            MoonTitleCard = true;
                        }
                        else
                            MDSystem.Instance.TitleCardUIElement.DisplayTitle("The Moon Lord", 60, 90, 1.0f, 0, Color.DarkSeaGreen, "False Husk");
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