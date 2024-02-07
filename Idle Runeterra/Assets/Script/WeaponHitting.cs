using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHitting : MonoBehaviour
{
	public CreatureMovement creature;
	public ChampionStats.DamageType damageType;
	public bool swordHitSomething = false;

	public void GettingReady() => swordHitSomething = false;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (swordHitSomething)
			return;

		if (!collision.TryGetComponent(out CreatureMovement creature))
			return;

		if (creature.team == this.creature.team)
			return;

		swordHitSomething = true;
		creature.ReciveDamage(this.creature.GetDamage(), damageType);
	}
}
