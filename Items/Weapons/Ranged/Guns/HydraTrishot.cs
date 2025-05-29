using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;

namespace MultidimensionMod.Items.Weapons.Ranged.Guns
{
    public class HydraTrishot : ModItem
    {

        public override void SetDefaults()
        {

            Item.damage = 10;
            Item.noMelee = true;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 50;
            Item.height = 20;
            Item.useTime = 40;
            Item.useAnimation = 40;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.shoot = ProjectileID.PurificationPowder;
            Item.useAmmo = AmmoID.Bullet;
            Item.knockBack = 0;
            Item.value = 2000;
            Item.autoReuse = true;
            Item.rare = ItemRarityID.Green;
            Item.UseSound = SoundID.Item11;
            Item.shootSpeed = 12f;

        }

        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Hydra Trishot");
            //Tooltip.SetDefault("Shoots 3 bullets in a spread");
        }

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
            int bulletAmount = 3;
            if (player.statLife < player.statLifeMax2 * 0.75f)
            {
                bulletAmount = 4;
            }
            if (player.statLife < player.statLifeMax2 * 0.50f)
            {
                bulletAmount = 5;
            }
            if (player.statLife < player.statLifeMax2 * 0.25f)
            {
                bulletAmount = 6;
            }
            for (int i = 0; i < bulletAmount; i++)
            {
                Vector2 perturbedSpeed = new Vector2(velocity.X, velocity.Y).RotatedByRandom(MathHelper.ToRadians(12));
                Projectile.NewProjectile(source, position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockback, player.whoAmI);
            }
            return false;
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-4, 0);
        }
    }
}
