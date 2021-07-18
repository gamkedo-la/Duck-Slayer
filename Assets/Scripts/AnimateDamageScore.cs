using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AnimateDamageScore : MonoBehaviour
{
    public TMP_Text label;

    [Header("Color Range")]
    [SerializeField] private Color shortRange;
    [SerializeField] private Color midRange;
    [SerializeField] private Color longRange;

    [Header("Fade To Color")]
    [SerializeField] private Color endColor;
    [SerializeField] TransformRef playerPosition;
    private Color startColor;

    private void Start()
    {
        StartCoroutine(Animate());
    }

    public void SetColorRange(HitRangeEnum value)
    {
        switch(value)
        {
            case HitRangeEnum.Long:
                startColor = longRange;
                break;
            case HitRangeEnum.Mid:
                startColor = midRange;
                break;
            default:
                startColor = shortRange;
                break;
        }
    }

    private IEnumerator Animate()
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
