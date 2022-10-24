using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobBase : MonoBehaviour
{
    public float mobSpeed = 0f;
    public Vector2 StartPosition;
 
    private void OnEnable()
    {
        transform.position = StartPosition;
    }

    void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime * mobSpeed);

        if(transform.position.x < -6)
        {
            gameObject.SetActive(false);
        }
    }
}
