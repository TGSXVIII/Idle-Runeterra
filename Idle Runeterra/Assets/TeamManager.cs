using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamManager : MonoBehaviour
{
    public GameObject spawnPoint;
    public GameObject nexus;
    public GameObject inhibiter;
    int gold;
    public List<tower> towers;
    public List<champion> champions;
    public List<minion> minions;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
//need to be replaced with refrences to the accual classes
public class tower
{
}

public class champion
{
    string name;
}

public class minion
{
}