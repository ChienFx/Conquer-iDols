using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour {
    
    public GameObject[] itemType;

    float minX, maxX;
    // Use this for initialization
    void Start () {
        //Bound constraint
        Vector3 bound = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0f));

        minX = -bound.x + 0.5f;
        maxX = 2 * bound.y + minX - 0.7f;

        StartCoroutine(SpawnerItem());
		StartCoroutine(SpawnerItem());
		StartCoroutine(SpawnerItem());
        //StartCoroutine(SpawnerItem());
    }
    
    IEnumerator SpawnerItem(){
        yield return new WaitForSeconds(Random.Range(0.2f, 5f - GameplayController.instance.gameSpeed));        

        Vector3 pos = transform.position;//get pos of TigerCan
        pos.x = Random.Range(minX, maxX);

        Instantiate(itemType[Random.Range(0, 3)], pos, Quaternion.identity);

        StartCoroutine(SpawnerItem());

    }
	
}
