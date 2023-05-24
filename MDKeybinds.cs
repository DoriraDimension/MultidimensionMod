using Terraria.ModLoader;

namespace MultidimensionMod
{
	public class MDKeybinds : ModSystem
	{
		public static ModKeybind ArmorAbility
		{
			get;
			private set;
		}

		public override void Load()
		{
			ArmorAbility = KeybindLoader.RegisterKeybind(Mod, "Armor Ability", "C");
		}

		public override void Unload()
		{
			ArmorAbility = null;
		}
	}
}