using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordHitting : WeaponHitting
{
	public override void ReadierOrShooting() => HitSomething = false;

	protected override void OnTriggerEnter2D(Collider2D collision)
	{
		if (HitEnemyCreature(collision, out CreatureMovement enemy))
		{
			enemy.ReciveDamage(creature.GetDamage(), damageType);
			HitSomething = true;
		}
		else if (HitEnemyStructure(collision, out Structure structure))
		{
			structure.ReciveDamage(creature.GetDamage());
			HitSomething = true;
		}
	}
}
