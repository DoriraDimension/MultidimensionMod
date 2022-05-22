using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Melee.Swords
{
	public class Shinorian : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Shinorian");
			Tooltip.SetDefault("Cloaked in a magic veil, this rapier hits extremely fast.");
		}

		public override void SetDefaults()
		{
			Item.damage = 28;
			Item.DamageType = DamageClass.Melee;
			Item.width = 56;
			Item.height = 56;
			Item.useTime = 8;
			Item.useAnimation = 8;
			Item.useStyle = ItemUseStyleID.Thrust;
			Item.knockBack = 2;
			Item.value = Item.sellPrice(silver: 78);
			Item.rare = ItemRarityID.LightRed;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.crit = 5;
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