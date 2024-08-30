using System;
using Terraria;
using MultidimensionMod.Biomes;
using MultidimensionMod.Base;
using MultidimensionMod.Items.Placeables.Banners;
using MultidimensionMod.Tiles.Biomes.ShroomForest;
using MultidimensionMod.Items.Summons;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using Terraria.Audio;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using Terraria.GameContent.Bestiary;
using MultidimensionMod.Items.Materials;
using Terraria.GameContent.ItemDropRules;
using MultidimensionMod.Items.Weapons.Typeless;
using Terraria.DataStructures;

namespace MultidimensionMod.NPCs.MushBiomes
{
    public class Puffer : ModNPC
    {
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[NPC.type] = 9;
            NPCID.Sets.CountsAsCritter[Type] = true;
            NPCID.Sets.DontDoHardmodeScaling[Type] = true;
            NPCID.Sets.CantTakeLunchMoney[Type] = true;
        }

        public override void SetDefaults()
        {
            NPC.width = 80;
            NPC.height = 52;
            NPC.aiStyle = -1;
            NPC.damage = 0;
            NPC.defense = 1000;
            NPC.lifeMax = 5;
            NPC.HitSound = SoundID.NPCHit10;
            NPC.DeathSound = SoundID.NPCDeath5;
            NPC.knockBackResist = 0.0f;
            NPC.chaseable = false;
            NPC.value = 1000f;
            NPC.buffImmune[31] = false;
            Banner = NPC.type;
            SpawnModBiomes = new int[1] { ModContent.GetInstance<ShroomForest>().Type };
            BannerItem = ModContent.ItemType<PufferBanner>();
        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[]
            {
                new FlavorTextBestiaryInfoElement("Mods.MultidimensionMod.Bestiary.Puffer")
            });
        }

        public override void OnSpawn(IEntitySource source)
        {
            NPC.life = 250;
        }

        public enum ActionState
        {
            Idle,
            Patrol,
            Alerted,
            Runaway
        }

        public ActionState AIState
        {
            get => (ActionState)NPC.ai[0];
            set => NPC.ai[0] = (int)value;
        }

        public int Gwah = 0;
        public ref float AITimer => ref NPC.ai[1];
        public ref float TimerRand => ref NPC.ai[2];
        public bool goRight = false;

        public override void AI()
        {
            Player target = Main.player[NPC.target];
            float distanceToPlayer = Vector2.Distance(target.Center, NPC.Center);
            if (NPC.life < NPC.lifeMax)
            {
                NPC.chaseable = true;
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
                        TimerRand = Main.rand.Next(180, 360);
                        AIState = ActionState.Patrol;
                        NPC.netUpdate = true;
                    }
                    if (distanceToPlayer < 100) //Go into alert mode when close enough
                    {
                        AIState = ActionState.Alerted;
                    }
                    NPC.frame.Y = 416;
                    break;
                case ActionState.Patrol:
                    NPC.TargetClosest(true);
                    if (!goRight)
                    {
                        NPC.spriteDirection = 1;
                        NPC.velocity.X = 1.5f;
                    }
                    if (goRight)
                    {
                        NPC.spriteDirection = -1;
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
                    if (distanceToPlayer < 100) //Go into alert mode when close enough
                    {
                        AIState = ActionState.Alerted;
                        NPC.netUpdate = true;
                    }
                    NPC.frameCounter += 1.0;
                    if (NPC.frameCounter >= 5.0)
                    {
                        NPC.frameCounter = 0.0;
                        NPC.frame.Y += 52;
                        if (NPC.frame.Y >= 8 * 52)
                        {
                            NPC.frame.Y = 0 * 52;
                        }
                    }
                    break;
                case ActionState.Alerted:
                    NPC.TargetClosest(true);
                    if (NPC.velocity.Y == 0)
                        NPC.velocity.X = 0;
                    NPC.frame.Y = 416;
                    Gwah++;
                    if (Gwah == 1)
                    {
                        SoundEngine.PlaySound(new("MultidimensionMod/Sounds/NPC/GooberAlert"), NPC.position);
                    }
                    if (Gwah >= 180)
                    {
                        SoundEngine.PlaySound(new("MultidimensionMod/Sounds/NPC/BigFart"), NPC.position);
                        if (Main.netMode != NetmodeID.MultiplayerClient)
                            Projectile.NewProjectile(NPC.GetSource_FromAI(), NPC.Center, new Vector2(0f, 0f), ModContent.ProjectileType<PufferFart>(), 0, 0);
                        Gwah = 0;
                        if (Main.rand.NextBool(10))
                        Item.NewItem(new EntitySource_Loot(NPC), NPC.position, NPC.Size, ModContent.ItemType<IntimidatingMushroom>(), 1);
                        AIState = ActionState.Runaway;
                        NPC.netUpdate = true;
                    }
                    else if (distanceToPlayer > 300)
                    {
                        AIState = ActionState.Patrol;
                        Gwah = 0;
                        NPC.netUpdate = true;
                    }
                    if (target.Center.X > NPC.Center.X)
                    {
                        NPC.spriteDirection = 1;
                    }
                    else
                    {
                        NPC.spriteDirection = -1;
                    }
                    break;
                case ActionState.Runaway:
                    if (NPC.spriteDirection == 1)
                    {
                        NPC.velocity.X = 4f;
                        if (BaseAI.HitTileOnSide(NPC, 1, true))
                        {
                            AIState = ActionState.Idle;
                        }
                    }
                    else if (NPC.spriteDirection == -1)
                    {
                        NPC.velocity.X = -4f;
                        if (BaseAI.HitTileOnSide(NPC, 0, true))
                        {
                            AIState = ActionState.Idle;
                        }
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
                    NPC.frameCounter += 1.0;
                    if (NPC.frameCounter >= -3.0)
                    {
                        NPC.frameCounter = 0.0;
                        NPC.frame.Y += 52;
                        if (NPC.frame.Y >= 8 * 52)
                        {
                            NPC.frame.Y = 0 * 52;
                        }
                    }
                    if (distanceToPlayer > 500)
                    {
                        AIState = ActionState.Patrol;
                        NPC.netUpdate = true;
                    }
                    break;
            }
            if (NPC.life <= 1)
            {
                NPC.life = 1;
                if (Main.netMode != NetmodeID.MultiplayerClient)
                    Projectile.NewProjectile(NPC.GetSource_FromAI(), NPC.Center, new Vector2(0f, 0f), ModContent.ProjectileType<PufferFart>(), 0, 0);
                SoundEngine.PlaySound(new("MultidimensionMod/Sounds/NPC/BigFart"), NPC.position);
                NPC.active = false;
            }
        }

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
            }
        }
    }
}