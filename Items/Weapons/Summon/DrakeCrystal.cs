using MultidimensionMod.Buffs.Minions;
using MultidimensionMod.Projectiles.Summon.Minions;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Summon
{
	public class DrakeCrystal : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Drake Crystal");
			Tooltip.SetDefault("I still have nightmares from the icy caves...\nSummons a tame juvenile Ice Drake to fight for you.");
			ItemID.Sets.GamepadWholeScreenUseRange[Item.type] = true;
			ItemID.Sets.LockOnIgnoresCollision[Item.type] = true;
		}

		public override void SetDefaults()
		{
			Item.damage = 16;
			Item.DamageType = DamageClass.Summon;
			Item.knockBack = 1f;
			Item.mana = 10;
			Item.width = 22;
			Item.height = 24;
			Item.useTime = 36;
			Item.useAnimation = 36;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.value = Item.sellPrice(silver: 10);
			Item.rare = ItemRarityID.Green;
			Item.UseSound = SoundID.NPCHit51;
			Item.autoReuse = true;
			Item.noMelee = true;
			Item.buffType = ModContent.BuffType<DrakeBuff>();
			Item.shoot = ModContent.ProjectileType<IceDrakeOfDOOM>();
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
	}
}