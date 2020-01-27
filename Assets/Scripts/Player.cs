using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    public float speed;
    public float increment;
    public float maxY;
    public float minY;

    private Vector2 targetPos;

    public int health;

    public GameObject moveEffect;
    public Animator camAnim;
    public Text healthDisplay;

    public GameObject spawner;
    public GameObject restartDisplay;
    public GameObject Pausa;


    public bool activadoPausa =false;

    private void Start()
    {
        
    }
    private void Update()
    {
        
        if (restartDisplay.activeSelf == false)
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                activadoPausa = !activadoPausa;
                Pausa.SetActive(activadoPausa);
                Time.timeScale = (activadoPausa) ? 0 : 1f;
                if (activadoPausa)
                {
                    GameManager.Instance.PausarAudio();
                }
                else {
                    GameManager.Instance.ReanudarAudio();
                }
            }
        }
    

        if (health <= 0) {
            spawner.SetActive(false);
            restartDisplay.SetActive(true);
            Destroy(gameObject);
            GameManager.Instance.MostrarAnuncio(); 
        }

        healthDisplay.text = health.ToString();

        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        
        if (Input.GetKeyDown(KeyCode.UpArrow) && transform.position.y < maxY) {
            camAnim.SetTrigger("shake");
            Instantiate(moveEffect, transform.position, Quaternion.identity);
            targetPos = new Vector2(transform.position.x, transform.position.y + increment);
        } else if (Input.GetKeyDown(KeyCode.DownArrow) && transform.position.y > minY) {
            camAnim.SetTrigger("shake");
            Instantiate(moveEffect, transform.position, Quaternion.identity);
            targetPos = new Vector2(transform.position.x, transform.position.y - increment);
        }
    }

    public void Pausar() {
        if (!restartDisplay.activeSelf)
        {
            activadoPausa = !activadoPausa;
            Pausa.SetActive(activadoPausa);
            Time.timeScale = (activadoPausa) ? 0 : 1f;
        }      
    }

    public void Arriba() {
        if (transform.position.y < maxY)
        {
            camAnim.SetTrigger("shake");
            Instantiate(moveEffect, transform.position, Quaternion.identity);
            targetPos = new Vector2(transform.position.x, transform.position.y + increment);
        }
    }

    public void Abajo() {
        if (transform.position.y > minY)
        {
            camAnim.SetTrigger("shake");
            Instantiate(moveEffect, transform.position, Quaternion.identity);
            targetPos = new Vector2(transform.position.x, transform.position.y - increment);
        }
    }
}
