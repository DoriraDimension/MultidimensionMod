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

namespace MultidimensionMod.NPCs.MushBiomes
{
    public class Mushbug : ModNPC
	{
		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Mushbug");
            Main.npcFrameCount[NPC.type] = 7;
		}

		public override void SetDefaults()
        {
            NPC.width = 50;
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

        public override void AI()
        {
            NPC.TargetClosest(true);
            Player target = Main.player[NPC.target];
            float distanceToPlayer = Vector2.Distance(target.Center, NPC.Center);
            if (distanceToPlayer > 100) //Only move if this distance away from the player
            {
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
            }
            else if (distanceToPlayer < 100 && NPC.life >= NPC.lifeMax) //Don't move if close enough and at full health
            {
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
            }
            if (NPC.life < NPC.lifeMax)
            {
                NPC.chaseable = true;
            }
            if (Main.rand.NextBool(600))
            {
                SoundEngine.PlaySound(SoundID.Zombie77, NPC.position);
            }
        }

        public override void FindFrame(int frameHeight)
        {
            if ((NPC.velocity.X == 0) && (NPC.velocity.X == 0)) //Disable animation when the bug stands still
            {
                NPC.frame.Y = 0;
            }
            else
            {
                NPC.frameCounter += 1.0;
                if (NPC.frameCounter >= 7.0)
                {
                    NPC.frameCounter = 0.0;
                    NPC.frame.Y += frameHeight;
                    if (NPC.frame.Y >= 7 * frameHeight)
                    {
                        NPC.frame.Y = 0 * frameHeight;
                    }
                }
            }
        }

        public override bool CanHitPlayer(Player target, ref int cooldownSlot) => NPC.life == NPC.lifeMax ? false : true;

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
                Gore.NewGore(NPC.GetSource_FromThis(), NPC.position, NPC.velocity, ModContent.Find<ModGore>("MultidimensionMod/MyceliBugGore1").Type, 1);
                Gore.NewGore(NPC.GetSource_FromThis(), NPC.position, NPC.velocity, ModContent.Find<ModGore>("MultidimensionMod/MyceliBugGore2").Type, 1);
            }
        }
	}
}