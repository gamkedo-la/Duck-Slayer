using UnityEngine;

public class SetPlayerTransformOnStart : MonoBehaviour
{
    private void Start()
    {
        GameManagerSingleton.instance.SetPlayerTransform(this.transform);
    }
}
