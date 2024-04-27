using MultidimensionMod.Projectiles.Melee.Flails;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace MultidimensionMod.Items.Weapons.Melee.Flails
{
    public class Pyrosphere : ModItem
	{
		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Pyrosphere");			
		}		
		
        public override void SetDefaults()
        {
            Item.width = 46;
            Item.height = 44;
            Item.maxStack = 1;
            Item.rare = ItemRarityID.Green;
            Item.value = Item.sellPrice(0, 0, 90, 50);
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.useAnimation = 45;
            Item.useTime = 45;
            Item.UseSound = SoundID.Item1;
            Item.damage = 21;
            Item.knockBack = 7;
            Item.DamageType = DamageClass.MeleeNoSpeed;
            Item.shoot = ModContent.ProjectileType<PyrosphereBall>();
            Item.shootSpeed = 10;
            Item.noUseGraphic = true;
            Item.noMelee = true;
            Item.channel = true;		
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            if (Main.keyState.PressingShift())
            {
                TooltipLine line = new(Mod, "Lore", Language.GetTextValue("Mods.MultidimensionMod.Items.Pyrosphere.Lore"))
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