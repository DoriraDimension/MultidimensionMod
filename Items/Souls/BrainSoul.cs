using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Souls
{
	public class BrainSoul : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Soul of the Brain");
			Tooltip.SetDefault("Like the related eye, this brain is supposed to test ones skills,\nbut rather than doing that it turned against the duty that a unknown being gave to it.\nIt resides in the bloody land of flesh, awaiting a new victim.");
			DisplayName.AddTranslation(GameCulture.German, "Seele des Gehirns");
			Tooltip.AddTranslation(GameCulture.German, "Wie das verwandte Auge, dieses Gehirn sollte eigentliche andere testen,\nallerdings, anstatt dies zu tun wandte es sich gegen die Pflicht die ein unbekanntes Wesen ihm gab.\nEs verweilt nun im blutigen Land aus Fleisch, wartend auf ein neues Opfer.");
			Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(7, 6));
			ItemID.Sets.ItemIconPulse[item.type] = true;
			ItemID.Sets.ItemNoGravity[item.type] = true;
		}

		public override void SetDefaults()
		{
			item.width = 26;
			item.height = 28;
			item.rare = ItemRarityID.Green;
		}

		public override void ModifyTooltips(List<TooltipLine> list)
		{
			foreach (TooltipLine item in list)
			{
				if (item.mod == "Terraria" && item.Name == "ItemName")
				{
					switch (Main.GameUpdateCount / 60 % 2)
					{
						case 0:
							item.overrideColor = new Color(78, 14, 16);
							break;
						case 1:
							item.overrideColor = new Color(220, 165, 166);
							break;
					}
				}
			}
		}
	}
}