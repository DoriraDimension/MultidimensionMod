using MultidimensionMod.Projectiles.Melee.Swords;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Melee.Swords
{
	public class LonelySword : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Lonely Sword");
			// Tooltip.SetDefault("A sword of a dark warrior that was given to Smiley after said warroir fell in battle.\nIt shoots a dark orb straight from 1995.");
		}

		public override void SetDefaults()
		{
			Item.damage = 32;
			Item.DamageType = DamageClass.Melee;
			Item.width = 46;
			Item.height = 54;
			Item.useTime = 23;
			Item.useAnimation = 23;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 4;
			Item.autoReuse = true;
			Item.value = Item.sellPrice(gold: 1);
			Item.rare = ItemRarityID.LightRed;
			Item.UseSound = SoundID.Item1;
			Item.shoot = ModContent.ProjectileType<OGMatterBall>();
			Item.shootSpeed = 8f;
		}
	}
}