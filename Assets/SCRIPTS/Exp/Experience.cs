using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Experience : MonoBehaviour
{

    public void PickUpExp(bool taken)
    {

        if (taken)
        {
            Destroy(gameObject);
            CountExperience exp = FindObjectOfType<CountExperience>();

            if (exp != null)
            {
                exp.UpdateExpCount(1);
            }
        }
    }
}
