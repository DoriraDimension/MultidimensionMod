using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Ranged.Guns
{
	public class DeltaShark : ModItem
	{
		public override void SetStaticDefaults() 
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults() {
			Item.damage = 34;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 80;
			Item.height = 36; 
			Item.useTime = 5; 
			Item.useAnimation = 5; 
			Item.useStyle = ItemUseStyleID.Shoot; 
			Item.noMelee = true; 
			Item.knockBack = 2;
			Item.value = Item.sellPrice(0, 5, 0, 0);
			Item.rare = ItemRarityID.Cyan;
			Item.UseSound = SoundID.Item11; 
			Item.autoReuse = true;
			Item.shoot = ProjectileID.PurificationPowder;
			Item.shootSpeed = 10f; 
			Item.useAmmo = AmmoID.Bullet;
			Item.crit = 12;
		}

		public override void AddRecipes() {
			CreateRecipe()
			.AddIngredient(ItemID.Megashark)
			.AddIngredient(ItemID.FragmentVortex, 15)
			.AddTile(TileID.LunarCraftingStation)
			.Register();
		}

		public override bool CanConsumeAmmo(Item ammo, Player player)
		{
			return Main.rand.NextFloat() >= .65f;
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(0, -6);
		}

		public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
		{
			if (Main.rand.NextBool(4))
            {
                type = ProjectileID.NanoBullet;
            }
		}
	}
}
