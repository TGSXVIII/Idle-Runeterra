using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CreatureMovement : ChampionStats
{
	[Header("Body")]
	[SerializeField]
	private Rigidbody2D rb;

	protected abstract void BasicAttack();
    protected virtual void Movement()
	{
		rb.MovePosition(rb.position + 
			new Vector2(movementSpeed * Time.deltaTime, 0f) * 
			(team == Team.Player ? Vector2.right : Vector2.left));
	}

	protected virtual void FixedUpdate()
    {
        Movement();
    }
}
