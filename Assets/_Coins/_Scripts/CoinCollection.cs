using UnityEngine;

public class CoinCollection : MonoBehaviour
{
    public GameObject CoinParticles;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            this.gameObject.GetComponent<BoxCollider>().enabled = false;
            this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
            CoinParticles.SetActive(true); // Activates particle animation for disappearing coin
            ScoreManager.instance.addScore();
            Invoke("destroyCoin", 2f);
        }
    }
    void destroyCoin()
    {
        Destroy(this.gameObject);
    }
}
