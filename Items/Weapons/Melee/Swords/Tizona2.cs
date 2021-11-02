using MultidimensionMod.Items.Materials;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Melee.Swords
{
	public class Tizona2 : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Lost Gen Blade, Zona");
			Tooltip.SetDefault("A long lost blade, forgotten in ancient times. \nCauses Bleeding");
			DisplayName.AddTranslation(GameCulture.German, "Verlorene Klinge, Zona");
			Tooltip.AddTranslation(GameCulture.German, "Eine lang verlorene Klinge, vergessen in uralten Zeiten. \nVerursacht Blutungen");
		}

		public override void SetDefaults()
		{
			item.damage = 84;
			item.melee = true;
			item.width = 54;
			item.height = 54;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.useTime = 16;
			item.useAnimation = 16;
			item.knockBack = 5;
			item.value = Item.buyPrice(gold: 6);
			item.rare = ItemRarityID.Yellow;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.crit = 5;

		}

		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.NextBool(3))
			{
				Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, (5));
			}
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Excalibur);
			recipe.AddIngredient(ModContent.ItemType<Blight2>(), 10);
			recipe.AddIngredient(ItemID.Ectoplasm, 5);
			recipe.AddTile(134);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(BuffID.Bleeding, 600);
		}
	}
}