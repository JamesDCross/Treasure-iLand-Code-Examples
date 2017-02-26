using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class SpawnerExample : MonoBehaviour
{
    public int randTreasure;
    public GameObject[] treasures;
    public Vector3 spawnValues;
    public int amountOfChestsToSpawn = 5;
    public float chestToChestRange = 1f;
    public float scatterDistance = 4f;
    public float depth = 0;
    Vector2 spawnPosition;
    GameObject chest;
    public List<GameObject> positions = new List<GameObject>();

    /*so for the moment conflicts are just deleted -which is fine
     as the amount of chests is random also*/

    /*Spawning the chests(treasures) into a list and checking their positions realtive to each other
     * If one chest is in range of 1f of another chest the chest is then destroyed. This means there
     * are no chests on top of each other or to close, which is not good for the gameplay.
     */

    void compareVectors()
    {
        //compare every chests vector2's x and y (absolute value) to every other with a range of some given number (chestToChestRange)
        for (int i = 0; i < positions.Count - 1; i++)
        {
            Debug.Log("i " + positions[i].transform.position.x);

            for (int j = i + 1; j < positions.Count; j++)
            {
                float ix = Mathf.Abs(positions[i].transform.position.x);
                float jx = Mathf.Abs(positions[j].transform.position.x);
                float iy = Mathf.Abs(positions[i].transform.position.y);
                float jy = Mathf.Abs(positions[j].transform.position.y);

                //if the condition is met
                //destroy
                //make a new one
                //check everything in the list again
                if (ix >= jx - chestToChestRange && ix <= jx + chestToChestRange && iy >= jy - chestToChestRange && iy <= jy + chestToChestRange)
                { 
                    Destroy(positions[i]); 
                }
            }
        }

    }

    void Start()
    {
        while (amountOfChestsToSpawn > 0)
        { 
            //spawn a chest randomly with a certain scatter distance  
            spawnPosition = new Vector2((Random.Range(-2f, 2f)) * scatterDistance, (Random.Range(-2f, 2f)) * scatterDistance);
            //make an object of type Treasure
            chest = Instantiate(treasures[0], spawnPosition, Quaternion.identity) as GameObject;
            //store the positions in a list
            positions.Add(chest);
            amountOfChestsToSpawn--;
        }
        compareVectors();
    }

}
