using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetSpawner : MonoBehaviour
{
    public GameObject[] prefab;
    public uint offset = 200;

    public uint sizeX = 30;
    public uint sizeY = 30;
    public uint sizeZ = 30;
    void Start()
    {
        var posOffset = new Vector3(sizeX / 2 * offset , sizeY / 2 * offset, sizeZ / 2 * offset);
        for (int i = 0; i < sizeX; i++)
            for (int j = 0; j < sizeY; j++)
                for (int k = 0; k < sizeZ; k++)
                {
                    var index = (int)Random.Range(-prefab.Length / 2, prefab.Length);
                    if (index < 0)
                        continue;
                    var pos = new Vector3
                        (i * offset + Random.Range(0, offset/2),
                        j * offset + Random.Range(0, offset/2),
                        k * offset + Random.Range(0, offset/2));
                    Instantiate(prefab[index], pos - posOffset, Quaternion.identity);
                }
    }

}
