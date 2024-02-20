using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Animator))]
public abstract class CreatureMovement : ChampionStats
{
	[Header("Componets")]
	[SerializeField, Tooltip("So it can \"walk\"")]
	private Rigidbody2D rb;
	[SerializeField, Tooltip("The Attack Range collider")]
	private BoxCollider2D AttackRange;
	[Tooltip("You don't want a static image... right?!")]
	public Animator animator;

	public abstract void Spawn(Team team, TeamManager manager);
	protected abstract void BasicAttack();
	protected virtual void Movement()
	{
		if (!movementAllowed)
			return;
		
		animator.SetBool("Moving", true);
		rb.MovePosition(rb.position +
			new Vector2(movementSpeed * Time.deltaTime, 0f) *
			(team == Team.Player ? Vector2.right : Vector2.left));
	}

	protected virtual void FixedUpdate()
	{
		foreach (ShopItem item in GetItems()[ShopItem.State.Passive])
		{
			item.GetComponent<PassiveShopItem>().PassiveAbility();
		}

		Movement();
	}

#if UNITY_EDITOR
	private void OnValidate()
	{
		if (AttackRange != null)
		{
			AttackRange.edgeRadius = GetAttackRange();
		}
	}
#endif
}
