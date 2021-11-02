using System.Collections.Generic;
using MultidimensionMod.Items.Materials;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Melee.Swords
{
	public class SheolSaber : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sheol Saber");
			Tooltip.SetDefault("A saber that was restored from old relics, it shoots demonic projectiles.");
			DisplayName.AddTranslation(GameCulture.German, "Sheol Säbel");
			Tooltip.AddTranslation(GameCulture.German, "Ein Säbel der aus alten Relikten restauriert wurde, es schießt dämonische Projektile.");
		}

		public override void SetDefaults()
		{
			item.damage = 65;
			item.melee = true;
			item.width = 60;
			item.height = 68;
			item.useTime = 18;
			item.useAnimation = 18;
			item.useStyle = 1;
			item.knockBack = 4;
			item.autoReuse = true;
			item.value = Item.sellPrice(gold: 1);
			item.rare = ItemRarityID.Pink;
			item.UseSound = SoundID.Item1;
			item.shoot = ProjectileID.DemonScythe;
			item.shootSpeed = 8f;
		}

		public override void ModifyTooltips(List<TooltipLine> list)
		{
			foreach (TooltipLine item in list)
			{
				if (item.mod == "Terraria" && item.Name == "ItemName")
				{
					item.overrideColor = MDRarity.RelicWeapon;
				}
			}
		}

		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.NextBool(3))
			{
				Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, (27));
			}
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<OldMoltenBlade>());
			recipe.AddIngredient(ModContent.ItemType<OldMoltenGuard>());
			recipe.AddIngredient(ItemID.DemoniteBar, 20);
			recipe.AddIngredient(ModContent.ItemType<Blight2>());
			recipe.AddTile(377);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}