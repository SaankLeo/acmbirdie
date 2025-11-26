using System.Collections;
using UnityEngine;

public class EnableBuildingDynamics : MonoBehaviour
{
    // Drag the parent object that holds all your bricks into this slot in Inspector
    public Transform buildingRoot;

    public float delay = 0.1f;

    // This function is called by the Samosa when it launches
    public void OnProjectileLaunched()
    {
        StartCoroutine(EnableAfterDelay());
    }

    IEnumerator EnableAfterDelay()
    {
        // Wait a split second so the building doesn't collapse before the hit
        yield return new WaitForSeconds(delay);

        if (buildingRoot != null)
        {
            // Find every brick inside the building and turn on Physics
            Rigidbody2D[] rbs = buildingRoot.GetComponentsInChildren<Rigidbody2D>();
            foreach (Rigidbody2D rb in rbs)
            {
                rb.bodyType = RigidbodyType2D.Dynamic;
            }
        }
    }
}