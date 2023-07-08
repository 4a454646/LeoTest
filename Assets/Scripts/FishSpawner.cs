using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawner : MonoBehaviour {
    private enum FishType {
        Basic,
        Annoying
    }
    // create a dictionary for fish health
    private Dictionary<FishType, int> fishHealth = new Dictionary<FishType, int>() {
        {FishType.Basic, 2},
        {FishType.Annoying, 3}
    };
    [SerializeField] private Sprite[] fishSprite;
    [SerializeField] FishType curFishType;
    [SerializeField] private Player player;
    [SerializeField] private GameObject fish;
    //[SerializeField] private Dictionary<FishType, float
    [SerializeField] private float fishSpawnDelay = 2f;
    // Start is called before the first frame update
    void Start() {

        player = FindObjectOfType<Player>();
        StartCoroutine(FishSpawn());
    }

    // Update is called once per frame
    void Update() {
        
    }

    private IEnumerator FishSpawn() {
        while(true) {
            yield return new WaitForSeconds(fishSpawnDelay);
            curFishType = (FishType)Random.Range(0, System.Enum.GetValues(typeof(FishType)).Length);
            print(curFishType);
            transform.position = new Vector2(Random.Range(-12f, 12f), -6f);
            float fishFirePower = Random.Range(15f, 20f);
            GameObject tempFish = Instantiate(
                fish,
                transform.position,
                Quaternion.identity
            );
            tempFish.GetComponent<SpriteRenderer>().sprite = fishSprite[(int)curFishType];
            tempFish.GetComponent<Fish>().health = fishHealth[curFishType];
            tempFish.transform.localRotation = Quaternion.Euler(0, transform.position.x < 0 ? 0 : 180, 0);
            if (curFishType == FishType.Annoying) {
                tempFish.GetComponent<Rigidbody2D>().velocity = new Vector2(
                    (player.transform.position.x - transform.position.x) / (fishFirePower / (Physics2D.gravity.magnitude * 2) + Mathf.Sqrt((2 * (player.transform.position.y - transform.position.y)) / Physics2D.gravity.magnitude)), 
                    fishFirePower
                );
            }
            else if (curFishType == FishType.Basic) {
                Vector3 trans = transform.position.x < 0 ? transform.right : -transform.right;
                tempFish.GetComponent<Rigidbody2D>().velocity = trans * Random.Range(0.5f, 1.5f) + transform.up * fishFirePower;
            }
        }
    }

}
