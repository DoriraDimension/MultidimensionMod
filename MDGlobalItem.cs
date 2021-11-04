using MultidimensionMod.Items.Accessories;
using MultidimensionMod.Items.Materials;
using MultidimensionMod.Items.Weapons.Melee.Boomerangs;
using MultidimensionMod.Items.Weapons.Melee.Swords;
using MultidimensionMod.Items.Weapons.Magic.Guns;
using MultidimensionMod.Items.Weapons.Ranged;
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
		}
	}
}