using System.Collections.Generic;

namespace MMXOnline;

public partial class RPCCreateProj : RPC {
	public static Dictionary<int, ProjCreate> functs = new Dictionary<int, ProjCreate> {
		// X Stuff.
		{ (int)ProjIds.Boomerang, BoomerangProj.rpcInvoke },
		{ (int)ProjIds.ShotgunIce, ShotgunIceProj.rpcInvoke },
		{ (int)ProjIds.BubbleSplash, BubbleSplashProj.rpcInvoke },
		{ (int)ProjIds.TriadThunder, TriadThunderProj.rpcInvoke },
		{ (int)ProjIds.TriadThunderQuake, TriadThunderQuake.rpcInvoke },
		{ (int)ProjIds.TriadThunderCharged, TriadThunderProjCharged.rpcInvoke },
		{ (int)ProjIds.RaySplasher, RaySplasherProj.rpcInvoke },
		{ (int)ProjIds.RaySplasherChargedProj, RaySplasherProj.rpcInvoke },
		{ (int)ProjIds.UPParryMelee, UPParryMeleeProj.rpcInvoke },
		{ (int)ProjIds.UPParryProj, UPParryRangedProj.rpcInvoke },
		//X4 Stuff.
		{ (int)ProjIds.BusterForceStock, BusterStockProj.rpcInvoke },
		{ (int)ProjIds.BusterForce3, ForceBuster3Proj.rpcInvoke },
		{ (int)ProjIds.BusterForcePlasma, BusterForcePlasmaProj.rpcInvoke },
		{ (int)ProjIds.BusterForcePlasmaHit, BusterForcePlasmaHit.rpcInvoke },
		{ (int)ProjIds.LightningWebProj, LightningWebProj.rpcInvoke },
		{ (int)ProjIds.LightningWeb, LightningWebProjWeb.rpcInvoke },
		{ (int)ProjIds.LightningWebChargedProj, LightningWebProjCharged.rpcInvoke },
		{ (int)ProjIds.LightningWebCharged, LightningWebProjWebCharged.rpcInvoke },
		{ (int)ProjIds.FrostTower, FrostTowerProj.rpcInvoke },
		{ (int)ProjIds.FrostTowerCharged, FrostTowerProjCharged.rpcInvoke },
		{ (int)ProjIds.SoulBodyHologram, SoulBodyHologram.rpcInvoke },
		{ (int)ProjIds.RisingFire, RisingFireProj.rpcInvoke },
		{ (int)ProjIds.RisingFireChargedStart, RisingFireProjChargedStart.rpcInvoke },
		{ (int)ProjIds.RisingFireCharged, RisingFireProjCharged.rpcInvoke },
		{ (int)ProjIds.RisingFireUnderwater, RisingFireWaterProj.rpcInvoke },
		{ (int)ProjIds.RisingFireUnderwaterCharged, RisingFireWaterProjCharged.rpcInvoke },
		{ (int)ProjIds.GroundHunter, GroundHunterProj.rpcInvoke },
		{ (int)ProjIds.GroundHunterCharged, GroundHunterChargedProj.rpcInvoke },
		{ (int)ProjIds.GroundHunterSmall, GroundHunterSmallProj.rpcInvoke },
		{ (int)ProjIds.AimingLaser, AimingLaserProj.rpcInvoke },
		{ (int)ProjIds.AimingLaserCharged, AimingLaserChargedProj.rpcInvoke },
		{ (int)ProjIds.DoubleCyclone, DoubleCycloneProj.rpcInvoke },
		{ (int)ProjIds.DoubleCycloneChargedSpawn, DoubleCycloneChargedSpawn.rpcInvoke },
		{ (int)ProjIds.DoubleCycloneCharged, DoubleCycloneChargedProj.rpcInvoke },
		{ (int)ProjIds.TwinSlasher, TwinSlasherProj.rpcInvoke },
		{ (int)ProjIds.TwinSlasherCharged, TwinSlasherProjCharged.rpcInvoke },
		// Vile stuff.
		{ (int)ProjIds.FrontRunner, VileCannonProj.rpcInvoke },
		{ (int)ProjIds.FatBoy, VileCannonProj.rpcInvoke },
		{ (int)ProjIds.LongshotGizmo, VileCannonProj.rpcInvoke },
		// Buster Zero
		{ (int)ProjIds.DZBuster, DZBusterProj.rpcInvoke },
		{ (int)ProjIds.DZBuster2, DZBuster2Proj.rpcInvoke },
		{ (int)ProjIds.DZBuster3, DZBuster3Proj.rpcInvoke },
		// Mavericks
		{ (int)ProjIds.VoltCSuck, VoltCSuckProj.rpcInvoke }
	};

}

public struct ProjParameters {
	public int projId;
	public Point pos;
	public int xDir;
	public Player player;
	public ushort netId;
	public byte[] extraData;
	public float angle;
	public float byteAngle;
}

public delegate Projectile ProjCreate(ProjParameters arg);
