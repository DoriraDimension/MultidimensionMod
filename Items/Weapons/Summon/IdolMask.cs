using MultidimensionMod.Buffs.Minions;
using MultidimensionMod.Items.Souls;
using MultidimensionMod.Projectiles.Summon.Minions;
using MultidimensionMod.Items.Materials;
using MultidimensionMod.Tiles;
using MultidimensionMod.Rarities;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Summon
{
	public class IdolMask : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Mask of the Idol");
			// Tooltip.SetDefault("mask that is funny clay man");
			ItemID.Sets.GamepadWholeScreenUseRange[Item.type] = true;
			ItemID.Sets.LockOnIgnoresCollision[Item.type] = true;
		}

		public override void SetDefaults()
		{
			Item.damage = 80;
			Item.DamageType = DamageClass.Summon;
			Item.knockBack = 1f;
			Item.mana = 10;
			Item.width = 30;
			Item.height = 32;
			Item.useTime = 36;
			Item.useAnimation = 36;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.value = Item.sellPrice(gold: 4);
			Item.rare = ItemRarityID.Lime;
			Item.UseSound = SoundID.Item97;
			Item.noMelee = true;
			Item.buffType = ModContent.BuffType<MaskBuff>();
			Item.shoot = ModContent.ProjectileType<GolemMask>();
		}

		public override bool CanUseItem(Player player)
        {
			return player.ownedProjectileCounts[Item.shoot] < 1;
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
			position = player.Center;
		}
	}
}