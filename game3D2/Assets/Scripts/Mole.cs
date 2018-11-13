using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mole : MonoBehaviour
{

    public float visibleHeight = 0.2f;
    public float hiddenHeight = -0.3f;
    public float speed = 4f;
    public float disappearDuration = 0.5f;
    private float disappearTimer = 1f;
    private Vector3 targetPosition;
    public bool isVisible;
    public float lifePoint = 40;
    public Vector3 newTargetPosition;
    public bool actualizado;

    // Use this for initialization
    void Awake()
    {
        targetPosition = new Vector3(
            transform.localPosition.x,
            hiddenHeight,
            transform.localPosition.z);
        isVisible = false;
        transform.localPosition = targetPosition;
        actualizado = true;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = Vector3.Lerp(transform.localPosition, targetPosition, Time.deltaTime * speed);
        disappearTimer -= Time.deltaTime;
        if (disappearTimer < 0f)
        {
            Hide();
        }
        /*if (lifePoint <= 0)
        {
            Destroy(gameObject);
        }*/
        if (!actualizado &&!isVisible && transform.localPosition.x!=newTargetPosition.x&& transform.localPosition.z != newTargetPosition.z)
        {
            transform.localPosition = newTargetPosition;
            actualizado = true;
            isVisible = true;
        }
    }

    public void Rise()
    {
        targetPosition = new Vector3(
           transform.localPosition.x,
           visibleHeight + 1.0f,
           transform.localPosition.z);
        isVisible = true;
        disappearTimer = disappearDuration;
    }

    public void Hide()
    {
        targetPosition = new Vector3(
           transform.localPosition.x,
           hiddenHeight,
           transform.localPosition.z);
        isVisible = false;
    }
    public void OnHit()
    {
        Hide();
    }

    public void moveTo(RaycastHit hit)
    {
        if (!isVisible)
        {
            Debug.Log("a");
            transform.localPosition = hit.point;
        }
        else
        {
            actualizado = false;
            newTargetPosition = hit.point;
        }
        
    }
        
}