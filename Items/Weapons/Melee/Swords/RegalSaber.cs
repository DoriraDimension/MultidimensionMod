using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace MultidimensionMod.Items.Weapons.Melee.Swords
{
	public class RegalSaber : ModItem
	{
		public int Grow = 0;
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.damage = 11;
			Item.DamageType = DamageClass.Melee;
			Item.width = 40;
			Item.height = 50;
			Item.useTime = 15;
			Item.useAnimation = 15;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 2;
			Item.autoReuse = true;
			Item.value = Item.sellPrice(0, 0, 70, 0);
			Item.rare = ItemRarityID.Green;
			Item.UseSound = SoundID.Item1;
			Item.crit = 31;
		}

		public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
		{
			target.AddBuff(137, 480);
		}

		public override bool? UseItem(Player player)
		{
			Grow += 1;
			if (Grow == 1)
            {
				Item.scale = 1.5f;
				Item.damage = 13;
            }
			if (Grow == 2)
            {
				Item.scale = 2f;
				Item.damage = 15;
            }
			if (Grow == 3)
            {
				Item.scale = 3f;
				Item.damage = 17;
            }
			if (Grow >= 4)
			{
				Item.damage = 11;
				Item.scale = 1f;
				Grow = 0;
			}
			return true;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ItemID.Gel, 56)
			.AddRecipeGroup(Recipes.GoldPlatinum, 12)
			.AddTile(TileID.Solidifier)
			.Register();
		}
	}
}