using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorClick : MonoBehaviour
{
    private bool isOpen;
    private Animator animator;
    private Coroutine currentRoutine;
    private const float duration = 7;


    private void Awake()
    {
        animator = transform.root.gameObject.GetComponent<Animator>();
    }
    public void OnMouseDown()
    {
        if(currentRoutine != null)
        {
            StopCoroutine(currentRoutine);
        }
        currentRoutine = StartCoroutine(RotateCoroutine());
        isOpen = !isOpen;
    }

    private IEnumerator RotateCoroutine()
    {

        for (float f = 0; f <= duration; f += Time.deltaTime)
        {
            float lerp = Mathf.Lerp(animator.GetFloat("Blend"), isOpen ? 0 : 1, f/duration);
            animator.SetFloat("Blend", lerp);
            yield return null;
        }
    }
}
