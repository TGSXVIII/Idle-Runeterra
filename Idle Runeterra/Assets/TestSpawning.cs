using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSpawning : MonoBehaviour
{
	public List<GameObject> minion;
	public ChampionStats.Team Team;

	private void Awake()
	{
		int n = minion.Count;
		while (n > 1)
		{
			n--;
			int k = Random.Range(0, n + 1);
			(minion[n], minion[k]) = (minion[k], minion[n]);
		}
	}

	public void Update()
	{
		if (Input.anyKeyDown)
		{
			StartCoroutine(Spawn());
		}
	}
	private IEnumerator Spawn()
	{
		foreach (var item in minion)
		{
			GameObject creature = Instantiate(item, transform.position, transform.rotation);
			if (creature.TryGetComponent(out Minions minion))
			{
				minion.Spawn(Team, new(new()));
			}
			yield return new WaitForSeconds(1);
		}
		Destroy(gameObject);
	}
}
