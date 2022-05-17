using MultidimensionMod.Items.Materials;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Melee.Swords
{
	public class SheolSaber : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sheol Saber");
			Tooltip.SetDefault("A saber that was restored from old relics, it shoots demonic projectiles.");
		}

		public override void SetDefaults()
		{
			Item.damage = 65;
			Item.DamageType = DamageClass.Melee;
			Item.width = 60;
			Item.height = 68;
			Item.useTime = 18;
			Item.useAnimation = 18;
			Item.useStyle = 1;
			Item.knockBack = 4;
			Item.autoReuse = true;
			Item.value = Item.sellPrice(gold: 1);
			Item.rare = ItemRarityID.Pink;
			Item.UseSound = SoundID.Item1;
			Item.shoot = ProjectileID.DemonScythe;
			Item.shootSpeed = 8f;
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
			CreateRecipe()
			.AddIngredient(ItemID.DemoniteBar, 20)
			.AddIngredient(ItemID.SoulofNight, 5)
			.AddIngredient(ModContent.ItemType<Blight2>())
			.AddTile(134)
			.Register();
		}
	}
}