using MultidimensionMod.Projectiles.Ranged;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria.DataStructures;
using MultidimensionMod.Items.Materials;
using MultidimensionMod.Tiles.Furniture.VoidMatter;

namespace MultidimensionMod.Items.Weapons.Ranged.Others
{
	public class DarkMatterLauncher : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.damage = 44;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 54;
			Item.height = 26;
			Item.useTime = 50;
			Item.useAnimation = 50;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 4;
			Item.value = Item.sellPrice(0, 0, 90, 0);
			Item.rare = ItemRarityID.LightRed;
			Item.UseSound = SoundID.Item11;
			Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<DarkMatterBlob>();
			Item.shootSpeed = 11f;
			Item.crit = 8;
		}

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
			type = ModContent.ProjectileType<DarkMatterBlob2>();
            int numberProjectiles = 8;
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(velocity.X, velocity.Y).RotatedByRandom(MathHelper.ToRadians(20));
                perturbedSpeed *= 1f - Main.rand.NextFloat(0.3f);
                Projectile.NewProjectile(source, position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, (int)((double)((float)damage) * 0.4), knockback, player.whoAmI);
            }
            return true;
        }

        public override Vector2? HoldoutOffset()
		{
			return new Vector2(-10, 0);
		}

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<PaleMatter>(), 5)
                .AddTile(ModContent.TileType<EmptyKingsFabricatorPlaced>())
                .Register();
        }
    }
}