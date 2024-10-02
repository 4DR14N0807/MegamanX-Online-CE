using System;
using System.Collections.Generic;

namespace MMXOnline;

public class FireStorm : Weapon {
	public FireStorm() : base() {
		index = (int)WeaponIds.FireStorm;
		rateOfFire = 0.75f;
	}

	public override void getProjectile(Point pos, int xDir, Player player, float chargeLevel, ushort netProjId) {
		base.getProjectile(pos, xDir, player, chargeLevel, netProjId);

		new FireStormProj(this, pos, xDir, player, netProjId);
	}
}


public class FireStormProj : Projectile {
	public FireStormProj(Weapon weapon, Point posicion, int xDir, Player player, ushort? netProjId, bool rpc = false) : 
	base(
		weapon, posicion, xDir, 300, 2,
		player, "fire_storm_proj", 0, 0.25f,
		netProjId, player.ownedByLocalPlayer
	) {
		maxTime = 1f;
		destroyOnHit = false;
	}
}
