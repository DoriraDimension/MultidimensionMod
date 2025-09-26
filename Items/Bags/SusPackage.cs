using System.Collections.Generic;
using MultidimensionMod.Items.Accessories;
using MultidimensionMod.Items.Weapons.Summon;
using MultidimensionMod.Items.Materials;
using MultidimensionMod.Items.Placeables;
using MultidimensionMod.Items.Weapons.Melee.Swords;
using MultidimensionMod.Items.Weapons.Magic.Staffs;
using MultidimensionMod.Items.Weapons.Typeless;
using MultidimensionMod.Items.Potions;
using MultidimensionMod.Rarities;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using MultidimensionMod.NPCs.MushBiomes;
using Terraria.DataStructures;
using MultidimensionMod.NPCs.Corruption;

namespace MultidimensionMod.Items.Bags
{
	public class SusPackage : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.width = 26;
			Item.height = 30;
			Item.rare = ModContent.RarityType<DoriraRarity>();
			Item.maxStack = 99;
		}

		public override bool CanRightClick()
		{
			return true;
		}

		public override void RightClick(Player player)
		{
			var source = player.GetSource_OpenItem(Type);
			player.QuickSpawnItem(source, ItemID.Torch, 10);
			player.QuickSpawnItem(source, ItemID.RecallPotion, 3);
			player.QuickSpawnItem(source, ItemID.Rope, 35);
			player.QuickSpawnItem(source, ItemID.Bomb, 5);
			player.QuickSpawnItem(source, ItemID.BuilderPotion, 2);
			player.QuickSpawnItem(source, ItemID.CopperCoin);
			player.QuickSpawnItem(source, ModContent.ItemType<Socks>());
            player.QuickSpawnItem(source, ModContent.ItemType<TheAncientChaos>());
            switch (player.name)
			{
				case "Dorira":
				case "Marco":
				case "Dorito":
				case "Karl":
				case "Silverking":
				case "They":
					player.QuickSpawnItem(source, ModContent.ItemType<FishLegacy>());
					player.QuickSpawnItem(source, ModContent.ItemType<Dimensium>(), 15);
					player.QuickSpawnItem(source, ModContent.ItemType<DimensionalForgeItem>());
					break;

				case "Teiteira":
				case "Fat":
					player.QuickSpawnItem(source, ItemID.SugarCookie, 5);
					player.QuickSpawnItem(source, ItemID.Holly);
					player.QuickSpawnItem(source, ItemID.Ale);
					break;

				case "Cotton":
				case "Dynosaur":
				case "Crabbane":
					player.QuickSpawnItem(source, ItemID.PinkDye, 3);
					player.QuickSpawnItem(source, ItemID.PinkPaint, 999);
					break;

				case "Tim":
				case "Illuminatim":
					player.QuickSpawnItem(source, ModContent.ItemType<Rambam>());
					player.QuickSpawnItem(source, ModContent.ItemType<MirrorOfOrigin>());
					break;

				case "Clint":
					player.QuickSpawnItem(source, ItemID.IronHammer);
					player.QuickSpawnItem(source, ModContent.ItemType<Geode>(), 3);
					player.QuickSpawnItem(source, ModContent.ItemType<FrozenGeode>(), 3);
					player.QuickSpawnItem(source, ModContent.ItemType<SandstoneGeode>(), 3);
					player.QuickSpawnItem(source, ModContent.ItemType<BloodGeode>(), 3);
					player.QuickSpawnItem(source, ModContent.ItemType<DecayGeode>(), 3);
					break;

				case "Darkrage":
					player.QuickSpawnItem(source, ModContent.ItemType<DrakeCrystal>());
					player.QuickSpawnItem(source, ModContent.ItemType<FrostScale>(), 14);
					player.QuickSpawnItem(source, ItemID.LihzahrdBanner);
					break;
				case "Rebel":
				case "RebelSpy":
				case "John Decay Fly":
					player.QuickSpawnItem(source, ModContent.ItemType<DecayGeode>(), 5);
					NPC.NewNPC(source, (int)player.Center.X, (int)player.Center.Y, ModContent.NPCType<DecayFly>());
                    NPC.NewNPC(source, (int)player.Center.X, (int)player.Center.Y - 5, ModContent.NPCType<DecayFly>());
                    NPC.NewNPC(source, (int)player.Center.X - 10, (int)player.Center.Y, ModContent.NPCType<DecayFly>());
                    NPC.NewNPC(source, (int)player.Center.X - 5, (int)player.Center.Y, ModContent.NPCType<DecayFly>());
                    NPC.NewNPC(source, (int)player.Center.X + 5, (int)player.Center.Y, ModContent.NPCType<DecayFly>());
                    NPC.NewNPC(source, (int)player.Center.X + 10, (int)player.Center.Y, ModContent.NPCType<DecayFly>());
                    break;
			}
		}
	}
}