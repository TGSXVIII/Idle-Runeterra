using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minions : CreatureMovement
{
	[Header("Exp Give")]
	public int expToGive = 0;

	protected override void BasicAttack()
	{
	}

	protected override void Die()
	{
		// get right team...

		foreach (Champion champ in new List<Champion>())
		{
			champ.GetEXP(expToGive);
		}
	}
}
