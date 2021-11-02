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
			item.damage = 27;
			item.knockBack = 3f;
			item.mana = 10;
			item.width = 58;
			item.height = 54;
			item.useTime = 36;
			item.useAnimation = 36;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.value = Item.sellPrice(silver: 10);
			item.rare = ItemRarityID.LightRed;
			item.UseSound = SoundID.Item34;

			item.noMelee = true;
			item.summon = true;
			item.buffType = ModContent.BuffType<DarkRebelsBuff>();
			item.shoot = ModContent.ProjectileType<DarkRebelsMinion>();
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			player.AddBuff(item.buffType, 2);

			position = Main.MouseWorld;
			return true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<DarkMatterClump>(), 15);
			recipe.AddTile(26);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}