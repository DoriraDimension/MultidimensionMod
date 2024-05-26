using MultidimensionMod.Projectiles.Summon.Minions;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using Terraria.DataStructures;

namespace MultidimensionMod.Items.Weapons.Summon
{
    public class ClawBaton : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Claw Baton");
            //Tooltip.SetDefault(@"Summons a chaos claw to fight with you");
        }

        public override void SetDefaults()
        {
            Item.useStyle = ItemUseStyleID.Swing;
            Item.shootSpeed = 14f;
            Item.shoot = ModContent.ProjectileType<ClawBatonHoldout>();
            Item.damage = 14;
            Item.width = 52;
            Item.height = 52;
            Item.UseSound = SoundID.Item44;
            Item.useAnimation = 30;
            Item.useTime = 30;
            Item.noMelee = true;
            Item.value = Item.sellPrice(0, 1, 0, 0);
            Item.knockBack = 5f;
            Item.rare = ItemRarityID.Orange;
            Item.DamageType = DamageClass.Summon;
            Item.mana = 5;
            Item.noUseGraphic = true;
        }

        public override bool AltFunctionUse(Player player)
        {
            return true;
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            if (player.altFunctionUse == 2)
            {
                player.MinionNPCTargetAim(false);
            }

            else
            {
                int shootMe = Main.rand.Next(2);
                {
                    switch (shootMe)
                    {
                        case 0:
                            shootMe = ModContent.ProjectileType<HydraClaw>();
                            break;
                        default:
                            shootMe = ModContent.ProjectileType<DragonClaw>();
                            break;
                    }
                }
                int i = Main.myPlayer;
                float num72 = Item.shootSpeed;
                int num73 = damage;
                float num74 = knockback;
                num74 = player.GetWeaponKnockback(Item, num74);
                player.itemTime = Item.useTime;
                Vector2 vector2 = player.RotatedRelativePoint(player.MountedCenter, true);
                float num78 = Main.mouseX + Main.screenPosition.X - vector2.X;
                float num79 = Main.mouseY + Main.screenPosition.Y - vector2.Y;
                if (player.gravDir == -1f)
                {
                    num79 = Main.screenPosition.Y + Main.screenHeight - Main.mouseY - vector2.Y;
                }
                float num80 = (float)Math.Sqrt(num78 * num78 + num79 * num79);
                float num81 = num80;
                if ((float.IsNaN(num78) && float.IsNaN(num79)) || (num78 == 0f && num79 == 0f))
                {
                    num78 = player.direction;
                    num79 = 0f;
                    num80 = num72;
                }
                else
                {
                    num80 = num72 / num80;
                }
                num78 = 0f;
                num79 = 0f;
                vector2.X = Main.mouseX + Main.screenPosition.X;
                vector2.Y = Main.mouseY + Main.screenPosition.Y;
                Projectile.NewProjectile(source, vector2.X, vector2.Y, num78, num79, shootMe, num73, num74, i, 0f, 0f);
            }
            return true;
        }
    }
}