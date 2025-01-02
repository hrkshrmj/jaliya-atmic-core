using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject[] prefab;
    [SerializeField] private Vector2[] spawnPositions;
    [SerializeField] private float spawnStartDelay;
    [SerializeField] private float spawnInterval;
    private AnimationCurve spawnFrequency;
    private Keyframe[] ks;

    private int randomSpawnIndex;

    void Start()
    {
        InvokeRepeating("SpawnEnemy", spawnStartDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {       
        if (GameManager.Singleton.isGameActive == false)
        {
            CancelInvoke();
        }
    }

    void SpawnEnemy()
    {
        randomSpawnIndex = Random.Range(0, spawnPositions.Length);
        GameObject enemyClone = Instantiate(prefab[randomSpawnIndex], spawnPositions[randomSpawnIndex], prefab[randomSpawnIndex].transform.rotation);
       // enemyClone.GetComponent<MovementManager>().moveSpeed = spawnFrequency.Evaluate(Time.time) % 10f;
    }

   void SpawnCurve()
    {
       

        ks = new Keyframe[50];
        for (var i = 0; i<ks.Length; i++)
        {
            ks[i] = new Keyframe(i, Mathf.Sin(i) + 0.3f * i, 90, 90);
        }
        spawnFrequency = new AnimationCurve(ks);
    }

    /* three different Prefabs, for each lane
     * three different spawnPositions, abstracted into lanes
     * make colliders and Raycast2D of each Prefab to only include layerMask of Player and other Enemies on the same layerMask     
     */
}
