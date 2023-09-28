using MultidimensionMod.Items.Materials;
using MultidimensionMod.Projectiles.Ranged;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace MultidimensionMod.Items.Weapons.Ranged.Bows
{
    public class  Mushbow : ModItem
	{
		public override void SetStaticDefaults()
		{
            //DisplayName.SetDefault("Mushroom Bow");
            ItemID.Sets.ItemsThatAllowRepeatedRightClick[Item.type] = true;
        }

		public override void SetDefaults()
		{
			Item.damage = 11;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 20;
			Item.height = 40;
			Item.useTime = 24;
			Item.useAnimation = 24;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 1;
            Item.value = Item.sellPrice(0, 0, 1, 30);
			Item.rare = ItemRarityID.Blue;
			Item.UseSound = SoundID.Item5;
			Item.autoReuse = true;
			Item.shoot = ProjectileID.PurificationPowder;
			Item.shootSpeed = 14f;
			Item.useAmmo = AmmoID.Arrow;
		}

        public override bool AltFunctionUse(Player player)
        {
            return true;
        }

        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            if (player.altFunctionUse == 2)
            {

                type = ModContent.ProjectileType<BloodshroomArrow>();
            }
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            if (player.altFunctionUse == 2)
            {
                player.statLife -= 10;
            }
            return true;
        }

        public override bool CanUseItem(Player player)
        {
            if (player.altFunctionUse == 2)
            {
                Item.damage = 33;
                Item.shootSpeed = 7f;
                if (player.statLife <= 10)
                {
                    return false;
                }
            }
            else
            {
                SetDefaults();
            }
            return base.CanUseItem(player);
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<Mushmatter>(), 4)
            .AddTile(TileID.WorkBenches)
            .Register();
        }
    }
}
