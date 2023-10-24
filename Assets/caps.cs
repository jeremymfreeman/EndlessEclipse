using UnityEngine;

public class Caps : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
        Debug.Log("You are killed by your enemy!");
    }
}
