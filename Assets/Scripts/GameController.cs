using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour {

    public static GameController Instance;

    public GameObject targetPrefab;
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
    }

    private Vector3 GetRandomPosition() {
        // Get the size of the object
        float objectWidth = targetPrefab.GetComponent<SpriteRenderer>().bounds.size.x; 
        float objectHeight = targetPrefab.GetComponent<SpriteRenderer>().bounds.size.y; 

        // Get the size of the screen in world coordinates
        Vector3 screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        // Define the boundaries for the random position
        float randomX = Random.Range(-screenBounds.x + objectWidth / 2, screenBounds.x - objectWidth / 2);
        float randomY = Random.Range(-screenBounds.y + objectHeight / 2, screenBounds.y - objectHeight / 2);

        // Create the random position
        Vector3 randomPosition = new Vector3(randomX, randomY, 0);

        return randomPosition;
    }

    public void SpawnTarget() {
        Instantiate(targetPrefab, GetRandomPosition(), Quaternion.identity);
    }

    public void TargetDestroyed() {
        hitCount++; // Increment hit count
        UpdateHitCountText();
    }

    public void TargetMissed() {
        missCount++;
        UpdateMissCountText();
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
