using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace MultidimensionMod
{
	public class MDGlobalTownNPC
	{
		public static void NewNPCQuotes(NPC npc, Mod mod, ref string chat)
		{
			switch (npc.type)
			{
			case 22:
				if (Main.hardMode)
				{
					if (Main.rand.NextBool(20))
					{
						chat = "I like soap.";
					}
					if (Main.rand.NextBool(20))
					{
						chat = "atedhaethathaethdhdgfhg?.";
					}
				}
				break;
			}
		}
	}
}
	