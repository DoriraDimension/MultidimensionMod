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
	public class DrakeCrystal : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Drake Crystal");
			Tooltip.SetDefault("I still have nightmares from the icy caves...\nSummons a tame juvenile Ice Drake to fight for you.");
			DisplayName.AddTranslation(GameCulture.German, "Drakenkristall");
			Tooltip.AddTranslation(GameCulture.German, "Ich hab immer noch Alpträume von den eisigen Höhlen...\nBeschwört ein zahmes Eis Draken Jungtier um für dich zu kämpfen.");
			ItemID.Sets.GamepadWholeScreenUseRange[item.type] = true;
			ItemID.Sets.LockOnIgnoresCollision[item.type] = true;
		}

		public override void SetDefaults()
		{
			item.damage = 16;
			item.summon = true;
			item.knockBack = 1f;
			item.mana = 10;
			item.width = 22;
			item.height = 24;
			item.useTime = 36;
			item.useAnimation = 36;
			item.useStyle = ItemUseStyleID.HoldingUp;
			item.value = Item.sellPrice(silver: 10);
			item.rare = ItemRarityID.Green;
			item.UseSound = SoundID.NPCHit51;
			item.autoReuse = true;
			item.noMelee = true;
			item.buffType = ModContent.BuffType<DrakeBuff>();
			item.shoot = ModContent.ProjectileType<IceDrakeOfDOOM>();
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			player.AddBuff(item.buffType, 2);

			position = Main.MouseWorld;
			return true;
		}
	}
}