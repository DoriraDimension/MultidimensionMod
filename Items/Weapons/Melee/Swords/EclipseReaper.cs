using MultidimensionMod.Projectiles.Melee.Swords;
using MultidimensionMod.Items.Materials;
using MultidimensionMod.Tiles;
using MultidimensionMod.Buffs.Debuffs;
using MultidimensionMod.Rarities;
using Terraria.GameContent.Creative;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Melee.Swords
{
	public class EclipseReaper : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.damage = 62;
			Item.DamageType = DamageClass.Melee;
			Item.width = 72;
			Item.height = 56;
			Item.useTime = 47;
			Item.useAnimation = 47;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 6;
			Item.autoReuse = true;
			Item.value = Item.sellPrice(0, 5, 0, 0);
			Item.rare = ModContent.RarityType<AseGneblessaArtifact>();
			Item.UseSound = SoundID.Item71;
			Item.crit = 10;
			Item.shoot = ModContent.ProjectileType<HiddenSunScythe>();
			Item.shootSpeed = 9f;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ItemID.DeathSickle)
			.AddIngredient(ModContent.ItemType<DarkMatterClump>(), 16)
			.AddIngredient(ModContent.ItemType<MadnessFragment>(), 10)
			.AddIngredient(ItemID.Ectoplasm, 6)
			.AddIngredient(ModContent.ItemType<Blight2>())
			.AddIngredient(ModContent.ItemType<Dimensium>(), 17)
			.AddTile(ModContent.TileType<DimensionalForge>())
			.Register();
		}

		public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.AddBuff(ModContent.BuffType<Madness>(), 240);
			target.GetGlobalNPC<MDGlobalNPC>().MadnessCringe = 50;
        }
	}
}