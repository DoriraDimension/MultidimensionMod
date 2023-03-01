using MultidimensionMod.Items.Materials;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Melee.Swords
{
	public class DormantKing : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Dormant King");
			// Tooltip.SetDefault("A blade forged by a long shattered cult who worshipped a unknown deity, it slows enemies down for 5 seconds.");
		}

		public override void SetDefaults()
		{
			Item.damage = 56;
			Item.DamageType = DamageClass.Melee;
			Item.width = 46;
			Item.height = 46;
			Item.useTime = 19;
			Item.useAnimation = 19;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 4;
			Item.autoReuse = true;
			Item.value = Item.sellPrice(silver: 84);
			Item.rare = ItemRarityID.LightRed;
			Item.UseSound = SoundID.Item1;
			Item.crit = 1;
		}

		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, (27));
		}

		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(BuffID.Slow, 320);
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ModContent.ItemType<CursedDesert>())
			.AddIngredient(ItemID.AncientBattleArmorMaterial)
			.AddRecipeGroup("AdamantiteBars", 5)
			.AddTile(134)
			.Register();
		}
	}
}