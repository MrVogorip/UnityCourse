using TMPro;
using UnityEngine;

public class DeleteZone : MonoBehaviour
{
    public TMP_Text text;
    public int counter;
    
    public void OnTriggerEnter(Collider other)
    {
        var box = other.gameObject.GetComponent<BoxController>();
        if (box == null)
            return;
        
        counter++;
        text.SetText($"Destroyed box: {counter}");
        Destroy(box.gameObject);
    }
}
