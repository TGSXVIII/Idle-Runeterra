using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : Structure
{
    public float attackSpeed = 1;
    public float attackRange = 10;
    public float attackCooldown = 1;
    public float timeToNextAttack = 1;
    public float targetingTime = 1;
    
    public float damage = 8;
    public float damageMultiplier = 0;
    
    public BoxCollider2D boxCollider2D;
    public TowerDetectionRange DetectionRange;
    public Transform TowerShootSpawnLocation;
    public GameObject towerShotsPreFab;

    // ADD SOMEHOW
    //timeToNextAttack += targetingTime;

    //damage += damageMultiplier;

    private void Update()
    {
        //if ("inside radious" && targetingTime <= 0)
        //{        
            if (timeToNextAttack >= 0)
            {
                timeToNextAttack -= Time.deltaTime;
            }
            if (timeToNextAttack <= 0 && DetectionRange.creatureDetection.Count > 0)
            {
                timeToNextAttack = attackCooldown;
                Attack();
            }
            // if (timeToNextAttack <= 0 && DetectionRange.creatureDetection.Count > 0 && "Has been hit before" "add damage multiplier")
            //{

            //}
        //}
    }

    private void Attack()
    {
        GameObject shoot = Instantiate(towerShotsPreFab, TowerShootSpawnLocation.position, TowerShootSpawnLocation.rotation);
        shoot.GetComponent<TowerShoot>().Spawned(this, DetectionRange.creatureDetection[0].transform.position);
    }

#if UNITY_EDITOR
    private void OnValidate()
        {
            boxCollider2D.edgeRadius = attackRange;
        }
#endif
}
