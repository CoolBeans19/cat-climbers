using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSpawn : MonoBehaviour
{

    // Rock prefab, spawn these
    public GameObject rock;

    // Players, keep track of their position to make sure
    public Transform player1;
    public Transform player2;

    // Variables to determine the time interval 
    public float maxTime;
    public float minTime;
    private int currentOdds;
    public int[] oddsAtDifficulty;

    // Variables to determine the distance from players on spawn
    public float xBuffer;

    private float currentTime;

    // Queue to hold rock prefabs
    private Queue<GameObject> rockQueue;
    private GameObject temp;

    // Use this for initialization
    void Start()
    {
        currentOdds = oddsAtDifficulty[0];
        currentTime = 0;
        DifficultyManager.inst.onDifficultyChange.AddListener(SetDifficulty);

        rockQueue = new Queue<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTime > 0.25f) // spawner ticks 4 times a second
        {
            CheckSpawn();
            currentTime = currentTime - 0.25f;
        }

        currentTime += Time.deltaTime;
    }

    private void CheckSpawn()
    {
        // Check if the minimum amount of time has passed to spawn the rock

        // Once the minimum time has been reached, the chances of a rock spawning start increasing
        //if (Random.Range(currentTime - minTime, currentTime) > minTime)
        if(Random.Range(0,currentOdds) == 0)
        {
            /*
            <make big boy game>
                //activate
                    <syntax>:^)
            */


            // Rock is spawned
            StartCoroutine(SpawnRock());
            // Time is reset
        }
    }

    // Used for spawning a new rock in the scene above a player
    IEnumerator SpawnRock()
    {

        // Initialize new spawn position vector
        Vector3 spawnPos = Vector3.zero;

        // Randomize which player the rock will spawn on
        if (Random.Range(0f, 1f) < 0.5f)
        {
            // Calculate new vector for the spawn position, adding a random offset to the x position
            spawnPos = new Vector3(player1.position.x + (Random.Range(-1f, 1f) * xBuffer),
                //player1.position.y + yBuffer,
                Camera.main.transform.position.y + Camera.main.orthographicSize + 10,
                0f);
        }
        else
        {
            spawnPos = new Vector3(player2.position.x + (Random.Range(-1f, 1f) * xBuffer),
                //player2.position.y + yBuffer,
                Camera.main.transform.position.y + Camera.main.orthographicSize + 5,
                0f);
        }

        // Create warning particles
        ParticleManager.inst.Spawn(ParticleManager.inst.gravelParticle, spawnPos);

        yield return new WaitForSeconds(1.0f);

        // Instantiate a new rock object
        temp = Instantiate(rock, spawnPos, Quaternion.identity);

        rockQueue.Enqueue(temp);

        yield return new WaitForSeconds(5.0f);

        DestroyRock();
    }

    private void DestroyRock()
    {
        GameObject.Destroy(rockQueue.Dequeue());

    }

    public void SetDifficulty(int difficulty)
    {
        if (difficulty >= oddsAtDifficulty.Length)
            difficulty = oddsAtDifficulty.Length - 1;
        if (difficulty < 0)
            difficulty = 0;
        currentOdds = oddsAtDifficulty[difficulty];
    }



}
