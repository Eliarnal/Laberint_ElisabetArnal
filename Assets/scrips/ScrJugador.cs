using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrJugador : MonoBehaviour
{

    Rigidbody2D rb;
    ScrPerla scr;

    float x, y;
    [SerializeField]
    float forsa = 5;

    AudioSource a;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        a = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");
        

    }
    private void FixedUpdate()
    {
        rb.AddForce(new Vector2(x * forsa, y * forsa));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "perla") //Per que el peix agafi les perles al col·lisionar
        {
            AudioSource perles;
            perles = collision.GetComponent<AudioSource>();
            if (perles) AudioSource.PlayClipAtPoint(perles.clip, Camera.main.transform.position);
            scr = collision.GetComponent<ScrPerla>();
            ScrControlerGame.punts += scr.valor;
            ScrControlerGame.PerlesRestants--;
            Destroy(collision.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        a.Play();
    }

}
