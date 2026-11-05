using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MultidimensionMod.Base;
using MultidimensionMod.Common.Systems;
using MultidimensionMod.Items;
using MultidimensionMod.Items.Materials;
using MultidimensionMod.Items.Pets;
using MultidimensionMod.Items.Placeables.Relics;
using MultidimensionMod.Items.Placeables.Trophies;
using MultidimensionMod.Items.Summons;
using MultidimensionMod.Items.Vanity;
using MultidimensionMod.NPCs.Bosses.FeudalFungus;
using MultidimensionMod.NPCs.Bosses.MushroomMonarch;
using MultidimensionMod.NPCs.Bosses.Smiley;
using MultidimensionMod.NPCs.Madness;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Common.CrossMod
{
    internal class WeakReferences
    {
        public static void PerformModSupport()
        {
            PerformBossChecklistSupport();
        }
        private static void PerformBossChecklistSupport()
        {
            Mod MusicMod = MultidimensionMod.Instance.musicMod;
            MultidimensionMod mod = ModContent.GetInstance<MultidimensionMod>();
            if (ModLoader.TryGetMod("BossChecklist", out Mod bossChecklist))
            {
                #region Mush Mon
                bossChecklist.Call("LogBoss", mod, nameof(MushroomMonarch), 1.5f, () => DownedSystem.downedMonarch, ModContent.NPCType<MushroomMonarch>(), new Dictionary<string, object>()
                {
                    ["spawnItems"] = ModContent.ItemType<IntimidatingMushroom>(),
                    ["collectibles"] = new List<int>
                    {
                        ModContent.ItemType<MonarchRelic>(),
                        ModContent.ItemType<MonarchTrophy>(),
                        ModContent.ItemType<MonarchMask>(),
                        MusicMod.Find<ModItem>("MonarchBox").Type,
                        ModContent.ItemType<SusSporeBag>(),
                    },
                    ["customPortrait"] = (SpriteBatch sb, Rectangle rect, Color color) =>
                    {
                        Texture2D texture = ModContent.Request<Texture2D>("MultidimensionMod/Common/CrossMod/BossChecklist/MushroomMonarch").Value;
                        Vector2 centered = new(rect.X + (rect.Width / 2) - (texture.Width / 2), rect.Y + (rect.Height / 2) - (texture.Height / 2));
                        sb.Draw(texture, centered, color);
                    },
                    ["despawnMessage"] = Language.GetOrRegister("Mods.MultidimensionMod.NPCs.MushroomMonarch.BossChecklistIntegration.DespawnMessage").Value,
                });
                #endregion

                #region Feudal
                bossChecklist.Call("LogBoss", mod, nameof(FeudalFungus), 2.7f, () => DownedSystem.downedFungus, ModContent.NPCType<FeudalFungus>(), new Dictionary<string, object>()
                {
                    ["spawnItems"] = ModContent.ItemType<ConfusingMushroom>(),
                    ["collectibles"] = new List<int>
                {
                        ModContent.ItemType<FungusRelic>(),
                        ModContent.ItemType<FungusTrophy>(),
                        ModContent.ItemType<FungusMask>(),
                        MusicMod.Find<ModItem>("FungusBox").Type,
                        ModContent.ItemType<SusGlowsporeBag>()
                },
                    ["customPortrait"] = (SpriteBatch sb, Rectangle rect, Color color) =>
                    {
                        Texture2D texture = ModContent.Request<Texture2D>("MultidimensionMod/Common/CrossMod/BossChecklist/FeudalFungus").Value;
                        Vector2 centered = new(rect.X + (rect.Width / 2) - (texture.Width / 2), rect.Y + (rect.Height / 2) - (texture.Height / 2));
                        sb.Draw(texture, centered, color);
                    },
                    ["despawnMessage"] = Language.GetOrRegister("Mods.MultidimensionMod.NPCs.FeudalFungus.BossChecklistIntegration.DespawnMessage").Value,
                });
                #endregion

                #region Night of Madness
                bossChecklist.Call("LogEvent", mod, "NightofMadness", 3.1f, () => DownedSystem.survivedMadness, new List<int>()
                    {
                        ModContent.NPCType<Madman>(),
                        ModContent.NPCType<MadnessDog>(),
                        ModContent.NPCType<MadnessBat>(),
                        ModContent.NPCType<MadnessBat2>(),
                        ModContent.NPCType<AMindFromBeyond>()
                    }, new Dictionary<string, object>()
                    {
                        ["spawnItems"] = ModContent.ItemType<MadnessCaller>(),
                        ["collectibles"] = new List<int>
                        {
                            //ModContent.ItemType<MindBeyondRelic>(),
                            ModContent.ItemType<MadnessFragment>(),
                            ModContent.ItemType<Blight2>(),
                            MusicMod.Find<ModItem>("MadnessBox").Type,
                            ModContent.ItemType<ShadeEye>()
                        },
                        ["availability"] = () => NPC.downedBoss2,
                        ["customPortrait"] = (SpriteBatch sb, Rectangle rect, Color color) =>
                        {
                            Texture2D texture = ModContent.Request<Texture2D>("MultidimensionMod/Common/CrossMod/BossChecklist/MadnessMoon").Value;
                            Vector2 centered = new(rect.X + (rect.Width / 2) - (texture.Width / 2), rect.Y + (rect.Height / 2) - (texture.Height / 2));
                            sb.Draw(texture, centered, color);
                        },
                        ["overrideHeadTextures"] = "MultidimensionMod/Biomes/MadnessIcon"
                    });
                #endregion

                #region Smile man
                bossChecklist.Call("LogBoss", mod, nameof(Smiley), 5.5f, () => DownedSystem.downedSmiley, ModContent.NPCType<Smiley>(), new Dictionary<string, object>()
                {
                    ["spawnItems"] = ModContent.ItemType<UnknownEmoji>(),
                    ["collectibles"] = new List<int>
                    {
                        ModContent.ItemType<SmileyRelic>(),
                        ModContent.ItemType<SmileyTrophy>(),
                        ModContent.ItemType<SmileyMask>(),
                        ModContent.ItemType<CuteEmoji>(),
                        //MusicMod.Find<ModItem>("SmileyBox").Type,
                    },
                    ["customPortrait"] = (SpriteBatch sb, Rectangle rect, Color color) =>
                    {
                        Texture2D texture = ModContent.Request<Texture2D>("MultidimensionMod/Common/CrossMod/BossChecklist/Smiley").Value;
                        Vector2 centered = new(rect.X + (rect.Width / 2) - (texture.Width / 2), rect.Y + (rect.Height / 2) - (texture.Height / 2));
                        sb.Draw(texture, centered, color);
                    },
                    ["despawnMessage"] = Language.GetOrRegister("Mods.MultidimensionMod.NPCs.Smiley.BossChecklistIntegration.DespawnMessage").Value,
                });
                #endregion

                /*KingSlime = 1f;
                EyeOfCthulhu = 2f;
                EaterOfWorlds = 3f; // and Brain of Cthulhu
                QueenBee = 4f;
                Skeletron = 5f;
                DeerClops = 6f;
                WallOfFlesh = 7f;
                QueenSlime = 8f;
                TheTwins = 9f;
                TheDestroyer = 10f;
                SkeletronPrime = 11f;
                Plantera = 12f;
                Golem = 13f;
                Betsy = 14f;
                EmpressOfLight = 15f;
                DukeFishron = 16f;
                LunaticCultist = 17f;
                Moonlord = 18f;
                Fogbound = 19f;*/
            }
        }
    }
}