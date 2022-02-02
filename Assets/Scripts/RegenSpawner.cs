using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegenSpawner : MonoBehaviour
{
    [SerializeField] Vector2 timeBetweenSpawn;
    [SerializeField] float destroyAfter = 2.3f;

    [SerializeField] GameObject itemToSpawn; //Add multiple items and randomize between which to spawn using arrays

    Transform pos;

    void Start()
    {
        pos = this.GetComponent<Transform>();
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        while(true){
            yield return new WaitForSeconds(Random.Range(timeBetweenSpawn.x, timeBetweenSpawn.y));
            GameObject enemy = Instantiate(itemToSpawn, pos.position, Quaternion.identity);
            Destroy(enemy, destroyAfter);
        }
    }
}
