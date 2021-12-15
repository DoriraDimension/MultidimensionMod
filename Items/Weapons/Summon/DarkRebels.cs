using MultidimensionMod.Buffs.Minions;
using MultidimensionMod.Projectiles.Minions;
using MultidimensionMod.Items.Materials;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Summon
{
	public class DarkRebels : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dark Rebels");
			Tooltip.SetDefault("Summons one of Smiley's trusted soldiers to fight for you.");
			DisplayName.AddTranslation(GameCulture.German, "Dunkle Rebellen");
			Tooltip.AddTranslation(GameCulture.German, "Beschwört einen von Smiley's vertrauten Soldaten um für dich zu kämpfen.");
			ItemID.Sets.GamepadWholeScreenUseRange[item.type] = true;
			ItemID.Sets.LockOnIgnoresCollision[item.type] = true;
		}

		public override void SetDefaults()
		{
			item.damage = 32;
			item.summon = true;
			item.knockBack = 1f;
			item.mana = 10;
			item.width = 58;
			item.height = 54;
			item.useTime = 36;
			item.useAnimation = 36;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.value = Item.sellPrice(silver: 10);
			item.rare = ItemRarityID.LightRed;
			item.UseSound = SoundID.NPCHit54;
			item.noMelee = true;
			item.buffType = ModContent.BuffType<DarkRebelsBuff>();
			item.shoot = ModContent.ProjectileType<DarkRebelsMinion>();
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			player.AddBuff(item.buffType, 2);

			position = Main.MouseWorld;
			return true;
		}
	}
}