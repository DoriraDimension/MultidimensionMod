using System.Collections.Generic;
using MultidimensionMod.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Melee.Others
{
	public class DataMiner : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Data Miner");
			Tooltip.SetDefault("The dimensional gods allmight drill, used by him to tear rifts into the dimensions.\nInflicts Electrified.");
			DisplayName.AddTranslation(GameCulture.German, "Data miner");
			Tooltip.AddTranslation(GameCulture.German, "Der allmächtige Bohrer des Dimensions Gottes, wird benutzt um Risse in die Dimensionen zu reißen\nVerursacht Elktrifiziert.");
		}

		public override void SetDefaults()
		{
			item.damage = 7000;
			item.melee = true;
			item.width = 20;
			item.height = 12;
			item.useTime = 5;
			item.useAnimation = 5;
			item.channel = true;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.knockBack = 2;
			item.value = Item.sellPrice(platinum: 1);
			item.rare = -12;
			item.UseSound = SoundID.Item23;
			item.autoReuse = true;
			//item.shoot = ModContent.ProjectileType<Projectiles.DataMinerProj>();
			item.shootSpeed = 20f;
			item.crit = 77;
		}

		public override void ModifyTooltips(List<TooltipLine> list)
		{
			foreach (TooltipLine item in list)
			{
				if (item.mod == "Terraria" && item.Name == "ItemName")
				{
					item.overrideColor = MDRarity.Dorira;
				}
			}
		}

		public override bool CanUseItem(Player player)
		{
			return NPC.downedMoonlord || (player.name == "Dorira") || (player.name == "Marco") || (player.name == "Dorito") || (player.name == "Karl") || (player.name == "Silverking");
		}
	}
}