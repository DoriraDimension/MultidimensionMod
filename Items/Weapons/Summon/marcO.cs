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
	public class marcO : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Lost Gen Servants, Blight");
			Tooltip.SetDefault("A long time ago a flying creepy creature roamed the night, with it's servants by it's side.\nBut one day it dissapeared and only left behind this gift.\nSummons the forgotten servant of the blighted crawler.");
			DisplayName.AddTranslation(GameCulture.German, "Verlorene Diener, Blight");
			Tooltip.AddTranslation(GameCulture.German, "Vor langer Zeit, eine fliegene gruselige Kreatur streifte durch die Nacht, mit seinen Diener an seiner Seite.\nAber eines Tages verschwand es und hinterlies dieses Geschenk.\nBeschwört den vergessenen Diener der Fäulnis");
			ItemID.Sets.GamepadWholeScreenUseRange[item.type] = true;
			ItemID.Sets.LockOnIgnoresCollision[item.type] = true;
		}

		public override void SetDefaults()
		{
			item.damage = 67;
			item.summon = true;
			item.knockBack = 1f;
			item.mana = 10;
			item.width = 20;
			item.height = 14;
			item.useTime = 36;
			item.useAnimation = 36;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.value = Item.sellPrice(silver: 10);
			item.rare = ItemRarityID.Green;
			item.UseSound = SoundID.NPCHit23;
			item.autoReuse = true;
			item.noMelee = true;
			item.buffType = ModContent.BuffType<OcramServantBuff>();
			item.shoot = ModContent.ProjectileType<ServantofOcram2>();
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
			recipe.AddIngredient(ModContent.ItemType<Blight2>(), 10);
			recipe.AddIngredient(ItemID.Ectoplasm, 5);
			recipe.AddTile(134);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}