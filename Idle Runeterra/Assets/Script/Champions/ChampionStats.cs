using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.Search;
using UnityEngine;

public abstract class ChampionStats : MonoBehaviour
{
	[Header("Level")]
	[SerializeField]
	protected float exp = 0;
	public float levelRequirement = 5;
	public int level = 1;

	[Header("Health")]
	[SerializeField]
	protected float health = 1;
	//[SerializeField]
	//private float healthRegn = 0;

	[Header("Mana")]
	[SerializeField]
	protected int mana = 0;
	//[SerializeField]
	//private int manaRegn = 0;

	[Header("Damage")]
	[SerializeField]
	protected float damage = 1;
	[SerializeField]
	protected float attackSpeed = 1;
	protected float nextAttackIn = 0;
	[SerializeField]
	protected float attackRange = 0.5f;

	[Header("Armor")]
	[SerializeField]
	protected int armor = 0;
	[SerializeField]
	protected int magicResist = 0;

	[Header("Crit")]
	[SerializeField]
	[Tooltip("This is in %. 1 = 1%")]
	protected int critChange = 15; // 15%
								 //[SerializeField]
								 //private int CritDamage = 2;

	[Header("Movement speed")]
	public bool movementAllowed = true;
	public float movementSpeed = 1;

	[Header("Exp Give")]
	public int expToGive = 0;
	public int goldFromDeath = 0;

	[Header("Team")]
	public bool isAlive = true;
	public TeamManager teamManager;
	public Team team;
	private GameManager gameManager;
	[SerializeField]
	protected Sprite icon;

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

	private void Awake()
	{
		gameManager = GameObject.FindWithTag("GameController").GetComponent<GameManager>();
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
	public abstract void LevelUP();

	public float GetHealth() => health;
	public float GetDamage() => damage;
	public float GetAttackSpeed() => attackSpeed;
	public float GetAttackRange() => attackRange;
	public float GetCritChange() => critChange;
	public int GetArmor() => armor;
	public int GetMana() => mana;
	public Sprite GetIcon() => icon;
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

	protected virtual void Die()
	{
		TeamManager enemyTeam = gameManager.GetEnemyTeam(team);
		enemyTeam.gold += goldFromDeath;
		foreach (Champion champ in enemyTeam.champions.Where(c => c.isAlive))
		{
			champ.GetEXP(expToGive);
		}
	}
}
