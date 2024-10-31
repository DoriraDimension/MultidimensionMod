using Terraria.ID;
using Terraria.ModLoader;
using MultidimensionMod.Buffs.Debuffs;

namespace MultidimensionMod.Items.Weapons.Typeless
{
    public class Moonpowder : ModItem
	{
		public override void SetDefaults()
        {
            Item.damage = 1;
            Item.DamageType = DamageClass.Generic;
            Item.shoot = ModContent.ProjectileType<Projectiles.Typeless.MoonpowderBag>();
            Item.useStyle = ItemUseStyleID.Swing;
            Item.shootSpeed = 10f;
            Item.width = 30;
            Item.height = 30;
            Item.maxStack = 99;
            Item.consumable = true;
            Item.UseSound = SoundID.Item1;
            Item.useAnimation = 15;
            Item.useTime = 15;
            Item.noMelee = true;
            Item.noUseGraphic = true;
            Item.value = 75;
            Item.rare = ItemRarityID.Green;
        }

		public override void SetStaticDefaults()
		{
			//Tooltip.SetDefault(@"Cleanses the Inferno");
		}
        
        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<Materials.Darkshroom>(), 1)
            .AddIngredient(ModContent.ItemType<Materials.MirePod>(), 2)
            .AddTile(TileID.Bottles)
            .Register();
        }
    }
}
