using UnityEngine;
using UnityEngine.UI;

public class ToggleTextOnClick : MonoBehaviour
{
    public GameObject infoText;

    private bool isShowing = false;

    public void ToggleText()
    {
        isShowing = !isShowing;
        infoText.SetActive(isShowing);
    }
}
