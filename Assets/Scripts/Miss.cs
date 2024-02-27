using UnityEngine;

public class Miss : MonoBehaviour
{
    private void OnMouseDown()
    {
        GameController.Instance.TargetMissed();
    }
}