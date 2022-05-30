using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Ranged.Guns
{
	public class ImpulseSniperRifle : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Impulse Sniper Rifle");
			Tooltip.SetDefault("[c/00EAFF:'How did this become top seller?']\nTurns bullets into a fast piercing laser impulse");
			// just a disclaimer how I have done that, you can also use [i: <Itemid> ] for Item displaying
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-19,2); // so that eye is on the scope
		}

		public override void SetDefaults()
		{
			Item.damage = 203;
			Item.crit = 31; // 35% total
			Item.DamageType = DamageClass.Ranged; // a gun
			Item.noMelee = true; // turning off hitbox damage
			Item.width = 120;
			Item.height = 32;
			Item.autoReuse = true; // autouse on
			Item.useTime = 40; // slower than sniper rifle
			Item.useAnimation = 40;
			Item.useStyle = 5;
			Item.knockBack = 11.5f; // insane
			Item.value = Item.sellPrice(gold: 8);
			Item.rare = ItemRarityID.Cyan;
			Item.UseSound = SoundID.Item115;
			Item.useAmmo = AmmoID.Bullet;
			Item.shoot = ProjectileID.MoonlordBullet; // luminite bullet, laser was scraped
			Item.shootSpeed = 32.5f;
		}

		public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
		{
			type = 638; // turning any bullet into luminite bullet
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ItemID.SniperRifle, 1) // 1 sniper rifle
			.AddIngredient(ItemID.Nanites, 24) // 24 nanites
			.AddIngredient(ItemID.SpectreBar, 10) // 10 spectre bars
			.AddIngredient(ItemID.ShroomiteBar, 12) // 12 shroomite bars
			.AddTile(412) 
			.Register();
		}
	}
}