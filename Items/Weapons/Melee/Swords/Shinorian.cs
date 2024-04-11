using MultidimensionMod.Projectiles.Melee.Swords;
using MultidimensionMod.Rarities;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Creative;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using Terraria.Localization;

namespace MultidimensionMod.Items.Weapons.Melee.Swords
{
	public class Shinorian : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.damage = 25;
			Item.DamageType = DamageClass.Melee;
			Item.width = 56;
			Item.height = 56;
			Item.useTime = 8;
			Item.useAnimation = 8;
			Item.useStyle = ItemUseStyleID.Rapier;
			Item.knockBack = 2;
			Item.value = Item.sellPrice(0, 3, 0, 0);
			Item.rare = ModContent.RarityType<AseGneblessaArtifact>();
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.noMelee = true;
			Item.noUseGraphic = true;
			Item.crit = 5;
			Item.shoot = ModContent.ProjectileType<HexStab>();
			Item.shootSpeed = 3.50f;
		}

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            if (Main.keyState.PressingShift())
            {
                TooltipLine line = new(Mod, "Lore", Language.GetTextValue("Mods.MultidimensionMod.Items.Shinorian.Lore"))
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

        public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ItemID.UnicornHorn)
			.AddIngredient(ItemID.Obsidian, 18)
			.AddIngredient(ItemID.SoulofFright, 6)
			.AddTile(TileID.MythrilAnvil)
			.Register();
		}
	}
}