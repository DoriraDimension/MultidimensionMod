using MultidimensionMod.Biomes;
using MultidimensionMod.Base;
using MultidimensionMod.Items.Placeables.Banners;
using MultidimensionMod.Tiles.Biomes.ShroomForest;
using System;
using Terraria;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using Terraria.Audio;
using Terraria.GameContent.Bestiary;
using Terraria.DataStructures;
using Microsoft.Xna.Framework.Graphics;
using MultidimensionMod.Items.Materials.Mushrooms;
using MultidimensionMod.Items.Weapons.Magic.Staffs;

namespace MultidimensionMod.NPCs.MushBiomes
{
    public class Mushbug : ModNPC
	{
		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Mushbug");
            Main.npcFrameCount[NPC.type] = 6;
		}

		public override void SetDefaults()
        {
            NPC.width = 48;
            NPC.height = 32;
            NPC.aiStyle = -1;
            NPC.damage = 10;
            NPC.defense = 9;
            NPC.lifeMax = 100;
            NPC.HitSound = SoundID.NPCHit45;
            NPC.DeathSound = SoundID.NPCDeath47;
            NPC.knockBackResist = 0.3f;
            NPC.value = 1000f;
            NPC.chaseable = false;
            NPC.buffImmune[31] = false;
            Banner = NPC.type;
            BannerItem = ModContent.ItemType<MushbugBanner>();
            SpawnModBiomes = new int[1] { ModContent.GetInstance<ShroomForest>().Type };
        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[]
            {
                new FlavorTextBestiaryInfoElement("Mods.MultidimensionMod.Bestiary.MyceliBug")
            });
        }

        private bool leafShell = false;
        private bool dapperShell = false;
        private bool sakuraShell = false;
        private bool midasShell = false;
        public int distance = 0;

        public override void OnSpawn(IEntitySource source)
        {
            distance = Main.rand.Next(70, 250);
            int choice = Main.rand.Next(4);
            if (choice == 0)
            {
                leafShell = true;
            }
            else if (choice == 1)
            {
                dapperShell = true;
            }
            else if (choice == 2)
            {
                sakuraShell = true;
            }
            else if (choice == 3)
            {
                if (Main.rand.NextBool(50))
                {
                    midasShell = true;
                }
                else
                    leafShell = true;
            }
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
        {
            Texture2D bug = ModContent.Request<Texture2D>(NPC.ModNPC.Texture).Value;
            Texture2D dapper = ModContent.Request<Texture2D>(NPC.ModNPC.Texture + "Dapper").Value;
            Texture2D sakura = ModContent.Request<Texture2D>(NPC.ModNPC.Texture + "Sakura").Value;
            Texture2D midas = ModContent.Request<Texture2D>(NPC.ModNPC.Texture + "Midas").Value;
            SpriteEffects effects = NPC.spriteDirection == -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
            if (midasShell)
                spriteBatch.Draw(midas, NPC.Center + new Vector2(0f, 3f) - screenPos, NPC.frame, drawColor, NPC.rotation, NPC.frame.Size() / 2, NPC.scale, effects, 0);
            else if (sakuraShell)
                spriteBatch.Draw(sakura, NPC.Center + new Vector2(0f, 3f) - screenPos, NPC.frame, drawColor, NPC.rotation, NPC.frame.Size() / 2, NPC.scale, effects, 0);
            else if (dapperShell)
                spriteBatch.Draw(dapper, NPC.Center + new Vector2(0f, 3f) - screenPos, NPC.frame, drawColor, NPC.rotation, NPC.frame.Size() / 2, NPC.scale, effects, 0);
            else if (leafShell)
                spriteBatch.Draw(bug, NPC.Center + new Vector2(0f, 3f) - screenPos, NPC.frame, drawColor, NPC.rotation, NPC.frame.Size() / 2, NPC.scale, effects, 0);
            return false;
        }

        public enum ActionState
        {
            Idle,
            Roam,
            Curious,
            Observe,
            Kill
        }

        public ActionState AIState
        {
            get => (ActionState)NPC.ai[0];
            set => NPC.ai[0] = (int)value;
        }

        public ref float AITimer => ref NPC.ai[1];
        public ref float TimerRand => ref NPC.ai[2];
        public bool goRight = false;

        public override void AI()
        {

            NPC.TargetClosest(true);
            Player target = Main.player[NPC.target];
            float distanceToPlayer = Vector2.Distance(target.Center, NPC.Center);
            if (Main.rand.NextBool(600))
            {
                SoundEngine.PlaySound(SoundID.Zombie77, NPC.position);
            }
            if (NPC.life < NPC.lifeMax||Main.hardMode)
            {
                NPC.chaseable = true;
                AIState = ActionState.Kill;
            }
            switch (AIState)
            {
                case ActionState.Idle:
                    if (NPC.velocity.Y == 0)
                        NPC.velocity.X = 0;
                    AITimer++;
                    if (AITimer >= TimerRand)
                    {
                        int choice = Main.rand.Next(2);
                        if (choice == 0)
                        {
                            goRight = true;
                            NPC.netUpdate = true;
                        }
                        else if (choice == 1)
                        {
                            goRight = false;
                            NPC.netUpdate = true;
                        }
                        AITimer = 0;
                        TimerRand = Main.rand.Next(60, 180);
                        AIState = ActionState.Roam;
                        NPC.netUpdate = true;
                    }
                    if (distanceToPlayer < 400) //Start walking towards player when close enough
                    {
                        AIState = ActionState.Curious;
                    }
                    NPC.frame.Y = 170;
                    break;
                case ActionState.Roam:
                    NPC.TargetClosest(true);
                    if (!goRight)
                    {
                        NPC.spriteDirection = -1;
                        NPC.velocity.X = 1.5f;
                    }
                    if (goRight)
                    {
                        NPC.spriteDirection = 1;
                        NPC.velocity.X = -1.5f;
                    }
                    BaseAI.WalkupHalfBricks(NPC);
                    if (BaseAI.HitTileOnSide(NPC, 3))
                    {
                        if (NPC.velocity.X < 0f && NPC.direction == -1 || NPC.velocity.X > 0f && NPC.direction == 1)
                        {
                            Vector2 newVec = BaseAI.AttemptJump(NPC.position, NPC.velocity, NPC.width, NPC.height, NPC.direction, NPC.directionY, 6, 10, 4, true);
                            if (NPC.velocity != newVec) { NPC.velocity = newVec; NPC.netUpdate = true; }
                        }
                        NPC.netUpdate = true;
                    }
                    AITimer++;
                    if (AITimer >= TimerRand)
                    {
                        AITimer = 0;
                        TimerRand = Main.rand.Next(60, 120);
                        AIState = ActionState.Idle;
                        NPC.netUpdate = true;
                    }
                    if (distanceToPlayer < 400) //Walk towards player if close enough
                    {
                        AIState = ActionState.Curious;
                        NPC.netUpdate = true;
                    }
                    NPC.frameCounter += 1.0;
                    if (NPC.frameCounter >= 4.0)
                    {
                        NPC.frameCounter = 0.0;
                        NPC.frame.Y += 34;
                        if (NPC.frame.Y >= 5 * 34)
                        {
                            NPC.frame.Y = 0 * 34;
                        }
                    }
                    break;
                case ActionState.Curious:
                    if (target.Center.X > NPC.Center.X)
                    {
                        NPC.spriteDirection = -1;
                    }
                    else
                    {
                        NPC.spriteDirection = 1;
                    }
                    float speedUp = 1.30f;
                    float maxVel = 3.0f;
                    if (distanceToPlayer < 200)
                    {
                        maxVel = 1.5f;
                        NPC.netUpdate = true;
                    }
                    if (NPC.Center.X > target.Center.X)
                    {
                        NPC.velocity.X -= speedUp;
                        if (NPC.velocity.X > 0f)
                        {
                            NPC.velocity.X -= speedUp;
                        }
                        if (NPC.velocity.X < 0f - maxVel)
                        {
                            NPC.velocity.X = 0f - maxVel;
                        }
                        NPC.netUpdate = true;
                    }
                    if (NPC.Center.X < target.Center.X)
                    {
                        NPC.velocity.X += speedUp;
                        if (NPC.velocity.X < 0f)
                        {
                            NPC.velocity.X += speedUp;
                        }
                        if (NPC.velocity.X > maxVel)
                        {
                            NPC.velocity.X = maxVel;
                        }
                        NPC.netUpdate = true;
                    }
                    BaseAI.WalkupHalfBricks(NPC);
                    if (Math.Abs(NPC.velocity.X) == NPC.ai[1])
                        NPC.velocity.X = NPC.ai[1] * NPC.spriteDirection;
                    if (BaseAI.HitTileOnSide(NPC, 3))
                    {
                        if (NPC.velocity.X < 0f && NPC.direction == -1 || NPC.velocity.X > 0f && NPC.direction == 1)
                        {
                            Vector2 newVec = BaseAI.AttemptJump(NPC.position, NPC.velocity, NPC.width, NPC.height, NPC.direction, NPC.directionY, 6, 10, 4, true);
                            if (NPC.velocity != newVec) { NPC.velocity = newVec; NPC.netUpdate = true; }
                        }
                        NPC.netUpdate = true;
                    }
                    if (distanceToPlayer <= distance)
                    {
                        AIState = ActionState.Observe;
                    }
                    break;
                case ActionState.Observe:
                    NPC.velocity.X = 0;
                    if (target.Center.X > NPC.Center.X)
                    {
                        NPC.spriteDirection = -1;
                    }
                    else
                    {
                        NPC.spriteDirection = 1;
                    }
                    NPC.netUpdate = true;
                    if (distanceToPlayer > distance)
                    {
                        AIState = ActionState.Curious;
                    }
                    NPC.frame.Y = 170;
                    break;
                case ActionState.Kill:
                    if (target.Center.X > NPC.Center.X)
                    {
                        NPC.spriteDirection = -1;
                    }
                    else
                    {
                        NPC.spriteDirection = 1;
                    }
                    float speedUp2 = 1.20f;
                    float maxVel2 = 3.0f;
                    if (distanceToPlayer < 200)
                    {
                        maxVel = 1.5f;
                        NPC.netUpdate = true;
                    }
                    if (NPC.Center.X > target.Center.X)
                    {
                        NPC.velocity.X -= speedUp2;
                        if (NPC.velocity.X > 0f)
                        {
                            NPC.velocity.X -= speedUp2;
                        }
                        if (NPC.velocity.X < 0f - maxVel2)
                        {
                            NPC.velocity.X = 0f - maxVel2;
                        }
                        NPC.netUpdate = true;
                    }
                    if (NPC.Center.X < target.Center.X)
                    {
                        NPC.velocity.X += speedUp2;
                        if (NPC.velocity.X < 0f)
                        {
                            NPC.velocity.X += speedUp2;
                        }
                        if (NPC.velocity.X > maxVel2)
                        {
                            NPC.velocity.X = maxVel2;
                        }
                        NPC.netUpdate = true;
                    }
                    BaseAI.WalkupHalfBricks(NPC);
                    if (Math.Abs(NPC.velocity.X) == NPC.ai[1])
                        NPC.velocity.X = NPC.ai[1] * NPC.spriteDirection;
                    if (BaseAI.HitTileOnSide(NPC, 3))
                    {
                        if (NPC.velocity.X < 0f && NPC.direction == -1 || NPC.velocity.X > 0f && NPC.direction == 1)
                        {
                            Vector2 newVec = BaseAI.AttemptJump(NPC.position, NPC.velocity, NPC.width, NPC.height, NPC.direction, NPC.directionY, 6, 10, 4, true);
                            if (NPC.velocity != newVec) { NPC.velocity = newVec; NPC.netUpdate = true; }
                        }
                        NPC.netUpdate = true;
                    }
                    break;
            }  
        }

        public override void FindFrame(int frameHeight)
        {
            if ((NPC.velocity.X == 0) && (NPC.velocity.X == 0)) //Disable animation when the bug stands still
            {
                NPC.frame.Y = 170;
            }
            else
            {
                NPC.frameCounter += 1.0;
                if (NPC.frameCounter >= 4.0)
                {
                    NPC.frameCounter = 0.0;
                    NPC.frame.Y += frameHeight;
                    if (NPC.frame.Y >= 5 * frameHeight)
                    {
                        NPC.frame.Y = 0 * frameHeight;
                    }
                }
            }
        }

        public override bool CanHitPlayer(Player target, ref int cooldownSlot) => NPC.life < NPC.lifeMax ||Main.hardMode ? true : false;

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
            return Main.tile[spawnInfo.SpawnTileX, spawnInfo.SpawnTileY].TileType == ModContent.TileType<Mycelium>() && spawnInfo.Player.InModBiome(ModContent.GetInstance<ShroomForest>()) ? 0.05f : 0f;
        }

        public override void HitEffect(NPC.HitInfo hit)
        {

            int dust1 = ModContent.DustType<Dusts.MushroomDust>();
            if (NPC.life <= 0)
            {
                Dust.NewDust(new Vector2(NPC.position.X, NPC.position.Y), NPC.width, NPC.height, dust1, 0f, 0f, 0);
                Dust.NewDust(new Vector2(NPC.position.X, NPC.position.Y), NPC.width, NPC.height, dust1, 0f, 0f, 0);
                Dust.NewDust(new Vector2(NPC.position.X, NPC.position.Y), NPC.width, NPC.height, dust1, 0f, 0f, 0);
                if (leafShell)
                    Gore.NewGore(NPC.GetSource_FromThis(), NPC.position, NPC.velocity, ModContent.Find<ModGore>("MultidimensionMod/MyceliBugGore2").Type, 1);
                else if (dapperShell)
                    Gore.NewGore(NPC.GetSource_FromThis(), NPC.position, NPC.velocity, ModContent.Find<ModGore>("MultidimensionMod/MyceliBugGore2D").Type, 1);
                else if (sakuraShell)
                    Gore.NewGore(NPC.GetSource_FromThis(), NPC.position, NPC.velocity, ModContent.Find<ModGore>("MultidimensionMod/MyceliBugGore2S").Type, 1);
                else if (midasShell)
                    Gore.NewGore(NPC.GetSource_FromThis(), NPC.position, NPC.velocity, ModContent.Find<ModGore>("MultidimensionMod/MyceliBugGore2M").Type, 1);
                Gore.NewGore(NPC.GetSource_FromThis(), NPC.position, NPC.velocity, ModContent.Find<ModGore>("MultidimensionMod/MyceliBugGore1").Type, 1);
            }
        }
	}
}