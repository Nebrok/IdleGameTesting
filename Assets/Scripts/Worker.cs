using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Worker : MonoBehaviour
{
    [SerializeField] public int WorkerRank;
    [SerializeField] public string WorkerName;


    //UI
    [SerializeField] public Image BackgroundImage;
    [SerializeField] public GameObject NameTextObject;
    [SerializeField] public GameObject LevelTextObject;
    [SerializeField] public GameObject EarningsTextObject;
    [SerializeField] public Slider ProgressBarObject;


    private Score _scoreRef;
    
    [SerializeField] private int _level = 0;
    private float _baseAmount = 1;
    private float _baseWorkTimeSeconds = 1.5f;
    private float _workTimeSeconds;

    private float _workTimeElapsed = 0.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (NameTextObject != null)
        {
            NameTextObject.GetComponent<TextMeshProUGUI>().text = WorkerName;
        }
        if (LevelTextObject != null)
        {
            LevelTextObject.GetComponent<TextMeshProUGUI>().text = "Lv: " + _level.ToString();
        }
        if (EarningsTextObject != null)
        {
            EarningsTextObject.GetComponent<TextMeshProUGUI>().text = (_baseAmount * _level).ToString();
        }

        _scoreRef = FindFirstObjectByType<Score>();

        _workTimeSeconds = _baseWorkTimeSeconds;
        if (_level <= 0)
        {
            BackgroundImage.color = new Color(0.5f, 0.5f, 0.5f, 1.0f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (_level <= 0)
        {
            return;
        }
        _workTimeElapsed += Time.deltaTime;
        if (_workTimeElapsed >= _workTimeSeconds)
        {
            WorkComplete();
        }
        ProgressBarObject.value = _workTimeElapsed / _workTimeSeconds;
    }

    void WorkComplete()
    {
        AddProductionToScore();
        _workTimeElapsed = 0.0f;
    }

    void AddProductionToScore()
    {
        _scoreRef.AddScore(_baseAmount * _level);
    }

    public void LevelUpWorker()
    {
        _level += 1;
        BackgroundImage.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        if (LevelTextObject != null)
        {
            LevelTextObject.GetComponent<TextMeshProUGUI>().text = "Lv: " + _level.ToString();
        }
        if (EarningsTextObject != null)
        {
            EarningsTextObject.GetComponent<TextMeshProUGUI>().text = (_baseAmount * _level).ToString();
        }
    }

}
