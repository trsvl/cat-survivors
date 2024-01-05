using UnityEngine;

public class Experience : MonoBehaviour
{
    [SerializeField] private int numberExp;
    public void PickUpExp(bool taken)
    {
        if (taken)
        {
            Destroy(gameObject);
            CountExperience exp = FindObjectOfType<CountExperience>();

            if (exp != null)
            {
                exp.UpdateExpCount(numberExp);
            }
        }
    }
}
