using MultidimensionMod.Projectiles.Melee.Boomerangs;
using MultidimensionMod.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Melee.Boomerangs
{
    public class Musharang : ModItem
	{
		public override void SetDefaults()
		{

            Item.damage = 16;            
            Item.DamageType = DamageClass.Melee;
            Item.width = 26;
            Item.height = 46;
			Item.useTime = 16;
			Item.useAnimation = 16;
            Item.noUseGraphic = true;
            Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 0;
            Item.value = Item.sellPrice(0, 5, 0, 0);
            Item.rare = ItemRarityID.Blue;
			Item.shootSpeed = 15f;
			Item.shoot = ModContent.ProjectileType<MusharangProj>();
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
            Item.noMelee = true;
        }

        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Musharang");
            //Tooltip.SetDefault("");
        }

        public override bool CanUseItem(Player player)
        {
            for (int i = 0; i < 1000; ++i)
            {
                if (Main.projectile[i].active && Main.projectile[i].owner == Main.myPlayer && Main.projectile[i].type == Item.shoot)
                {
                    return false;
                }
            }
            return true;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<Mushmatter>(), 3)
            .AddTile(TileID.WorkBenches)
            .Register();
        }
    }
}
