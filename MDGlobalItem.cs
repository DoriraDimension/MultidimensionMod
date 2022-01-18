using MultidimensionMod.Items.Accessories;
using MultidimensionMod.Items.Materials;
using MultidimensionMod.Items.Weapons.Melee.Boomerangs;
using MultidimensionMod.Items.Weapons.Melee.Swords;
using MultidimensionMod.Items.Weapons.Magic.Guns;
using MultidimensionMod.Items.Weapons.Ranged;
using MultidimensionMod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Reflection;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria.ModLoader.IO;

namespace MultidimensionMod
{
	public class MDGlobalItem : GlobalItem
	{
		public override void SetDefaults(Item item)
		{
			Mod calamityMod = ModLoader.GetMod("CalamityMod");
			if (calamityMod != null)
			{
				calamityMod.GetItem("GrandDad").DisplayName.AddTranslation(GameCulture.English, "Grand Daddy");
			}
			if (item.type == ItemID.SpiritFlame)
			{
				item.UseSound = SoundID.Item103;
			}
			if (item.type == ItemID.NightsEdge)
			{
				item.autoReuse = true;
			}
			if (item.type == ItemID.TrueNightsEdge)
			{
				item.autoReuse = true;
			}
			if (item.type == ItemID.TrueExcalibur)
			{
				item.autoReuse = true;
			}
			if (item.type == ItemID.BoneSword)
			{
				item.damage = 31;
				item.autoReuse = true;
			}
		}
	}
}