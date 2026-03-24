using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public int coinsCollected;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Coin")
        {
            // add one to our coin counter
            coinsCollected += 1;

            // disables the coin, making it invisible
            other.gameObject.SetActive(false);

            // completely remove the coin
            Destroy(other.gameObject);
        }
    }
}
