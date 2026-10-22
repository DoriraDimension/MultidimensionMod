using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MultidimensionMod.Common.Players;
using MultidimensionMod.Dusts;
using MultidimensionMod.Items.Armor;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Accessories
{
	public class AstralTitansEyeJewel : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

		public override void SetDefaults()
		{
			Item.width = 24;
			Item.height = 38;
			Item.accessory = true;
			Item.value = Item.sellPrice(0, 4, 0, 0);
			Item.rare = ItemRarityID.Lime;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
            player.GetModPlayer<MDPlayer>().AstralEye = true;
		}

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            if (Main.keyState.PressingShift())
            {
                TooltipLine line = new(Mod, "Lore", Language.GetTextValue("Mods.MultidimensionMod.Items.AstralTitansEyeJewel.Lore"))
                {
                    OverrideColor = Color.LightGray
                };
                tooltips.Add(line);
            }
            else
            {
                TooltipLine line = new(Mod, "HoldShift", Language.GetTextValue("Mods.MultidimensionMod.MiscText.SpecialTooltips.Viewer"))
                {
                    OverrideColor = Color.Gray,
                };
                tooltips.Add(line);
            }
        }

        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            Texture2D texture = ModContent.Request<Texture2D>("MultidimensionMod/Items/Accessories/AstralTitansEyeJewel_Glow").Value;
            spriteBatch.Draw
            (
                texture,
                new Vector2
                (
                    Item.position.X - Main.screenPosition.X + Item.width * 0.5f,
                    Item.position.Y - Main.screenPosition.Y + Item.height - texture.Height * 0.5f
                ),
                new Rectangle(0, 0, texture.Width, texture.Height),
                Color.White,
                rotation,
                texture.Size() * 0.5f,
                scale,
                SpriteEffects.None,
                0f
            );
        }
    }

    public class AstralTitansEyeJewelOff : ModItem
    {
        public override string Texture => "MultidimensionMod/Items/Accessories/AstralTitansEyeJewel_Glow";
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            ItemID.Sets.ShimmerTransformToItem[Type] = ModContent.ItemType<AstralTitansEyeJewel>();
        }

        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 38;
            Item.value = Item.sellPrice(0, 0, 0, 0);
            Item.rare = ItemRarityID.Gray;
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            if (Main.keyState.PressingShift())
            {
                TooltipLine line = new(Mod, "Lore", Language.GetTextValue("Mods.MultidimensionMod.Items.AstralTitansEyeJewelOff.Lore"))
                {
                    OverrideColor = Color.LightGray
                };
                tooltips.Add(line);
            }
            else
            {
                TooltipLine line = new(Mod, "HoldShift", Language.GetTextValue("Mods.MultidimensionMod.MiscText.SpecialTooltips.Viewer"))
                {
                    OverrideColor = Color.Gray,
                };
                tooltips.Add(line);
            }
        }
    }

    internal class OffensiveParticle : ModProjectile
    {
        public override string Texture => "MultidimensionMod/Projectiles/NoTexture";
        public bool IsStone = false;
        public bool IsDirt = false;
        public bool IsCloud = false;

        public override void SetDefaults()
        {
            Projectile.width = 16;
            Projectile.height = 16;
            Projectile.friendly = true;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = true;
            Projectile.alpha = 255;
            Projectile.timeLeft = 240;
        }

        public override void OnSpawn(IEntitySource source)
        {
            int choice = Main.rand.Next(3);
            if (choice == 0)
            {
                IsDirt = true;
            }
            else if (choice == 1)
            {
                IsStone = true;
            }
            else if (choice == 2)
            {
                IsCloud = true;
            }
        }
        private int ShapingTimer = 0;
        public override void AI()
        {
            ShapingTimer++;
            Projectile.alpha -= 5;
            if (ShapingTimer < 60)
            {
                for (int i = 0; i < 3; i++)
                {
                    int dustIndex = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, ModContent.DustType<DimensionDust1>(), 0f, 0f, 100, default(Color), 2f);
                    Main.dust[dustIndex].velocity *= 1.8f;
                    Main.dust[dustIndex].alpha = 50;
                }
            }
            if (ShapingTimer >= 60)
            {
                Player player = Main.player[Projectile.owner];
                float distanceFromTarget = 700f;
                Vector2 targetCenter = Projectile.position;
                bool foundTarget = false;

                if (player.HasMinionAttackTargetNPC)
                {
                    NPC npc = Main.npc[player.MinionAttackTargetNPC];
                    float between = Vector2.Distance(npc.Center, Projectile.Center);
                    if (between < 2000f)
                    {
                        distanceFromTarget = between;
                        targetCenter = npc.Center;
                        foundTarget = true;
                        Projectile.netUpdate = true;
                    }
                }
                if (!foundTarget)
                {
                    for (int i = 0; i < Main.maxNPCs; i++)
                    {
                        NPC npc = Main.npc[i];
                        if (npc.CanBeChasedBy())
                        {
                            float between = Vector2.Distance(npc.Center, Projectile.Center);
                            bool closest = Vector2.Distance(Projectile.Center, targetCenter) > between;
                            bool inRange = between < distanceFromTarget;
                            bool lineOfSight = Collision.CanHitLine(Projectile.position, Projectile.width, Projectile.height, npc.position, npc.width, npc.height);
                            bool closeThroughWall = between < 100f;
                            if (((closest && inRange) || !foundTarget) && (lineOfSight || closeThroughWall))
                            {
                                distanceFromTarget = between;
                                targetCenter = npc.Center;
                                foundTarget = true;
                                Projectile.netUpdate = true;
                            }
                        }
                    }
                }

                float speed = 20f;
                float inertia = 20f;

                if (foundTarget)
                {
                    if (distanceFromTarget > 40f)
                    {
                        Vector2 direction = targetCenter - Projectile.Center;
                        direction.Normalize();
                        direction *= speed;
                        Projectile.velocity = (Projectile.velocity * (inertia - 1) + direction) / inertia;
                    }
                }
            }
        }

        public override bool PreDraw(ref Color lightColor)
        {
            Texture2D dirt = ModContent.Request<Texture2D>("MultidimensionMod/Items/Accessories/AstralTitansEyeJewel_Dirt").Value;
            Texture2D stone = ModContent.Request<Texture2D>("MultidimensionMod/Items/Accessories/AstralTitansEyeJewel_Stone").Value;
            Texture2D cloud = ModContent.Request<Texture2D>("MultidimensionMod/Items/Accessories/AstralTitansEyeJewel_Cloud").Value;
            Vector2 drawOrigin = new(dirt.Width / 2, dirt.Height / 2);
            var effects = Projectile.spriteDirection == 1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
            if (IsDirt)
            {
                Main.EntitySpriteDraw(dirt, Projectile.Center - Main.screenPosition, null, Projectile.GetAlpha(lightColor), Projectile.rotation, drawOrigin, Projectile.scale, effects, 0);
            }
            if (IsStone)
            {
                Main.EntitySpriteDraw(stone, Projectile.Center - Main.screenPosition, null, Projectile.GetAlpha(lightColor), Projectile.rotation, drawOrigin, Projectile.scale, effects, 0);
            }
            if (IsCloud)
            {
                Main.EntitySpriteDraw(cloud, Projectile.Center - Main.screenPosition, null, Projectile.GetAlpha(lightColor), Projectile.rotation, drawOrigin, Projectile.scale, effects, 0);
            }
            return false;
        }
    }

    internal class DefensiveParticle : ModProjectile
    {
        public override string Texture => "MultidimensionMod/Projectiles/NoTexture";

        public override void SetDefaults()
        {
            Projectile.width = 25;
            Projectile.height = 25;
            Projectile.friendly = true;
            Projectile.ignoreWater = true;
            Projectile.penetrate = -1;
            Projectile.tileCollide = true;
            Projectile.alpha = 255;
            Projectile.timeLeft = 480;
        }
        private int ShapingTimer = 0;
        public override bool? CanHitNPC(NPC target)
        {
            return Projectile.timeLeft < 420 ? null : false;
        }
        public override void AI()
        {
            Projectile.rotation += (Math.Abs(Projectile.velocity.X) + Math.Abs(Projectile.velocity.Y)) * 0.01f * (float)Projectile.direction;
            Projectile.alpha -= 5;
            ShapingTimer++;
            if (ShapingTimer < 60)
            {
                for (int i = 0; i < 3; i++)
                {
                    int dustIndex = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, ModContent.DustType<DimensionDust1>(), 0f, 0f, 100, default(Color), 2f);
                    Main.dust[dustIndex].velocity *= 1.8f;
                    Main.dust[dustIndex].alpha = 50;
                }
            }
            Player player = Main.player[Projectile.owner];

            if (!player.active || player.dead)
            {
                Projectile.Kill();
                return;
            }

            // ai[0] = unique projectile index
            // ai[1] = total number of projectiles
            int index = (int)Projectile.ai[0];
            int total = Math.Max(1, (int)Projectile.ai[1]);

            // Keep the projectile's unique angle.
            float spacing = MathHelper.TwoPi / total;
            float baseAngle = index * spacing;

            // Orbit speed.
            float rotationSpeed = 0.03f;

            // Store elapsed orbit time separately from the startup timer.
            Projectile.localAI[1] += rotationSpeed;

            float angle = baseAngle + Projectile.localAI[1];

            // Desired position around the player.
            float radius = 100f;

            Vector2 targetPosition = player.Center + new Vector2(MathF.Cos(angle), MathF.Sin(angle)) * radius;

            // Smoothly fly toward the desired orbit position.
            Vector2 toTarget = targetPosition - Projectile.Center;

            float maxSpeed = 12f;
            float inertia = 0.12f;

            Vector2 desiredVelocity = toTarget * 0.1f;

            if (desiredVelocity.Length() > maxSpeed)
                desiredVelocity = Vector2.Normalize(desiredVelocity) * maxSpeed;

            Projectile.velocity = Vector2.Lerp( Projectile.velocity, desiredVelocity, inertia
            );
        }

        public override bool PreDraw(ref Color lightColor)
        {
            Texture2D rock = ModContent.Request<Texture2D>("MultidimensionMod/Items/Accessories/AstralTitansEyeJewel_Boulder").Value;
            Vector2 drawOrigin = new(rock.Width / 2, rock.Height / 2);
            var effects = Projectile.spriteDirection == 1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
            Main.EntitySpriteDraw(rock, Projectile.Center - Main.screenPosition, null, Projectile.GetAlpha(lightColor), Projectile.rotation, drawOrigin, Projectile.scale, effects, 0);
            return false;
        }
    }
}