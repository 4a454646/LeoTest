using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawner : MonoBehaviour
{
    private enum FishType
    {
        Basic,
        Annoying
    }

    [SerializeField] private Player player;
    [SerializeField] private GameObject fish;
    [SerializeField] private Sprite[] fishSprite;
    //[SerializeField] private Dictionary<FishType, float
    [SerializeField] private float fishSpawnDelay = 2f;
    [SerializeField] private float fishFireSpeed = 7f;
    [SerializeField] private float fishFirePower = 20f;
    // Start is called before the first frame update
    void Start()
    {

        player = FindObjectOfType<Player>();
        StartCoroutine(fishSpawn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator fishSpawn()
    {
        while(true)
        {
            yield return new WaitForSeconds(fishSpawnDelay);
            
            transform.position = new Vector2(Random.Range(-12f, 12f), -6f);

            GameObject tempFish = Instantiate(
                fish,
                transform.position,
                Quaternion.identity
            );

            if(transform.position.x < 0)
            {
                tempFish.GetComponent<Rigidbody2D>().velocity = (transform.right * fishFireSpeed) + (transform.up * fishFirePower);

            }
            else
            {
                tempFish.transform.localRotation = Quaternion.Euler(0, 180, 0);
                tempFish.GetComponent<Rigidbody2D>().velocity = (-transform.right * fishFireSpeed) + (transform.up * fishFirePower);

            }


        }
    }

}
