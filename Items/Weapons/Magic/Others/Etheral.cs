using MultidimensionMod.Projectiles.Magic;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace MultidimensionMod.Items.Weapons.Magic.Others
{
    public class Etheral : ModItem
	{
		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Etheral");
			//Tooltip.SetDefault(" \"If in the wrong hands, it can cause devastating damage, so don't give it to me\" \n-TheRedstoneBro");
		}

        public override void SetDefaults()
		{
            Item.damage = 180;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.useAnimation = 7;
            Item.useTime = 7;
            Item.width = 46;
            Item.height = 26;
            Item.mana = 10;
            Item.shootSpeed = 16f;
            Item.knockBack = 0f;
            Item.reuseDelay = 5;
            Item.UseSound = SoundID.Item13;
            Item.channel = true;
            Item.shoot = ModContent.ProjectileType<EtheralProj>();
            Item.value = Item.sellPrice(0, 20, 0, 0);
            Item.noMelee = true;
            Item.DamageType = DamageClass.Magic;
            Item.autoReuse = true;
			Item.noUseGraphic = true;
            Item.rare = ItemRarityID.Cyan;     
		}

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            if (Main.keyState.PressingShift())
            {
                TooltipLine line = new(Mod, "Lore", Language.GetTextValue("Mods.MultidimensionMod.Items.Etheral.Lore"))
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
            .AddIngredient(ItemID.ChargedBlasterCannon)
            .AddIngredient(ItemID.FragmentSolar, 3)
            .AddIngredient(ItemID.FragmentVortex, 3)
            .AddIngredient(ItemID.FragmentNebula, 3)
            .AddIngredient(ItemID.FragmentStardust, 3)
            .AddTile(TileID.LunarCraftingStation)
            .Register();
        }
    }
}
