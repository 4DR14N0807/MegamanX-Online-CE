using System;
using System.Collections.Generic;
using SFML.Graphics;

namespace MMXOnline;

public class SnailChan : CrystalSnail {

	public static Weapon getW() { return new Weapon(WeaponIds.SnailChanGeneric, 148); }

	public SnailChan(
		Player player, Point pos, Point destPos,
		int xDir, ushort? netId, bool ownedByLocalPlayer, bool sendRpc = false
	) : base(
		player, pos, destPos, xDir, netId, ownedByLocalPlayer
	) {

		weapon = getW();

		awardWeaponId = WeaponIds.CrystalHunter;
		weakWeaponId = WeaponIds.MagnetMine;
		weakMaverickWeaponId = WeaponIds.MagnetMine;

		netActorCreateId = NetActorCreateId.SnailChan;
		netOwner = player;
		if (sendRpc) {
			createActorRpc(player.id);
		}

		barIndexes = (54, 43);
	}

	public override string getMaverickPrefix() {
		return "snailchan";
	}
}
