using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationRandomizer : MonoBehaviour
{
    public List<GameObject> locationSpawnPoints;
    public List<GameObject> locationPrefabs;

    void Start()
    {
        SpawnLocations();
    }

    void SpawnLocations()
    {
        foreach (GameObject loc in locationSpawnPoints)
        {
            int random = Random.Range(0, locationPrefabs.Count);
            if (locationPrefabs[random] != null)
            {
                GameObject location = Instantiate(locationPrefabs[random], loc.transform.position, Quaternion.identity);
                location.transform.parent = loc.transform;
            }
        }
    }
}
