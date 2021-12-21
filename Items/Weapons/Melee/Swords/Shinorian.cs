using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Melee.Swords
{
	public class Shinorian : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Shinorian");
			Tooltip.SetDefault("Cloaked in a magic veil, this rapier hits extremely fast.");
			DisplayName.AddTranslation(GameCulture.German, "Shinorian");
			Tooltip.AddTranslation(GameCulture.German, "Gehüllt in einen magischen Schleier, dieser Rapier trifft extrem schnell.");
		}

		public override void SetDefaults()
		{
			item.damage = 28;
			item.melee = true;
			item.width = 56;
			item.height = 56;
			item.useTime = 8;
			item.useAnimation = 8;
			item.useStyle = 3;
			item.knockBack = 2;
			item.value = Item.sellPrice(silver: 78);
			item.rare = ItemRarityID.LightRed;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.crit = 5;
		}

		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.NextBool(5))
			{
				Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, (27));
			}
		}
	}
}