using UnityEngine;

public class RespawnCoins : MonoBehaviour
{
    public Vector3 coinSpawn1, coinSpawn2, coinSpawn3, coinSpawn4;
    public GameObject coinPrefab;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Instantiate(coinPrefab, coinSpawn1, Quaternion.identity);
            Instantiate(coinPrefab, coinSpawn2, Quaternion.identity);
            Instantiate(coinPrefab, coinSpawn3, Quaternion.identity);
            Instantiate(coinPrefab, coinSpawn4, Quaternion.identity);
        }
    }
}
