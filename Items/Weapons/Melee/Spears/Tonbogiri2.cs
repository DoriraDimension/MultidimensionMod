using MultidimensionMod.Projectiles.Melee.Spears;
using MultidimensionMod.Items.Materials;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Melee.Spears
{
	public class Tonbogiri2 : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Lost Gen Spear, Bogiri");
			Tooltip.SetDefault("A long lost spear, forgotten in ancient times.\nIt's venom coating inflicts the venom debuff on hit.");
		}

		public override void SetDefaults()
		{
			Item.damage = 70;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useAnimation = 16;
			Item.useTime = 25;
			Item.shootSpeed = 4.5f;
			Item.knockBack = 6.5f;
			Item.crit = 6;
			Item.width = 70;
			Item.height = 70;
			Item.scale = 1f;
			Item.rare = ItemRarityID.Yellow;
			Item.value = Item.sellPrice(gold: 1);
			Item.DamageType = DamageClass.Melee;
			Item.noMelee = true;
			Item.noUseGraphic = true;
			Item.autoReuse = true;
			Item.UseSound = SoundID.Item1;
			Item.shoot = ModContent.ProjectileType<Tonbogiri2Proj>();
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
			return player.ownedProjectileCounts[Item.shoot] < 1;
		}
		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ItemID.Gungnir)
			.AddIngredient(ModContent.ItemType<Blight2>(), 10)
			.AddIngredient(ItemID.Ectoplasm, 5)
			.AddTile(134)
			.Register();
		}
	}
}
