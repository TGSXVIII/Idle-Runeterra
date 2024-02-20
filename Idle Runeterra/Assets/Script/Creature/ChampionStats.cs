using System;
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
	[SerializeField]
	private float healthRegn = 0;

	[Header("Mana")]
	[SerializeField]
	protected float mana = 0;
	[SerializeField]
	private float manaRegn = 0;

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
	[SerializeField]
	private float CritDamage = 2;

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

	[Header("Shop items")]
	public Dictionary<ShopItem.State, List<ShopItem>> items = new();

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
		items.TryAdd(ShopItem.State.Normal, new());
		items.TryAdd(ShopItem.State.Passive, new());
		items.TryAdd(ShopItem.State.Active, new());

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
	public float GetMana() => mana;
	public Dictionary<ShopItem.State, List<ShopItem>> GetItems() => items;
	public Sprite GetIcon() => icon;
	public void ReciveDamage(float damage, DamageType type)
	{
		health -= type switch { 
			DamageType.TrueDamage => damage,
			DamageType.NormalDamage => damage * (1 - armor),
			DamageType.MagicDamage => damage * (1 - magicResist),
			_ => 0,
		};
		
		if (health <= 0) Die();
	}

	public void AddItem(ShopItem item)
	{
		ItemRemovedOrAdded(item, true);
		items[item.GetState()].Add(item);
	}
	public void RemoveItem(ShopItem item)
	{
		ItemRemovedOrAdded(item, false);
		items[item.GetState()].Remove(item);
	}

	private void ItemRemovedOrAdded(ShopItem item, bool added)
	{
		int addOrRemove = added ? 1 : -1;
		health += item.health * addOrRemove;
		healthRegn += item.healthRegn * addOrRemove;
		mana += item.mana * addOrRemove;
		manaRegn += item.manaRegn * addOrRemove;
		damage += item.damage * addOrRemove;
		attackSpeed += item.attackSpeed * addOrRemove;
		attackRange += item.attackRange * addOrRemove;
		armor += item.armor * addOrRemove;
		magicResist += item.magicResist * addOrRemove;
		critChange += item.critChange * addOrRemove;
		CritDamage += item.critDamage * addOrRemove;
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
