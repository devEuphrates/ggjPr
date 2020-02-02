using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public float speed = 2f;
    public int minGap = 2;
    private int zc = 0;
    private Vector3 s1, s2;
    public GameObject wall, hole;
    public int points = 0;
    private float turn = 0;
    public GameObject spWall;
    public GameObject player;
    public GameObject score;
    public GameObject playButton;
    public Animator anima;
    public bool gameEnded;
    private int lvl = 1;


    public void PauseGame()
    {
        Time.timeScale = 0;
    }


    public void ResumeGame()
    {
        Time.timeScale = 1;
    }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    public void GivePoint(Transform caller)
    {
        points += lvl;
        Vector3 pos = caller.position;

        Destroy(caller.gameObject);
        Instantiate(spWall, pos, Quaternion.identity, transform);
        score.GetComponent<Text>().text = points.ToString();
        score.GetComponent<Animator>().Play("text");
    }

    public void Kill()
    {
        Debug.Log("Death");
        gameEnded = true;
        speed = 0;
        foreach (var item in GameObject.FindGameObjectsWithTag("TBD"))
        {
            Destroy(item);
        }
        playButton.SetActive(true);
    }

    float t = 0f;
    void Start()
    {
        gameEnded = true;
        speed = 0;
        score.GetComponent<Text>().text = points.ToString();
        player = GameObject.Find("Character");
        s1 = new Vector3(-2f, -10f, 0f);
        s2 = new Vector3( 2f, -10f, 0f);
        speed = GameManager.Instance.speed;
        for (int i = 0; i < 20; i++)
        {
            float ypos0 = s1.y - 1 + i * 1f;
            Instantiate(wall, new Vector3(s1.x, ypos0, s1.z), Quaternion.identity, transform);
            float ypos1 = s2.y - 1 + i * 1f;
            Instantiate(wall, new Vector3(s2.x, ypos1, s2.z), Quaternion.identity, transform);
        }
    }

    private void Update()
    {
        turn += Time.deltaTime * speed / 10f;
        if (turn >= 2) turn = 0;
        speed = GameManager.Instance.speed;

        t += speed * Time.deltaTime * 2f;

        if (t >= 1f)
        {
            System.Random rnd = new System.Random();

            int r = rnd.Next(1, 10);

            if (r > 1)
            {
                SpawnWall(s1);
                SpawnWall(s2);
            }
            else
            {
                if (zc >= minGap)
                {
                    zc = 0;
                    System.Random random = new System.Random((int)Time.timeSinceLevelLoad);
                    int z = random.Next(5);
                    if (z < 3)
                    {
                        SpawnHole(s1);
                        SpawnWall(s2);
                    }
                    else if (z >= 3)
                    {
                        SpawnHole(s2);
                        SpawnWall(s1);
                    }
                    zc = 0;
                }
                else
                {
                    SpawnWall(s1);
                    SpawnWall(s2);
                    zc++;
                }
            }
            t = 0f;
        }
    }

    public void PlayGame() 
    {
        gameEnded = false;
        speed = 2f;
        playButton.SetActive(false);
        anima.Play("char_spawn");
        score.GetComponent<Animator>().Play("f_in");
    }

    public void SpawnWall(Vector3 pos)
    {
        Instantiate(wall, new Vector3(pos.x, pos.y, pos.z), Quaternion.identity, transform);
    }

    public void SpawnHole(Vector3 pos)
    {
        Instantiate(hole, new Vector3(pos.x, pos.y, pos.z), Quaternion.identity, transform);
    }

}
