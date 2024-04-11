using MultidimensionMod.Common.Globals;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.Utilities;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using System;
using Microsoft.Xna.Framework;

namespace MultidimensionMod.NPCs.TownNPCs
{
    public class Dapperbox : ModNPC
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
            NPC.width = 34;
            NPC.height = 16;
            NPC.aiStyle = -1;
            NPC.defense = 0;
            NPC.lifeMax = 100;
            NPC.dontTakeDamage = true;
            NPC.npcSlots = 0;
        }

        public override bool NeedSaving() => true;
        public override bool UsesPartyHat() => false;
        public override bool CheckActive() => false;
        public override bool CanChat() => true;

        public override string GetChat()
        {
            return Language.GetTextValue("Mods.MultidimensionMod.Dialogue.Dappercap.Box");
        }

        public override void AI()
        {
            if (NPC.AnyNPCs(ModContent.NPCType<MushroomHeir>()))
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
            if (MDWorld.BoxTimer >= 7200)
            {
                MDWorld.BoxTimer = 0;

                if (Main.netMode == NetmodeID.Server)
                    NetMessage.SendData(MessageID.WorldData);

                NPC.Transform(ModContent.NPCType<MushroomHeir>());
                NPC.life = NPC.lifeMax;
                Main.NewText("Dappercap come out from hiding.", Color.Red);
            }
        }
    }
}