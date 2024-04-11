using MultidimensionMod.Projectiles.Magic;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace MultidimensionMod.Items.Weapons.Magic.Others
{
    public class EtheralEX : ModItem
	{
        
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Light");
			//Tooltip.SetDefault(@"Etheral EX");
        }

	    public override void SetDefaults()
	    {
	        Item.damage = 300;
            Item.DamageType = DamageClass.Magic;
	        Item.mana = 15;
	        Item.width = 130;
	        Item.height = 46;
	        Item.useTime = 10;
	        Item.useAnimation = 10;
	        Item.reuseDelay = 5;
	        Item.useStyle = 5;
	        Item.UseSound = SoundID.Item13;
	        Item.noMelee = true;
            Item.noUseGraphic = true;
			Item.channel = true;
	        Item.knockBack = 0f;
	        Item.value = Item.sellPrice(0, 30, 0, 0);
            Item.channel = true;
            Item.shoot = ModContent.ProjectileType<EtheralEXProj>();
            Item.shootSpeed = 30f;
            Item.rare = ItemRarityID.Red;
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            if (Main.keyState.PressingShift())
            {
                TooltipLine line = new(Mod, "Lore", Language.GetTextValue("Mods.MultidimensionMod.Items.EtheralEX.Lore"))
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
            .AddIngredient(ModContent.ItemType<Etheral>())
            .AddIngredient(ItemID.LastPrism)
            //.AddIngredient(ModContent.ItemType<Materials.RadiumBar>(), 10)
            //.AddIngredient(ModContent.ItemType<Materials.DarkMatter>(), 10)
            .AddTile(TileID.LunarCraftingStation)
            .Register();
        }
    }
}