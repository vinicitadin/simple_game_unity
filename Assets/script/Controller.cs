using System.Collections.Generic;
using System.Net.Sockets;
using TMPro;
using UnityEngine;

public enum ColorCode
{
    Red = 0,
    Green = 1,
    Blue = 2,
    Yellow = 3,
}

public class Controller : MonoBehaviour
{
    [UnityEngine.Range(0.02f, 20.0f)]
    public float velocidade;

    [UnityEngine.Range(0.1f, 100f)]
    public float velJump;

    public GameObject personagem;

    private Rigidbody rb;

    public List<TextMeshProUGUI> pontosTxt;

    public int[] score = new int[4];

    public AudioSource musicAs;

    public AudioSource fxAs;

    public List<AudioClip> musicList;

    public ColorCode colorCode;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = personagem.GetComponent<Rigidbody>();
        PlayMusic();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            //Debug.Log("A foi pressionado");
            //personagem.transform.position = new Vector3(
            //    personagem.transform.position.x - velocidade,
            //    personagem.transform.position.y,
            //    personagem.transform.position.z);
            rb.AddForce(-velocidade * rb.mass, 0, 0);
        }
        if (Input.GetKey(KeyCode.W))
        {
            //Debug.Log("W foi pressionado");
            //personagem.transform.position = new Vector3(
            //    personagem.transform.position.x,
            //    personagem.transform.position.y,
            //    personagem.transform.position.z + velocidade);
            rb.AddForce(0, 0, velocidade * rb.mass);
        }
        if (Input.GetKey(KeyCode.S))
        {
            //Debug.Log("S foi pressionado");
            //personagem.transform.position = new Vector3(
            //    personagem.transform.position.x,
            //    personagem.transform.position.y,
            //    personagem.transform.position.z - velocidade);
            rb.AddForce(0, 0, -velocidade * rb.mass);
        }
        if (Input.GetKey(KeyCode.D))
        {
            //Debug.Log("D foi pressionado");
            //personagem.transform.position = new Vector3(
            //    personagem.transform.position.x + velocidade,
            //    personagem.transform.position.y,
            //    personagem.transform.position.z);
            rb.AddForce(velocidade * rb.mass, 0, 0);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(0, velJump * rb.mass, 0);
        }
    }

    public void Pontuar(int valor, ColorCode colorCode)
    {
        int index = (int)colorCode;
        score[index] += valor;
        AtualizarPontos(colorCode);
    }

    public void AtualizarPontos(ColorCode colorCode)
    {
        pontosTxt[(int)colorCode].text = "Pontos: " + score[(int)colorCode];
    }

    public void RecebeAudioClip(AudioClip clip)
    {

    }

    public void PlayMusic()
    {
        musicAs.clip = musicList[Random.Range(0, musicList.Count-1)];
        musicAs.Play();
    }

    public void PlayFx(AudioClip clip)
    {
        fxAs.PlayOneShot(clip);
    }
}
