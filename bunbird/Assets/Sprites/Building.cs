using UnityEngine;
using UnityEngine.SceneManagement;

public class Brick : MonoBehaviour
{
    public float breakSpeed = 3f;
    public int points = 10;

    void OnCollisionEnter2D(Collision2D collision)
    {
        // If hit hard enough
        if (collision.relativeVelocity.magnitude > breakSpeed)
        {
            // Update the Slider!
            if (ScoreManage.instance != null)
            {
                ScoreManage.instance.AddPoints(points);
            }

            // Destroy this block
            Destroy(gameObject);

        }
    }

}