using MultidimensionMod.Base;
using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace MultidimensionMod.NPCs.Bosses.FeudalFungus
{
    [AutoloadBossHead]
    public class FeudalFungus : ModNPC
    {
        public int damage = 0;

		public override void SendExtraAI(BinaryWriter writer)
		{
			base.SendExtraAI(writer);
			if(Main.netMode == NetmodeID.Server || Main.dedServ)
			{
				writer.Write(internalAI[0]);
				writer.Write(internalAI[1]);
                writer.Write(internalAI[2]);
                writer.Write(internalAI[3]);
                writer.Write(internalAI[4]);
            }
		}

		public override void ReceiveExtraAI(BinaryReader reader)
		{
			base.ReceiveExtraAI(reader);
			if(Main.netMode == NetmodeID.MultiplayerClient)
			{
                internalAI[0] = (float)reader.ReadDouble();
                internalAI[1] = (float)reader.ReadDouble();
                internalAI[2] = (float)reader.ReadDouble();
                internalAI[3] = (float)reader.ReadDouble();
                internalAI[4] = (float)reader.ReadDouble();
            }	
		}	

        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Feudal Fungus");
            //Main.NPCFrameCount[NPC.type] = 8;
        }

        public override void SetDefaults()
        {
            NPC.lifeMax = 1200;   //boss life
            NPC.damage = 24;  //boss damage
            NPC.defense = 12;    //boss defense
            NPC.knockBackResist = 0f;   //this boss will behavior like the DemonEye  //boss frame/animation 
            NPC.value = Item.sellPrice(0, 0, 50, 0);
            NPC.aiStyle = 26;
            NPC.width = 74;
            NPC.height = 108;
            NPC.npcSlots = 1f;
            NPC.boss = true;
            NPC.lavaImmune = true;
            NPC.noGravity = false;
            NPC.buffImmune[46] = true;
            NPC.buffImmune[47] = true;
            NPC.netAlways = true;
            NPC.noGravity = true;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            if (!Main.dedServ)
                Music = MusicLoader.GetMusicSlot(Mod, "Sounds/Music/Monarch");
            NPC.alpha = 255;
        }

        public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
        {
            scale = 1.5f;
            return null;
        }

        public static int AISTATE_HOVER = 0, AISTATE_FLIER = 1, AISTATE_SHOOT = 2;
		public float[] internalAI = new float[5];

        public int despawnTimer = 0;

        public override void AI()
        {
            if (Main.expertMode)
            {
                damage = NPC.damage / 4;
            }
            else
            {
                damage = NPC.damage / 2;
            }
            Player player = Main.player[NPC.target];
             
            if ((Main.dayTime && player.position.Y < Main.worldSurface) || !player.ZoneGlowshroom)
            {
                despawnTimer++;
                if (Main.netMode != 1 && despawnTimer > 480)
                {
                    NPC.dontTakeDamage = true;
                    NPC.velocity *= 0;

                    if (NPC.velocity.X <= .1f && NPC.velocity.X >= -.1f)
                    {
                        NPC.velocity.X = 0;
                    }
                    if (NPC.velocity.Y <= .1f && NPC.velocity.Y >= -.1f)
                    {
                        NPC.velocity.Y = 0;
                    }

                    NPC.alpha += 10;

                    if (NPC.alpha >= 255)
                    {
                        NPC.active = false;
                    }
                }
                else
                {
                    despawnTimer = 0;
                    NPC.dontTakeDamage = false;
                }
                return;
            }
            despawnTimer = 0;
            NPC.alpha -= 10;
            if (NPC.alpha < 0)
            {
                NPC.alpha = 0;
            }

            NPC.noTileCollide = true;

            if (Main.netMode != 1 && internalAI[1] != AISTATE_SHOOT)
			{
                internalAI[0]++;
                if (internalAI[0] >= 180)
                {
                    internalAI[0] = 0;
                    internalAI[1] = Main.rand.Next(3);
                    NPC.ai = new float[4];
                    NPC.netUpdate = true;
                }
            }
			if(internalAI[1] == AISTATE_HOVER) 
            {
                BaseAI.AISpaceOctopus(NPC, ref NPC.ai, player.Center, 0.15f, 4f, 170, 56f, FireMagic);
            }
            else if (internalAI[1] == AISTATE_FLIER) 
            {
                BaseAI.AIFlier(NPC, ref NPC.ai, true, 0.1f,0.04f, 5f, 3f, false, 1);
            }
            else if (internalAI[1] == AISTATE_SHOOT)
            {
                BaseAI.AISpaceOctopus(NPC, ref NPC.ai, player.Center, 0.15f, 4f, 170, 56f, null);
                if (Main.netMode != 1)
                {
                    internalAI[0]++;
                }
                if (internalAI[0] >= 60)
                {
                    int attack = Main.rand.Next(4);
                    internalAI[1] = Main.rand.Next(3);
                    internalAI[0] = 0;
                    FungusAttack(attack);
                    NPC.netUpdate = true;
                }
            }

            NPC.rotation = 0;

            if (internalAI[4] ++ > 90 && Main.expertMode && Main.netMode != 1)
            {
                internalAI[4] = 0;
                Vector2 pos = new Vector2(player.Center.X + Main.rand.Next(70, 150) * (Main.rand.NextBool(2)? 1 : -1), player.Center.Y + Main.rand.Next(70, 150) * (Main.rand.NextBool(2)? 1 : -1));
                Vector2 velocity = Vector2.Normalize(player.Center - pos) * .1f;
                //int proj = Projectile.NewProjectile(pos.X, pos.Y, velocity.X, velocity.Y, ModContent.ProjectileType<FungusCloud>(), damage, 0, Main.myPlayer, 0f, 0f);
                //Main.projectile[proj].timeLeft = 720;
                //Main.projectile[proj].alpha = 255;
            }
        }


        public float[] shootAI = new float[4];

        public void FireMagic(NPC NPC, Vector2 velocity)
        {
            Player player = Main.player[NPC.target];
            //BaseAI.ShootPeriodic(NPC, player.position, player.width, player.height, mod.ProjType("Mushshot"), ref shootAI[0], 5, damage, 8f, false, new Vector2(20f, 15f));
        }

        public override void BossLoot(ref string name, ref int potionType)
        {

        }

        public override void ApplyDifficultyAndPlayerScaling(int numPlayers, float balance, float bossAdjustment)
        {
            NPC.lifeMax = (int)(NPC.lifeMax * 0.6f * balance);
            NPC.damage = (int)(NPC.damage * 0.6f);
        }

        public void FungusAttack(int Attack)
        {
            if (Attack == 1)
            {
                for (int i = 0; i < 4; i++)
                {
                    //NPC.NewNPC((int)NPC.Center.X, (int)NPC.Center.Y, ModContent.NPCType<FungusFlier>());
                }
            }
            else if (Attack == 2)
            {
                float spread = 12f * 0.0174f;
                double startAngle = Math.Atan2(NPC.velocity.X, NPC.velocity.Y) - spread / 2;
                double deltaAngle = spread / (Main.expertMode ? 5 : 4);
                double offsetAngle;
                for (int i = 0; i < (Main.expertMode ? 5 : 4); i++)
                {
                    offsetAngle = startAngle + deltaAngle * (i + i * i) / 2f + 32f * i;
                    //Projectile.NewProjectile(NPC.Center.X, NPC.Center.Y, (float)(Math.Sin(offsetAngle) * 6f), (float)(Math.Cos(offsetAngle) * 6f), mod.ProjectileType("FungusCloud"), damage, 0, Main.myPlayer, 0f, 1f);
                }
            }
            else
            {
                for (int i = 0; i < 4; i++)
                {
                    //NPC.NewNPC((int)NPC.Center.X, (int)NPC.Center.Y, ModContent.NPCType<FungusSpore>(), 0, i);
                }
            }
        }

        public void MoveToPoint(Vector2 point, bool goUpFirst = false)
        {
            float moveSpeed = 4f;
            if (moveSpeed == 0f || NPC.Center == point) return; //don't move if you have no move speed
            float velMultiplier = 1f;
            Vector2 dist = point - NPC.Center;
            float length = dist == Vector2.Zero ? 0f : dist.Length();
            if (length < moveSpeed)
            {
                velMultiplier = MathHelper.Lerp(0f, 1f, length / moveSpeed);
            }
            if (length < 200f)
            {
                moveSpeed *= 0.5f;
            }
            if (length < 100f)
            {
                moveSpeed *= 0.5f;
            }
            if (length < 50f)
            {
                moveSpeed *= 0.5f;
            }
            NPC.velocity = length == 0f ? Vector2.Zero : Vector2.Normalize(dist);
            NPC.velocity *= moveSpeed;
            NPC.velocity *= velMultiplier;
        }
    }   
}


