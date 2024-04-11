using MultidimensionMod.Items.Materials;
using MultidimensionMod.Projectiles.Melee.Swords;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using System.Collections.Generic;
using Terraria.Localization;

namespace MultidimensionMod.Items.Weapons.Melee.Swords
{
	public class TundranaScythe : ModItem
	{
		public override void SetStaticDefaults() 
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.damage = 90;
			Item.DamageType = DamageClass.Melee;
			Item.width = 76;
			Item.height = 76;
			Item.useTime = 42;
			Item.useAnimation = 28;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 4;
			Item.autoReuse = true;
			Item.value = Item.sellPrice(0, 3, 0, 0);
			Item.rare = ItemRarityID.Lime;
			Item.UseSound = SoundID.Item1;
			Item.shoot = ModContent.ProjectileType<TundraSickle>();
			Item.shootSpeed = 12f;
		}

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            if (Main.keyState.PressingShift())
            {
                TooltipLine line = new(Mod, "Lore", Language.GetTextValue("Mods.MultidimensionMod.Items.TundranaScythe.Lore"))
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
    }
}