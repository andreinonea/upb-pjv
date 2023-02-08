using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    List<GameObject> spawnPoints;

    [SerializeField]
    int minorVictory;

    [SerializeField]
    int majorVictory;

    [SerializeField]
    int maxEnemiesAtOnce;

    [SerializeField]
    float spawnRate;

    int score;
    int enemies;

    [SerializeField]
    GameObject enemy;

    bool cooldown = false;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        enemies = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (score >= majorVictory || enemies == maxEnemiesAtOnce || cooldown)
            return;

        int selectedSpawn = Random.Range(0, spawnPoints.Count);
        Instantiate(enemy, spawnPoints[selectedSpawn].transform.position, Quaternion.identity);
        ++enemies;
        cooldown = true;
        StartCoroutine(Cooldown());
    }

    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(spawnRate);
        cooldown = false;
    }

    public void AddScore()
    {
        --enemies;
        ++score;

        if (score == minorVictory)
            AnimateMinorVictory();
        else if (score == majorVictory)
            AnimateMajorVictory();
    }

    private void AnimateMinorVictory()
    {
        GameObject ken = GameObject.Find("ken-sprite-sheet_21");
        ken.GetComponent<SpriteRenderer>().enabled = true;
        Destroy(ken, 1.5f);
    }

    private void AnimateMajorVictory()
    {
        GameObject.Find("Planta").GetComponent<SpriteRenderer>().enabled = true;
    }
}
