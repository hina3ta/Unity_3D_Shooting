using UnityEngine;
using System.Collections;

public class ParticleScript : MonoBehaviour {

    // Use this for initialization
    void Start () {

    }

    // Update is called once per frame
    void Update () {
        ParticleSystem ps_FX = GetComponent<ParticleSystem>();
        if (Input.GetKey(KeyCode.Space)) {
            ps_FX.Play();
        }
        
    }
}

