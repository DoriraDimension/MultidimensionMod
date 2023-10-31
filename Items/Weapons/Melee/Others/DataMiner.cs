using MultidimensionMod.Projectiles.Melee.Others;
using MultidimensionMod.Rarities;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using System.Collections.Generic;
using Terraria.Localization;
using Microsoft.Xna.Framework;

namespace MultidimensionMod.Items.Weapons.Melee.Others
{
	public class DataMiner : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.damage = 7000;
			Item.DamageType = DamageClass.Melee;
			Item.width = 20;
			Item.height = 12;
			Item.useTime = 5;
			Item.useAnimation = 5;
			Item.channel = true;
			Item.noUseGraphic = true;
			Item.noMelee = true;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 2;
			Item.value = Item.sellPrice(1, 0, 0, 0);
			Item.rare = ModContent.RarityType<DoriraRarity>();
			Item.UseSound = SoundID.Item23;
			Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<DataMinerProj>();
			Item.shootSpeed = 20f;
			Item.crit = 77;
		}

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            if (Main.keyState.PressingShift())
            {
                TooltipLine line = new(Mod, "Lore", Language.GetTextValue("Mods.MultidimensionMod.Items.DataMiner.Lore"))
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