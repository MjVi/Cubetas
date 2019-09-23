using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform ObjectToSpawn;
    public GameObject ball;
    public float difficulty = 4;
    public float tiempo;
    public List<Material> balls = new List<Material>();
    public List<Material> buckets = new List<Material>();
    public static List<Material> bucketsCopy = new List<Material>();
    public static List<Material> ballsCopy = new List<Material>();

    void Start()
    {
        bucketsCopy = buckets;
        ballsCopy = balls;
        Spawn();
        //InvokeRepeating("Spawn", 1, 3);
    }

    private void Update()
    {
        tiempo += Time.deltaTime;
        if (tiempo > difficulty)
        {
            Spawn();
        }
    }

    public void Spawn()
    {
        if (PlayerControl.life > 0)
        {
            Shuffle(balls);
            Material ball_color = balls[0];
            ball.GetComponent<Renderer>().material = ball_color;
            Instantiate(ObjectToSpawn, gameObject.transform.position, Quaternion.identity);
            ballsCopy = balls;
            tiempo = 0;

            if (PlayerControl.seconds > 5)
            {
                difficulty = difficulty - 0.1f;
                difficulty = difficulty <= 1 ? 1 : difficulty;
            }
        }
    }

    void Shuffle(List<Material> balls)
    { 
        for (int i = 0; i < 3; i++)
        {
            Material temp = balls[i];
            int randomIndex = Random.Range(i, balls.Count);
            balls[i] = balls[randomIndex];
            balls[randomIndex] = temp;
        }
    }
}
