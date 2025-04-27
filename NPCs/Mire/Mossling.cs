using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MultidimensionMod.Base;
using MultidimensionMod.Biomes;
using MultidimensionMod.Items.Accessories;
using MultidimensionMod.Items.Materials;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.NPCs.Mire
{
    public class Mossling : ModNPC
    {
        public override void SetStaticDefaults()
        {
            //Main.npcFrameCount[NPC.type] = Bush Animation studios;
        }

        public enum ActionState
        {
            Walking,
            Dashing
        }

        public ActionState AIState
        {
            get => (ActionState)NPC.ai[0];
            set => NPC.ai[0] = (int)value;
        }

        public override void SetDefaults()
        {
            NPC.width = 114;
            NPC.height = 40;
            NPC.damage = 10;
            NPC.defense = 50; //god
            NPC.damage = 5;
            NPC.lifeMax = 30;
            NPC.knockBackResist = 0.10f;
            NPC.value = 100f;
            NPC.aiStyle = -1;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            SpawnModBiomes = new int[2] { ModContent.GetInstance<TheShroudedMire>().Type, ModContent.GetInstance<TheLakeDepths>().Type };
        }

        public override void SetBestiary(BestiaryDatabase dataNPC, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[]
            {
                new FlavorTextBestiaryInfoElement("Mods.MultidimensionMod.Bestiary.Mossling")
            });
        }

        private bool Green;

        public override void OnSpawn(IEntitySource source)
        {
            Player player = Main.LocalPlayer;
            if (player.InModBiome(ModContent.GetInstance<TheLakeDepths>()))
            {
                Green = true;
            }
        }

        public override void AI()
        {
            Player target = Main.player[NPC.target];
            float distanceToPlayer = Vector2.Distance(target.Center, NPC.Center);
            if (target.dead || !target.active || Vector2.Distance(target.Center, NPC.Center) > 5000)
            {
                NPC.TargetClosest();
            }
            switch (AIState)
            {
                case ActionState.Walking:
                    WalkAI();
                    break;
            }
        }

        public void WalkAI()
        {
            Player target = Main.player[NPC.target];
            if (target.Center.X > NPC.Center.X)
            {
                NPC.spriteDirection = 1;
            }
            else
            {
                NPC.spriteDirection = -1;
            }
            float speedUp = 0.70f;
            float maxVel = 1.80f;
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
                    Vector2 newVec = BaseAI.AttemptJump(NPC.position, NPC.velocity, NPC.width, NPC.height, NPC.direction, NPC.directionY, 3, 4, 4, true);
                    if (NPC.velocity != newVec) { NPC.velocity = newVec; NPC.netUpdate = true; }
                }
                NPC.netUpdate = true;
            }
        }

        public override void HitEffect(NPC.HitInfo hit)
        {

        }

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<MirePod>(), 3, 1, 2));
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
        {
            Texture2D tex = ModContent.Request<Texture2D>(NPC.ModNPC.Texture).Value;
            Texture2D glow = ModContent.Request<Texture2D>(NPC.ModNPC.Texture + "_Glow").Value;
            Texture2D nightGlow = ModContent.Request<Texture2D>(NPC.ModNPC.Texture + "Night_Glow").Value;
            Texture2D theNefariousGreen = ModContent.Request<Texture2D>(NPC.ModNPC.Texture + "Cave").Value;
            SpriteEffects effects = NPC.spriteDirection == -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
            if (Green)
                spriteBatch.Draw(theNefariousGreen, NPC.Center + new Vector2(0f, 0f) - screenPos, NPC.frame, drawColor, NPC.rotation, NPC.frame.Size() / 2, NPC.scale, effects, 0);
            else
            {
                spriteBatch.Draw(tex, NPC.Center + new Vector2(0f, 0f) - screenPos, NPC.frame, drawColor, NPC.rotation, NPC.frame.Size() / 2, NPC.scale, effects, 0);
                if (!Main.dayTime)
                {
                    spriteBatch.Draw(nightGlow, NPC.Center + new Vector2(0f, 0f) - screenPos, NPC.frame, Color.White, NPC.rotation, NPC.frame.Size() / 2, NPC.scale, effects, 0);

                }
            }
            spriteBatch.Draw(glow, NPC.Center + new Vector2(0f, 0f) - screenPos, NPC.frame, Color.White, NPC.rotation, NPC.frame.Size() / 2, NPC.scale, effects, 0);
            return false;
        }
    }
}