using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Typeless
{
    public class Sunpowder : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 1;
            Item.DamageType = DamageClass.Generic;
            Item.shoot = ModContent.ProjectileType<Projectiles.Typeless.SunpowderBag>();
            Item.useStyle = ItemUseStyleID.Swing;
            Item.shootSpeed = 10f;
            Item.width = 16;
            Item.height = 24;
            Item.maxStack = 99;
            Item.consumable = true;
            Item.UseSound = SoundID.Item1;
            Item.useAnimation = 15;
            Item.useTime = 15;
            Item.noMelee = true;
            Item.noUseGraphic = true;
            Item.value = 75;
        }

        public override void SetStaticDefaults()
        {
            //Tooltip.SetDefault(@"Cleanses the mire");
        }


        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<Materials.Hotshroom>(), 1)
                .AddIngredient(ModContent.ItemType<Materials.DragonScale>(), 2)
                .AddTile(TileID.Bottles)
                .Register();
        }
    }
}
