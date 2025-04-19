using MultidimensionMod.Items.Materials;
using MultidimensionMod.Dusts;
using MultidimensionMod.Biomes;
using MultidimensionMod.Base;
using MultidimensionMod.Items;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;
using Terraria.GameContent.ItemDropRules;
using Terraria.GameContent.Bestiary;
using Terraria.Audio;
using MultidimensionMod.Items.Placeables.Banners;
using MultidimensionMod.Utilities;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria.GameContent;
using MultidimensionMod.Buffs.Misc;
using MultidimensionMod.Common.Globals;

namespace MultidimensionMod.NPCs.Madness
{
    public class AMindFromBeyond : ModNPC
    {
        private static Asset<Texture2D> segmentTexture;

        public override void Load()
        {
            segmentTexture = ModContent.Request<Texture2D>(Texture + "Segment");
        }
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[NPC.type] = 1;
        }
        public override void SetDefaults()
        {
            NPC.width = 60;
            NPC.height = 100;
            NPC.damage = 20;
            NPC.defense = 30;
            NPC.lifeMax = 6000;
            NPC.noGravity = true;
            NPC.noTileCollide = true;
            NPC.knockBackResist = 0f;
            NPC.value = 100000;
            NPC.lavaImmune = true;
            NPC.netAlways = true;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.Opacity=0f;
            NPC.scale=2f;

            SpawnModBiomes = new int[1] { ModContent.GetInstance<MadnessMoon>().Type };
        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[]
            {
                new FlavorTextBestiaryInfoElement("Mods.MultidimensionMod.Bestiary.AMindFromBeyond")
            });
        }

        bool isHiding=true;
        Vector2 AnchorPosition;
        bool HasFoundSpot=false;
        int AITimer=0;
        public override void AI()
        {
            if(isHiding)
            {
                NPC.Opacity=0f;
                AITimer=0;
            }
            if(NPC.Opacity!=1f)
            {
                NPC.dontTakeDamage=true;
            }
            
            NPC.TargetClosest();
            Player player = Main.player[NPC.target];
            NPC.rotation =(player.Center-NPC.Center).ToRotation();

            if (player.Center.X > NPC.Center.X)
            {
                NPC.spriteDirection = -1;
            }
            else
            {
                NPC.spriteDirection = 1;
            }
            //Find a good spot to emerge
            if(isHiding&&!HasFoundSpot)
            {
                Vector2 playerCenter = new(player.Center.X, MDHelper.GetFirstTileFloor((int)player.Center.X / 16, (int)player.Center.Y / 16) * 16);
                NPC.Center = NPC.FindGroundVector(playerCenter, 15);
                HasFoundSpot=true;
                AnchorPosition=NPC.Center;
                AITimer=0;
                isHiding=false;
            }

            if(!isHiding&&AITimer<100)
            {
                AITimer++;
                NPC.velocity.Y=-1f;
                NPC.Opacity+=0.01f;
            }
            else if(!isHiding)
            {
                for(int i=0; i < Main.maxNPCs;i++)
                {
                    NPC n = Main.npc[i];
                    if(n.active && (n.type == ModContent.NPCType<Madman>()||n.type == ModContent.NPCType<MadnessDog>()||n.type == ModContent.NPCType<MadnessBat2>()||n.type == ModContent.NPCType<MadnessBat>())&&!n.HasBuff<MadnessEmpower>())
                        n.AddBuff(ModContent.BuffType<MadnessEmpower>(),5);
                }
                NPC.dontTakeDamage=false;

                AITimer++;
                if(Vector2.Distance(AnchorPosition,NPC.Center)<300f)
                {
                    NPC.velocity += (player.Center-NPC.Center).SafeNormalize(Vector2.UnitX)*0.1f;
                }
                else
                {
                    NPC.velocity += (AnchorPosition-NPC.Center).SafeNormalize(Vector2.UnitX)*0.3f;

                }
                if(NPC.velocity.Length()>2f)
                    NPC.velocity=NPC.velocity.SafeNormalize(Vector2.UnitX)*2f;

                if(AITimer%180==0)
                {
                    if (Main.netMode != NetmodeID.MultiplayerClient)
                        Projectile.NewProjectile(NPC.GetSource_FromAI(), NPC.Center, (player.Center-NPC.Center).SafeNormalize(Vector2.UnitX)*19f, ModContent.ProjectileType<BigBrainProjectile>(), NPC.damage / 3, 0f, Main.myPlayer);
                }

                if(Vector2.Distance(player.Center,NPC.Center)>1000f||NPC.Opacity!=1f)
                {
                    NPC.Opacity-=0.05f;
                    if(NPC.Opacity<0.01f)
                    {
                        isHiding=true;
                        HasFoundSpot=false;
                    }

                }
            } 
        }
        

        public override bool PreDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
        {
            
            if (!isHiding && HasFoundSpot)
            {


                Vector2 segmentOrigin =  (segmentTexture.Size() / 2f);
                Vector2 CurrentPos = AnchorPosition;
              


                float segmentRotation = new Vector2(0,-1).ToRotation();
        
                int segsDrawn=0;
                while(Vector2.Distance(NPC.Center,CurrentPos)>50f||segsDrawn<1)
                {
                    segsDrawn++;
                    Color segmentDrawColor = Lighting.GetColor((int)CurrentPos.X / 16, (int)(CurrentPos.Y / 16f));

                    Main.spriteBatch.Draw(segmentTexture.Value, CurrentPos - Main.screenPosition, null, segmentDrawColor*NPC.Opacity, segmentRotation+MathHelper.PiOver2, segmentOrigin, 1f, NPC.spriteDirection == 1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0f);

                    Vector2 direction = (NPC.Center - CurrentPos).SafeNormalize(Vector2.UnitX);

                    segmentRotation = ((segmentRotation.ToRotationVector2() + (direction *0.3f*segsDrawn)).SafeNormalize(Vector2.UnitX)).ToRotation();
                    CurrentPos += new Vector2(segmentTexture.Height(),0).RotatedBy(segmentRotation);
                }
            }
            Main.spriteBatch.Draw(TextureAssets.Npc[NPC.type].Value, NPC.Center - Main.screenPosition, null, drawColor*NPC.Opacity, NPC.rotation, NPC.frame.Size() / 2, NPC.scale, NPC.spriteDirection == 1 ? SpriteEffects.FlipVertically : SpriteEffects.None, 0f);
            Texture2D tex = ModContent.Request<Texture2D>("MultidimensionMod/ExtraTextures/Aura").Value;
            Main.spriteBatch.Draw(tex, NPC.Center - Main.screenPosition, null, new Color(255,200,0)*0.1f*NPC.Opacity, NPC.rotation, ModContent.Request<Texture2D>("MultidimensionMod/ExtraTextures/Aura").Value.Size() / 2, 2f, NPC.spriteDirection == 1 ? SpriteEffects.FlipVertically : SpriteEffects.None, 0f);

            return false;
        }

        public override void HitEffect(NPC.HitInfo hit)
        {
            for (int k = 0; k < 3; k++)
            {
                Dust.NewDust(NPC.position, NPC.width, NPC.height, Main.rand.NextBool(2) ? ModContent.DustType<MadnessP>() : ModContent.DustType<MadnessB>(), hit.HitDirection, -1f, 0);
            }
            if (NPC.life <= 0)
            {
                for (int k = 0; k < 15; k++)
                {
                    Dust.NewDust(NPC.position, NPC.width, NPC.height, Main.rand.NextBool(2) ? ModContent.DustType<MadnessP>() : ModContent.DustType<MadnessB>(), hit.HitDirection, -1f, 0);
                }
            }
        }

        public override void ModifyNPCLoot(NPCLoot NPCloot)
        {
            NPCloot.Add(ItemDropRule.Common(ModContent.ItemType<MadnessFragment>(), 3, 1, 2));
            NPCloot.Add(ItemDropRule.Common(ModContent.ItemType<Blight2>(), 1));
            NPCloot.Add(ItemDropRule.Common(ModContent.ItemType<ShadeEye>(), 100));
        }

        public override void OnHitPlayer(Player target, Player.HurtInfo info)
        {
            target.AddBuff(ModContent.BuffType<Buffs.Debuffs.Madness>(), 300);
        }
    }
    public class BigBrainProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {

        }

        public override void SetDefaults()
        {
            Projectile.width = 14;
            Projectile.height = 14;
            Projectile.hostile = true;
            Projectile.penetrate = -1;
            Projectile.timeLeft = 600;
        }

        public override void AI()
        {
            Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, Main.rand.NextBool(2) ? DustID.YellowTorch : 54);
            Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, Main.rand.NextBool(2) ? DustID.YellowTorch : 54);
            Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, Main.rand.NextBool(2) ? DustID.YellowTorch : 54);
        }

        public override void OnHitPlayer(Player target, Player.HurtInfo info)
        {
            target.AddBuff(ModContent.BuffType<Buffs.Debuffs.Madness>(), 300);
        }
    }
}