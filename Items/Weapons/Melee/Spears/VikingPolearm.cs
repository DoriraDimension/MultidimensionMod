using MultidimensionMod.Projectiles.Melee.Spears;
using MultidimensionMod.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Melee.Spears
{
	public class VikingPolearm : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Viking Drakeslayer");
			Tooltip.SetDefault("Inflicts Drakeblood Poison");
		}

		public override void SetDefaults()
		{
			Item.damage = 14;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useAnimation = 28;
			Item.useTime = 28;
			Item.shootSpeed = 1.6f;
			Item.knockBack = 7f;
			Item.width = 46;
			Item.height = 46;
			Item.rare = ItemRarityID.Blue;
			Item.value = Item.sellPrice(silver: 15);
			Item.DamageType = DamageClass.Melee;
			Item.noMelee = true;
			Item.noUseGraphic = true;
			Item.autoReuse = true;
			Item.UseSound = SoundID.Item1;
			Item.shoot = ModContent.ProjectileType<VikingPolearmProj>();
		}

		public override bool CanUseItem(Player player)
		{
			return player.ownedProjectileCounts[Item.shoot] < 1;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ModContent.ItemType<VikingRelic>(), 6)
			.AddIngredient(ItemID.BorealWood, 12)
			.AddTile(TileID.Anvils)
			.Register();
		}
	}
}
