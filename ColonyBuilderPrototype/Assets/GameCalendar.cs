using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameEngine;
using UnityEngine.UI;
using System;

public class GameCalendar : MonoBehaviour {

    public int CurrentWeek { get; private set; }
    public Months CurrentMonth { get; private set; }
    public Seasons CurrentSeason { get; private set; }
    public Text seasonDisplay;
    public int CurrentYear { get; private set; }
    public Text dateDisplay;

    public enum Months {
        January = 1,
        February = 2,
        March = 3,
        April = 4,
        May = 5,
        June = 6,
        July = 7,
        August = 8,
        September = 9,
        October = 10,
        November = 11,
        December = 12
    }

    public enum Seasons {
        Winter = 1,
        Spring = 2,
        Summer = 3,
        Fall = 4
    }

	private void Start() {
        TimeManager.OnTick += calendarUpdate;
        CurrentMonth = Months.January;
        CurrentWeek = 1;
        CurrentYear = 1;
        CurrentSeason = Seasons.Winter;

        seasonDisplay.text = CurrentSeason.ToString();
        dateDisplay.text = "Week " + CurrentWeek + " of " + CurrentMonth + ", Year " + CurrentYear;
    }


    private void Update() {
        
    }

    private void calendarUpdate(object sender, TimeManager.OnTickEventArgs e) {
        int thisTick = e.tick;
        CurrentWeek++;
        if (CurrentWeek > 4){
            CurrentWeek -= 4;
            CurrentMonth++;
            if ((int)CurrentMonth == 3)
                CurrentSeason = Seasons.Spring;
            else if ((int)CurrentMonth == 6)
                CurrentSeason = Seasons.Summer;
            else if ((int)CurrentMonth == 9)
                CurrentSeason = Seasons.Fall;
            else if ((int)CurrentMonth == 12)
                CurrentSeason = Seasons.Winter;
            else if ((int)CurrentMonth > 12) {
                CurrentMonth = Months.January;
                CurrentYear++;
            }
        }

        
        seasonDisplay.text = CurrentSeason.ToString();
        dateDisplay.text = "Week "+CurrentWeek + " of " + CurrentMonth + ", Year " + CurrentYear;

    }

}

