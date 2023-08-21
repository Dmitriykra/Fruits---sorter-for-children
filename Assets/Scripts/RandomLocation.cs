using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomLocation : MonoBehaviour
{
    public Transform[] transform = new Transform[7];

    // Start is called before the first frame update
    void Start()
    {
        
        for(int i = 0; i < transform.Length; i++)
        {
            if(transform[i]==null)
            {
                continue;
            }
            transform[i].Translate(new Vector3(-RandomX(), -RandomY(), 0));
        }
    }

    private int RandomX()
    {
        return Random.Range(0, 0);
    }

    private int RandomY()
    {
        return Random.Range(0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
