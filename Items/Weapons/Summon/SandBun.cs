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
	public class SandBun : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sand Bun");
			Tooltip.SetDefault("People always talk about Sand Cake, but what about Sand Buns?\nSummons a Lesser Sand Elemental to fight for you.\nYeah idk either how they would eat these.");
			DisplayName.AddTranslation(GameCulture.German, "Sand Brötchen");
			Tooltip.AddTranslation(GameCulture.German, "Leute reden immer von Sandkuchen, aber was ist mit Sand Brötchen?\nBeschwört einen Niederen Sand Elementar um für dich zu kämpfen.\nJa, kein Plan wie die das essen würden.");
			ItemID.Sets.GamepadWholeScreenUseRange[item.type] = true;
			ItemID.Sets.LockOnIgnoresCollision[item.type] = true;
		}

		public override void SetDefaults()
		{
			item.damage = 21;
			item.summon = true;
			item.knockBack = 1f;
			item.mana = 10;
			item.width = 20;
			item.height = 14;
			item.useTime = 36;
			item.useAnimation = 36;
			item.useStyle = ItemUseStyleID.HoldingUp;
			item.value = Item.sellPrice(silver: 10);
			item.rare = ItemRarityID.Green;
			item.UseSound = SoundID.NPCHit23;
			item.autoReuse = true;
			item.noMelee = true;
			item.buffType = ModContent.BuffType<SandEleBuff>();
			item.shoot = ModContent.ProjectileType<FlyingSand>();
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			player.AddBuff(item.buffType, 2);

			position = Main.MouseWorld;
			return true;
		}
	}
}