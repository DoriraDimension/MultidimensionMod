using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using MonoMod;

using Terraria.ID;
using Terraria.ModLoader;


//this is utterly fucking retarded
namespace MultidimensionMod.NPCs.Boss.Smiley
{
	public class Transition : ModNPC
    {
		int timer = 0;
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Smiley");
			Main.npcFrameCount[npc.type] = 13;
		}

		public override void SetDefaults()
		{

			npc.aiStyle = -1;
			npc.lifeMax = 10000;
			npc.damage = 20;
			npc.defense = 0;
			npc.knockBackResist = 0f;
			npc.dontTakeDamage = true;
			npc.alpha = 0;

			npc.width = 88;
			npc.height = 88;
			npc.value = Item.buyPrice(0, 10, 0, 0);
			npc.npcSlots = 5f;
			npc.boss = true;
			npc.lavaImmune = true;
			npc.noGravity = true;
			npc.noTileCollide = true;
			music = MusicID.Boss2;
		}
        public override void AI()
        {
			timer++;
        }
        public override void FindFrame(int frameHeight)
        {
            if (timer % 6 == 0)
            {
				npc.frame.Y += frameHeight;
				if (npc.frame.Y == frameHeight * 13)
				{
					NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y - 1, ModContent.NPCType<Smiley2>());

				}
			}
			
		}
    }

}
