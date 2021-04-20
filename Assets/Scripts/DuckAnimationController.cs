using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckAnimationController : MonoBehaviour
{
    [SerializeField] Animator animator;
    public int isFlyingID;

    private void Awake()
    {
        isFlyingID = Animator.StringToHash("IsFlying");
    }

    void Start()
    {
        animator.SetBool(isFlyingID, true);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
