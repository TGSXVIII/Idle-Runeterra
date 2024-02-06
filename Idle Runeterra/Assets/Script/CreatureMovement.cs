using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class CreatureMovement : ChampionStats
{
	[Header("Componets")]
	[SerializeField]
	private Rigidbody2D rb;
	[SerializeField]
	private BoxCollider2D col;

	protected abstract void BasicAttack();
	protected virtual void Movement()
	{
		if (!movementAllowed)
			return;

		rb.MovePosition(rb.position +
			new Vector2(movementSpeed * Time.deltaTime, 0f) *
			(team == Team.Player ? Vector2.right : Vector2.left));
	}

	protected virtual void FixedUpdate()
	{
		Movement();
	}

#if UNITY_EDITOR
	private void OnValidate()
	{
		col.edgeRadius = GetAttackRange();
	}
#endif
}
