using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objectives : MonoBehaviour
{
    private Rigidbody RbObjective;

    private GeneratorManager scriptGeneratorManager;

    [SerializeField] private ParticleSystem _explosion;

    [SerializeField] private int ScoreValue;

    private float XRange = 4.0f;
    private float YPosition = 6.0f;
    private float MinVelocity = 8.0f;
    private float MaxVelocity = 14.5f;
    private float TorqueForce = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        RbObjective = GetComponent<Rigidbody>();
        transform.position = GeneratorPosition();
        RbObjective.AddForce(DrivingForce(), ForceMode.Impulse);
        RbObjective.AddTorque(TorqueValue(), TorqueValue(), TorqueValue(), ForceMode.Impulse);

        scriptGeneratorManager = GameObject.Find("GeneratorManager").GetComponent<GeneratorManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    Vector3 GeneratorPosition()
    {
        return new Vector3(Random.Range(-XRange, XRange), -YPosition, -1.25f);
    }

    Vector3 DrivingForce()
    {
        return Vector3.up * Random.Range(MinVelocity, MaxVelocity);
    }

    float TorqueValue()
    {
        return Random.Range(-TorqueForce, TorqueForce);
    }

    private void OnMouseDown()
    {
        if (scriptGeneratorManager._gameActive)
        {
            Destroy(gameObject);
            Instantiate(_explosion, transform.position, _explosion.transform.rotation);
            scriptGeneratorManager.UpdateScore(ScoreValue);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if (!gameObject.CompareTag("Bad"))
        {
            scriptGeneratorManager.GameOver();
        }
        
    }
}
