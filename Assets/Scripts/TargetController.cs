using UnityEngine;
using TMPro;

public class TargetController : MonoBehaviour {

    public static TargetController Instance;

    public GameObject targetPrefab; // Assign the target prefab in the Unity editor
    public TextMeshProUGUI hitCountText; // Assign the TextMeshPro text to display hit count
    public TextMeshProUGUI missCountText;

    private int hitCount = 0;
    private int missCount = 0;

    void Start() {
        UpdateHitCountText();
        UpdateMissCountText();
        SpawnTarget();
    }

    void Update() {
        Instance = this;
        CheckForMiss();
    }

    private Vector3 GetRandomPosition() {
        // Get the size of the object
        float objectWidth = targetPrefab.GetComponent<SpriteRenderer>().bounds.size.x; 
        float objectHeight = targetPrefab.GetComponent<SpriteRenderer>().bounds.size.y; 

        // Get the size of the screen in world coordinates
        Vector2 screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        // Define the boundaries for the random position
        float randomX = Random.Range(-screenBounds.x + objectWidth / 2, screenBounds.x - objectWidth / 2);
        float randomY = Random.Range(-screenBounds.y + objectHeight / 2, screenBounds.y - objectHeight / 2);

        // Create the random position
        Vector2 randomPosition = new Vector3(randomX, randomY, 0);

        return randomPosition;
    }

    public void SpawnTarget() {
        Instantiate(targetPrefab, GetRandomPosition(), Quaternion.identity);
    }

    private void CheckForMiss() {
    // Check for mouse click or touch input
    if (Input.GetMouseButtonDown(0)) {
        // Cast a ray from the mouse position
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;

        // Perform the raycast
        if (Physics.Raycast(ray, out hitInfo)) {
            // Check if the hit object is not the target
            if(hitInfo.collider.gameObject != targetPrefab) {
                // Increment the miss count if the hit object is not the target
                missCount++;
                UpdateMissCountText(); // Update miss count text
            }
        } 
        else {
            // If no object is hit, increment the miss count
            missCount++;
            UpdateMissCountText(); // Update miss count text
            }
        }
    }   

    public void TargetDestroyed() {
        hitCount++; // Increment hit count
        UpdateHitCountText();
    }

    void UpdateHitCountText() {
        if (hitCountText != null) {
            hitCountText.text = "Hits: " + hitCount.ToString();
        }
    }

    void UpdateMissCountText() {
        if (missCountText != null) {
            missCountText.text = "Misses: " + missCount.ToString();
        }
    }
}
