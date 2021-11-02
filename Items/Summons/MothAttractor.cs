using MultidimensionMod.Projectiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Summons
{
	public class MothAttractor : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Moth Attractor");
			Tooltip.SetDefault("It's interesting how easy it is to lure in moths with just light, so if we make a bigger lamp we attract bigger moths, right?.\nSummons a Mothron during an eclipse. ");
			DisplayName.AddTranslation(GameCulture.German, "Motten Anzieher");
			Tooltip.AddTranslation(GameCulture.German, "Es ist interresant wie leicht es ist Motten mit Licht anzulocken, wenn wir eine größere Lampe machen, dann können wir größere Motten anlocken, richtig?\nBeschwört einen Mothron während einer Sonnenfinsternis.");
			ItemID.Sets.SortingPriorityBossSpawns[item.type] = 12;
		}

		public override void SetDefaults()
		{
			item.width = 40;
			item.height = 26;
			item.maxStack = 20;
			item.value = Item.sellPrice(gold: 0);
			item.rare = ItemRarityID.Pink;
			item.useAnimation = 30;
			item.useTime = 30;
			item.useStyle = ItemUseStyleID.HoldingUp;
			item.UseSound = SoundID.NPCHit44;
			item.consumable = true;
		}

		public override bool CanUseItem(Player player)
		{
			return Main.eclipse && Main.hardMode && NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3 && !NPC.AnyNPCs(NPCID.Mothron);
		}

		public override bool UseItem(Player player)
		{
			NPC.SpawnOnPlayer(player.whoAmI, NPCID.Mothron);
			return true;
		}

		public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
		{
			Texture2D texture = mod.GetTexture("Items/Summons/MothAttractor_Glow");
			spriteBatch.Draw
			(
				texture,
				new Vector2
				(
					item.position.X - Main.screenPosition.X + item.width * 0.5f,
					item.position.Y - Main.screenPosition.Y + item.height - texture.Height * 0.5f + 2f
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

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddRecipeGroup("IronBar", 6);
			recipe.AddIngredient(ItemID.SoulofLight, 3);
			recipe.AddTile(134);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}