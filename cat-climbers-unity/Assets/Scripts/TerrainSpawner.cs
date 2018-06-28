using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainSpawner : MonoBehaviour {
    public GameObject[] piecePrefabs;
    public LinkedList<GameObject> piecePool;

    private float maxGenHeight;
    private float currentGenHeight;
    private float gapFactor = 1.7f;

    private void Awake()
    {
        piecePool = new LinkedList<GameObject>();
        currentGenHeight = Camera.main.transform.position.y - Camera.main.orthographicSize - 10; ;
        maxGenHeight = Camera.main.transform.position.y + Camera.main.orthographicSize + 10;
        for (int i = 0; i < 100; i++)
        {
            GameObject t = Instantiate(piecePrefabs[Random.Range(0, piecePrefabs.Length)]);
            t.SetActive(false);
            piecePool.AddFirst(t);
        }
        
    }

    private void Update()
    {
        maxGenHeight = Camera.main.transform.position.y + Camera.main.orthographicSize + 10;

        if (currentGenHeight < maxGenHeight)
        {
            SpawnPiece(currentGenHeight);
        }
    }


    public void SpawnPiece(float y)
    {
        GameObject g = FetchPiece();
        g.SetActive(true);
        g.transform.position = new Vector3(Random.Range(-10, 10), y);
        g.transform.rotation = Quaternion.AngleAxis(Random.Range(0, 360), Vector3.forward);
        float scale = Random.Range(1f, 2.5f);
        g.transform.localScale = new Vector3(scale,scale,1);
        currentGenHeight = currentGenHeight + scale * gapFactor;
    }

    private GameObject FetchPiece()
    {

        GameObject g = piecePool.Last.Value;
        piecePool.RemoveLast();
        piecePool.AddFirst(g);
        return g;
    }



}
