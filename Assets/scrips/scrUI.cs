using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scrUI : MonoBehaviour
{
    //Canvas on es mostra la puntuació, el nombre de perles i el temps que transcorre al joc

    [SerializeField] Text Punts; 
    [SerializeField] Text Perles;
    [SerializeField] Text Temps;
    float crono;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        crono += Time.deltaTime;
        Punts.text = "Points: " + ScrControlerGame.punts;
        Perles.text = "Pearls: " + ScrControlerGame.PerlesRestants;
        Temps.text = "Time: " + crono.ToString("0.0");

        

    }

    
}
