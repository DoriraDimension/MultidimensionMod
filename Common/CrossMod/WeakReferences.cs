using MultidimensionMod.Common.Systems;
using MultidimensionMod.Items.Pets;
using MultidimensionMod.Items.Summons;
using MultidimensionMod.Items.Placeables.Trophies;
using MultidimensionMod.Items.Placeables.Relics;
using MultidimensionMod.Items.Vanity;
using MultidimensionMod.NPCs.Bosses.FeudalFungus;
using MultidimensionMod.NPCs.Bosses.MushroomMonarch;
using MultidimensionMod.NPCs.Bosses.Smiley;
using MultidimensionMod.Items.Placeables.MusicBoxes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Terraria;
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
                        ModContent.ItemType<MonarchBox>(),
                        ModContent.ItemType<SusSporeBag>(),
                },
                    ["customPortrait"] = (SpriteBatch sb, Rectangle rect, Color color) =>
                    {
                        Texture2D texture = ModContent.Request<Texture2D>("MultidimensionMod/Common/CrossMod/BossChecklist/MushroomMonarch").Value;
                        Vector2 centered = new(rect.X + (rect.Width / 2) - (texture.Width / 2), rect.Y + (rect.Height / 2) - (texture.Height / 2));
                        sb.Draw(texture, centered, color);
                    }
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
                        ModContent.ItemType<FungusBox>(),
                        ModContent.ItemType<SusGlowsporeBag>()
                },
                    ["customPortrait"] = (SpriteBatch sb, Rectangle rect, Color color) =>
                    {
                        Texture2D texture = ModContent.Request<Texture2D>("MultidimensionMod/Common/CrossMod/BossChecklist/FeudalFungus").Value;
                        Vector2 centered = new(rect.X + (rect.Width / 2) - (texture.Width / 2), rect.Y + (rect.Height / 2) - (texture.Height / 2));
                        sb.Draw(texture, centered, color);
                    }
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
                },
                    ["customPortrait"] = (SpriteBatch sb, Rectangle rect, Color color) =>
                    {
                        Texture2D texture = ModContent.Request<Texture2D>("MultidimensionMod/Common/CrossMod/BossChecklist/Smiley").Value;
                        Vector2 centered = new(rect.X + (rect.Width / 2) - (texture.Width / 2), rect.Y + (rect.Height / 2) - (texture.Height / 2));
                        sb.Draw(texture, centered, color);
                    }
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
                Moonlord = 18f;*/
            }
        }
    }
}