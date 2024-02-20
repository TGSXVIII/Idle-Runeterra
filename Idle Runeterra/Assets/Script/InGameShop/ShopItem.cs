using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopItem : MonoBehaviour
{
	[Header("Shop stats")]
	[Space(5)]
	public bool unlocked = false;
	public int unlockAtLevel = 1;
	public int cost = 10;
	public Sprite icon;

	[Header("Camp. Stats")]
	public float health;
	public float healthRegn;
	
	[Space(10)]
	public float mana;
	public float manaRegn;
	
	[Space(10)]
	public float damage;
	public float attackSpeed;
	public float attackRange;

	[Space(10)]
	public int armor;
	public int magicResist;

	[Space(10)]
	public int critChange;
	public float critDamage;

	[Space(10)]
	public float movementSpeed;

	public enum State
	{
		Normal,
		Passive,
		Active
	}

	public virtual State GetState() => State.Normal;
}
