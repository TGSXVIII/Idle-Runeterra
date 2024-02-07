using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class Minions : CreatureMovement
{
	[Header("Exp Give")]
	public int expToGive = 0;
	
	[Header("Object and Scripts")]
	public GameObject weaponPoint;
	public CreatureInRange creatureInRange;
	public WeaponHitting sword;

	private AttackAnimation attackAnimation;
	private float timeToNextAttack = 0;
	private float animationLength;

	private enum AttackAnimation
	{
		Idle,
		AttackRight,
		AttackLeft,
	}

	public override void Spawn(Team team, TeamManager manager)
	{
		teamManager = manager;
		this.team = team;
		bool playerTeam = team == Team.Player;
		float x = weaponPoint.transform.localPosition.x * (playerTeam ? 1 : -1);
		weaponPoint.transform.localPosition = new Vector3(x, weaponPoint.transform.localPosition.y);
		attackAnimation = playerTeam ? AttackAnimation.AttackRight : AttackAnimation.AttackLeft;

		animationLength = animator.runtimeAnimatorController.animationClips.First(
			c => c.name.Contains(attackAnimation.ToString())
			).length;
	}

	private void Update()
	{
		if (timeToNextAttack >= 0)
		{
			timeToNextAttack -= Time.deltaTime;
		}
		if (timeToNextAttack <= 0 && creatureInRange.InRange.Count > 0)
		{
			timeToNextAttack = animationLength + GetAttackSpeed();
			BasicAttack();
		}
	}

	protected override void BasicAttack()
	{
		sword.GettingReady();
		animator.Play(attackAnimation.ToString());
	}

	protected override void Die()
	{
		// get right team...

		foreach (Champion champ in new List<Champion>())
		{
			champ.GetEXP(expToGive);
		}

		Destroy(gameObject);
	}
}
