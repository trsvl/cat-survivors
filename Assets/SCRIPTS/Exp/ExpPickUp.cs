using UnityEngine;

public class ExpPickUp : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Experience"))
        {
            Experience exp = collision.gameObject.GetComponent<Experience>();
            exp.PickUpExp(true);
        }
    }
}
