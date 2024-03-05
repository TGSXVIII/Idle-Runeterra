using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionShooting : WeaponHitting
{
	public Transform BulletSpawnPoint;
	public GameObject bulletPrefab;
	public override void ReadierOrShooting() 
	{
		GameObject bullet = Instantiate(bulletPrefab, BulletSpawnPoint.position, BulletSpawnPoint.rotation);
		bullet.GetComponent<NormalBullet>().Spawned(creature);
	}

	protected override void OnTriggerEnter2D(Collider2D collision) { }
}
