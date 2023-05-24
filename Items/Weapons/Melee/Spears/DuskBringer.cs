using MultidimensionMod.Projectiles.Melee.Spears;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace MultidimensionMod.Items.Weapons.Melee.Spears
{
	public class DuskBringer : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.damage = 34;
			Item.DamageType = DamageClass.Melee;
			Item.useAnimation = 24;
			Item.useTime = 24;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 7f;
			Item.width = 54;
			Item.height = 56;
			Item.rare = ItemRarityID.Blue;
			Item.value = Item.sellPrice(0, 1, 0, 0);
			Item.noMelee = true;
			Item.noUseGraphic = true;
			Item.autoReuse = true;
			Item.UseSound = SoundID.Item1;
			Item.shoot = ModContent.ProjectileType<DuskBringerProj>();
			Item.shootSpeed = 4.4f;
		}

		public override bool CanUseItem(Player player)
		{
			return player.ownedProjectileCounts[Item.shoot] < 1;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ItemID.TheRottedFork)
			.AddIngredient(ItemID.DarkLance)
			.AddIngredient(ModContent.ItemType<GrassSpear>())
			.AddIngredient(ModContent.ItemType<MoltenLance>())
			.AddTile(TileID.Anvils)
			.Register();

			CreateRecipe()
			.AddIngredient(ModContent.ItemType<Soulpiercer>())
			.AddIngredient(ItemID.DarkLance)
			.AddIngredient(ModContent.ItemType<GrassSpear>())
			.AddIngredient(ModContent.ItemType<MoltenLance>())
			.AddTile(TileID.Anvils)
			.Register();
		}
	}
}
