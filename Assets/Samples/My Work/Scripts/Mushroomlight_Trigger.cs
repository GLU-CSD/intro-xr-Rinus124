using UnityEngine;

public class Mushroomlight_Trigger : MonoBehaviour
{
    [SerializeField] private Light Mushroom;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Mushroom.enabled = true;
            Debug.Log("Licht aan");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Mushroom.enabled = false;
            Debug.Log("Licht uit");
        }
    }
}

