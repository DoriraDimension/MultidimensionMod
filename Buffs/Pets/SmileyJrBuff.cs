using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Buffs.Pets
{
	public class SmileyJrBuff : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Smiley Jr");
			Description.SetDefault("You will take care of him now.");
			DisplayName.AddTranslation(GameCulture.German, "Smiley Jr");
			Description.AddTranslation(GameCulture.German, "Du wirst dich jetzt um ihn kümmern.");
			Main.buffNoTimeDisplay[Type] = true;
			Main.vanityPet[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			player.buffTime[buffIndex] = 18000;
			player.GetModPlayer<MDPlayer>().SmileyJr = true;
			bool petProjectileNotSpawned = player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Pets.SmileyJr>()] <= 0;
			if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer) {
				Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, ModContent.ProjectileType<Projectiles.Pets.SmileyJr>(), 0, 0f, player.whoAmI, 0f, 0f);
			}
		}
	}
}