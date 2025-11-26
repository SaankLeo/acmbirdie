using UnityEngine;
public class oof : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) Debug.Log("Left click at " + Input.mousePosition);
    }
}
