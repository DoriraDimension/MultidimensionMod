using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MultidimensionMod.Biomes;
using MultidimensionMod.Items.Accessories;
using MultidimensionMod.Items.Materials;
using Terraria;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.NPCs.Mire
{
    public class Newt : ModNPC
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Newt");
            Main.npcFrameCount[NPC.type] = 15;
        }

        public override void SetDefaults()
        {
            NPC.width = 112;
            NPC.height = 30;
            NPC.damage = 10;
            NPC.defense = 10;
            NPC.damage = 28;
            NPC.defense = 6;
            NPC.lifeMax = 60;
            NPC.knockBackResist = 0.55f;
            NPC.value = 100f;
            NPC.aiStyle = 3;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            AIType = NPCID.Crawdad;
            SpawnModBiomes = new int[1] { ModContent.GetInstance<TheShroudedMire>().Type };
        }

        public override void SetBestiary(BestiaryDatabase dataNPC, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[]
            {
                new FlavorTextBestiaryInfoElement("Mods.MultidimensionMod.Bestiary.Newt")
            });
        }

        private bool acidAttack;
        private int acidFrame;
        private int acidCounter;
        private int acidTimer;

        public override void AI()
        {
            Player player = Main.player[NPC.target]; // makes it so you can reference the player the NPC is targetting
            if (acidAttack == false)
            {
                NPC.frameCounter++;
                if (NPC.frameCounter >= 10)
                {
                    NPC.frameCounter = 0;
                    NPC.frame.Y += 30;
                    if (NPC.frame.Y > 420)
                    {
                        NPC.frameCounter = 0;
                        NPC.frame.Y = 0;
                    }
                }
            }
            else
            {
                NPC.frameCounter = 0;
                NPC.frame.Y = 0;
            }
            if (!acidAttack)
            {
                if (NPC.velocity.X < 0) // so it faces the player
                {
                    NPC.direction = 1;
                }
                else if (NPC.velocity.X > 0)
                {
                    NPC.direction = -1;
                }
            }
            else
            {
                if (player.position.X < NPC.position.X)
                {
                    NPC.direction = 1;
                }
                else
                {
                    NPC.direction = -1;
                }
            }
            if (acidAttack == true)
            {
                if (acidFrame < 3)
                {
                    acidCounter++;
                }
                if (acidCounter > 5)
                {
                    acidFrame++;
                    acidCounter = 0;
                }
                if (acidFrame >= 3)
                {
                    acidFrame = 0;
                }
            }
            float distance = NPC.Distance(Main.player[NPC.target].Center);
            if (distance >= 100 && distance <= 400) // distance until it does the acid attack
            {
                if (Main.rand.NextBool(30)) // so it wont do it repeatedly when the player is near. increase to lower the chance of it doing it
                {
                    if (acidAttack == false)
                    {
                        acidAttack = true;
                    }
                }
            }
            if (acidAttack == true)
            {
                acidTimer++;
                NPC.aiStyle = 0;
                NPC.velocity.X = 0;
                if (acidTimer == 90)
                {
                    if (NPC.direction == -1)
                    {
                        Projectile.NewProjectile(NPC.GetSource_FromAI(), new Vector2(NPC.position.X + 56f, NPC.Center.Y), new Vector2(3 + Main.rand.Next(0, 3), -4 + Main.rand.Next(-4, 0)), ModContent.ProjectileType<NewtAcidProj>(), 15 / 4, 3);
                    }
                    else
                    {
                        Projectile.NewProjectile(NPC.GetSource_FromAI(), new Vector2(NPC.Center.X - 56f, NPC.Center.Y), new Vector2(-6 + Main.rand.Next(-6, 0), -4 + Main.rand.Next(-4, 0)), ModContent.ProjectileType<NewtAcidProj>(), 15 / 4, 3);
                    }
                }
                if (acidTimer >= 90)
                {
                    acidAttack = false;
                    acidTimer = 0;
                    acidCounter = 0;
                    acidFrame = 0;
                }
            }
            if (acidAttack == false) // so it changes back to aiStyle 3 after the attacks are done
            {
                NPC.aiStyle = 3;
            }
        }

        public override void HitEffect(NPC.HitInfo hit)
        {
            if (NPC.life <= 0)
            {
                Gore.NewGore(NPC.GetSource_FromThis(), NPC.position, NPC.velocity, ModContent.Find<ModGore>("MultidimensionMod/NewtGore1").Type, 1); //tail
                Gore.NewGore(NPC.GetSource_FromThis(), NPC.position, NPC.velocity, ModContent.Find<ModGore>("MultidimensionMod/NewtGore2").Type, 1); //body
                Gore.NewGore(NPC.GetSource_FromThis(), NPC.position, NPC.velocity, ModContent.Find<ModGore>("MultidimensionMod/NewtGore3").Type, 1); //legs
                Gore.NewGore(NPC.GetSource_FromThis(), NPC.position, NPC.velocity, ModContent.Find<ModGore>("MultidimensionMod/NewtGore3").Type, 1);
                Gore.NewGore(NPC.GetSource_FromThis(), NPC.position, NPC.velocity, ModContent.Find<ModGore>("MultidimensionMod/NewtGore3").Type, 1);
                Gore.NewGore(NPC.GetSource_FromThis(), NPC.position, NPC.velocity, ModContent.Find<ModGore>("MultidimensionMod/NewtGore3").Type, 1);
                Gore.NewGore(NPC.GetSource_FromThis(), NPC.position, NPC.velocity, ModContent.Find<ModGore>("MultidimensionMod/NewtGore4").Type, 1); //head
            }
        }

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<MirePod>(), 3, 1, 2));
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
        {
            Texture2D texture = ModContent.Request<Texture2D>(NPC.ModNPC.Texture).Value;
            Texture2D acidAni = ModContent.Request<Texture2D>(NPC.ModNPC.Texture + "_Shoot").Value;
            var effects = NPC.direction == -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
            if (acidAttack == false) // i think this is important for it to not do its usual walking cycle while its also doing those attacks
            {
                spriteBatch.Draw(texture, NPC.Center - Main.screenPosition, NPC.frame, drawColor, NPC.rotation, NPC.frame.Size() / 2, NPC.scale, effects, 0f);
            }
            if (acidAttack == true)
            {
                Vector2 drawCenter = new Vector2(NPC.Center.X, NPC.Center.Y);
                int num214 = acidAni.Height / 4;
                int y6 = num214 * acidFrame;
                Main.spriteBatch.Draw(acidAni, drawCenter - Main.screenPosition, new Microsoft.Xna.Framework.Rectangle?(new Rectangle(0, y6, acidAni.Width, num214)), drawColor, NPC.rotation, new Vector2(acidAni.Width / 2f, num214 / 2f), NPC.scale, effects, 0f);
            }
            return false;
        }
    }
}