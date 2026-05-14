using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using MultidimensionMod.Projectiles.Ranged;

namespace MultidimensionMod.Items.Ammo
{
    public class StoneDart : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 99;
        }

        public override void SetDefaults()
        {
            Item.damage = 8;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 14;
            Item.height = 22;
            Item.maxStack = 9999;
            Item.knockBack = 4f;
            Item.value = Item.sellPrice(0, 0, 0, 10);
            Item.rare = 0;
            Item.consumable = true;
            Item.shoot = ModContent.ProjectileType<StoneDartProj>();
            Item.shootSpeed = 0.2f;
            Item.ammo = AmmoID.Dart;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(100);
            recipe.AddIngredient(ItemID.StoneBlock);
            recipe.Register();
        }
    }
}
