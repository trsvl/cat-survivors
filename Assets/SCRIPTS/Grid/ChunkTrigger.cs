using UnityEngine;

public class ChunkTrigger : MonoBehaviour
{
    MapController mapController;
    [SerializeField] private GameObject targetMap;

    void Start()
    {
        mapController = FindObjectOfType<MapController>();
    }
    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            mapController.CurrentChunk = targetMap;
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            if (mapController.CurrentChunk == targetMap)
            {
                mapController.CurrentChunk = null;
            }
        }
    }
}
