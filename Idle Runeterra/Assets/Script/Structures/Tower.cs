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
    public float attackSpeedMultiplier = 1.0f; // Default multiplier

    public BoxCollider2D boxCollider2D;
    public TowerDetectionRange DetectionRange;
    public Transform TowerShootSpawnLocation;
    public GameObject towerShotsPreFab;

    private bool isTargeting = false;
    private GameObject currentTarget;

    private void Update()
    {
        if (timeToNextAttack > 0)
        {
            timeToNextAttack -= Time.deltaTime;
        }

        if (!isTargeting && DetectionRange.creatureDetection.Count > 0)
        {
            StartCoroutine(TargetAndAttack());
        }
    }

    private IEnumerator TargetAndAttack()
    {
        isTargeting = true;
        yield return new WaitForSeconds(targetingTime);

        if (DetectionRange.creatureDetection.Count > 0)
        {
            currentTarget = DetectionRange.creatureDetection[0].gameObject;
            Attack();
        }

        isTargeting = false;
    }

    private void Attack()
    {
        // Adjust attack speed based on multiplier
        float adjustedAttackCooldown = attackCooldown / (attackSpeed * attackSpeedMultiplier);

        GameObject shoot = Instantiate(towerShotsPreFab, TowerShootSpawnLocation.position, TowerShootSpawnLocation.rotation);
        shoot.GetComponent<TowerShoot>().Spawned(this, currentTarget.transform.position);
        timeToNextAttack = adjustedAttackCooldown;
    }

#if UNITY_EDITOR
    private void OnValidate()
    {
        boxCollider2D.edgeRadius = attackRange;
    }
#endif
}
