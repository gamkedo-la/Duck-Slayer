using UnityEngine;

public class Destroy_Self_After_Duration : MonoBehaviour
{
    public float DurationInSeconds;
    // Start is called before the first frame update
    void Start()
    {
      Destroy(gameObject, DurationInSeconds);
    }
}
