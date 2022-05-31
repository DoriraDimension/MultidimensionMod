using MultidimensionMod.Buffs.Minions;
using MultidimensionMod.Projectiles.Summon.Minions;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Summon
{
	public class DarkRebels : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dark Rebels");
			Tooltip.SetDefault("Summons one of Smiley's trusted soldiers to fight for you.\nThe Darklings who hide in the dungeon are ready to fight whenever they get called to battle.");
			ItemID.Sets.GamepadWholeScreenUseRange[Item.type] = true;
			ItemID.Sets.LockOnIgnoresCollision[Item.type] = true;
		}

		public override void SetDefaults()
		{
			Item.damage = 32;
			Item.DamageType = DamageClass.Summon;
			Item.knockBack = 1f;
			Item.mana = 10;
			Item.width = 40;
			Item.height = 38;
			Item.useTime = 36;
			Item.useAnimation = 36;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.value = Item.sellPrice(silver: 10);
			Item.rare = ItemRarityID.LightRed;
			Item.UseSound = SoundID.NPCHit54;
			Item.noMelee = true;
			Item.buffType = ModContent.BuffType<DarkRebelsBuff>();
			Item.shoot = ModContent.ProjectileType<DarkRebelsMinion>();
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			player.AddBuff(Item.buffType, 2);
			var projectile = Projectile.NewProjectileDirect(source, position, velocity, type, damage, knockback, Main.myPlayer);
			projectile.originalDamage = Item.damage;
			return false;
		}

		public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
		{
			position = Main.MouseWorld;
		}
	}
}