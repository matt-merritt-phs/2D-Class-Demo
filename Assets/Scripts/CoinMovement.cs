using UnityEngine;

public class CoinMovement : MonoBehaviour
{
    public Vector3 initialPosition;
    public float amplitude;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // set our new position to be our starting position, and then move up or down based on the sine wave
        transform.position = initialPosition + Vector3.up * Mathf.Sin(Time.time) * amplitude;
    }
}
