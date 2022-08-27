using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, 50 * Time.deltaTime);


    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            FindObjectOfType<AudioManager>().PlayCoin("CoinCollect",transform.position);
            Destroy(gameObject);
            PlayerManager.numberOfCoins += 1;
            GameObject.Find("CoinCollect").transform.position = transform.position;

        }
    }
}
