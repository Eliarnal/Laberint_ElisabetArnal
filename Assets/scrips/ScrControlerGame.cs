using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScrControlerGame : MonoBehaviour
{
    [SerializeField]
    GameObject MissatgeGuanyador;
    static GameObject MissatgeGameOver;
    [SerializeField] GameObject MissatgeVictoria;
    [SerializeField] GameObject MissatgeMenu;
    [SerializeField] GameObject MissatgeControls;
    [SerializeField] GameObject CanvasUi;
    
    [SerializeField] AudioSource so;

    
    bool pausat = false;
    bool active;

   

    public static int punts = 0;
    public static int PerlesRestants = 0;
    string[] nivells = { "nivell1", "nivell2", "nivell3" };
    static int nivell = 0;

    // Start is called before the first frame update
    void Start()
    {
        
        MissatgeGameOver = GameObject.FindGameObjectWithTag("GameOver");
        MissatgeGameOver.SetActive(false);
        Time.timeScale = 1;

        CanvasUi = GameObject.FindGameObjectWithTag("UI");
        CanvasUi.SetActive(false);

        

    }

    // Update is called once per frame
    private void Update()
    {
        if (PerlesRestants == 0) Win();
        ControlEntradaUsuari();
        //Menu();


    }

    void Win() //Mostra el missatge de victòria del nivell
    {
        if(ScrControlerGame.PerlesRestants == 0)
        {
            Time.timeScale = 0;
            MissatgeGuanyador.SetActive(true);
        }
        print("Enhorabona");
    }

    public static void GameOver() //Quan el peix col·lisiona amb el remolí apareix pa pantalla de game over
    {
        MissatgeGameOver.SetActive(true);
        Time.timeScale = 0;

    }

    void NextLevel() //Per passar de nivell
    {
        nivell++;
        if (nivell < nivells.Length)
            SceneManager.LoadScene(nivells[nivell]);
        else Final();
    }

    void ControlEntradaUsuari() //Controls del jugador a través del teclat
    {
        if (Input.GetKeyDown(KeyCode.X)) EliminaPerles(); //Eliminar les perles al moment i passar al deguent nivell
        if (Input.GetKeyDown(KeyCode.Return) && PerlesRestants == 0) NextLevel();
        

      
        if (Input.GetKeyDown(KeyCode.C)) MissatgeControls.SetActive(true); //Per activar el menú de controls
        if (Input.GetKeyDown(KeyCode.J)) //Per començar el joc
        {
            MissatgeMenu.SetActive(false);
            CanvasUi.SetActive(true);
            Time.timeScale = 1;
            punts = 0;
            PerlesRestants = 6;

        }
        if (Input.GetKeyDown(KeyCode.R)) //Per poder tornar al menú al perdre el joc
        {
            SceneManager.LoadScene("nivell1");


        }

        if (Input.GetKeyDown(KeyCode.M)) //per tornar al menú respecte al menú dels controls
        {
            MissatgeControls.SetActive(false);
            MissatgeMenu.SetActive(true);

        }

        // Control de la música
        if (Input.GetKeyDown(KeyCode.B)) SilenciFondo(); //Apagar la música de fons
        if (Input.GetKeyDown(KeyCode.Alpha1)) AudioListener.volume += 0.05f;// Controlar el volum de la música
        if (Input.GetKeyDown(KeyCode.Alpha2)) AudioListener.volume -= 0.05f;
        AudioListener.volume = Mathf.Clamp(AudioListener.volume, 0, 1); 

        if (Input.GetKeyDown(KeyCode.S)) Application.Quit(); //Tecla per sortir
        if (Input.GetKeyDown(KeyCode.W)) Application.OpenURL("https://www.emav.com/");//Tecla per anar a la web de l'emav
    }

    void EliminaPerles()
    {
        GameObject[] perla;
        perla = GameObject.FindGameObjectsWithTag("perla");
        foreach (GameObject p in perla)
        {
            punts += p.GetComponent<ScrPerla>().valor;
            Destroy(p);
            PerlesRestants--;
        }
    }

    void Final() //funció per mostrar el missatge de victòria del final de joc
    {
        MissatgeVictoria.SetActive(true);
    }

    //void Menu()
    //{
        //if (MissatgeMenu == false)
        //{
            //CanvasUi.SetActive(true);
        //}

    //}

    void SilenciFondo() //Funció per pausar la música de fons
    {
        pausat = !pausat;
        if (pausat) so.Pause(); else so.Play();
    }
   


}
