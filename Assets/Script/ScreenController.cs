using UnityEngine;
using UnityEngine.Video;
using UnityEngine.XR.Interaction.Toolkit;

public class VideoScreenController : MonoBehaviour
{
    [SerializeField] private VideoPlayer videoPlayer;
    [SerializeField] private XRSimpleInteractable simpleInteractable;
    
    private void Awake()
    {
               
        if (simpleInteractable != null)
        {
            simpleInteractable.selectEntered.AddListener(OnSelectEntered);
        }
    }

    private void OnDestroy()
    {
        if (simpleInteractable != null)
        {
            simpleInteractable.selectEntered.RemoveListener(OnSelectEntered);
        }
    }

    private void OnSelectEntered(SelectEnterEventArgs args)
    {
        
        if (videoPlayer != null)
        {
            if (videoPlayer.isPlaying)
            {
                videoPlayer.Pause();
                Debug.Log("Video Paused");
            }
            else
            {
                videoPlayer.Play();
                Debug.Log("Video Playing");
            }
        }
    }
}
