using MultidimensionMod.Buffs.Minions;
using MultidimensionMod.Projectiles.Summon.Minions;
using MultidimensionMod.Items.Materials;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Summon
{
	public class marcO : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Lost Gen Servants, Blight");
			Tooltip.SetDefault("A long time ago a flying creepy creature roamed the night, with it's servants by it's side.\nBut one day it dissapeared and only left behind this gift.\nSummons the forgotten servant of the blighted crawler.");
			ItemID.Sets.GamepadWholeScreenUseRange[Item.type] = true;
			ItemID.Sets.LockOnIgnoresCollision[Item.type] = true;
		}

		public override void SetDefaults()
		{
			Item.damage = 67;
			Item.DamageType = DamageClass.Summon;
			Item.knockBack = 1f;
			Item.mana = 10;
			Item.width = 20;
			Item.height = 14;
			Item.useTime = 36;
			Item.useAnimation = 36;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.value = Item.sellPrice(silver: 10);
			Item.rare = ItemRarityID.Yellow;
			Item.UseSound = SoundID.NPCHit23;
			Item.autoReuse = true;
			Item.noMelee = true;
			Item.buffType = ModContent.BuffType<OcramServantBuff>();
			Item.shoot = ModContent.ProjectileType<ServantofOcram2>();
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			player.AddBuff(Item.buffType, 2);

			position = Main.MouseWorld;
			var projectile = Projectile.NewProjectileDirect(source, position, velocity, type, damage, knockback, Main.myPlayer);
			projectile.originalDamage = Item.damage;
			return false;
		}

		public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
		{
			position = Main.MouseWorld;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ModContent.ItemType<Blight2>(), 5)
			.AddIngredient(ItemID.Ectoplasm, 3)
			.AddTile(134)
			.Register();
		}
	}
}