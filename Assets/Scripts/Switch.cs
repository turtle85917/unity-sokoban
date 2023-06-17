using UnityEngine;

public class Switch : MonoBehaviour
{
    public bool on;

    public void Update()
    {
        switch(on)
        {
            case true:
                transform.localPosition = new(0, 3.95f, 0);
                transform.rotation = new(0, 0, 180, 0);
                break;
            case false:
            default:
                transform.localPosition = new(0, 3.65f, 0);
                transform.rotation = new(0, 0, 0, 0);
                break;
        }
    }
}
