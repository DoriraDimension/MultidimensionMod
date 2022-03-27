using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Ranged.Guns
{
	public class DeltaShark : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Delta Shark");
			Tooltip.SetDefault("65% chance to not consume ammo.\nA small juvenile robotic shark, watch out for his parents.");
			DisplayName.AddTranslation(GameCulture.German, "Delta Hai");
			Tooltip.AddTranslation(GameCulture.German, "65% Chance keine Munition zu verbrauchen. \nEin kleines robotisches Hai Jungtier, pass auf seine Eltern auf.");
		}

		public override void SetDefaults() {
			item.damage = 53;
			item.ranged = true; 
			item.width = 80;
			item.height = 36; 
			item.useTime = 5; 
			item.useAnimation = 5; 
			item.useStyle = ItemUseStyleID.HoldingOut; 
			item.noMelee = true; 
			item.knockBack = 2;
			item.value = Item.sellPrice(gold: 2);
			item.rare = ItemRarityID.Cyan;
			item.UseSound = SoundID.Item11; 
			item.autoReuse = true;
			item.shoot = 20;
			item.shootSpeed = 10f; 
			item.useAmmo = AmmoID.Bullet;
			item.crit = 12;
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Megashark);
			recipe.AddIngredient(ItemID.FragmentVortex, 15);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

		public override bool ConsumeAmmo(Player player)
		{
			return Main.rand.NextFloat() >= .65f;
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(0, -6);
		}
	}
}
