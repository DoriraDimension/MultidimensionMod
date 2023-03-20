using MultidimensionMod.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Melee.Swords
{
	public class CursedDesert : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Cursed Desert");
			// Tooltip.SetDefault("A sword forged in the dark caves of the desert by a long shattered cult, it slows down enemies on hit for 2 seconds.");
		}

		public override void SetDefaults()
		{
			Item.damage = 23;
			Item.DamageType = DamageClass.Melee;
			Item.width = 46;
			Item.height = 46;
			Item.useTime = 25;
			Item.useAnimation = 25;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 3;
			Item.autoReuse = true;
			Item.value = Item.sellPrice(silver: 17);
			Item.rare = ItemRarityID.Green;
			Item.UseSound = SoundID.Item1;
			Item.crit = 1;
		}

		public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
		{
			target.AddBuff(BuffID.Slow, 120);
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ItemID.Amber, 5)
			.AddIngredient(ItemID.Deathweed, 2)
			.AddIngredient(ModContent.ItemType<ManaInfusedSandstone>(), 4)
			.AddTile(16)
			.Register();
		}
	}
}