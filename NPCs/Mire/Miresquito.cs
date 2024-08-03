using MultidimensionMod.Base;
using MultidimensionMod.Biomes;
using Terraria;
using Terraria.GameContent.Bestiary;
using Terraria.ID;
using Terraria.ModLoader;


namespace MultidimensionMod.NPCs.Mire
{
     public class Miresquito : ModNPC
	{
		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Miresquito");
			Main.npcFrameCount[NPC.type] = 4;
		}

		public override void SetDefaults()
		{
            NPC.aiStyle = 1;
            NPC.noGravity = true;
            NPC.noTileCollide = false;
            NPC.width = 64;
			NPC.height = 64;
			NPC.damage = 45;
			NPC.defense = 10;
			NPC.lifeMax = 200;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.value = 6000f;
            NPC.lavaImmune = false;
            NPC.knockBackResist = 0.5f;
            SpawnModBiomes = new int[1] { ModContent.GetInstance<TheShroudedMire>().Type };
        }

        public override void SetBestiary(BestiaryDatabase dataNPC, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[]
            {
                new FlavorTextBestiaryInfoElement("Mods.MultidimensionMod.Bestiary.Miresquito")
            });
        }

        public override void FindFrame(int frameHeight)
        {
            if (NPC.frameCounter++ > 7)
            {
                NPC.frame.Y += 60;
                NPC.frameCounter = 0;
                if (NPC.frame.Y >= 240)
                {
                    NPC.frame.Y = 0;
                }
            }
        }

        public override void AI()
        {
            BaseAI.AIFlier(NPC, ref NPC.ai, false, 0.2f, 0.1f, 3, 2.5f, true, 250);
            NPC.rotation = NPC.velocity.X * 0.05f;
            if (NPC.velocity.X > 0)
            {
                NPC.spriteDirection = 1;
            }
            else
            {
                NPC.spriteDirection = -1;
            }
        }

        public override void OnHitPlayer(Player target, Player.HurtInfo hurtInfo)
        {
            NPC.life += 5;
        }
	}
}
