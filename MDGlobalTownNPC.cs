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
				if (NPC.downedSlimeKing)
				{
					shop.item[nextSlot].SetDefaults(ItemID.SlimeCrown);
					shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 1, 50);
					nextSlot++;
				}

				if (NPC.downedBoss1)
				{
					shop.item[nextSlot].SetDefaults(ItemID.SuspiciousLookingEye);
					shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 4, 10);
					nextSlot++;
				}

				if (NPC.downedBoss2)
				{
					shop.item[nextSlot].SetDefaults(ItemID.WormFood);
					shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 6, 40);
					nextSlot++;
				}

				if (NPC.downedBoss2 && WorldGen.crimson)
				{
					shop.item[nextSlot].SetDefaults(ItemID.BloodySpine);
					shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 6, 40);
					nextSlot++;
				}
			}

			if (type == NPCID.Steampunker)
            {
				if(NPC.downedMechBoss1)
                {
					shop.item[nextSlot].SetDefaults(ItemID.MechanicalWorm);
					shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 14, 40);
					nextSlot++;
				}

				if (NPC.downedMechBoss2)
				{
					shop.item[nextSlot].SetDefaults(ItemID.MechanicalEye);
					shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 14, 40);
					nextSlot++;
				}

				if (NPC.downedMechBoss3)
				{
					shop.item[nextSlot].SetDefaults(ItemID.MechanicalSkull);
					shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 14, 40);
					nextSlot++;
				}
			}

			if (type == NPCID.WitchDoctor)
			{
				if (NPC.downedQueenBee)
				{
					shop.item[nextSlot].SetDefaults(ItemID.Abeemination);
					shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 6, 20);
					nextSlot++;
				}

				if (NPC.downedPlantBoss)
				{
					shop.item[nextSlot].SetDefaults(ModContent.ItemType<PlantMurderStarterSet>());
					shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 17, 50);
					nextSlot++;
				}

				if (NPC.downedGolemBoss)
				{
					shop.item[nextSlot].SetDefaults(ItemID.LihzahrdPowerCell);
					shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 16, 50);
					nextSlot++;
				}
			}

			if (type == NPCID.Clothier)
			{
				if (NPC.downedBoss3)
				{
					shop.item[nextSlot].SetDefaults(ItemID.ClothierVoodooDoll);
					shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 10);
					nextSlot++;
				}

				if (Main.hardMode)
				{
					shop.item[nextSlot].SetDefaults(ItemID.GuideVoodooDoll);
					shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 7, 10);
					nextSlot++;
				}

				if (NPC.downedGolemBoss)
				{
					shop.item[nextSlot].SetDefaults(ModContent.ItemType<MothAttractor>());
					shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 5, 50);
					nextSlot++;
				}
			}

			if (type == NPCID.Wizard)
			{
				if (NPC.downedBoss3)
				{
					shop.item[nextSlot].SetDefaults(ModContent.ItemType<MoonRuneStone>());
					shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 13, 30);
					nextSlot++;
				}

				if (NPC.downedMoonlord)
				{
					shop.item[nextSlot].SetDefaults(ItemID.CelestialSigil);
					shop.item[nextSlot].shopCustomPrice = Item.buyPrice(1, 50);
					nextSlot++;
				}
			}

			if (type == NPCID.Truffle)
			{
				if (NPC.downedFishron)
				{
					shop.item[nextSlot].SetDefaults(ItemID.TruffleWorm);
					shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 10);
					nextSlot++;
				}
			}
		}
	}
}
	
