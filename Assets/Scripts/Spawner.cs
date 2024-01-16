using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject object_;
    // Start is called before the first frame update
   
    public float seconds;

    private float elapsedSeconds;
    
    
    protected void Update()
    {
        StartCoroutine (SpawnerDestruction());

        elapsedSeconds += Time.deltaTime;
        if (elapsedSeconds >= seconds)
        {
            
            Vector3 randomPos = new Vector3(Random.Range(-7, 7),0.5f, Random.Range(-4, 4));
            Instantiate(object_, randomPos, Quaternion.identity);
            
            elapsedSeconds = 0;
        }
    }
    
    IEnumerator SpawnerDestruction(){

        yield return new WaitForSeconds (60);
        Debug.Log("DESTROYED");
        gameObject.SetActive(false);

    }
}
