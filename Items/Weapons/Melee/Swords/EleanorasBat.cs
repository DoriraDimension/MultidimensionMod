using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Melee.Swords
{
	public class EleanorasBat : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dimensional Goddess's Bat");
			Tooltip.SetDefault("Enemies will Bleed and burn on hit. \nDa Bat.");
			DisplayName.AddTranslation(GameCulture.German, "Baseballschläger der Dimensions Göttin");
			Tooltip.AddTranslation(GameCulture.German, "Gegner werden bluten und brennen wenn getroffen. \nDa Bat");
		}

		public override void SetDefaults()
		{
			item.damage = 696;
			item.melee = true;
			item.width = 94;
			item.height = 94;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.useTime = 15;
			item.useAnimation = 15;
			item.knockBack = 15;
			item.value = Item.sellPrice(gold: 69);
			item.rare = ItemRarityID.Purple;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.crit = 69; 

		}

		public override void ModifyTooltips(List<TooltipLine> list)
		{
			foreach (TooltipLine item in list)
			{
				if (item.mod == "Terraria" && item.Name == "ItemName")
				{
					item.overrideColor = MDRarity.Eleanora;
				}
			}
		}

		public override bool CanUseItem(Player player)
		{
			return  NPC.downedMoonlord || (player.name == "Eleanora") || (player.name == "EleanoraKitti") || (player.name == "Ellie") || (player.name == "Sunclaw");
		}

		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.NextBool(3))
			{
				Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, (6));
			}
		}

		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(BuffID.OnFire, 600);
			target.AddBuff(BuffID.Bleeding, 600);
		}

		public override void AddRecipes()
		{

			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Pearlwood, 350);
			recipe.AddIngredient(ItemID.FragmentSolar, 50);
			recipe.AddIngredient(ItemID.Meowmere);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}