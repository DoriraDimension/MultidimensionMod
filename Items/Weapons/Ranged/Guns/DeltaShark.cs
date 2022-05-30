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
		}

		public override void SetDefaults() {
			Item.damage = 34;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 80;
			Item.height = 36; 
			Item.useTime = 5; 
			Item.useAnimation = 5; 
			Item.useStyle = ItemUseStyleID.Shoot; 
			Item.noMelee = true; 
			Item.knockBack = 2;
			Item.value = Item.sellPrice(gold: 2);
			Item.rare = ItemRarityID.Cyan;
			Item.UseSound = SoundID.Item11; 
			Item.autoReuse = true;
			Item.shoot = 20;
			Item.shootSpeed = 10f; 
			Item.useAmmo = AmmoID.Bullet;
			Item.crit = 12;
		}

		public override void AddRecipes() {
			CreateRecipe()
			.AddIngredient(ItemID.Megashark)
			.AddIngredient(ItemID.FragmentVortex, 15)
			.AddTile(TileID.LunarCraftingStation)
			.Register();
		}

		public override bool CanConsumeAmmo(Item ammo, Player player)
		{
			return Main.rand.NextFloat() >= .65f;
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(0, -6);
		}
	}
}
