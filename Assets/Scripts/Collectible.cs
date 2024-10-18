using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    // Start is called before the first frame update
    public float colorChangeSpeed = 0.05f; 
    //private Gradient gradient;
    //private Renderer objectRenderer;
    //private Color currentColor= Color.HSVToRGB(0f / 360f, 0.42f, 0.94f);
    //private float t = 0.0f; 

    void Start()
    {
        //objectRenderer = GetComponent<Renderer>();
        //gradient = new Gradient();
        //var colors = new GradientColorKey[2];
        //colors[0] = new GradientColorKey(Color.HSVToRGB(0f / 336f, 0.72f, 1.0f), 0.0f);
        //colors[1] = new GradientColorKey(Color.HSVToRGB(36f / 360f, 0.73f, 0.95f), 1.0f);
        

        //var alphas = new GradientAlphaKey[2];
        //alphas[0] = new GradientAlphaKey(1.0f, 0.0f);
        //alphas[1] = new GradientAlphaKey(0.0f, 1.0f);
        //gradient.SetKeys(colors, alphas);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(90.0f * Time.deltaTime, 0.0f, 0.0f, Space.Self);
        //t += Time.deltaTime * colorChangeSpeed;
        //t = Mathf.Repeat(t, 1.0f);
        //Color targetColor = gradient.Evaluate(t);
        //currentColor = Color.Lerp(currentColor,targetColor,Time.deltaTime*colorChangeSpeed);
        //objectRenderer.material.color = currentColor;

    }

    private void OnCollisionEnter(Collision collision)
    {

        gameObject.SetActive(false);
    }
}
