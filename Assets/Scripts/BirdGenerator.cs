using UnityEngine;

public class BirdGenerator : MonoBehaviour
{
    [Header("Generation Params")]
    [SerializeField] private float minimumX = -4f;
    [SerializeField] private float maximumX = 4f;
    [SerializeField] private float minimumY = -5f;
    [SerializeField] private float maximumY = 5f;

    [SerializeField] private GameObject objectToSpawn;
    [SerializeField] private int numToGenerate = 20;

    [ContextMenu("Generate")]
    public void Generate() {
        for (int i = 0; i < numToGenerate; i++) {
            // determine the bird's new position
            float xOffset = Random.Range(minimumX, maximumX);
            float yOffset = Random.Range(minimumY, maximumY);
            Vector3 newPosition = transform.position +
                new Vector3(xOffset, yOffset, 0f);

            // generate a new bird 
            var newBird = Instantiate(objectToSpawn, newPosition, Quaternion.identity, transform);

        }
    }
}
