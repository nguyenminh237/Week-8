using UnityEngine;

public class EnterGame : MonoBehaviour
{
    // Canvas popup se duoc gan o giai doan 4
    public Canvas GameMenu;

    private bool hasTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        // Tim script dieu khien may bay
        AirplaneController airplane =
            other.GetComponentInParent<AirplaneController>();

        // Neu doi tuong khong phai may bay
        if (airplane == null)
            return;

        // Kiem tra Tag Player
        if (!airplane.CompareTag("Player"))
            return;

        // Kiem tra may bay da cat canh chua
        if (!airplane.HasTakenOff)
        {
            Debug.Log("May bay chua cat canh!");
            return;
        }

        // Tranh kich hoat nhieu lan
        if (hasTriggered)
            return;

        hasTriggered = true;

        Debug.Log("May bay da cat canh va cham EnterWall!");

        // Hien thi Popup neu da gan Canvas
        if (GameMenu != null)
        {
            GameMenu.enabled = true;
        }
    }
}
