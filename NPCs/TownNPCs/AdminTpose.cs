using System;
using MultidimensionMod.Common.Globals;
using MultidimensionMod.Common.Systems;
using MultidimensionMod.Items.Critters;
using MultidimensionMod.Items.Materials;
using MultidimensionMod.Items.Materials.Mushrooms;
using MultidimensionMod.Items.Summons;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace MultidimensionMod.NPCs.TownNPCs
{
    public class AdminTpose : ModNPC
    {
        public override void SetStaticDefaults()
        {
            NPCID.Sets.ActsLikeTownNPC[Type] = true;
            NPCID.Sets.NoTownNPCHappiness[Type] = true;
            NPCID.Sets.NPCBestiaryDrawModifiers drawModifiers = new(0) { Hide = true };
            NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, drawModifiers);
        }
        public override void SetDefaults()
        {
            NPC.friendly = true;
            NPC.width = 40;
            NPC.height = 50;
            NPC.aiStyle = -1;
            NPC.defense = 0;
            NPC.lifeMax = 3007;
            NPC.dontTakeDamage = true;
            NPC.npcSlots = 0;
            NPC.noGravity = true;
        }

        public override bool NeedSaving() => true;
        public override bool UsesPartyHat() => false;
        public override bool CheckActive() => false;
        public override bool CanChat() => true;

        public override string GetChat()
        {
            return Language.GetTextValue("Mods.MultidimensionMod.NPCs.Dialogue.Admin.Tpose");
        }
 
        public override void AI()
        {
            if (NPC.AnyNPCs(ModContent.NPCType<Admin>()))
            {
                NPC.active = false;
            }
            NPC.dontTakeDamage = true;
            NPC.velocity.X = 0;
            if (Main.netMode != NetmodeID.MultiplayerClient)
            {
                NPC.homeless = false;
                NPC.homeTileX = -1;
                NPC.homeTileY = -1;
                NPC.netUpdate = true;
            }
            if (MDWorld.TposeTimer >= 10800)
            {
                MDWorld.TposeTimer = 0;

                if (Main.netMode == NetmodeID.Server)
                    NetMessage.SendData(MessageID.WorldData);

                NPC.Transform(ModContent.NPCType<Admin>());
                NPC.life = NPC.lifeMax;
                Main.NewText("John God has calmed down.", MDColors.AdminColor);
                SoundEngine.PlaySound(new("MultidimensionMod/Sounds/Custom/Glitch"));
            }
        }
    }

    public class AdminArrival : ModNPC
    {
        public override void SetStaticDefaults()
        {
            NPCID.Sets.ActsLikeTownNPC[Type] = true;
            NPCID.Sets.NoTownNPCHappiness[Type] = true;
            NPCID.Sets.NPCBestiaryDrawModifiers drawModifiers = new(0) { Hide = true };
            NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, drawModifiers);
        }
        public override void SetDefaults()
        {
            NPC.friendly = true;
            NPC.width = 40;
            NPC.height = 50;
            NPC.aiStyle = -1;
            NPC.defense = 0;
            NPC.lifeMax = 3007;
            NPC.dontTakeDamage = true;
            NPC.npcSlots = 0;
        }

        public override bool NeedSaving() => true;
        public override bool UsesPartyHat() => false;
        public override bool CheckActive() => false;
        public override bool CanChat() => true;

        public override string GetChat()
        {
            WeightedRandom<string> chat = new WeightedRandom<string>();
            chat.Add(Language.GetTextValue("Mods.MultidimensionMod.NPCs.Dialogue.Admin.AdminArrival1"));
            return chat;
        }

        public int chatNumber = 0;
        public override void SetChatButtons(ref string button, ref string button2)
        {
            Player player = Main.LocalPlayer;
            string talk1 = Language.GetTextValue("Mods.MultidimensionMod.NPCs.Admin.MiscText.AdminResponse1");
            string talk2 = Language.GetTextValue("Mods.MultidimensionMod.NPCs.Admin.MiscText.AdminResponse2");
            string talk3 = Language.GetTextValue("Mods.MultidimensionMod.NPCs.Admin.MiscText.AdminResponse3");
            string talk4 = Language.GetTextValue("Mods.MultidimensionMod.NPCs.Admin.MiscText.AdminResponse4");
            string talk5 = Language.GetTextValue("Mods.MultidimensionMod.NPCs.Admin.MiscText.AdminResponse5");
            string talk6 = Language.GetTextValue("Mods.MultidimensionMod.NPCs.Admin.MiscText.AdminResponse6");
            string talk7 = Language.GetTextValue("Mods.MultidimensionMod.NPCs.Admin.MiscText.AdminResponse7");
            string talk8 = Language.GetTextValue("Mods.MultidimensionMod.NPCs.Admin.MiscText.AdminResponse8");
            string talk9 = Language.GetTextValue("Mods.MultidimensionMod.NPCs.Admin.MiscText.AdminResponse9");
            if (chatNumber == 0 && !DownedSystem.metAdmin)
            {
                button = talk1;
            }
            if (chatNumber == 1 && !DownedSystem.metAdmin)
            {
                button = talk2;
            }
            if (chatNumber == 2 && !DownedSystem.metAdmin)
            {
                button = talk3;
            }
            if (chatNumber == 3 && !DownedSystem.metAdmin)
            {
                button = talk4;
            }
            if (chatNumber == 4 && !DownedSystem.metAdmin)
            {
                button = talk5;
            }
            if (chatNumber == 5 && !DownedSystem.metAdmin)
            {
                button = talk6;
            }
            if (chatNumber == 6 && !DownedSystem.metAdmin)
            {
                button = talk7;
            }
            if (chatNumber == 7 && !DownedSystem.metAdmin)
            {
                button = talk8;
            }
            if (chatNumber == 8 && !DownedSystem.metAdmin)
            {
                button = talk9;
            }
        }

        public override void OnChatButtonClicked(bool firstButton, ref string shopName)
        {
            if (firstButton)
            {
                if (chatNumber == 0)
                {
                    Main.npcChatText = Language.GetTextValue("Mods.MultidimensionMod.NPCs.Dialogue.Admin.AdminArrival2");
                }
                if (chatNumber == 1)
                {
                    Main.npcChatText = Language.GetTextValue("Mods.MultidimensionMod.NPCs.Dialogue.Admin.AdminArrival3");
                }
                if (chatNumber == 2)
                {
                    Main.npcChatText = Language.GetTextValue("Mods.MultidimensionMod.NPCs.Dialogue.Admin.AdminArrival4");
                }
                if (chatNumber == 3)
                {
                    Main.npcChatText = Language.GetTextValue("Mods.MultidimensionMod.NPCs.Dialogue.Admin.AdminArrival5");
                }
                if (chatNumber == 4)
                {
                    Main.npcChatText = Language.GetTextValue("Mods.MultidimensionMod.NPCs.Dialogue.Admin.AdminArrival6");
                }
                if (chatNumber == 5)
                {
                    Main.npcChatText = Language.GetTextValue("Mods.MultidimensionMod.NPCs.Dialogue.Admin.AdminArrival7");
                }
                if (chatNumber == 6)
                {
                    Main.npcChatText = Language.GetTextValue("Mods.MultidimensionMod.NPCs.Dialogue.Admin.AdminArrival8");
                }
                if (chatNumber == 7)
                {
                    Main.npcChatText = Language.GetTextValue("Mods.MultidimensionMod.NPCs.Dialogue.Admin.AdminArrival9");
                    DownedSystem.metAdmin = true;
                    NPC.Transform(ModContent.NPCType<Admin>());
                    NPC.life = 2989;
                }
                if (chatNumber != 9)
                {
                    chatNumber++;
                }
            }
        }

        public override void AI()
        {
            if (Main.LocalPlayer.talkNPC != NPC.whoAmI)
            {
                chatNumber = 0;
            }
            if (NPC.AnyNPCs(ModContent.NPCType<Admin>()))
            {
                NPC.active = false;
            }
            NPC.dontTakeDamage = true;
            NPC.velocity.X = 0;
            if (Main.netMode != NetmodeID.MultiplayerClient)
            {
                NPC.homeless = false;
                NPC.homeTileX = -1;
                NPC.homeTileY = -1;
                NPC.netUpdate = true;
            }
        }
    }
}