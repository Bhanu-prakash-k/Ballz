using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderClamping : MonoBehaviour
{
    [SerializeField] private Transform leftBorder;
    [SerializeField] private Transform rightBorder;
    [SerializeField] private Transform topBorder;
    [SerializeField] private Transform bottomBorder;

    

    private void Awake()
    {
        //blockSpawner.position = Camera.main.ViewportToWorldPoint(new Vector3(0.1f, 0.9f, 0));
    }

    // Start is called before the first frame update
    void Start()
    {
        leftBorder.position = Camera.main.ViewportToWorldPoint(new Vector3(0, 0.5f, 0));
        rightBorder.position = Camera.main.ViewportToWorldPoint(new Vector3(1, 0.5f, 0));
        topBorder.position = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 1, 0));
        bottomBorder.position = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0f, 0));
    }

    
}
