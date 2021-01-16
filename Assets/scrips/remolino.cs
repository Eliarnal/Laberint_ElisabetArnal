using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class remolino : MonoBehaviour
{
    [SerializeField] GameObject remolino1;
    

    float escala = 1f;

    [SerializeField]
    float velGir = -90;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, velGir * Time.deltaTime); // Per que giri el remolí
    }

    private void OnTriggerStay2D(Collider2D collision) //Quan el peix col·lisioni amb el remolí s'acabi el joc
    {
        if(collision.CompareTag("remolino") && GetComponentInParent<Rigidbody2D>().velocity.magnitude < 3)
        {
            GetComponentInParent<Rigidbody2D>().velocity = new Vector2(0, 0);
            transform.parent.position = Vector3.Lerp(transform.parent.position, collision.transform.position, .05f);

            if (escala > 0)
            {
                escala -= .03f;
                transform.parent.localScale = new Vector3(escala, escala, 1);
            }
            else
            {
                ScrControlerGame.GameOver();
            }

            





        }

    }
}
