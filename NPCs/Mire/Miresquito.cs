using Microsoft.Xna.Framework;
using MultidimensionMod.Base;
using MultidimensionMod.Biomes;
using MultidimensionMod.Items.Materials;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;


namespace MultidimensionMod.NPCs.Mire
{
     public class Miresquito : ModNPC
	{
		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Miresquito");
			Main.npcFrameCount[NPC.type] = 16;
		}

		public override void SetDefaults()
		{
            NPC.aiStyle = 1;
            NPC.noGravity = true;
            NPC.noTileCollide = false;
            NPC.width = 64;
			NPC.height = 64;
			NPC.damage = 25;
			NPC.defense = 10;
			NPC.lifeMax = 200;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.value = 6000f;
            NPC.lavaImmune = false;
            NPC.knockBackResist = 0.5f;
            SpawnModBiomes = new int[1] { ModContent.GetInstance<TheShroudedMire>().Type };
        }

        public int TheNefariousObeseness = 0;

        public override void SetBestiary(BestiaryDatabase dataNPC, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[]
            {
                new FlavorTextBestiaryInfoElement("Mods.MultidimensionMod.Bestiary.Miresquito")
            });
        }

        public override void FindFrame(int frameHeight)
        {
            if (TheNefariousObeseness < 2)
            {
                if (NPC.frameCounter++ > 3)
                {
                    NPC.frame.Y += 64;
                    NPC.frameCounter = 0;
                    if (NPC.frame.Y >= 192)
                    {
                        NPC.frame.Y = 0;
                    }
                }
            }
            if (TheNefariousObeseness >= 2 && TheNefariousObeseness < 4)
            {
                if (NPC.frameCounter++ > 4)
                {
                    NPC.frame.Y += 64;
                    NPC.frameCounter = 0;
                    if (NPC.frame.Y >= 512)
                    {
                        NPC.frame.Y = 192;
                    }
                }
            }
            if (TheNefariousObeseness >= 4 && TheNefariousObeseness < 6)
            {
                if (NPC.frameCounter++ > 5)
                {
                    NPC.frame.Y += 64;
                    NPC.frameCounter = 0;
                    if (NPC.frame.Y >= 766)
                    {
                        NPC.frame.Y = 512;
                    }
                }
            }
            if (TheNefariousObeseness >= 6)
            {
                if (NPC.frameCounter++ > 7)
                {
                    NPC.frame.Y += 64;
                    NPC.frameCounter = 0;
                    if (NPC.frame.Y >= 960)
                    {
                        NPC.frame.Y = 766;
                    }
                }
            }
        }

        public override void AI()
        {
            int maxVelocity = 4;
            if (TheNefariousObeseness >= 2 && TheNefariousObeseness < 4)
            {
                maxVelocity = (int)2.5;
            }
            else if (TheNefariousObeseness >= 4 && TheNefariousObeseness < 6)
            {
                maxVelocity = 1;
            }
            else if (TheNefariousObeseness >= 6)
            {
                maxVelocity = 0;
                NPC.noGravity = false;
                NPC.velocity.X = 0;
                NPC.aiStyle = -1;
            }
            if (TheNefariousObeseness < 6)
            {
                BaseAI.AIFlier(NPC, ref NPC.ai, false, 0.2f, 0.1f, maxVelocity, 2.5f, true, 250);
            }
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
            if (TheNefariousObeseness < 6)
            {
                SoundEngine.PlaySound(SoundID.Item3, NPC.position);
                TheNefariousObeseness++;
                NPC.life += 5;
            }
        }

        //Drop hearts on death when fat enough (At least tier 3)
        public override void ModifyNPCLoot(NPCLoot NPCloot)
        {
            NPCloot.Add(ItemDropRule.Common(ModContent.ItemType<MirePod>(), 3, 1, 2));
            if (TheNefariousObeseness >= 6)
            {
                NPCloot.Add(ItemDropRule.Common(ItemID.Heart, 1, 4, 4));
            }
            else if (TheNefariousObeseness >= 6)
            {
                NPCloot.Add(ItemDropRule.Common(ItemID.Heart, 1, 2, 2));
            }
        }

        public override void HitEffect(NPC.HitInfo hit)
        {
            if (NPC.life <= 0)
            {
                Gore.NewGore(NPC.GetSource_FromThis(), NPC.position, NPC.velocity, ModContent.Find<ModGore>("MultidimensionMod/MiresquitoGore1").Type, 1); //head
                Gore.NewGore(NPC.GetSource_FromThis(), NPC.position, NPC.velocity, ModContent.Find<ModGore>("MultidimensionMod/MiresquitoGore2").Type, 1); //wing
                //Rest of the body has no gores, instead it creates a blood explosion that inscreases
                if (TheNefariousObeseness < 2)
                {
                    int dust = DustID.Blood;
                    Dust.NewDust(new Vector2(NPC.position.X, NPC.position.Y), NPC.width, NPC.height, dust, 0f, 0f, 0);
                    Dust.NewDust(new Vector2(NPC.position.X, NPC.position.Y), NPC.width, NPC.height, dust, 0f, 0f, 0);
                    Dust.NewDust(new Vector2(NPC.position.X, NPC.position.Y), NPC.width, NPC.height, dust, 0f, 0f, 0);
                }
                if (TheNefariousObeseness >= 2 && TheNefariousObeseness < 4)
                {
                    for (int i = 0; i < 16; i++)
                    {
                        int dust = DustID.Blood;
                        Dust.NewDust(new Vector2(NPC.position.X, NPC.position.Y), NPC.width, NPC.height, dust, 0f, 0f, 0);
                        Dust.NewDust(new Vector2(NPC.position.X, NPC.position.Y), NPC.width, NPC.height, dust, 0f, 0f, 0);
                        Dust.NewDust(new Vector2(NPC.position.X, NPC.position.Y), NPC.width, NPC.height, dust, 0f, 0f, 0);
                    }
                }
                if (TheNefariousObeseness >= 4 && TheNefariousObeseness < 6)
                {
                    for (int i = 0; i < 32; i++)
                    {
                        int dust = DustID.Blood;
                        Dust.NewDust(new Vector2(NPC.position.X, NPC.position.Y), NPC.width * (int)1.2, NPC.height * (int)1.2, dust, 0f, 0f, 0);
                        Dust.NewDust(new Vector2(NPC.position.X, NPC.position.Y), NPC.width * (int)1.2, NPC.height * (int)1.2, dust, 0f, 0f, 0);
                        Dust.NewDust(new Vector2(NPC.position.X, NPC.position.Y), NPC.width * (int)1.2, NPC.height * (int)1.2, dust, 0f, 0f, 0);
                    }
                }
                if (TheNefariousObeseness >= 6)
                {
                    for (int i = 0; i < 64; i++)
                    {
                        int dust = DustID.Blood;
                        Dust.NewDust(new Vector2(NPC.position.X, NPC.position.Y), NPC.width * (int)1.5, NPC.height * (int)1.5, dust, 0f, 0f, 0);
                        Dust.NewDust(new Vector2(NPC.position.X, NPC.position.Y), NPC.width * (int)1.5, NPC.height * (int)1.5, dust, 0f, 0f, 0);
                        Dust.NewDust(new Vector2(NPC.position.X, NPC.position.Y), NPC.width * (int)1.5, NPC.height * (int)1.5, dust, 0f, 0f, 0);
                    }
                }
            }
        }
    }
}
