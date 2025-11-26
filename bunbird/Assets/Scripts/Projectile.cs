using System.Collections;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpringJoint2D springJoint;
    private bool isPressed;

    [SerializeField] private float releaseDelay = 0.15f;

    [Header("Power Settings")]
    [SerializeField] private float launchBoost = 2f;

    // --- THE FIX IS HERE ---
    // We changed "Building" to "EnableBuildingDynamics"
    public EnableBuildingDynamics buildingPhysicsScript;
    // -----------------------

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        springJoint = GetComponent<SpringJoint2D>();
    }

    void Update()
    {
        if (isPressed)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0f;
            rb.position = mousePos;
        }
    }

    private void OnMouseDown()
    {
        isPressed = true;
        rb.isKinematic = true;
    }

    private void OnMouseUp()
    {
        isPressed = false;
        rb.isKinematic = false;
        StartCoroutine(Release());
    }

    IEnumerator Release()
    {
        yield return new WaitForSeconds(releaseDelay);

        springJoint.enabled = false;

        // Apply the Boost
        rb.velocity = rb.velocity * launchBoost;

        // Trigger the crash physics
        if (buildingPhysicsScript != null)
        {
            buildingPhysicsScript.OnProjectileLaunched();
        }
    }
}