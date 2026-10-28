using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MultidimensionMod.Buffs.Minions;
using MultidimensionMod.Buffs.Pets;
using MultidimensionMod.Common.Globals;
using MultidimensionMod.Common.Players;
using MultidimensionMod.Items.Potions.Food;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Projectiles.Pets
{
    public class KFCPet : ModProjectile
    {
        private float stretchTimer;
        private float verticalScale = 1f;
        public override void SetStaticDefaults()
        {
            Main.projFrames[Projectile.type] = 5;
            Main.projPet[Projectile.type] = true;
            ProjectileID.Sets.CharacterPreviewAnimations[Projectile.type] = ProjectileID.Sets.SimpleLoop(0, 0).WithOffset(-4, 4).WithSpriteDirection(-1);
        }

        public override void SetDefaults()
        {
            Projectile.width = 32;
            Projectile.height = 42;

            Projectile.friendly = true;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
            Projectile.penetrate = -1;
            Projectile.timeLeft = 2;
            Projectile.netImportant = true;
        }

        private int FrameY;
        public override bool PreAI()
        {
            Player player = Main.player[Projectile.owner];
            player.dino = false;
            if (!player.dead && player.HasBuff(ModContent.BuffType<KFCBuff>()))
                Projectile.timeLeft = 2;

            if (Main.bloodMoon || Main.eclipse || MDWorld.MadnessMoon)
            {
                FrameY = 4;
            }
            else if (player.GetModPlayer<MDPlayer>().TotalMoneyCollectedByKevin < 12500 && player.GetModPlayer<MDPlayer>().TotalMoneyCollectedByKevin > 5000)
            {
                FrameY = 3;
            }
            else if (player.GetModPlayer<MDPlayer>().TotalMoneyCollectedByKevin >= 25000 && player.GetModPlayer<MDPlayer>().TotalMoneyCollectedByKevin < 37500)
            {
                FrameY = 2;
            }
            else if (player.GetModPlayer<MDPlayer>().TotalMoneyCollectedByKevin > 37500)
            {
                FrameY = 1;
            }
            else
            {
                FrameY = 0;
            }
            return true;
        }


        public override void AI()
        {
            Player player = Main.player[Projectile.owner];

            if (!player.active || player.dead || !player.HasBuff(ModContent.BuffType<KFCBuff>()))
            {
                Projectile.Kill();
                return;
            }

            Projectile.timeLeft = 2;

            // Search for coins within 400 pixels.
            Item coin = FindNearestCoin(400f);

            Vector2 targetPosition;

            if (coin != null)
            {
                // Prioritize collecting money.
                targetPosition = coin.Center;
            }
            else
            {
                // Otherwise, follow the player.
                targetPosition = player.Center
                    + new Vector2(-player.direction * 40f, -35f);
            }

            Vector2 difference = targetPosition - Projectile.Center;
            float distance = difference.Length();

            if (distance > 8f)
            {
                float speed = coin != null ? 12f : 10f;

                Projectile.velocity = Vector2.Lerp(
                    Projectile.velocity,
                    Vector2.Normalize(difference) * speed,
                    0.12f
                );
            }
            else
            {
                Projectile.velocity *= 0.8f;
            }
            if (distance > 100f)
            {
                Projectile.Center = player.Center
                    + new Vector2(-player.direction * 40f, -35f);

                Projectile.velocity = Vector2.Zero;
                Projectile.netUpdate = true;
            }
            HungerForCoins(player);

            stretchTimer += 0.12f;

            verticalScale = 1f + MathF.Sin(stretchTimer) * 0.06f;
            int nuggetCount = (int)(player.GetModPlayer<MDPlayer>().TotalMoneyCollectedByKevin / 50000);
            if (player.GetModPlayer<MDPlayer>().TotalMoneyCollectedByKevin >= 50000 && distance <= 2f)
            {
                for (int i = 0; i < nuggetCount; i++)
                {
                    int nuggetType;

                    if (Main.bloodMoon || Main.eclipse || MDWorld.MadnessMoon)
                    {
                        nuggetType = ModContent.ItemType<EvilNugget>();
                    }
                    else
                    {
                        int choice = Main.rand.Next(3);

                        if (choice == 0)
                            nuggetType = ItemID.ChickenNugget;
                        else if (choice == 1)
                            nuggetType = Main.rand.NextBool(20) ? ModContent.ItemType<GoldenNugget>() : ItemID.ChickenNugget;
                        else
                            nuggetType = Main.rand.NextBool(5) ? ModContent.ItemType<EvilNugget>() : ItemID.ChickenNugget;
                    }

                    Item.NewItem( new EntitySource_Loot(Projectile), Projectile.position, Projectile.Size, nuggetType);
                }
                player.GetModPlayer<MDPlayer>().TotalMoneyCollectedByKevin %= 50000;
            }
        }

        private Item FindNearestCoin(float searchRange)
        {
            Item nearestCoin = null;
            float closestDistance = searchRange * searchRange;

            foreach (Item item in Main.item)
            {
                if (!item.active || item.stack <= 0)
                    continue;

                if (item.type != ItemID.CopperCoin &&
                    item.type != ItemID.SilverCoin &&
                    item.type != ItemID.GoldCoin &&
                    item.type != ItemID.PlatinumCoin)
                    continue;

                float distance = Vector2.DistanceSquared(
                    Projectile.Center,
                    item.Center
                );

                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    nearestCoin = item;
                }
            }

            return nearestCoin;
        }

        private void HungerForCoins(Player player)
        {
            // Only the owning player should collect items.
            if (Projectile.owner != Main.myPlayer)
                return;

            float pickupRange = 24f;

            foreach (Item item in Main.item)
            {
                if (!item.active || item.stack <= 0)
                    continue;

                if (item.type != ItemID.CopperCoin &&
                    item.type != ItemID.SilverCoin &&
                    item.type != ItemID.GoldCoin &&
                    item.type != ItemID.PlatinumCoin)
                    continue;

                if (Vector2.DistanceSquared(Projectile.Center, item.Center)
                    > pickupRange * pickupRange)
                    continue;

                int coinValue = item.type switch
                {
                    ItemID.CopperCoin => 1,
                    ItemID.SilverCoin => 100,
                    ItemID.GoldCoin => 10000,
                    ItemID.PlatinumCoin => 1000000,
                    _ => 0
                };

                int totalValue = coinValue * item.stack;

                player.GetModPlayer<MDPlayer>().TotalMoneyCollectedByKevin += totalValue;

                item.TurnToAir();
            }
        }

        public override bool PreDraw(ref Color lightColor)
        {
            Texture2D texture = Terraria.GameContent.TextureAssets.Projectile[Projectile.type].Value;
            int height = texture.Height / 5;
            int y = height * FrameY;
            Rectangle rect = new(0, y, texture.Width, height);
            Vector2 origin = new(texture.Width / 2, height / 2);
            var effects = Projectile.spriteDirection == 1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;

            Main.EntitySpriteDraw(texture, Projectile.Center + new Vector2(0, 2) - Main.screenPosition, new Rectangle?(rect), Projectile.GetAlpha(lightColor), Projectile.rotation, origin, new Vector2(1f, verticalScale), effects, 0);

            return false;
        }
    }
}