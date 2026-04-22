using TMPro;
using UnityEngine;


public class Score : MonoBehaviour
{
    //public ScientficNumber MainScore;
    public float MainScore;

    [SerializeField] public GameObject ScoreTextObject;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ScoreTextObject != null)
        {
            ScoreTextObject.GetComponent<TextMeshProUGUI>().text = MainScore.ToString();
        }
    }

    public void AddScore(float additionalScore)
    {
        MainScore += additionalScore;
    }
}
