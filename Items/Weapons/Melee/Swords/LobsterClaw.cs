using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Melee.Swords
{
	public class LobsterClaw : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Lobster Claw");
			Tooltip.SetDefault("The claw of a Parrot Lobster, it's shiny.");
			DisplayName.AddTranslation(GameCulture.German, "Hummer Schere");
			Tooltip.AddTranslation(GameCulture.German, "Die Schere eines Papagei Hummers, sie glänzt.");
		}

		public override void SetDefaults()
		{
			item.damage = 14;
			item.melee = true;
			item.width = 20;
			item.height = 26;
			item.useTime = 7;
			item.useAnimation = 7;
			item.useStyle = 1;
			item.knockBack = 1;
			item.autoReuse = true;
			item.value = Item.sellPrice(copper: 50);
			item.rare = ItemRarityID.Green;
			item.UseSound = SoundID.Item1;
		}
	}
}