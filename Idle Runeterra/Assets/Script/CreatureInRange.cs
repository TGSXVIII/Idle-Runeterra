using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureInRange : MonoBehaviour
{
    public CreatureMovement creature;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		AllowMovement(collision);
	}
	private void OnTriggerExit2D(Collider2D collision)
	{
		AllowMovement(collision);
	}
	private void AllowMovement(Collider2D collider)
	{
		if (!collider.TryGetComponent(out CreatureMovement creature))
			return;

		if (creature.team == this.creature.team)
			return;

		Debug.Log(collider.name);
		creature.movementAllowed = !creature.movementAllowed;
	}
}
