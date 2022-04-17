using Terraria.ModLoader;
using Terraria;
using Terraria.Localization;
using Terraria.ID;

namespace MultidimensionMod.Items.Materials
{
	public class IceblossomItem : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Iceblossom");
			Tooltip.SetDefault("A kind of flora found in the Frozen Underworld, its ancestor, the Fireblossom, adapted to the environment to survive.\nThe influence of the icy magic made this plant dangerous to eat.");
		}

		public override void SetDefaults()
		{
			Item.maxStack = 999;
			Item.width = 12;
			Item.height = 14;
			Item.value = 80;
			Item.useStyle = ItemUseStyleID.EatFood;
			Item.useAnimation = 15;
			Item.useTime = 15;
			Item.UseSound = SoundID.Item2;
			Item.consumable = true;
			Item.buffType = (47); //Frozen
			Item.buffTime = 900;
		}
	}
}