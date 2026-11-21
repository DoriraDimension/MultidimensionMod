using MultidimensionMod.Items.Materials;
using MultidimensionMod.Items.Placeables;
using MultidimensionMod.Items.Pets;
using MultidimensionMod.Items.Summons;
using MultidimensionMod.Items.Accessories;
using MultidimensionMod.Items.Weapons.Melee.Others;
using MultidimensionMod.Items.Weapons.Melee.Swords;
using MultidimensionMod.Common.Systems;
using MultidimensionMod.Common.Globals;
using MultidimensionMod.Projectiles.Ranged;
//using MultidimensionMod.Items.Quest;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.GameContent.Personalities;
using Terraria.Utilities;
using Terraria.GameContent.Bestiary;
using Terraria.Audio;
using MultidimensionMod.Items.Materials.Mushrooms;
using MultidimensionMod.Common.Players;
using MultidimensionMod.Common.Globals.NPCs;
using MultidimensionMod.Items.Placeables.Plushies;
using MultidimensionMod.Items;
using MultidimensionMod.UI;

namespace MultidimensionMod.NPCs.TownNPCs
{
    [AutoloadHead]
    public class Cultissima : ModNPC
    {
        /*public override void ModifyActiveShop(string shopName, Item[] items)
        {
        }*/
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[NPC.type] = 1;
            NPCID.Sets.ExtraFramesCount[NPC.type] = 0;
            NPCID.Sets.AttackFrameCount[NPC.type] = 0;
            NPCID.Sets.DangerDetectRange[NPC.type] = 700;
            NPCID.Sets.AttackType[NPC.type] = 0;
            NPCID.Sets.AttackTime[NPC.type] = 90;
            NPCID.Sets.AttackAverageChance[NPC.type] = 30;
            NPCID.Sets.HatOffsetY[NPC.type] = 4;
            NPCID.Sets.NPCBestiaryDrawModifiers drawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers()
            {
                Velocity = 1f
            };
            NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, drawModifiers);
            NPC.Happiness
                .SetBiomeAffection<SnowBiome>(AffectionLevel.Love)
                .SetBiomeAffection<OceanBiome>(AffectionLevel.Like)
                .SetBiomeAffection<UndergroundBiome>(AffectionLevel.Dislike)
                .SetBiomeAffection<HallowBiome>(AffectionLevel.Hate)
                .SetNPCAffection(NPCID.Stylist, AffectionLevel.Love)
                .SetNPCAffection(ModContent.NPCType<Admin>(), AffectionLevel.Like)
                .SetNPCAffection(ModContent.NPCType<MushroomHeir>(), AffectionLevel.Dislike)
                .SetNPCAffection(NPCID.WitchDoctor, AffectionLevel.Hate)
            ;
        }

        public override void SetDefaults()
        {
            NPC.townNPC = true;
            NPC.friendly = true;
            NPC.width = 28;
            NPC.height = 44;
            NPC.aiStyle = NPCAIStyleID.Passive;
            NPC.damage = 10;
            NPC.defense = 10;
            NPC.lifeMax = 250;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.knockBackResist = 0f;
        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[]
            {
                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Snow,
                new FlavorTextBestiaryInfoElement("Mods.MultidimensionMod.Bestiary.Cultissima"),
                new FlavorTextBestiaryInfoElement("Mods.MultidimensionMod.Bestiary.CultissimaComment")
            });
        }

        public override bool CheckDead()
        {
            /*MDWorld.TposeTimer = 0;
            Main.NewText("Avaeris's mind got trapped in the cosmos.", Color.Red.R, Color.Red.G, Color.Red.B);
            SoundEngine.PlaySound(new("MultidimensionMod/Sounds/Custom/Glitch"));
            NPC.SetDefaults(ModContent.NPCType<AdminTpose>());
            NPC.life = 1;

            if (Main.netMode == NetmodeID.Server)
                NetMessage.SendData(MessageID.WorldData);

            return false;*/
            return true;
        }

        public override List<string> SetNPCNameList()
        {
            return new List<string>() {
                "Cultissima"
            };
        }

        public override string GetChat()
        {
            Player player = Main.LocalPlayer;
            WeightedRandom<string> chat = new WeightedRandom<string>();
            int fishGuy = NPC.FindFirstNPC(NPCID.Angler);
            if (fishGuy >= 0 && Main.rand.NextBool(4))
            {
                chat.Add(Language.GetTextValue("Mods.MultidimensionMod.NPCs.Dialogue.Cultissima.AnglerDialogue", Main.npc[fishGuy].GivenName));
            }
            chat.Add(Language.GetTextValue("Mods.MultidimensionMod.NPCs.Dialogue.Cultissima.GenericDialogue1"));
            chat.Add(Language.GetTextValue("Mods.MultidimensionMod.NPCs.Dialogue.Cultissima.GenericDialogue2"));
            chat.Add(Language.GetTextValue("Mods.MultidimensionMod.NPCs.Dialogue.Cultissima.GenericDialogue3"));
            return chat;
        }

        public override void SetChatButtons(ref string button, ref string button2)
        {
            Player player = Main.LocalPlayer;
            button = Language.GetTextValue("Mods.MultidimensionMod.MiscText.SoulSynchText");
        }

        public override void OnChatButtonClicked(bool firstButton, ref string shopName)
        {
            if (firstButton)
            {
                SoulDecipheringUISystem.OpenUI(NPC.whoAmI);
            }
        }
        public override bool PreAI()
        {
            if (SoulDecipheringUISystem.IsNPCBeingUsed(NPC.whoAmI))
            {
                NPC.velocity = Vector2.Zero;
                return false;
            }

            return true;
        }


        public override void AI()
        {

        }

        public override bool CanGoToStatue(bool toKingStatue)
        {
            return false;
        }

        public override void TownNPCAttackStrength(ref int damage, ref float knockback)
        {
            damage = 100;
            knockback = 6f;
        }

        public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
        {
            cooldown = 30;
            randExtraCooldown = 30;
        }

        public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
        {
            projType = ModContent.ProjectileType<DimensionalLightning>();
            attackDelay = 1;
        }

        public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
        {
            multiplier = 7f;
        }
    }
}