using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AnimateDamageScore : MonoBehaviour
{
    public TMP_Text label;
    public Color startColor;
    public Color endColor;
    public float rotationSpeed = 500f;
    [SerializeField] TransformRef playerPosition;

    void Start()
    {
        StartCoroutine(Animate());
    }

    public IEnumerator Animate()
    {
        Vector3 startPosition = transform.position;
        Vector3 finalPosition = transform.position + new Vector3(0, 1, 0);
        label.color = startColor;

        float percentage = 0.0f;
        while (percentage < 1.0f)
        {
            yield return new WaitForEndOfFrame();

            // animate upwards
            transform.position = Vector3.Lerp(startPosition, finalPosition, percentage);
            percentage += Time.deltaTime;

            // fade label color
            label.color = Color.Lerp(startColor, endColor, percentage);

            transform.LookAt(playerPosition.GetPosition());

            //var currentRotation = this.transform.rotation.eulerAngles;
            //currentRotation.y += Time.deltaTime * rotationSpeed;
            //this.transform.rotation = Quaternion.Euler(currentRotation);
        }
    }
}
