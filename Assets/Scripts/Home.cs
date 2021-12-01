using UnityEngine;

public class Home : MonoBehaviour
{
    public GameObject OccupiedFrog;

    private void OnEnable()
    {
        OccupiedFrog.SetActive(true);
    }

    private void OnDisable()
    {
        OccupiedFrog.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            enabled = true;

            FindObjectOfType<GameManager>().HomeOccupied();
        }
    }


}
