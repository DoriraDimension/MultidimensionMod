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
using System;
using static Terraria.GameContent.Animations.IL_Actions.NPCs;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;

namespace MultidimensionMod.NPCs
{
    public class AldinGrabber : ModNPC
    {
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[NPC.type] = 21;
            NPCID.Sets.NPCBestiaryDrawModifiers value = new(0) { Hide = true };
            NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, value);
        }

        public override void SetDefaults()
        {
            NPC.width = 50;
            NPC.height = 86;
            NPC.lifeMax = 1;
            NPC.dontTakeDamage = true;
            NPC.noGravity = true;
        }

        public override void OnSpawn(IEntitySource source)
        {
            int i = CombatText.NewText(NPC.getRect(), Color.AliceBlue, Language.GetTextValue("Y E S"), false, false);
            Main.combatText[i].lifeTime = 100;
        }

        public int AldinTimer = 0;
        public int EscapeTimer = 0;
        public override void AI()
        {
            Player player = Main.LocalPlayer;
            AldinTimer++;
            if (AldinTimer >= 300)
            {
                NPC.NewNPC(NPC.GetSource_FromAI(), (int)NPC.Center.X, (int)NPC.Center.Y + 40, ModContent.NPCType<AldinGrabberEscape>());
                NPC.active = false;
            }
        }
        public bool FuckYou = false;

        public override void FindFrame(int frameHeight)
        {
            if (AldinTimer >= 180)
            {
                if (++NPC.frameCounter >= 5)
                {
                    NPC.frameCounter = 0;
                    NPC.frame.Y += frameHeight;
                    if (NPC.frame.Y > 20 * frameHeight)
                        NPC.frame.Y = 20 * frameHeight;
                }
            }
            else
            {
                if (++NPC.frameCounter >= 5)
                {
                    NPC.frameCounter = 0;
                    NPC.frame.Y += frameHeight;
                    if (NPC.frame.Y > 9 * frameHeight)
                        NPC.frame.Y = 9 * frameHeight;
                }
            }
        }
    }
}