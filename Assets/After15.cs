using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class After15 : MonoBehaviour
{

    public GameObject box;
    public GameObject box2;
    public GameObject number_text;
    public GameObject timer_text;
    public GameObject panel_end;
    public GameObject panel_seperator;

    //public TextMeshProUGUI text_321;
    //public GameObject panel_321;

    private float count_down = 3;
    private bool checkTime = true;
    private int num;
    private int counter1 = 0;
    private int counter2 = 0;
    private float timer = 0;
    private int score = -1;
    private int score2 = -1;

    public UnityEngine.UI.Text text_comp;
    public UnityEngine.UI.Text text_comp2;
    public UnityEngine.UI.Text timer_text_comp;
    public UnityEngine.UI.Text score_text_comp;
    public UnityEngine.UI.Text score2_text_comp;


    public UnityEngine.UI.Text txt_end_high;
    public UnityEngine.UI.Text txt_end_score;
    // Start is called before the first frame update
    void Start()
    {
        float box_size = Screen.width * 16 / 100;
        box.GetComponent<RectTransform>().sizeDelta = new Vector2(box_size, box_size);
        box2.GetComponent<RectTransform>().sizeDelta = new Vector2(box_size, box_size);
        if (PlayerPrefs.HasKey("score"))
        {
            score = PlayerPrefs.GetInt("score");
        }
        score_text_comp.text = score.ToString();
        panel_end.active = false;
        panel_seperator.active = false;
        random_point(box.GetComponent<RectTransform>(), true);
        random_point(box2.GetComponent<RectTransform>(), false);
        generate_num();
    }

    // Update is called once per frame
    void Update()
    {

        panel_seperator.active = true;
        if (checkTime == true)
        {
            timer -= Time.deltaTime;
        }

        if (timer >= 0)
        {
            timer_text_comp.text = timer.ToString("0.0");
        }
        else
        {
            timer_text_comp.text = "0";
            box.active = false;
            box2.active = false;
            panel_seperator.active = false;
            panel_end.active = true;
            if (PlayerPrefs.GetInt("high_score") < score)
            {
                PlayerPrefs.SetInt("high_score", score);
            }
            txt_end_high.text = "High Score: " + PlayerPrefs.GetInt("high_score").ToString();
            txt_end_score.text = "Score: " + score.ToString();
        }

    }

    private void generate_num()
    {
        score++;
        score2 = score;
        score_text_comp.text = score.ToString();

        score2_text_comp.text = score2.ToString();
        int temp = num;
        while (temp == num)
        {
            num = Random.RandomRange(1, 6);
        }
        switch (num)
        {
            case 1:
                timer = times._1;
                break;
            case 2:
                timer = times._2;
                break;
            case 3:
                timer = times._3;
                break;
            case 4:
                timer = times._4;
                break;
            case 5:
                timer = times._5;
                break;
            default:
                break;
        }

        text_comp.text = num.ToString();
        text_comp2.text = num.ToString();
    }


    public void random_point(RectTransform rect, bool left)
    {

        float x, y;
        //var rect = box.GetComponent<RectTransform>();
        if (left)
        {
            x = Random.RandomRange((rect.sizeDelta.x / 2), (Screen.width / 2 - rect.sizeDelta.x / 2));
            y = Random.RandomRange(rect.sizeDelta.y / 2, Screen.height - rect.sizeDelta.y / 2);
        }
        else
        {
            x = Random.RandomRange(Screen.width / 2 + rect.sizeDelta.x / 2, Screen.width - rect.sizeDelta.x / 2);
            y = Random.RandomRange(rect.sizeDelta.y / 2, Screen.height - rect.sizeDelta.y / 2);
        }

        rect.position = new Vector3(x, y, 0);
    }

    class times
    {
        public static float _1 = 2f;
        public static float _2 = 6f;
        public static float _3 = 8f;
        public static float _4 = 13f;
        public static float _5 = 15f;
    }

    public void btn_replay()
    {
        /*
        counter1 = 0;
        counter2 = 0;
        score = -1;
        random_point(box.GetComponent<RectTransform>(), true);
        random_point(box2.GetComponent<RectTransform>(), false);
        generate_num();
        box.active = true;
        box2.active = true;
        panel_end.active = false;*/
        Application.LoadLevel(1);
    }

    public void box_click1()
    {
        random_point(box.GetComponent<RectTransform>(), true);

        counter1++;
        if (counter2 == num && counter1 == num)
        {
            counter1 = 0;
            counter2 = 0;
            generate_num();
        }
        else if (counter1 > num || counter2 > num)
        {
            panel_end.active = true;
            checkTime = false;
            box.active = false;
            box2.active = false;
            if (PlayerPrefs.GetInt("high_score") < score)
            {
                PlayerPrefs.SetInt("high_score", score);
            }
            txt_end_high.text = "High Score: " + PlayerPrefs.GetInt("high_score").ToString();
            txt_end_score.text = "Score: " + score.ToString();

        }
    }
    public void box_click2()
    {
        random_point(box2.GetComponent<RectTransform>(), false);
        counter2++;
        if (counter2 == num && counter1 == num)
        {
            counter1 = 0;
            counter2 = 0;
            generate_num();
        }
        else if (counter1 > num || counter2 > num)
        {
            panel_end.active = true;
            checkTime = false;
            box.active = false;
            box2.active = false;
            if (PlayerPrefs.GetInt("high_score") < score)
            {
                PlayerPrefs.SetInt("high_score", score);
            }
            txt_end_high.text = "High Score: " + PlayerPrefs.GetInt("high_score").ToString();
            txt_end_score.text = "Score: " + score.ToString();
        }
    }

    public void btn_home()
    {
        Application.LoadLevel(0);
    }
}

