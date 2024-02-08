using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordHitting : WeaponHitting
{
	public override void ReadierOrShooting() => HitSomething = false;

	protected override void OnTriggerEnter2D(Collider2D collision)
	{
		if (!HitEnemyCreature(collision, out CreatureMovement enemy))
			return;

		HitSomething = true;
		Debug.Log("hit: " + enemy);
		enemy.ReciveDamage(creature.GetDamage(), damageType);
	}
}
