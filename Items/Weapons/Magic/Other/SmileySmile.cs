using MultidimensionMod.Projectiles.Magic;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Magic.Other
{
	public class SmileySmile : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Smiley's Dark Blast");
			Tooltip.SetDefault("A smiling stare.\nShoots dark energy beams");
			DisplayName.AddTranslation(GameCulture.German, "Smileys dunkler Schuss");
			Tooltip.AddTranslation(GameCulture.German, "Ein lächelndes starren.\nVerschießt dunkle Energielaser.");
		}

		public override void SetDefaults()
		{
			item.damage = 47;
			item.magic = true;
			item.width = 28;
			item.height = 26;
			item.useTime = 17;
			item.useAnimation = 17;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true;
			item.mana = 5;
			item.knockBack = 1;
			item.value = Item.sellPrice(gold: 1);
			item.rare = ItemRarityID.LightRed;
			item.UseSound = SoundID.DD2_SonicBoomBladeSlash;
			item.autoReuse = true;
			item.shoot = ModContent.ProjectileType<DarkBolt>();
			item.shootSpeed = 35f;
		}
	}
}
