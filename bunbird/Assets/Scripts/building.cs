using UnityEngine;

public class Building : MonoBehaviour
{
    public int damage = 10;

    // drag the BuildingRoot (with BuildingHealth) here in Inspector
    public PlayerHealth buildingHealth;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Projectile"))
        {
            Debug.Log("Brick hit by projectile! -" + damage + " HP");

            if (buildingHealth != null)
            {
                buildingHealth.TakeDamage(damage);
            }

            Destroy(gameObject);
        }
    }
}
