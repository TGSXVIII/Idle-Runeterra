using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CreatureInRange : MonoBehaviour
{
    public CreatureMovement creature;
	public List<CreatureMovement> InRange = new();

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (AllowMovement(collision, out CreatureMovement creature))
		{
			this.creature.movementAllowed = false;
			InRange.Add(creature);
		}
	}
	private void OnTriggerExit2D(Collider2D collision)
	{
		if (AllowMovement(collision, out CreatureMovement creature))
		{
			InRange.Remove(creature);
			if (InRange.Count <= 0)
			{
				this.creature.movementAllowed = true;
			}
		}
	}
	private bool AllowMovement(Collider2D collider, out CreatureMovement creatureToReturn)
	{
		creatureToReturn = null;
		if (!collider.TryGetComponent(out CreatureMovement creature))
			return false;

		if (creature.team == this.creature.team)
			return false;
		
		creatureToReturn = creature;
		return true;
	}
}
