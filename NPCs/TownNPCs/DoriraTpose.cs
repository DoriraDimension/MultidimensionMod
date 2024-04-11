using MultidimensionMod.Common.Globals;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.Utilities;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace MultidimensionMod.NPCs.TownNPCs
{
    public class DoriraTpose : ModNPC
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
            return Language.GetTextValue("Mods.MultidimensionMod.Dialogue.Dorira.Tpose");
        }
 
        public override void AI()
        {
            if (NPC.AnyNPCs(ModContent.NPCType<Dorira>()))
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

                NPC.Transform(ModContent.NPCType<Dorira>());
                NPC.life = NPC.lifeMax;
                Main.NewText("Dorira has calmed down.", MDColors.DoriraColor);
                SoundEngine.PlaySound(new("MultidimensionMod/Sounds/Custom/Glitch"));
            }
        }
    }
}