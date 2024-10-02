using System;
using System.Collections.Generic;
using System.Linq;
using SFML.Graphics;

namespace MMXOnline;

public class CommandSelection : Weapon {

	public Weapon? weapon;

	public CommandSelection() : base() {
		index = (int)WeaponIds.CommandSelection;
		shootSounds = new string[] { "", "", "", "" };
	}

	public override bool canShoot(int chargeLevel, Player player) {
		return base.canShoot(chargeLevel, player) && !Menu.inMenu;
	}

	int[] getWeaponPool() {
		Random random = new Random();
		int[] pool = Enumerable.Range(0, 25).OrderBy( x 
		=>
		random.Next()).Take(4).ToArray();

		return pool;
	}

	public override void getProjectile(Point pos, int xDir, Player player, float chargeLevel, ushort netProjId) {
		base.getProjectile(pos, xDir, player, chargeLevel, netProjId);

		MegamanX mmx = player.character as MegamanX ?? throw new NullReferenceException();

		if (weapon == null) {
			mmx.cSelect = this;
			mmx.changeState(new CommandSelectionState());
			Menu.change(new CommandSelectionMenu(mmx, getWeaponPool()));
			//mmx.cSelectMenu = new CommandSelectionMenu(mmx, getWeaponPool());
		} else {
			weapon.getProjectile(pos, xDir, player, chargeLevel, netProjId);
			string sound = weapon.shootSounds[(int)chargeLevel];
			if (!string.IsNullOrEmpty(sound)) mmx.playSound(sound);
			weapon = null!;
		}
	}
}


public class CommandSelectionMenu : IMainMenu {

	int cursor = 0;
	int[] options;
	MegamanX mmx = null!;
	int time = 0;
	public CommandSelectionMenu(Character character, int[] options) {
		this.options = options;
		mmx = character as MegamanX ?? throw new NullReferenceException();
	}

	Weapon getWeapon(int ind) {
		int i = options[ind];

		return Weapon.getTrainingXWeapons().Find(w => w.index == i).clone();
	}

	public void update() {

		Helpers.menuUpDown(ref cursor, 0, 3);

		if (Global.input.isPressedMenu(Control.Shoot) && time >= 2) {
			if (mmx.cSelect != null) mmx.cSelect.weapon = getWeapon(cursor);
			Menu.exit();
		}

		time++;
	}

	public void render() {
		Point p = mmx.pos;
		Rect rect = new Rect(
			p.x + (32 * mmx.xDir),
			p.y - 64,
			p.x + (160 * mmx.xDir),
			p.y
		);
		float xCursor = mmx.xDir > 0 ? rect.x1 : rect.x2;
		var align = mmx.xDir > 0 ? Alignment.Left : Alignment.Right;

		DrawWrappers.DrawRect(rect.x1, rect.y1, rect.x2, rect.y2, true, Color.Black,8 , ZIndex.Foreground);
		Global.sprites["cursor"].drawToHUD(0, xCursor + 6, rect.y1 + (16 * cursor) + 7);

		for (int i = 0; i < 4; i++) {
			Fonts.drawText(
				FontType.LigthGrey, getWeaponName(i),
				xCursor + 12, rect.y1 + (16 * i) + 4,
				Alignment.Left
			);
		}
	}

	string getWeaponName(int i) {
		return 
			SelectWeaponMenu.weaponNames[options[i]];
	}
}


public class CommandSelectionState : CharState {

	MegamanX mmx = null!;

	public CommandSelectionState() : base("win") {
		normalCtrl = false;
		attackCtrl = false;
	}

	public override void onEnter(CharState oldState) {
		base.onEnter(oldState);
		character.stopMovingWeak();
		mmx = character as MegamanX ?? throw new NullReferenceException();
	}

	public override void update() {
		base.update();

		if (!Menu.inMenu) character.changeToIdleOrFall();
	}
}
