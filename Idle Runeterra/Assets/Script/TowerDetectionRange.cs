using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerDetectionRange : MonoBehaviour
{
    public List<CreatureMovement> creatureDetection;
    public Tower tower;

    /// <summary>
    /// Adds enemies into a list
    /// </summary>
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (!collider.gameObject.TryGetComponent(out CreatureMovement creature))
            return;

        if (tower.team == creature.team)
            return;

        else creatureDetection.Add(creature);
    }

    /// <summary>
    /// Removes enemies from the list
    /// </summary>
    private void OnTriggerExit2D(Collider2D collider)
    {
        if (!collider.gameObject.TryGetComponent(out CreatureMovement creature))
            return;

        if (tower.team == creature.team)
            return;

        else creatureDetection.Remove(creature);
    }
}
