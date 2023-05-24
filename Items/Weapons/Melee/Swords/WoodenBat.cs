using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace MultidimensionMod.Items.Weapons.Melee.Swords
{
	public class WoodenBat : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.damage = 10;
			Item.DamageType = DamageClass.Melee;
			Item.width = 52;
			Item.height = 52;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.useTime = 30;
			Item.useAnimation = 30;
			Item.knockBack = 4;
			Item.value = Item.buyPrice(0, 0, 0, 5);
			Item.rare = ItemRarityID.White;
			Item.UseSound = SoundID.Item1;

		}

		public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
		{
			if (Main.rand.NextFloat() < .1500f)
				target.AddBuff(BuffID.Confused, 180);
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddRecipeGroup("Wood", 50)
			.AddTile(TileID.WorkBenches)
			.Register();
		}
	}
}