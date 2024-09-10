using MultidimensionMod.Projectiles.Magic;
using MultidimensionMod.Dusts;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using Terraria.DataStructures;
using System.Collections.Generic;
using Terraria.Localization;
using System.Linq;

namespace MultidimensionMod.Items.Weapons.Magic.Others
{
	public class GreatMoonlight : ModItem
	{
        public int attackType = 0; // keeps track of which attack it is
        public int comboExpireTimer = 0; // we want the attack pattern to reset if the weapon is not used for certain period of time
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.damage = 100;
			Item.DamageType = DamageClass.Magic;
			Item.width = 72;
			Item.height = 72;
			Item.useTime = 32;
			Item.useAnimation = 32;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 6;
            Item.autoReuse = true;
			Item.value = Item.sellPrice(0, 5, 0, 0);
			Item.rare = ItemRarityID.Cyan;
			Item.shoot = ModContent.ProjectileType<MoonlightBlade>();
			Item.shootSpeed = 15f;
			Item.noUseGraphic = true;
			Item.noMelee = true;
		}

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            if (Main.keyState.PressingShift())
            {
                TooltipLine line = new(Mod, "Lore", Language.GetTextValue("Mods.MultidimensionMod.Items.GreatMoonlight.Lore"))
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

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            // Using the shoot function, we override the swing projectile to set ai[0] (which attack it is)
            Projectile.NewProjectile(source, position, velocity, type, damage, knockback, Main.myPlayer, attackType);
            attackType = (attackType + 1) % 2; // Increment attackType to make sure next swing is different
            comboExpireTimer = 0; // Every time the weapon is used, we reset this so the combo does not expire
            return false; // return false to prevent original projectile from being shot
        }

        public override void UpdateInventory(Player player)
        {
            if (comboExpireTimer++ >= 120) // after 120 ticks (== 2 seconds) in inventory, reset the attack pattern
                attackType = 0;
        }

        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
		{
			Texture2D texture = ModContent.Request<Texture2D>("MultidimensionMod/Items/Weapons/Magic/Others/GreatMoonlight_Glow").Value;
			spriteBatch.Draw
			(
				texture,
				new Vector2
				(
					Item.position.X - Main.screenPosition.X + Item.width * 0.5f,
					Item.position.Y - Main.screenPosition.Y + Item.height - texture.Height * 0.5f
				),
				new Rectangle(0, 0, texture.Width, texture.Height),
				Color.White,
				rotation,
				texture.Size() * 0.5f,
				scale,
				SpriteEffects.None,
				0f
			);
		}
	}
}