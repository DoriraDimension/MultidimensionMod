using MultidimensionMod.Projectiles.Spears;
using MultidimensionMod.Items.Materials;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Melee.Spears
{
	public class Tonbogiri2 : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Lost Gen Spear, Bogiri");
			Tooltip.SetDefault("A long lost spear, forgotten in ancient times.\nIt's venom coating inflicts the venom debuff on hit.");
			DisplayName.AddTranslation(GameCulture.German, "Verlorener Speer, Bogiri");
			Tooltip.AddTranslation(GameCulture.German, "Ein lang verlorener Speer, vergessen in uralten Zeiten. \nSeine Toxikum beschichtung verursacht den Toxikum debuff.");
		}

		public override void SetDefaults()
		{
			item.damage = 70;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.useAnimation = 16;
			item.useTime = 25;
			item.shootSpeed = 4.5f;
			item.knockBack = 6.5f;
			item.crit = 6;
			item.width = 70;
			item.height = 70;
			item.scale = 1f;
			item.rare = ItemRarityID.Yellow;
			item.value = Item.sellPrice(gold: 4);
			item.melee = true;
			item.noMelee = true;
			item.noUseGraphic = true;
			item.autoReuse = true;
			item.UseSound = SoundID.Item1;
			item.shoot = ModContent.ProjectileType<Tonbogiri2Proj>();
		}

		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.NextBool(3))
			{
				Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, (256));
			}
		}

		public override bool CanUseItem(Player player)
		{
			return player.ownedProjectileCounts[item.shoot] < 1;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Gungnir);
			recipe.AddIngredient(ModContent.ItemType<Blight2>(), 10);
			recipe.AddIngredient(ItemID.Ectoplasm, 5);
			recipe.AddTile(134);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
