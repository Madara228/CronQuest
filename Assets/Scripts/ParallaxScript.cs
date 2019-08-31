using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxScript : MonoBehaviour
{
    public GameObject cam;
    private float lenght, startPosinition;
    float parallaxEffect;
    void Start()
    {
        parallaxEffect = Random.Range(0.0f, 1f);
        startPosinition = transform.position.x;
        lenght = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    private void FixedUpdate()
    {
        float temp = (cam.transform.position.x * (1 - parallaxEffect));
        float dist = (cam.transform.position.x * parallaxEffect);
        transform.position = new Vector3(startPosinition + dist, transform.position.y, transform.position.z);

        if (temp > startPosinition + lenght) {startPosinition += lenght;}
        else if(temp<startPosinition - lenght) {startPosinition -= lenght;}
    }
}
