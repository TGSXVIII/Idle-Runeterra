using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : Structure
{
    public float attackRange = 10;
    public float attackSpeed = 1;
    public float damage = 8;
    public BoxCollider2D boxCollider2D;

    // Update is called once per frame
    void Update()
    {

    }

#if UNITY_EDITOR
        private void OnValidate()
        {
            boxCollider2D.edgeRadius = attackRange;
        }
#endif
}
