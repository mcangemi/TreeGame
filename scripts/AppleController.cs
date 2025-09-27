using System.Collections;
using UnityEngine;

public class AppleController : MonoBehaviour
{
    private Vector2 startPos;
    public GameObject[] applePrefabs;
    public float numApples = 0;

    void Start()
    {
        IEnumerator Method = SpawnApples();
        StartCoroutine(Method);
        startPos = transform.position;
    }

    IEnumerator SpawnApples()
    {
        while (true)
        {
            int index = Random.Range(0, applePrefabs.Length);
            float xpos = Random.Range(transform.position.x - 1f, transform.position.x + 1f);
            Vector2 pos = new Vector2(xpos, transform.position.y);
            Instantiate(applePrefabs[index], pos, Quaternion.identity);
            numApples++;
            float wait = 1.01f - Time.deltaTime / 10;
            if (wait < 0.2f) wait = 0.2f;
            yield return new WaitForSeconds(1.01f - Time.deltaTime / 10);
        }
    }
}
