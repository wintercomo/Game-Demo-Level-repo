using UnityEngine;

public class MoveRocket : MonoBehaviour
{
    private bool allowMovement = false;
    private float beginningSpeed = 0.1f;
    private float increaseFactor = 0.1f;

    // Update is called once per frame
    void Update()
    {
        if (allowMovement)
        {
            transform.Translate(0, beginningSpeed + increaseFactor, 0);
            increaseFactor = increaseFactor + 0.001f;
        }
    }
    public void AllowMovement()
    {
        allowMovement = true;
    }
}
