using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class Minions : CreatureMovement
{
	[Header("Attack method")]
	public CreatureInRange creatureInRange;
	public WeaponHitting weapon;
	[Tooltip("Only change this if you don't have \"Attack\" in your animation name.")]
	public string AttackAnimationName = "Attack";

	private float timeToNextAttack = 0;
	private float animationLength;

	public override void Spawn(Team team, TeamManager manager)
	{
		teamManager = manager;
		this.team = team;
		bool playerTeam = team == Team.Player;
		transform.Rotate(0, playerTeam ? 0 : 180, 0);
		animationLength = animator.runtimeAnimatorController.animationClips.First(
			c => c.name.Contains(AttackAnimationName)
			).length;
	}

	private void Update()
	{
		if (timeToNextAttack >= 0)
		{
			timeToNextAttack -= Time.deltaTime;
		}
		if (timeToNextAttack <= 0 && creatureInRange.targetsInRange.Count > 0)
		{
			timeToNextAttack = animationLength + GetAttackSpeed();
			BasicAttack();
		}
	}

	protected override void BasicAttack()
	{
		animator.SetTrigger("Attack");
	}

	public void ReadierOrShooting()
	{
		weapon.ReadierOrShooting();
	}

	protected override void Die()
	{
		base.Die();
		Destroy(gameObject);
	}

	public override void LevelUP()
	{
		throw new System.NotImplementedException();
	}
}
