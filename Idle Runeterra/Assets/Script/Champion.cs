using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Champion : CreatureMovement
{
	[Header("Champion")]
	public string ChanmpionName = "Bob";

	public Faction faction = Faction.none;
	public enum Faction
	{
		none,
		FirstFaction,
		SecondFaction,
	}

	protected override void Die()
	{
		// needs to say to team manager that i died.
		Destroy(gameObject);
	}

	protected abstract void Ultimate();
	protected abstract void ActiveAbility();
	protected abstract void PassiveAbility();
}
