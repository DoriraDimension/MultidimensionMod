using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using MultidimensionMod.Projectiles.Ranged;

namespace MultidimensionMod.Items.Ammo
{
    public class StarfeatherDart : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 99;
        }

        public override void SetDefaults()
        {
            Item.damage = 7;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 14;
            Item.height = 22;
            Item.maxStack = 9999;
            Item.knockBack = 4f;
            Item.value = Item.sellPrice(0, 0, 0, 10);
            Item.rare = ItemRarityID.White;
            Item.consumable = true;
            Item.shoot = ModContent.ProjectileType<StarfeatherDartProj>();
            Item.shootSpeed = 3.5f;
            Item.ammo = AmmoID.Dart;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(20);
            recipe.AddIngredient(ItemID.FallenStar);
            recipe.AddIngredient(ItemID.Feather, 2);
            recipe.Register();
        }
    }
}