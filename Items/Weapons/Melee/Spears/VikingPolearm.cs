using MultidimensionMod.Projectiles.Melee.Spears;
using MultidimensionMod.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace MultidimensionMod.Items.Weapons.Melee.Spears
{
	public class VikingPolearm : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.damage = 14;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useAnimation = 40;
			Item.useTime = 40;
			Item.shootSpeed = 1.6f;
			Item.knockBack = 7f;
			Item.width = 46;
			Item.height = 46;
			Item.rare = ItemRarityID.Blue;
			Item.value = Item.sellPrice(0, 0, 50, 0);
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
