using MultidimensionMod.Projectiles.Magic;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Magic.Staffs
{
    public class GunkWand : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Gunk Wand");
            //Tooltip.SetDefault(@"Shoots a gunk ball that grows over time
//The larger the ball is, the more damage it does");
        }

        public override void SetDefaults()
        {
            Item.damage = 20;
            Item.DamageType = DamageClass.Magic;
            Item.mana = 6;
            Item.width = 36;
            Item.height = 38;
            Item.useTime = 37;
            Item.useAnimation = 37;
            Item.useStyle = 1;
            Item.noMelee = true;
            Item.knockBack = 3;
            Item.value = 1000;
            Item.rare = 2;
            Item.UseSound = SoundID.Item20;
            Item.autoReuse = true;
            Item.shoot = ModContent.ProjectileType<Gunk>();
            Item.shootSpeed = 4f;
        }
    }
}