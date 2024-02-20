using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class CreatureInRange : MonoBehaviour
{
	public CreatureMovement creature;
	public List<GameObject> targetsInRange = new();

	private void OnTriggerEnter2D(Collider2D collision)
	{
		AllowMovement(collision, true);
	}
	private void OnTriggerExit2D(Collider2D collision)
	{
		AllowMovement(collision, false);
	}
	private void AllowMovement(Collider2D collider, bool entering)
	{
		if (HitCtretureAndIsEnemyTeam(collider))
		{
			if (entering)
			{
				Entering(collider.gameObject);
				return;
			}
			Exiting(collider.gameObject);
		}
		else if (HitScrutureAndIsEnemyTeam(collider))
		{
			if (entering)
			{
				Entering(collider.gameObject);
				return;
			}

			Exiting(collider.gameObject);
		}
	}

	private void Entering(GameObject enemy)
	{
		creature.movementAllowed = false;
		creature.animator.SetBool("Moving", false);
		targetsInRange.Add(enemy);
	}
	private void Exiting(GameObject enemy)
	{
		targetsInRange.Remove(enemy);
		if (targetsInRange.Count <= 0)
		{
			creature.movementAllowed = true;
		}
	}

	private bool HitCtretureAndIsEnemyTeam(Collider2D collider)
	{
		if (!collider.TryGetComponent(out CreatureMovement creature))
			return false;

		if (creature.team == this.creature.team)
			return false;

		return true;
	}
	private bool HitScrutureAndIsEnemyTeam(Collider2D collider)
	{
		if (!collider.TryGetComponent(out Structure structure))
			return false;

		if (creature.team == structure.team)
			return false;

		return true;
	}
}
