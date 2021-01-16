using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrPerla : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    float velGir = 90;
    public int valor = 0;

    void Awake()
    {
        ScrControlerGame.PerlesRestants++;
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, velGir * Time.deltaTime);
    }
}
