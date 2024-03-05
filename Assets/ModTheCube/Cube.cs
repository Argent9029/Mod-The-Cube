using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;
    private float startDelay = 3f;

    Vector3 originalScale;

    float speed = 80;



    void Start()
    {
        originalScale = transform.localScale;

        transform.position = new Vector3(3, 6, 1);

        StartCoroutine(ChangeColor());

        StartCoroutine(PositionChange());

        StartCoroutine(ScaleChange());
    }
    
    void Update()
    {
        transform.Rotate(10.0f * Time.deltaTime, 1.0f * Time.deltaTime, 0.0f);
    }

    IEnumerator ChangeColor()
    {
        while (true)
        {
            Material material = Renderer.material;
            if (material.color == new Color(255f, 0f, 0f, 100f))
            {
                material.color = new Color(0f, 255f, 0f, 100f);
                yield return new WaitForSeconds(startDelay);
            }
            else if (material.color == new Color(0f, 255f, 0f, 100f))
            {
                material.color = new Color(0f, 255f, 255f, 10f);
                yield return new WaitForSeconds(startDelay);
            }
            else
            {
                material.color = new Color(255f, 0f, 0f, 100f);
                yield return new WaitForSeconds(startDelay);
            }
        }
    }

    IEnumerator PositionChange()
    {
        while (true)
        {
            if (transform.position.z != -7)
            {
                speed += 10;
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1);
                yield return new WaitForSeconds(1.5f);
            }
            else
            {
                speed = 10;
                transform.position = new Vector3(transform.position.x, transform.position.y, 7);
                yield return new WaitForSeconds(1.5f);
            }
        }
    }

    IEnumerator ScaleChange()
    {
        while (true)
        {
            if (transform.localScale == originalScale)
            {
                transform.localScale = Vector3.one * 2.3f;
                yield return new WaitForSeconds(1.5f);
            }
            else
            {
                transform.localScale = originalScale;
                yield return new WaitForSeconds(1.5f);
            }
        }
    }
}
