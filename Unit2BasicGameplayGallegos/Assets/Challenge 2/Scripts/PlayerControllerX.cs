using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    private float coolDown = 0.0f;
    private bool dogReady = true;

    // Update is called once per frame
    void Update()
    {
        coolDown += Time.deltaTime;
        if (coolDown > 1.5f)
        {
            dogReady = true;
        }
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space) && dogReady == true)
        {
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
            coolDown = 0;
            dogReady = false;
        }
    }
}
