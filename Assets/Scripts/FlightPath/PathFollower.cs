using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum PathFollowMode { Once, Loop, PingPong }
public class PathFollower : MonoBehaviour
{
    public BezierSpline spline;
    public PathFollowMode mode;
    private bool goingForward = true;

    public bool lookForward;
    public float duration;

    private float progress;

    private void Update()
    {
        if (goingForward)
        {


            progress += Time.deltaTime / duration;
            if (progress > 1f)
            {
                switch (mode)
                {
                    case PathFollowMode.Once:
                        progress = 1f;
                        break;

                    case PathFollowMode.Loop:
                        progress -= 1f;
                        break;

                    case PathFollowMode.PingPong:
                        progress = 2f - progress;
                        goingForward = false;
                        break;
                }

            }
        }
        else
        {
            progress -= Time.deltaTime / duration;
            if (progress < 0f)
            {
                progress = -progress;
                goingForward = true;
            }
        }

        Vector3 position = spline.GetPoint(progress);

        //transform.localPosition = position;
        transform.position = position;

        if (lookForward)
        {
            transform.LookAt(position + spline.GetDirection(progress));
        }
    }
}
