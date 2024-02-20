using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponHitting : MonoBehaviour
{
	public CreatureMovement creature;
	public ChampionStats.DamageType damageType;
	public bool HitSomething = false;

	public abstract void ReadierOrShooting();

	protected abstract void OnTriggerEnter2D(Collider2D collision);
	
	protected bool HitEnemyCreature(Collider2D collision, out CreatureMovement enemy)
	{
		enemy = null;
		if (HitSomething)
			return false;

		if (!collision.TryGetComponent(out CreatureMovement creature))
			return false;

		enemy = creature;
		return creature.team != this.creature.team;
	}
	protected bool HitEnemyStructure(Collider2D collistion, out Structure enemy)
	{
		enemy = null;
		if (HitSomething)
			return false;

		if (!collistion.TryGetComponent(out Structure structure))
			return false;

		enemy = structure;
		return creature.team != structure.team;
	}
}
