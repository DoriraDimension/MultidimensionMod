using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MultidimensionMod.Common.Players;
using MultidimensionMod.Dusts;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Accessories
{
	public class CreationMedaillon : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.width = 38;
			Item.height = 38;
			Item.accessory = true;
			Item.value = Item.sellPrice(0, 8, 30, 0);
			Item.rare = ItemRarityID.Red;
		}

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            if (Main.keyState.PressingShift())
            {
                TooltipLine line = new(Mod, "Lore", Language.GetTextValue("Mods.MultidimensionMod.Items.CreationMedaillon.Lore"))
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

        public override void UpdateAccessory(Player player, bool hideVisual)
		{
            player.GetModPlayer<MDPlayer>().CreationMedallionP = true;
        }

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ModContent.ItemType<AstralTitansEyeJewel>())
			.AddIngredient(ModContent.ItemType<DivineStarBlessing>())
			.AddIngredient(ItemID.LunarBar, 10)
			.AddTile(TileID.LunarCraftingStation)
			.Register();
		}

        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            Texture2D texture = ModContent.Request<Texture2D>("MultidimensionMod/Items/Accessories/CreationMedaillon_Glow").Value;
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

    internal class OffensiveParticleA : ModProjectile
    {
        public override string Texture => "MultidimensionMod/Projectiles/NoTexture";

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

        private int ShapingTimer = 0;
        public override void AI()
        {
            ShapingTimer++;
            Projectile.alpha -= 5;
            if (ShapingTimer < 60)
            {
                Projectile.rotation += 0.6f * (float)Projectile.direction;
                Projectile.spriteDirection = Projectile.direction;
                for (int i = 0; i < 3; i++)
                {
                    int dustIndex = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, ModContent.DustType<DimensionDust1>(), 0f, 0f, 100, default(Color), 2f);
                    Main.dust[dustIndex].velocity *= 1.8f;
                    Main.dust[dustIndex].alpha = 50;
                }
            }
            if (ShapingTimer >= 60)
            {
                Projectile.direction = Projectile.spriteDirection = Projectile.velocity.X > 0f ? 1 : -1;
                Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;
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
            Texture2D dirt = ModContent.Request<Texture2D>("MultidimensionMod/Items/Accessories/CreationMedaillon_GlimmerNeedle").Value;
            Vector2 drawOrigin = new(dirt.Width / 2, dirt.Height / 2);
            var effects = Projectile.spriteDirection == 1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
            Main.EntitySpriteDraw(dirt, Projectile.Center - Main.screenPosition, null, Projectile.GetAlpha(lightColor), Projectile.rotation, drawOrigin, Projectile.scale, effects, 0);
            return false;
        }
    }

    internal class DefensiveParticleA : ModProjectile
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

            Projectile.velocity = Vector2.Lerp(Projectile.velocity, desiredVelocity, inertia
            );
        }

        public override bool PreDraw(ref Color lightColor)
        {
            Texture2D rock = ModContent.Request<Texture2D>("MultidimensionMod/Items/Accessories/CreationMedaillon_AetherStar").Value;
            Vector2 drawOrigin = new(rock.Width / 2, rock.Height / 2);
            var effects = Projectile.spriteDirection == 1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
            Main.EntitySpriteDraw(rock, Projectile.Center - Main.screenPosition, null, Projectile.GetAlpha(lightColor), Projectile.rotation, drawOrigin, Projectile.scale, effects, 0);
            return false;
        }
    }
}