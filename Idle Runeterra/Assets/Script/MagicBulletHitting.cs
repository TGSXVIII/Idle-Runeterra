using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ChampionStats;

public class MagicBulletHitting : WeaponHitting
{
	public Rigidbody2D rb;
	public float movementSpeed = 1;

	public void Spawned(CreatureMovement creature)
	{
		this.creature = creature;
	}

	protected override void OnTriggerEnter2D(Collider2D collision) 
	{
		if (!HitEnemyCreature(collision, out CreatureMovement enemy))
			return;

		enemy.ReciveDamage(creature.GetDamage(), damageType);
		Destroy(gameObject);
	}

	private void Update()
	{
		rb.MovePosition(rb.position +
			new Vector2(movementSpeed * Time.deltaTime, 0f) *
			(creature.team == Team.Player ? Vector2.right : Vector2.left));
	}

	public override void GettingReady() { }
}
