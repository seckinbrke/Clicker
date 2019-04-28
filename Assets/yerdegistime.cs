using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class yerdegistime : MonoBehaviour
{
    public GameObject box;
    public GameObject number_text;
    public GameObject timer_text;
    public GameObject panel_end;

    public TextMeshProUGUI text_321;
    public GameObject panel_321;

    private float count_down = 3;
    private int num;
    private int counter = 0;
    private float timer = 0;
    private int score = -1;
    private int score2 = -1;

    public UnityEngine.UI.Text text_comp;
    public UnityEngine.UI.Text timer_text_comp;
    public UnityEngine.UI.Text score_text_comp;
    public UnityEngine.UI.Text score2_text_comp;



    public UnityEngine.UI.Text txt_end_high;
    public UnityEngine.UI.Text txt_end_score;

    void Start()
    {
        float box_size = Screen.width * 16 / 100;
        box.GetComponent<RectTransform>().sizeDelta = new Vector2(box_size, box_size);
        if (!PlayerPrefs.HasKey("high_score"))
        {
            PlayerPrefs.SetInt("high_score", 0);
        }

        panel_end.active = false;
        panel_321.active = true;
        random_point();
        generate_num();
    }

    void Update()
    {
        if (count_down > 0)
        {
            count_down -= Time.deltaTime;
            text_321.text = count_down.ToString("0");
        }
        else
        {
            panel_321.active = false;
        

        timer -= Time.deltaTime;
        if (timer >= 0)
        {
            timer_text_comp.text = timer.ToString("0.0");
        }
        else
        {
            timer_text_comp.text = "0";
            box.active = false;
            panel_end.active = true;
            if (PlayerPrefs.GetInt("high_score") < score)
            {
                PlayerPrefs.SetInt("high_score", score);
            }
            txt_end_high.text = "High Score: " + PlayerPrefs.GetInt("high_score").ToString();
            txt_end_score.text = "Score: " + score.ToString();
        }
        }
    }

    private void generate_num()
    {
        score++;
        if(score > 14)
        {
            PlayerPrefs.SetInt("score", score);
            Application.LoadLevel(2);
        }
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

    }
    public void box_click()
    {
        random_point();
        counter++;
        if (counter == num)
        {
            counter = 0;
            generate_num();
        }
    }

    public void random_point()
    {
        float x, y;
        var rect = box.GetComponent<RectTransform>();
        x = Random.RandomRange(rect.sizeDelta.x / 2, Screen.width - rect.sizeDelta.x / 2);
        y = Random.RandomRange(rect.sizeDelta.y / 2, Screen.height - rect.sizeDelta.y / 2);


        rect.position = new Vector3(x, y, 0);
    }

    class times
    {
        public static float _1 = 0.9f;
        public static float _2 = 1.7f;
        public static float _3 = 2.2f;
        public static float _4 = 2.7f;
        public static float _5 = 3.1f;
    }

    public void btn_replay()
    {
        counter = 0;
        score = -1;
        score2 = -1;
        random_point();
        generate_num();
        box.active = true;
        panel_end.active = false;
    }


  
    public void btn_home()
    {
        Application.LoadLevel(0);
    }
}