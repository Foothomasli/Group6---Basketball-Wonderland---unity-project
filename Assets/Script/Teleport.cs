using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TeleportByClick : MonoBehaviour
{
    public Transform teleportPointA; // 第一个传送点
    public Transform teleportPointB; // 第二个传送点

    private bool isAtPointA = true;

    public void OnTeleport()
    {
        // 切换传送位置
        Transform targetPoint = isAtPointA ? teleportPointB : teleportPointA;
        transform.position = targetPoint.position;
        transform.rotation = targetPoint.rotation;

        Debug.Log($"Teleported to {targetPoint.name}");
        isAtPointA = !isAtPointA;
    }
}
