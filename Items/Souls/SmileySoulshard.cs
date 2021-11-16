using MultidimensionMod.NPCs.Dungeon;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Souls
{
	public class SmileySoulshard : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Smiley Soulshard");
			Tooltip.SetDefault("A shard that reflects the soul of a dark being.\nSmiley was born as a being of pure dark whos purpose was to spread darkness all across existence, but unlike his siblings, he refused to be evil.\nWhen his creator was'nt paying attention he left his home together with a small army of Darklings.\nNow he is hiding in the Terrarian world with hope to find a person strong enough to take on his creator.\nEquip to make Darklings friendly and receive +1 mana regen.");
			DisplayName.AddTranslation(GameCulture.German, "Smiley Seelenscherbe");
			Tooltip.AddTranslation(GameCulture.German, "Eine Scherbe die die Seele eines dunklen Wesens reflektiert.\nSmiley wurde als ein Wesen der reinen Dunkelheit geboren mit dem Zweck die Dunkelheit über die gesamte Existenz zu verteilen, aber nicht so wie seine Geschwister,weigerte er sich böse zu sein\nWenn sein Schöper nicht hinsah, verschwand er mit einer kleinen Armee aus Dunkellingen.\nJetzt versteckt er sich in Terraria mit der Hoffnung eine Person zu finden die stark genug ist um seinem Schöpfer zu trotzen.\nRüste aus für +1 Mana regen und um Dunkellinge freundlich zu machen. ");
			ItemID.Sets.ItemIconPulse[item.type] = true;
			ItemID.Sets.ItemNoGravity[item.type] = true;
		}

		public override void SetDefaults()
		{
			item.width = 24;
			item.height = 24;
			item.accessory = true;
			item.rare = ItemRarityID.LightRed;
		}

		public override void ModifyTooltips(List<TooltipLine> list)
		{
			foreach (TooltipLine item in list)
			{
				if (item.mod == "Terraria" && item.Name == "ItemName")
				{
					item.overrideColor = MDRarity.Souls;
				}
			}
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.npcTypeNoAggro[ModContent.NPCType<Darkling>()] = true;
			player.manaRegen += 1;
		}
	}
}
