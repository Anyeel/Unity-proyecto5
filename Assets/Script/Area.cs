using System.Collections;
using UnityEngine;

public class Area : MonoBehaviour
{
    [SerializeField] float damage = 10f;
    [SerializeField] float fadeTime = 2f;
    [SerializeField] Color initialColor;
    PlayerStats playerStats; 

    void Start()
    {
        playerStats = FindAnyObjectByType<PlayerStats>();
    }

    public IEnumerator FadeArea()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        Color currentColor = initialColor;
        float time = 0;

        while (time < fadeTime)
        {
            time += Time.deltaTime;
            currentColor.a = initialColor.a - (initialColor.a * (time / fadeTime));
            spriteRenderer.color = currentColor;
            yield return null;
        }

        Destroy(gameObject);
    }

}

// t : 0 -> ft
// v : 0 -> 1 (t respecto de ft)
// a(v)
//      v = 0 -> 1
