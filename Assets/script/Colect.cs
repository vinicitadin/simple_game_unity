using UnityEngine;

public class Collect : MonoBehaviour
{
    [Range(-5,5)]
    public int valorPonto;

    public ColorCode colorCode;

    public AudioClip audio;

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.name);
        if (other.CompareTag("Player"))
        {
            GameObject obj = GameObject.FindGameObjectWithTag("GameController");
            obj.GetComponent<Controller>().Pontuar(valorPonto, colorCode);
            obj.GetComponent<Controller>().PlayFx(audio);
            this.gameObject.SetActive(false);
        }
    }
}
