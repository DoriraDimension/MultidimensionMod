using MultidimensionMod.Common.Systems;
using MultidimensionMod.Items.Weapons.Magic.Others;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.Localization;
using Terraria.Audio;
using MultidimensionMod.Base;
using Terraria.GameContent.Bestiary;

namespace MultidimensionMod.NPCs.Friendly
{
    public class AdelSpirit : ModNPC
    {
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[NPC.type] = 2;
        }

        public override void SetDefaults()
        {
            NPC.width = 156;
            NPC.height = 112;
            NPC.lifeMax = 1;
            NPC.dontTakeDamage = true;
            NPC.noGravity = true;
            NPC.alpha = 110;
        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[]
            {
                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheHallow,
                new FlavorTextBestiaryInfoElement("Mods.MultidimensionMod.Bestiary.Adel")
            });
        }

        public override void OnSpawn(IEntitySource source)
        {
            int pieCut = 20;
            for (int m = 0; m < pieCut; m++)
            {
                int dustID = Dust.NewDust(new Vector2(NPC.Center.X - 1, NPC.Center.Y - 1), 2, 2, DustID.PinkCrystalShard, 0f, 0f, 100, Color.White, 1.6f);
                Main.dust[dustID].velocity = BaseUtility.RotateVector(default, new Vector2(6f, 0f), m / (float)pieCut * 6.28f);
                Main.dust[dustID].noLight = false;
                Main.dust[dustID].noGravity = true;
            }
        }

        public int AdelTimer = 0;
        public override void AI()
        {
            Player player = Main.LocalPlayer;
            Lighting.AddLight((int)(NPC.Center.X / 16f), (int)(NPC.Center.Y / 16f), 2.5f, 1.0f, 1.5f);
            if (player.ZoneHallow && !player.ZoneUnderworldHeight)
            {
                if (DownedSystem.listenedToNonsense && !DownedSystem.metAdel)
                {
                    AdelTimer++;
                    if (AdelTimer == 180)
                    {
                        int i = CombatText.NewText(NPC.getRect(), MDColors.AdelText, Language.GetTextValue("Mods.MultidimensionMod.SoulConversation.WallofFlesh.Adel1"), false, false);
                        Main.combatText[i].lifeTime = 150;
                    }
                    if (AdelTimer == 420)
                    {
                        int i = CombatText.NewText(NPC.getRect(), MDColors.AdelText, Language.GetTextValue("Mods.MultidimensionMod.SoulConversation.WallofFlesh.Adel2"), false, false);
                        Main.combatText[i].lifeTime = 150;
                    }
                    if (AdelTimer == 660)
                    {
                        int i = CombatText.NewText(NPC.getRect(), MDColors.AdelText, Language.GetTextValue("Mods.MultidimensionMod.SoulConversation.WallofFlesh.Adel3"), false, false);
                        Main.combatText[i].lifeTime = 150;
                    }
                    if (AdelTimer == 900)
                    {
                        int i = CombatText.NewText(NPC.getRect(), MDColors.AdelText, Language.GetTextValue("Mods.MultidimensionMod.SoulConversation.WallofFlesh.Adel4"), false, false);
                        Main.combatText[i].lifeTime = 150;
                    }
                    if (AdelTimer == 1140)
                    {
                        int i = CombatText.NewText(NPC.getRect(), MDColors.AdelText, Language.GetTextValue("Mods.MultidimensionMod.SoulConversation.WallofFlesh.Adel5"), false, false);
                        Main.combatText[i].lifeTime = 150;
                    }
                    if (AdelTimer == 1380)
                    {
                        int i = CombatText.NewText(NPC.getRect(), MDColors.AdelText, Language.GetTextValue("Mods.MultidimensionMod.SoulConversation.WallofFlesh.Adel6"), false, false);
                        Main.combatText[i].lifeTime = 150;
                    }
                    if (AdelTimer == 1620)
                    {
                        int i = CombatText.NewText(NPC.getRect(), MDColors.AdelText, Language.GetTextValue("Mods.MultidimensionMod.SoulConversation.WallofFlesh.Adel7"), false, false);
                        Main.combatText[i].lifeTime = 180;
                    }
                    if (AdelTimer == 1870)
                    {
                        int i = CombatText.NewText(NPC.getRect(), MDColors.AdelText, Language.GetTextValue("Mods.MultidimensionMod.SoulConversation.WallofFlesh.Adel8"), false, false);
                        Main.combatText[i].lifeTime = 150;
                        Item.NewItem(new EntitySource_Loot(NPC), NPC.position, NPC.Size, ModContent.ItemType<Mythos>(), 1);
                    }
                    if (AdelTimer == 2100)
                    {
                        int i = CombatText.NewText(NPC.getRect(), MDColors.AdelText, Language.GetTextValue("Mods.MultidimensionMod.SoulConversation.WallofFlesh.Adel9"), false, false);
                        Main.combatText[i].lifeTime = 150;
                    }
                    if (AdelTimer == 2340)
                    {
                        Main.NewText(Language.GetTextValue("Mods.MultidimensionMod.SoulConversation.WallofFlesh.Adel10"));
                    }
                    if (AdelTimer >= 2341)
                    {
                        NPC.SetEventFlagCleared(ref DownedSystem.metAdel, -1);
                        AdelTimer = 1801;
                        NPC.active = false;
                        SoundEngine.PlaySound(new("MultidimensionMod/Sounds/Custom/HallowedCry"), NPC.position);
                    }
                }
            }
        }

        public override void FindFrame(int frameHeight)
        {
            if (AdelTimer >= 1870)
            {
                NPC.frame.Y = 1 * frameHeight;
            }
            else
                NPC.frame.Y = 0 * frameHeight;

        }
    }
}