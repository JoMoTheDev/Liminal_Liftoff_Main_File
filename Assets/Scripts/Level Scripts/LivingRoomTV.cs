using UnityEngine;

public class LivingRoomTV : MonoBehaviour
{
    public GameObject enemy;
    public GameObject mainDoor;
    public bool isOn;


    public void ActivateEnemy()
    {
        if (isOn)
        {
            enemy.SetActive(true);
            mainDoor.SetActive(false);
        }
    }
}
