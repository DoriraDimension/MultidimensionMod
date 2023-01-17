using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Souls
{
	public class PlantSoul : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Soul of Plantera");
			Tooltip.SetDefault("Plantera is the guardian of the jungle.\nShe will hunt down and kill anyone who damages the small pink bulbs that are scattered around the jungle,\nas these are actually young plants that will eventually grow into another guardian, Plantera will defend them with her life.");
			Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(7, 10));
			ItemID.Sets.AnimatesAsSoul[Item.type] = true;
			ItemID.Sets.ItemIconPulse[Item.type] = true;
			ItemID.Sets.ItemNoGravity[Item.type] = true;
		}

		public override void SetDefaults()
		{
			Item.width = 22;
			Item.height = 36;
			Item.rare = ItemRarityID.Lime;
		}

		public override void ModifyTooltips(List<TooltipLine> list)
		{
			foreach (TooltipLine Item in list)
			{
				if (Item.Mod == "Terraria" && Item.Name == "ItemName")
				{
					switch (Main.GameUpdateCount / 60 % 2)
					{
						case 0:
							Item.OverrideColor = new Color(225, 128, 206);
							break;
						case 1:
							Item.OverrideColor = new Color(110, 183, 4);
							break;
					}
				}
			}
		}
	}
}