using UnityEngine;

public class Target : MonoBehaviour
{
    private void OnMouseDown()
    {
        Destroy(gameObject); // Destroy the target when clicked
        GameController.Instance.SpawnTarget(); // Ask the controller to spawn a new target
        GameController.Instance.TargetDestroyed(); // Inform controller that target was destroyed
    }
}
