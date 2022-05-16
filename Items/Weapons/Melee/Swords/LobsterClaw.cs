using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Melee.Swords
{
	public class LobsterClaw : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Lobster Claw");
			Tooltip.SetDefault("The claw of a Parrot Lobster, it's shiny.");
		}

		public override void SetDefaults()
		{
			Item.damage = 14;
			Item.DamageType = DamageClass.Melee;
			Item.width = 20;
			Item.height = 26;
			Item.useTime = 7;
			Item.useAnimation = 7;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 1;
			Item.autoReuse = true;
			Item.value = Item.sellPrice(copper: 50);
			Item.rare = ItemRarityID.Green;
			Item.UseSound = SoundID.Item1;
		}
	}
}