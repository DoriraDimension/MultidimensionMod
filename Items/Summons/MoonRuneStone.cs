using MultidimensionMod.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.Audio;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria.Localization;

namespace MultidimensionMod.Items.Summons
{
	public class MoonRuneStone : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
			ItemID.Sets.SortingPriorityBossSpawns[Item.type] = 12;
		}

		public override void SetDefaults()
		{
			Item.width = 26;
			Item.height = 30;
			Item.maxStack = 20;
			Item.value = Item.sellPrice(gold: 0);
			Item.rare = ItemRarityID.Yellow;
			Item.useAnimation = 30;
			Item.useTime = 30;
			Item.useStyle = ItemUseStyleID.HoldUp;
			Item.consumable = true;
		}

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            if (Main.keyState.PressingShift())
            {
                TooltipLine line = new(Mod, "Lore", Language.GetTextValue("Mods.MultidimensionMod.Items.MoonRuneStone.Lore"))
                {
                    OverrideColor = Color.LightGray
                };
                tooltips.Add(line);
            }
            else
            {
                TooltipLine line = new(Mod, "HoldShift", Language.GetTextValue("Mods.MultidimensionMod.SpecialTooltips.Viewer"))
                {
                    OverrideColor = Color.Gray,
                };
                tooltips.Add(line);
            }
        }

        public override bool CanUseItem(Player player)
		{
			return Main.hardMode && !NPC.AnyNPCs(NPCID.CultistBoss);
		}

		public override bool? UseItem(Player player)
		{
			NPC.SpawnOnPlayer(player.whoAmI, NPCID.CultistBoss);
			SoundEngine.PlaySound(SoundID.Roar, player.position);
			return true;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ModContent.ItemType<DarkMatterClump>(), 3)
			.AddIngredient(ItemID.Ectoplasm, 2)
			.AddIngredient(ItemID.SoulofNight, 5)
			.AddIngredient(ItemID.BlueBrick, 10)
			.AddTile(TileID.MythrilAnvil)
			.Register();

			CreateRecipe()
            .AddIngredient(ModContent.ItemType<DarkMatterClump>(), 3)
            .AddIngredient(ItemID.Ectoplasm, 2)
            .AddIngredient(ItemID.SoulofNight, 5)
            .AddIngredient(ItemID.PinkBrick, 10)
            .AddTile(TileID.MythrilAnvil)
            .Register();

			CreateRecipe()
            .AddIngredient(ModContent.ItemType<DarkMatterClump>(), 3)
            .AddIngredient(ItemID.Ectoplasm, 2)
            .AddIngredient(ItemID.SoulofNight, 5)
            .AddIngredient(ItemID.GreenBrick, 10)
            .AddTile(TileID.MythrilAnvil)
            .Register();
		}
	}
}