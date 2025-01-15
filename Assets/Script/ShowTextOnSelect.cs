using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ShowTextOnSelect : MonoBehaviour
{
    // 在 Inspector 中拖拽一个要显示的文本对象 (World-Space Canvas 或 3D Text)
    public GameObject textObject;

    // 缓存 XR Interactable 引用
    private XRBaseInteractable interactable;

    // 用于追踪文本可见性
    private bool isVisible = false;

    private void Awake()
    {
        // 获取同一物体上的 XRBaseInteractable (或 XRSimpleInteractable)
        interactable = GetComponent<XRBaseInteractable>();

        // 订阅事件
        interactable.selectEntered.AddListener(OnSelectEntered);

        // 如果初始想隐藏文本，可在这里设
        if (textObject != null) 
        {
            textObject.SetActive(false);
        }
    }

    private void OnDestroy()
    {
        // 取消订阅，避免潜在空引用
        interactable.selectEntered.RemoveListener(OnSelectEntered);
    }

    // 当 XR 射线按下"Select"键时，切换文本可视性
    private void OnSelectEntered(SelectEnterEventArgs args)
    {
        if (textObject != null)
        {
            // 切换可见状态
            isVisible = !isVisible;
            textObject.SetActive(isVisible);
        }
    }
}
