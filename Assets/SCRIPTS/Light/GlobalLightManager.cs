using UnityEngine;

public class GlobalLightManager : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Vector3 offset;

    void Update()
    {
        transform.position = player.position + offset;
    }
}
