using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ChampionStats;

public class TowerShoot : MonoBehaviour
{
    public Rigidbody2D rb;
    public float movementSpeed = 1;
    public Tower tower;
    public DamageType damageType;
    public Vector2 target;

    public void Spawned(Tower tower)
    {
        this.tower = tower;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!collision.TryGetComponent(out CreatureMovement creature))
           return;

        if (creature.team == tower.team)
            return;

        creature.ReciveDamage(tower.damage, damageType);
        Destroy(gameObject);
    }

    // Update is called once per frame
    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, movementSpeed * Time.deltaTime);
    }
}
