using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FaireClics : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI clickCounter;
    [SerializeField] TextMeshProUGUI velocityCounter;
    [SerializeField] GameObject player;
    int nbrClics;
    float _velocity;
    Rigidbody _rigidbody;
    void Start()
    {
        _rigidbody = player.GetComponent<Rigidbody>();
        nbrClics = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            nbrClics++;
            clickCounter.text = $"Nombre de clics : {nbrClics} clics";
        }
        velocityCounter.text = $"Vélocité : {_rigidbody.velocity.magnitude}";
    }
    private void FixedUpdate()
    {
        _rigidbody.AddForce(-Physics.gravity, ForceMode.Acceleration);
    }
}
