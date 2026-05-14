using UnityEngine;

public class KillZone : MonoBehaviour
{
    private GameObject objResult;

    private Controller myController;

    private void Start()
    {
        objResult = GameObject.FindGameObjectWithTag("GameController");
        myController = objResult.GetComponent<Controller>();
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.name);
        if (other.CompareTag("Player"))
        {
            myController.GameOver();
        }
    }
}
