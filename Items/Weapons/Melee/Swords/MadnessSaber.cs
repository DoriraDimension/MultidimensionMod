using MultidimensionMod.Items.Materials;
using MultidimensionMod.Buffs.Debuffs;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Melee.Swords
{
	public class MadnessSaber : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mindslicing Madness");
			Tooltip.SetDefault("A blade made from the flesh of creatures that attampted ascension\nInflicts madness on hit");
		}

		public override void SetDefaults()
		{
			Item.damage = 19;
			Item.DamageType = DamageClass.Melee;
			Item.width = 42;
			Item.height = 50;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.useTime = 34;
			Item.useAnimation = 34;
			Item.knockBack = 5;
			Item.value = Item.buyPrice(silver: 23);
			Item.rare = ItemRarityID.Green;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;

		}

		public override void MeleeEffects(Player player, Rectangle hitbox)
		{

		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ModContent.ItemType<MadnessFragment>(), 12)
			.AddTile(134)
			.Register();
		}

		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(ModContent.BuffType<Madness>(), 600);
		}
	}
}