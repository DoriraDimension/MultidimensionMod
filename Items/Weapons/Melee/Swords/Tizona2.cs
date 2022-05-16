using MultidimensionMod.Items.Materials;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Melee.Swords
{
	public class Tizona2 : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Lost Gen Blade, Zona");
			Tooltip.SetDefault("A long lost blade, forgotten in ancient times. \nCauses Bleeding");
		}

		public override void SetDefaults()
		{
			Item.damage = 84;
			Item.DamageType = DamageClass.Melee;
			Item.width = 54;
			Item.height = 54;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.useTime = 16;
			Item.useAnimation = 16;
			Item.knockBack = 5;
			Item.value = Item.buyPrice(gold: 6);
			Item.rare = ItemRarityID.Yellow;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.crit = 5;

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
			CreateRecipe()
			.AddIngredient(ItemID.Excalibur)
			.AddIngredient(ModContent.ItemType<Blight2>(), 5)
			.AddIngredient(ItemID.Ectoplasm, 3)
			.AddTile(134)
			.Register();
		}

		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(BuffID.Bleeding, 600);
		}
	}
}