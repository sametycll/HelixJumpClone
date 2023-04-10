using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HellixManager : MonoBehaviour
{
    [SerializeField] GameObject[] rings;
    [SerializeField] int countOfRings = 10;
    [SerializeField] float ringofDistance = 5f;
    float yPos;

    private void Start()
    {
        for (int i = 0; i < countOfRings; i++)
        {
            if (i ==0)
            {
                SpawnRings(0);
            }
            else
            {
                SpawnRings(Random.Range(1,rings.Length-1));
            }

        }
        SpawnRings(rings.Length-1);
    }

    void SpawnRings(int index)
    {
        GameObject newRing = Instantiate(rings[index], new Vector3(transform.position.x,yPos,transform.position.z),Quaternion.identity);
        yPos -= ringofDistance;
        newRing.transform.parent = transform;
    }

     


}
