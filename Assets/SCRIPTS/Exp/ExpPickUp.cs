using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpPickUp : MonoBehaviour
{
private void OnCollisionEnter2D(Collision2D collision)
{
    if (collision.gameObject.TryGetComponent<Experience>(out Experience CountExperience))
    {
            CountExperience.PickUpExp(true);
    }
}

}
