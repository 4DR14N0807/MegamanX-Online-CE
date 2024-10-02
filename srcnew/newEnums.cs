namespace MMXOnline;

public enum ArmorId {
	None = 0,
	Light = 1,
	Giga = 2,
	Max = 3,
	Force = 4,
	Xtreme = 14
}

public enum ArmorP {
	Boots = 0,
	Body = 1,
	Helm = 2,
	Arm = 3
}

public enum SpecialStateIds {
	None,
	AxlRoll,
	HyorogaStart,
	XTeleport,
	PZeroParry,
	ForceNovaStrike,
	XtremeDash,
	Dodge,
}

public static class ArmorParts {
	public static readonly string[] name = {
		"Leg",
		"Body",
		"Helm",
		"Arm"
	};
}


public enum RockF2WeaponIds {
	None = -1,
	QuickBoomerang,
	Slide,
	FlameSword,
	Uppercut,
	Buster,
}
