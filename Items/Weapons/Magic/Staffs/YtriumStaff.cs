using MultidimensionMod.Projectiles.Magic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using MultidimensionMod.Projectiles.Ranged;

namespace MultidimensionMod.Items.Weapons.Magic.Staffs
{
    public class YtriumStaff : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Ytrium Staff");
            Item.staff[Item.type] = true;
        }

        public override void SetDefaults()
        {

            Item.width = 44;
            Item.height = 44;
            Item.DamageType = DamageClass.Magic;
            Item.value = Item.sellPrice(0, 1, 40, 0);
            Item.rare = ItemRarityID.LightRed;
            Item.damage = 30;
            Item.useTime = 85;
            Item.useAnimation = 85;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.noMelee = true;
            Item.knockBack = 4;
            Item.mana = 12;
            Item.UseSound = SoundID.Item13;
            Item.autoReuse = true;
            Item.shoot = ModContent.ProjectileType<YtriumShard>();
            Item.shootSpeed = 12f;
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            float rotation = MathHelper.ToRadians(10);

            for (int i = 0; i < 3; i++)
            {
                Vector2 perturbedSpeed = new Vector2(velocity.X, velocity.Y).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (3 - 1))) * .8f;
                Projectile.NewProjectile(source, position, perturbedSpeed, ModContent.ProjectileType<YtriumShard>(), damage, knockback, player.whoAmI);
            }
            return true;
        }
    }
}