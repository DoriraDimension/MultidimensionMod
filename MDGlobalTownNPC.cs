using MultidimensionMod.Items.Summons;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace MultidimensionMod
{
	public class MDGlobalTownNPC : GlobalNPC
	{
		public override void SetupShop(int type, Chest shop, ref int nextSlot)
		{
			if (type == NPCID.Dryad)
			{
				if (NPC.downedSlimeKing && ModContent.GetInstance<MDConfig>().DisableNPCItemSelling)
				{
					shop.item[nextSlot].SetDefaults(ItemID.SlimeCrown);
					shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 1, 50);
					nextSlot++;
				}

				if (NPC.downedBoss1 && ModContent.GetInstance<MDConfig>().DisableNPCItemSelling)
				{
					shop.item[nextSlot].SetDefaults(ItemID.SuspiciousLookingEye);
					shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 4, 10);
					nextSlot++;
				}

				if (NPC.downedBoss2 && ModContent.GetInstance<MDConfig>().DisableNPCItemSelling)
				{
					shop.item[nextSlot].SetDefaults(ItemID.WormFood);
					shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 6, 40);
					nextSlot++;
				}

				if (NPC.downedBoss2 && WorldGen.crimson && ModContent.GetInstance<MDConfig>().DisableNPCItemSelling)
				{
					shop.item[nextSlot].SetDefaults(ItemID.BloodySpine);
					shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 6, 40);
					nextSlot++;
				}
			}

			if (type == NPCID.Steampunker)
            {
				if(NPC.downedMechBoss1 && ModContent.GetInstance<MDConfig>().DisableNPCItemSelling)
                {
					shop.item[nextSlot].SetDefaults(ItemID.MechanicalWorm);
					shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 14, 40);
					nextSlot++;
				}

				if (NPC.downedMechBoss2 && ModContent.GetInstance<MDConfig>().DisableNPCItemSelling)
				{
					shop.item[nextSlot].SetDefaults(ItemID.MechanicalEye);
					shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 14, 40);
					nextSlot++;
				}

				if (NPC.downedMechBoss3 && ModContent.GetInstance<MDConfig>().DisableNPCItemSelling)
				{
					shop.item[nextSlot].SetDefaults(ItemID.MechanicalSkull);
					shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 14, 40);
					nextSlot++;
				}
			}

			if (type == NPCID.WitchDoctor)
			{
				if (NPC.downedQueenBee && ModContent.GetInstance<MDConfig>().DisableNPCItemSelling)
				{
					shop.item[nextSlot].SetDefaults(ItemID.Abeemination);
					shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 6, 20);
					nextSlot++;
				}

				if (NPC.downedPlantBoss && ModContent.GetInstance<MDConfig>().DisableNPCItemSelling)
				{
					shop.item[nextSlot].SetDefaults(ModContent.ItemType<PlantMurderStarterSet>());
					shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 17, 50);
					nextSlot++;
				}

				if (NPC.downedGolemBoss && ModContent.GetInstance<MDConfig>().DisableNPCItemSelling)
				{
					shop.item[nextSlot].SetDefaults(ItemID.LihzahrdPowerCell);
					shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 16, 50);
					nextSlot++;
				}
			}

			if (type == NPCID.Clothier)
			{
				if (NPC.downedBoss3 && ModContent.GetInstance<MDConfig>().DisableNPCItemSelling)
				{
					shop.item[nextSlot].SetDefaults(ItemID.ClothierVoodooDoll);
					shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 10);
					nextSlot++;
				}

				if (Main.hardMode && ModContent.GetInstance<MDConfig>().DisableNPCItemSelling)
				{
					shop.item[nextSlot].SetDefaults(ItemID.GuideVoodooDoll);
					shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 7, 10);
					nextSlot++;
				}

				if (NPC.downedGolemBoss && ModContent.GetInstance<MDConfig>().DisableNPCItemSelling)
				{
					shop.item[nextSlot].SetDefaults(ModContent.ItemType<MothAttractor>());
					shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 5, 50);
					nextSlot++;
				}
			}

			if (type == NPCID.Wizard)
			{
				if (NPC.downedBoss3 && ModContent.GetInstance<MDConfig>().DisableNPCItemSelling)
				{
					shop.item[nextSlot].SetDefaults(ModContent.ItemType<MoonRuneStone>());
					shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 13, 30);
					nextSlot++;
				}

				if (NPC.downedMoonlord && ModContent.GetInstance<MDConfig>().DisableNPCItemSelling)
				{
					shop.item[nextSlot].SetDefaults(ItemID.CelestialSigil);
					shop.item[nextSlot].shopCustomPrice = Item.buyPrice(1, 50);
					nextSlot++;
				}
			}

			if (type == NPCID.Truffle)
			{
				if (NPC.downedFishron && ModContent.GetInstance<MDConfig>().DisableNPCItemSelling)
				{
					shop.item[nextSlot].SetDefaults(ItemID.TruffleWorm);
					shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 10);
					nextSlot++;
				}
			}

			if (type == NPCID.Cyborg)
			{
				if (NPC.downedMartians && ModContent.GetInstance<MDConfig>().DisableNPCItemSelling)
				{
					shop.item[nextSlot].SetDefaults(ModContent.ItemType<MartianCellphone>());
					shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 12);
					nextSlot++;
				}
			}
		}
	}
}	
