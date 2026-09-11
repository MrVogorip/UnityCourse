using UnityEngine;

public class CanvasController : MonoBehaviour
{
    private CanvasGroup canvasGroup;
    
    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void ToggleCanvas(bool toggle)
    {
        canvasGroup.interactable = toggle;
        canvasGroup.blocksRaycasts = toggle;
        canvasGroup.alpha = toggle ? 1 : 0;
    }
}
