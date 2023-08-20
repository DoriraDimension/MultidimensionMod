using MultidimensionMod.Common.Systems;
using MultidimensionMod.Items.Weapons.Melee.Swords;
using MultidimensionMod.Dusts;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Terraria.Localization;
using MultidimensionMod.Base;
using Terraria.ID;
using Terraria.Audio;
using Terraria.GameContent.Bestiary;

namespace MultidimensionMod.NPCs.Friendly
{
    public class VertrariusSpirit : ModNPC
    {
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[NPC.type] = 2;
            var drawModifier = new NPCID.Sets.NPCBestiaryDrawModifiers(0)
            {
                CustomTexturePath = "MultidimensionMod/NPCs/Bestiary/VertrariusBestiary",
            };
            NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, drawModifier);
        }

        public override void SetDefaults()
        {
            NPC.width = 194;
            NPC.height = 136;
            NPC.lifeMax = 1;
            NPC.dontTakeDamage = true;
            NPC.noGravity = true;
            NPC.alpha = 110;
        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[]
            {
                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheUnderworld,
                new FlavorTextBestiaryInfoElement("Mods.MultidimensionMod.Bestiary.Vertrarius")
            });
        }

        public override void OnSpawn(IEntitySource source)
        {
            int pieCut = 20;
            for (int m = 0; m < pieCut; m++)
            {
                int dustID = Dust.NewDust(new Vector2(NPC.Center.X - 1, NPC.Center.Y - 1), 2, 2, ModContent.DustType<BlazingDust>(), 0f, 0f, 100, Color.White, 1.6f);
                Main.dust[dustID].velocity = BaseUtility.RotateVector(default, new Vector2(6f, 0f), m / (float)pieCut * 6.28f);
                Main.dust[dustID].noLight = false;
                Main.dust[dustID].noGravity = true;
            }
        }

        public int VertrariusTimer = 0;
        public override void AI()
        {
            Player player = Main.LocalPlayer;
            Lighting.AddLight((int)(NPC.Center.X / 16f), (int)(NPC.Center.Y / 16f), 3f, 1.0f, 1.0f);
            if (player.ZoneUnderworldHeight && !player.ZoneHallow)
            {
                if (DownedSystem.listenedToNonsense && !DownedSystem.metVertrarius)
                {
                    VertrariusTimer++;
                    if (VertrariusTimer == 180)
                    {
                        int i = CombatText.NewText(NPC.getRect(), Color.Orange, Language.GetTextValue("Mods.MultidimensionMod.SoulConversation.WallofFlesh.Vertrarius1"), false, false);
                        Main.combatText[i].lifeTime = 150;
                    }
                    if (VertrariusTimer == 420)
                    {
                        int i = CombatText.NewText(NPC.getRect(), Color.Orange, Language.GetTextValue("Mods.MultidimensionMod.SoulConversation.WallofFlesh.Vertrarius2"), false, false);
                        Main.combatText[i].lifeTime = 150;
                    }
                    if (VertrariusTimer == 660)
                    {
                        int i = CombatText.NewText(NPC.getRect(), Color.Orange, Language.GetTextValue("Mods.MultidimensionMod.SoulConversation.WallofFlesh.Vertrarius3"), false, false);
                        Main.combatText[i].lifeTime = 150;
                    }
                    if (VertrariusTimer == 900)
                    {
                        int i = CombatText.NewText(NPC.getRect(), Color.Orange, Language.GetTextValue("Mods.MultidimensionMod.SoulConversation.WallofFlesh.Vertrarius4"), false, false);
                        Main.combatText[i].lifeTime = 150;
                    }
                    if (VertrariusTimer == 1140)
                    {
                        int i = CombatText.NewText(NPC.getRect(), Color.Orange, Language.GetTextValue("Mods.MultidimensionMod.SoulConversation.WallofFlesh.Vertrarius5"), false, false);
                        Main.combatText[i].lifeTime = 150;
                    }
                    if (VertrariusTimer == 1380)
                    {
                        int i = CombatText.NewText(NPC.getRect(), Color.Orange, Language.GetTextValue("Mods.MultidimensionMod.SoulConversation.WallofFlesh.Vertrarius6"), false, false);
                        Main.combatText[i].lifeTime = 150;
                    }
                    if (VertrariusTimer == 1620)
                    {
                        int i = CombatText.NewText(NPC.getRect(), Color.Orange, Language.GetTextValue("Mods.MultidimensionMod.SoulConversation.WallofFlesh.Vertrarius7"), false, false);
                        Main.combatText[i].lifeTime = 150;
                    }
                    if (VertrariusTimer == 1870)
                    {
                        int i = CombatText.NewText(NPC.getRect(), Color.Orange, Language.GetTextValue("Mods.MultidimensionMod.SoulConversation.WallofFlesh.Vertrarius8"), false, false);
                        Main.combatText[i].lifeTime = 150;
                    }
                    if (VertrariusTimer == 2100)
                    {
                        int i = CombatText.NewText(NPC.getRect(), Color.Orange, Language.GetTextValue("Mods.MultidimensionMod.SoulConversation.WallofFlesh.Vertrarius9"), false, false);
                        Main.combatText[i].lifeTime = 150;
                    }
                    if (VertrariusTimer == 2340)
                    {
                        int i = CombatText.NewText(NPC.getRect(), Color.Orange, Language.GetTextValue("Mods.MultidimensionMod.SoulConversation.WallofFlesh.Vertrarius10"), false, false);
                        Main.combatText[i].lifeTime = 150;
                        Item.NewItem(new EntitySource_Loot(NPC), NPC.position, NPC.Size, ModContent.ItemType<Vulkanus>(), 1);
                    }
                    if (VertrariusTimer == 2580)
                    {
                        int i = CombatText.NewText(NPC.getRect(), Color.Orange, Language.GetTextValue("Mods.MultidimensionMod.SoulConversation.WallofFlesh.Vertrarius11"), false, false);
                        Main.combatText[i].lifeTime = 150;
                    }
                    if (VertrariusTimer == 2820)
                    {
                        Main.NewText(Language.GetTextValue("Mods.MultidimensionMod.SoulConversation.WallofFlesh.Vertrarius12"));
                    }
                    if (VertrariusTimer >= 2821)
                    {
                        NPC.SetEventFlagCleared(ref DownedSystem.metVertrarius, -1);
                        VertrariusTimer = 2161;
                        NPC.active = false;
                        SoundEngine.PlaySound(SoundID.DD2_BetsyFlameBreath, NPC.position);
                    }
                }
            }
        }

        public override void FindFrame(int frameHeight)
        {
            if (VertrariusTimer >= 2340)
            {
                NPC.frame.Y = 1 * frameHeight;
            }
            else
                NPC.frame.Y = 0 * frameHeight;

        }
    }
}