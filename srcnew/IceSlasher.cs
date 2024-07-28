using System;
using System.Collections.Generic;

namespace MMXOnline;

public class IceSlasher : Weapon {
    public IceSlasher() : base() {
        index = (int)WeaponIds.IceSlasher;
        ammo = maxAmmo;
        rateOfFire = 1.25f;
        killFeedIndex = 8;
        weaponSlotIndex = 123;
        weaponBarBaseIndex = 72;
        weaponBarIndex = 61;
    }


	public override void getProjectile(Point pos, int xDir, Player player, float chargeLevel, ushort netProjId) {
		new IceSlasherProj(this, pos, xDir, player, netProjId, true);
	}
}


public class IceSlasherProj : Projectile {
    public IceSlasherProj(Weapon weapon, Point pos, int xDir, Player player, ushort? netId, bool rpc = false) :
    base(weapon, pos, xDir, 300, 0, player, "ice_slasher_proj", 0, 1, netId, player.ownedByLocalPlayer) {
        maxTime = 1;
        destroyOnHit = false;
        projId = (int)ProjIds.IceSlasher;
    }
}


public class ISlasherFreeze : CharState {

    public const float totalFreezeTime = 5f * 60;
    public float freezeTime = totalFreezeTime;
    public ISlasherFreeze(Character character, float time) : base(character?.sprite?.name ?? "grabbed") {
        immuneToWind = true;
        freezeTime = time;
    }

    public override void update() {
		base.update();
		character.stopMoving();
		if (freezeTime <= 0) {
			freezeTime = 0;
			character.changeToIdleOrFall();
		}
		// Does not stack with other time stops.
		//freezeTime -= 1;
	}

    public override bool canEnter(Character character) {
		if (character.isInvulnerable() ||
			character.isVaccinated() ||
			character.isCCImmune() ||
			character.charState.invincible
		) {
			return false;
		}
		return base.canEnter(character);
	}

	public override void onEnter(CharState oldState) {
		base.onEnter(oldState);
		character.useGravity = false;
		character.frameSpeed = 0;
		character.stopMoving();
	}

	public override void onExit(CharState newState) {
		base.onExit(newState);
		character.useGravity = true;
		character.frameSpeed = 1;
	}
}
