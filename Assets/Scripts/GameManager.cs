using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Universe;
using GoogleMobileAds.Api;
using UnityEngine.SceneManagement;

public class GameManager : Manager<GameManager>
{
    public AudioClip musicaFondo;
    AudioSource fuenteAudio;
    private float musicVolume = 1f;

    public InterstitialAd anuncio;
    [SerializeField] private string appID = "ca-app-pub-1323171051784743~3405474268";
    [SerializeField] private string anuncioID = "ca-app-pub-3940256099942544/1033173712 ";

    void Start()
    {
        SceneManager.LoadScene("Menu");
        PedirInterstitial();
        fuenteAudio = GetComponent<AudioSource>();
        fuenteAudio.clip = musicaFondo;
        fuenteAudio.Play();

    }
    private void Awake()
    {
        MobileAds.Initialize(appID);
    }
    void Update()
    {
        fuenteAudio.volume = musicVolume;
    }

    public float getVolume() {
        return musicVolume;
    }

    public void CambiarEscena(string escena) {
        SceneManager.LoadScene(escena);
    }

    public void SalirJuego() {
        Application.Quit();
    }

    public void PausarAudio() {
        fuenteAudio.Stop();
    }

    public void ReanudarAudio() {
        fuenteAudio.Play();
    }

    public void SetVolume(float vol)
    {
        musicVolume = vol;
    }


    public void PedirInterstitial() {
        anuncio = new InterstitialAd(anuncioID);
        AdRequest pedir = new AdRequest.Builder().Build();
        anuncio.LoadAd(pedir);
    }

    public void MostrarAnuncio() {
        anuncio.Show();
        anuncio.Destroy();
        PedirInterstitial();
    }
}
