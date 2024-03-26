using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlappyBird : MonoBehaviour
{
    public GameObject Ship;
    public GameObject PipePrefab;
    public float Gravity = 30;
    public float Jump = 10;
    public float PipeSpawnInterval = 2;
    public float PipeSpeed = 5;

    private float VerticalSpeed;
    private float PipeSpawnCountdown;
    private GameObject PipesHolder;
    private int PipeCount;

    void Start()
    {
        PipeCount = 0;
        Destroy(PipesHolder);
        PipesHolder = new GameObject("PipesHolder");
        PipesHolder.transform.parent = this.transform;

        VerticalSpeed = 0;
        Ship.transform.position = Vector3.up * 1;

        PipeSpawnCountdown = 0;
    }

    
    void Update()
    {
        VerticalSpeed += -Gravity * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            VerticalSpeed = 0;
            VerticalSpeed += Jump;
        }

        Ship.transform.position += Vector3.up * VerticalSpeed * Time.deltaTime;

        PipeSpawnCountdown -= Time.deltaTime;

        if (PipeSpawnCountdown <= 0 )
        {
            PipeSpawnCountdown = PipeSpawnInterval;

            GameObject pipe = Instantiate(PipePrefab);
            pipe.transform.parent = PipesHolder.transform;
            pipe.transform.name = (++PipeCount).ToString();

            pipe.transform.position += Vector3.right * 30;
            pipe.transform.position -= Vector3.up * Mathf.Lerp(4, 9, Random.value);
        }

        PipesHolder.transform.position += Vector3.left * PipeSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider collider)
    {

        Start();
    }
}
