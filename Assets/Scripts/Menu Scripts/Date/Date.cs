using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Date : MonoBehaviour
{
    #region Old
    //public TextMeshPro largeText;

    //// Start is called before the first frame update
    //void Start()
    //{
    //    string time = System.DateTime.UtcNow.ToLocalTime().ToString("HH:mm");//Display only Time

    //    //string time = System.DateTime.UtcNow.ToLocalTime().ToString("dd-MM-yyyy    HH:mm");//Display Year and Time

    //    //string time = System.DateTime.UtcNow.ToLocalTime().ToString("M/d/yy    HH:mm tt");//Display Year and Time with AM/PM

    //    print(time);

    //    largeText.text = time;

    //}
    #endregion

    //Note: Make player set how he/ she wants format to be at the start of the games.

    public TextMeshProUGUI[] UI_TIME_TEXT;
    public TextMeshProUGUI[] UI_DATE_TEXT;
    public TimeFormat timeFormat = TimeFormat.Hour_24;
    public DateFormat dateFormat = DateFormat.MM_DD_YYYY;

    public float secPerMin = 1;

    private string _time;
    private string _date;

    private bool isAm = false;

    int hr, min, seconds,
        day, month, year;

    int h;

    int maxHr = 24,
        maxMin = 60,
        maxSec = 60,
        maxDay = 30,
        maxMonth = 12;

    float timer = 0;

    public enum TimeFormat
    {
        Hour_24,
        Hour_12
    }

    public enum DateFormat
    {
        MM_DD_YYYY,
        DD_MM_YYYY,
        YYYY_MM_DD,
        YYYY_DD_MM
    }

    private void Awake()
    {
        seconds = System.DateTime.Now.Second;
        hr = System.DateTime.Now.Hour;
        min = System.DateTime.Now.Minute;
        day = System.DateTime.Now.Day;
        month = System.DateTime.Now.Month;
        year = System.DateTime.Now.Year;

        if (hr < 12)
        {
            isAm = true;
        }

        SetTimeDateString();
    }

    public void Update()
    {
        if (timer >= secPerMin)
        {
            seconds++;
            if (seconds >= maxSec)
            {
                seconds = 0;
                min++;
                if (min >= maxMin)
                {
                    min = 0;
                    hr++;
                    if (hr >= maxHr)
                    {
                        hr = 0;
                        day++;
                        if (day >= maxDay)
                        {
                            day = 1;
                            month++;
                            if (month >= maxMonth)
                            {
                                month = 1;
                                year++;
                            }
                        }
                    }
                }
            }
           
            SetTimeDateString();

            timer = 0;
        }
        else
        {
            timer += Time.deltaTime;
        }
    }


    void SetTimeDateString()
    {
        
        switch (timeFormat)
        {
            case TimeFormat.Hour_12:
                {
                    if (hr >= 13)
                    {
                        h = hr - 12;
                    }
                    else if (hr == 0)
                    {
                        hr = 12;
                    }
                    else
                    {
                        h = hr;
                    }


                    _time = $"{h}:";

                    if (min < 10)
                    {
                            _time += "0" + min;
                    }
                    else
                    {
                        _time += min;
                    }

                    if(seconds < 10)
                    {
                        _time += ":0" + seconds;
                    }
                    else
                    {
                        _time += ":" + seconds;
                    }

                    if (isAm)
                    {
                        _time += " AM";
                    }
                    else
                    {
                        _time += " PM";
                    }

                    break;
                }//End Case Hour_12
            case TimeFormat.Hour_24:
                {
                    if (hr <= 9)
                    {
                        _time = "0" + hr + ":";
                    }
                    else
                    {
                        _time = hr + ":";
                    }

                    if (min < 10)
                    {
                        _time += "0" + min + ":";
                    }
                    else
                    {
                        _time += min + ":";
                    }

                    if (seconds < 10)
                    {
                        _time += "0" + seconds;
                    }
                    else
                    {
                        _time += seconds;
                    }

                    break;
                }// End Case Hour_24
        }// End Switch Time Format

        switch (dateFormat)
        {
            case DateFormat.MM_DD_YYYY:
                {
                    _date = month + "/" + day + "/" + year;
                    break;
                }
            case DateFormat.DD_MM_YYYY:
                {
                    _date = day + "/" + month + "/" + year;
                    break;
                }
            case DateFormat.YYYY_MM_DD:
                {
                    _date = year + "/" + month + "/" + day;
                    break;
                }
            case DateFormat.YYYY_DD_MM:
                {
                    _date = year + "/" + day + "/" + month;
                    break;
                }
        }// End Switch Date Format

        for (int i = 0; i < UI_TIME_TEXT.Length; i++)
        {
            UI_TIME_TEXT[i].text = _time;
        }

        for (int i = 0; i < UI_DATE_TEXT.Length; i++)
        {
            UI_DATE_TEXT[i].text = _date;
        }

    }

    #region TimeScript
    //public class TimeScript: MonoBehaviour
    //{

    //    public string myFormat; //format = h:mm:ss tt

    //    public TextMeshProUGUI mainClock;

    //    public System.TimeSpan timeSpan = new System.TimeSpan(0, 0, 0, 0, 0);

    //    public System.DateTime date = new System.DateTime(1990, 04, 20);

    //    public float timeRate = 1;

    //    public void Update()
    //    {
    //        float milliseconds = Time.deltaTime * 1000 * timeRate;

    //        timeSpan += new System.TimeSpan(0, 0, 0, 0, (int)milliseconds);
    //        System.DateTime dateTime = date.DateTime.MinValue.Add(timeSpan);

    //        mainClock.text = dateTime.ToString(@myFormat);

    //        mainClock.text = dateTime.ToString(@myFormat, new CultureInfo("en-US"));


    //    }

    //    public void AddTime(int value)
    //    {
    //        timeSpan += new System.TimeSpan(value, 0, 0);
    //    }

    //}
    #endregion

    #region Clock
    //public class Clock : MonoBehaviour
    //{


    //    //Note: Make player set how he/ she wants format to be at the start of the games.

    //    public TextMeshProUGUI[] UI_TIME_TEXT;
    //    public TextMeshProUGUI[] UI_DATE_TEXT;
    //    public TimeFormat timeFormat; //= new TimeFormat.Hour_24;
    //    public DateFormat dateFormat; //= new DateFormat.MM_DD_YYYY;

    //    public float secPerMin = 1;

    //    private string _time;
    //    private string _date;

    //    private bool isAm = false;

    //    int hr, min,
    //        day, month, year;

    //    int maxHr = 24,
    //        maxMin = 60,
    //        maxDay = 30,
    //        maxMonth = 12;

    //    float timer = 0;

    //    public enum TimeFormat
    //    {
    //        Hour_24,
    //        Hour_12
    //    }

    //    public enum DateFormat
    //    {
    //        MM_DD_YYYY,
    //        DD_MM_YYYY,
    //        YYYY_MM_DD,
    //        YYYY_DD_MM
    //    }

    //    private void Awake()
    //    {
    //        if (hr < 12)
    //        {
    //            isAm = true;
    //        }
    //    }

    //    public void Update()
    //    {
    //        if (timer >= secPerMin)
    //        {
    //            min++;
    //            if (min >= maxMin)
    //            {
    //                min = 0;
    //                hr++;
    //                if (hr >= maxHr)
    //                {
    //                    hr = 0;
    //                    day++;
    //                    if (day >= maxDay)
    //                    {
    //                        day = 1;
    //                        month++;
    //                        if (month >= maxMonth)
    //                        {
    //                            month = 1;
    //                            year++;
    //                        }
    //                    }
    //                }
    //            }
    //            SetTimeDateString();

    //            timer = 0;
    //        }
    //        else
    //        {
    //            timer += Time.deltaTime;
    //        }
    //    }


    //    void SetTimeDateString()
    //    {
    //        switch (timeFormat)
    //        {
    //            case TimeFormat.Hour_24:
    //                {
    //                    if (hr <= 9)
    //                    {
    //                        _time = "0" + hr + ":";
    //                    }
    //                    else
    //                    {
    //                        _time = hr + ":";
    //                    }

    //                    if (min < 9)
    //                    {
    //                        _time += "0" + min;
    //                    }
    //                    else
    //                    {
    //                        _time += min;
    //                    }

    //                    break;
    //                }
    //            case TimeFormat.Hour_12:
    //                {
    //                    int h;

    //                    if (hr >= 13)
    //                    {
    //                        h = hr - 12;
    //                    }
    //                    else if (hr == 0)
    //                    {
    //                        hr = 12;
    //                    }
    //                    else
    //                    {
    //                        h = hr;
    //                    }

    //                    _time = h + ":";

    //                    if (min < 9)
    //                    {
    //                        _time += "0" + min;
    //                    }
    //                    else
    //                    {
    //                        _time += min;
    //                    }

    //                    if (isAm)
    //                    {
    //                        _time += " AM";
    //                    }
    //                    else
    //                    {
    //                        _time += " PM";
    //                    }

    //                    break;
    //                }
    //        }

    //        switch (dateFormat)
    //        {
    //            case DateFormat.MM_DD_YYYY:
    //                {
    //                    _date = month + "/" + day + "/" + year;
    //                    break;
    //                }
    //            case DateFormat.DD_MM_YYYY:
    //                {
    //                    _date = day + "/" + month + "/" + year;
    //                    break;
    //                }
    //            case DateFormat.YYYY_MM_DD:
    //                {
    //                    _date = year + "/" + month + "/" + day;
    //                    break;
    //                }
    //            case DateFormat.YYYY_DD_MM:
    //                {
    //                    _date = year + "/" + day + "/" + month;
    //                    break;
    //                }
    //        }
    //    }
    //}
    #endregion


}






