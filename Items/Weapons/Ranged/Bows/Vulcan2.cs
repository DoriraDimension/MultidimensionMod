using MultidimensionMod.Items.Materials;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Ranged.Bows
{
	public class Vulcan2 : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Lost Gen Repeater, Vulca");
			Tooltip.SetDefault("A long lost repeater, forgotten in ancient times.\nConverts Wooden Arrows into Hellfire Arrows");
		}

		public override void SetDefaults()
		{
			Item.damage = 68;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 48;
			Item.height = 22;
			Item.useTime = 17;
			Item.useAnimation = 17;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 5;
			Item.value = Item.sellPrice(gold: 2);
			Item.rare = ItemRarityID.Yellow;
			Item.UseSound = SoundID.Item5;
			Item.autoReuse = true;
			Item.shoot = 10;
			Item.shootSpeed = 28f;
			Item.useAmmo = AmmoID.Arrow;
			Item.crit = 5;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ItemID.HallowedRepeater)
			.AddIngredient(ModContent.ItemType<Blight2>(), 5)
			.AddIngredient(ItemID.Ectoplasm, 3)
			.AddTile(134)
			.Register();
		}

		public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
		{
			if (type == ProjectileID.WoodenArrowFriendly)
			{
				type = ProjectileID.HellfireArrow;
			}
		}
	}
}
