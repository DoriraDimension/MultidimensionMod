using Microsoft.Xna.Framework;
using MultidimensionMod.Projectiles.Melee.Yoyos;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Melee.Yoyos
{
    public class Depthwalker : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Depthwalker");
            //Tooltip.SetDefault(@"Inflicts Poisoned on hit
            //Walk the Hydra");
            ItemID.Sets.Yoyo[Item.type] = true; // Used to increase the gamepad range when using Strings.
            ItemID.Sets.GamepadExtraRange[Item.type] = 15; // Increases the gamepad range. Some vanilla values: 4 (Wood), 10 (Valor), 13 (Yelets), 18 (The Eye of Cthulhu), 21 (Terrarian).
            ItemID.Sets.GamepadSmartQuickReach[Item.type] = true; // Unused, but weapons that require aiming on the screen are in this set.
        }

        public override void SetDefaults()
        {
            Item.damage = 13;
            Item.DamageType = DamageClass.MeleeNoSpeed;
            Item.useTime = 25;
            Item.useAnimation = 25;
            Item.width = 26;
            Item.height = 40;
            Item.value = Item.sellPrice(0, 0, 10, 0);
            Item.rare = ItemRarityID.Green;
            Item.knockBack = 1;
            Item.channel = true;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.noMelee = true;
            Item.noUseGraphic = true;
            Item.UseSound = SoundID.Item1;
            Item.channel = true;
            Item.shoot = ModContent.ProjectileType<DepthwalkerProj>();
            Item.shootSpeed = 16f;
        }

        public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.AddBuff(BuffID.Poisoned, 180);
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            float yoyoAmount = player.yoyoGlove ? 4 : 3;
            float rotation = MathHelper.ToRadians(20);

            position += Vector2.Normalize(velocity) * 20f;

            for (int i = 0; i < yoyoAmount; i++)
            {
                Vector2 perturbedSpeed = velocity.RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (yoyoAmount - 1))) * .2f;
                Projectile.NewProjectile(source, position, perturbedSpeed, type, damage, knockback, player.whoAmI);
            }

            return false;
        }
    }
}
