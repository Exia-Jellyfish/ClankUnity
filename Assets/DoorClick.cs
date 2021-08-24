using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorClick : MonoBehaviour
{
    private Quaternion openRotation = Quaternion.Euler(0, -90, 0);
    private Quaternion closeRotation = Quaternion.Euler(0, 0, 0);
    private bool isOpen;
    private float speed = 1f;
    private GameObject hinges;
    private Coroutine currentCoroutine;
    private const float DURATION = 2f;

    private void Awake()
    {
        hinges = transform.root.gameObject;
    }

    public void OnMouseDown()
    {
        Debug.Log(isOpen);
        Debug.Log(hinges);
        Debug.Log(Time.deltaTime * speed);


        
        if (currentCoroutine != null)
        {
            StopCoroutine(currentCoroutine);
        }

        if (!isOpen)
        {
            currentCoroutine = StartCoroutine(RotateCoroutine(closeRotation, openRotation, transform.rotation));
        }
        else
        {
            currentCoroutine = StartCoroutine(RotateCoroutine(openRotation, closeRotation, transform.rotation));
        }
        isOpen = !isOpen;
    }

    private IEnumerator RotateCoroutine(Quaternion initialRotation, Quaternion finalRotation, Quaternion currentRotation)
    {
        float ratio = Mathf.Abs(currentRotation.y - initialRotation.y) / (finalRotation.y - initialRotation.y);
        float duration = (ratio == 0 ? 1 : ratio) * DURATION;
        Debug.Log(ratio);

        for (float f = 0; f <= duration; f += Time.deltaTime)
        {
            float lerp = f / duration > 0.98f ? 1 : f / duration;
            hinges.transform.rotation = Quaternion.Slerp(initialRotation, finalRotation, lerp);
            yield return null;
        }
    }
}
