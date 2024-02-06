using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;

public abstract class ChampionStats : MonoBehaviour
{
	[Header("Level")]
	[SerializeField]
	private float exp = 0;
	public float levelRequirement = 5;
	public int level = 1;

	[Header("Health")]
	[SerializeField]
	private float health = 1;
	//[SerializeField]
	//private float healthRegn = 0;

	[Header("Mana")]
	[SerializeField]
	private int mana = 0;
	//[SerializeField]
	//private int manaRegn = 0;

	[Header("Damage")]
	[SerializeField]
	private float damage = 1;
	[SerializeField]
	private float attackSpeed = 0;
	[SerializeField]
	private float attackRange = 0.5f;

	[Header("Armor")]
	[SerializeField]
	private int armor = 0;
	[SerializeField]
	private int magicResist = 0;

	[Header("Crit")]
	[SerializeField]
	private int critChange = 15; // 15%
								 //[SerializeField]
								 //private int CritDamage = 2;

	[Header("Movement speed")]
	public bool movementAllowed = true;
	public float movementSpeed = 1;

	[Header("Team")]
	//public TeamManager teamManager;
	public Team team;

	//[Header("Game manager")]
	//public Gamemanager gamemanager

	//[Header("Shop items")]
	//List<ShopItem> items;

	public enum Team
	{
		Player,
		Enemy
	}
	public enum DamageType
	{
		TrueDamage,
		NormalDamage,
		MagicDamage
	}

	public void GetEXP(float exp)
	{
		this.exp += exp;
		while (this.exp > levelRequirement)
		{
			this.exp -= levelRequirement;
			//levelRequirement
			level++;
			LevelUP();
		}
	}
	public void LevelUP()
	{

	}
	public float GetHealth() => health;
	public float GetDamage() => damage;
	public float GetAttackSpeed() => attackSpeed;
	public float GetAttackRange() => attackRange;
	public float GetCritChange() => critChange;
	public int GetArmor() => armor;
	public int GetMana() => mana;

	public void ReciveDamage(float damage, DamageType type)
	{
		float realDamage;
		switch (type)
		{
			case DamageType.TrueDamage:
				realDamage = damage;
				break;
			case DamageType.NormalDamage:
				float damageRedution = armor;
				realDamage = damage * (1 - damageRedution);
				break;
			case DamageType.MagicDamage:
				float magicRedution = magicResist;
				realDamage = damage * (1 - magicRedution);
				break;
			default:
				realDamage = 0;
				break;
		}
		health -= realDamage;

		if (health <= 0)
		{
			Die();
		}
	}

	// Needs the shop!
	public void GetItem(/* ShopItem item */)
	{
		// stats need to be added;
		//items.Add(item);
	}
	public void RemoveItem(/* ShopItem item */)
	{
		// stats need to be removed;
		//items.RemoveAt(item);
	}

	protected abstract void Die();
}
