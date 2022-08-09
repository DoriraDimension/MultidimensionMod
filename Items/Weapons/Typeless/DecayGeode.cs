using MultidimensionMod.Projectiles.Typeless;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Typeless
{
	public class DecayGeode : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Decay Geode");
			Tooltip.SetDefault("A geode found in the Corruption.\nA blacksmith can break this open for you, sadly, there is none.\nRight click to recieve Corruption minerals.");
		}

		public override void SetDefaults()
		{
			Item.damage = 31;
			Item.width = 24;
			Item.height = 20;
			Item.rare = ItemRarityID.Green;
			Item.maxStack = 9999;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.DamageType = DamageClass.Generic;
			Item.useTime = 30;
			Item.useAnimation = 30;
			Item.noMelee = true;
			Item.consumable = true;
			Item.knockBack = 2;
			Item.noUseGraphic = true;
			Item.UseSound = SoundID.Item1;
			Item.shoot = ModContent.ProjectileType<DecayGeodeThrown>();
			Item.shootSpeed = 14f;
		}
	}
}