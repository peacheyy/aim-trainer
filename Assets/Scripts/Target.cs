using UnityEngine;

public class Target : MonoBehaviour
{
    private void OnMouseDown()
    {
        Destroy(gameObject); // Destroy the target when clicked
        TargetController.Instance.SpawnTarget(); // Ask the controller to spawn a new target
        TargetController.Instance.TargetDestroyed(); // Inform controller that target was destroyed
    }
}
