using UnityEngine;

public class PlayerData : MonoBehaviour
{
    // Public Data
    public int coinsCollected;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Coin")
        {
            // add to our coin counter
            coinsCollected += 1;

            // make the coin disabled
            other.gameObject.SetActive(false);
        }
    }
}
