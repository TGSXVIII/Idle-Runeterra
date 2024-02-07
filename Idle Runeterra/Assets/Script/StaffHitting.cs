using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaffHitting : WeaponHitting
{
	public Transform BulletSpawnPoint;
	public GameObject magicBulletPrefab;
	public override void GettingReady() { }

	protected override void OnTriggerEnter2D(Collider2D collision) { }

	public void Shoot()
	{
		GameObject bullet = Instantiate(magicBulletPrefab, BulletSpawnPoint.position, BulletSpawnPoint.rotation);
		bullet.GetComponent<MagicBulletHitting>().Spawned(creature);
	}
}
