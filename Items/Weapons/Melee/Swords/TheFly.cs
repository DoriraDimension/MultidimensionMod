using MultidimensionMod.Projectiles.Melee.Swords;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace MultidimensionMod.Items.Weapons.Melee.Swords
{
	public class TheFly : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.damage = 18;
			Item.DamageType = DamageClass.Melee;
			Item.width = 38;
			Item.height = 38;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.useTime = 70;
			Item.useAnimation = 33;
			Item.value = Item.sellPrice(0, 1, 0, 0);
			Item.rare = ItemRarityID.Green;
			Item.autoReuse = true;
			Item.knockBack = 3f;
			Item.UseSound = SoundID.Item1;
			Item.shoot = ModContent.ProjectileType<DecayFlyFriendly>();
			Item.shootSpeed = 13f;

		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ItemID.IronBroadsword)
			.AddIngredient(ItemID.ShadowScale, 5)
			.AddTile(TileID.Anvils)
			.Register();

			CreateRecipe()
           .AddIngredient(ItemID.LeadBroadsword)
           .AddIngredient(ItemID.ShadowScale, 5)
           .AddTile(TileID.Anvils)
           .Register();
		}
	}
}