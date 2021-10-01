
using UnityEngine;

public class Decoration : MonoBehaviour
{

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            collision.gameObject.SetActive(false);
        }
    }
}
