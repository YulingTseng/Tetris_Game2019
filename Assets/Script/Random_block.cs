using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Random_block : MonoBehaviour
{
    public GameObject[] block;
    // Start is called before the first frame update
    void Start()
    {
        next();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void next()
    {
        int i = Random.Range(0, block.Length);

        Instantiate(block[i],new Vector2(6,22),Quaternion.identity);
    }
}
