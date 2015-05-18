using UnityEngine;

public class DayNightCycle
{
    public float HourDuratarionInSeconds;
    public float DayDurationInSeconds;
    public float RealTimeSecondsOfDayPassed;
    public float CurrentTime;
    public int CurrentHour;
    public int CurrentMinute;
    //public bool Night;
    //public bool SunDown;
    //public bool SunUp;
    public bool SwitchingSkyboxes;
    public DayOrNight CurrentDayOrNight;

    public Clock UIClock;

    private float _skyboxBlender;

    public void InitialiseCycle()
    {
        UIClock = GameObject.Find("Clock").GetComponent<Clock>();
        CurrentDayOrNight = DayOrNight.Day;
        RenderSettings.skybox.SetFloat("_Blend", 1f);


        HourDuratarionInSeconds = 2f;
        DayDurationInSeconds = HourDuratarionInSeconds * 24;

        RealTimeSecondsOfDayPassed = 24f;
    }

    public void PassTime()
    {
        RealTimeSecondsOfDayPassed += Time.deltaTime;

        if (RealTimeSecondsOfDayPassed >= DayDurationInSeconds)
            RealTimeSecondsOfDayPassed = 0f;

        CurrentTime = (RealTimeSecondsOfDayPassed / DayDurationInSeconds) * 24;
    //    Debug.Log("The time is now: " + CurrentTime + " total day: " + DayDurationInSeconds + " " + RealTimeSecondsOfDayPassed);
        Debug.Log(CurrentDayOrNight + " " + CurrentTime);


        UIClock.TurnPointer();


        if(CurrentTime > 6 && CurrentTime < 18 && 
            CurrentDayOrNight == DayOrNight.Night)
        {
            if(!SwitchingSkyboxes)
            {
                _skyboxBlender = 0;
                SwitchingSkyboxes = true;
            }

            SwitchSkybox(DayOrNight.Day);
        }
        else if (CurrentTime > 18 && 
            CurrentDayOrNight == DayOrNight.Day)
        {
            if (!SwitchingSkyboxes)
            {
                _skyboxBlender = 1;
                SwitchingSkyboxes = true;
            }

            SwitchSkybox(DayOrNight.Night);
        }

        //if (CurrentTime < 6 || CurrentTime > 18)
        //{
        //    Night = true;
        //    if(!SunDown)
        //    {
        //        SwitchSkybox(DayOrNight.Night);
        //    }
        //}
        //else
        //{
        //    Night = false;
        //    if(!SunUp)
        //    {
        //        SwitchSkybox(DayOrNight.Day);
        //    }
        //}

        
    }

    public void SwitchSkybox(DayOrNight goToTime)
    {
        if (goToTime == DayOrNight.Day)
        {
            _skyboxBlender = Mathf.Lerp(_skyboxBlender, 1f, 1f * Time.deltaTime);
            RenderSettings.skybox.SetFloat("_Blend", _skyboxBlender);
            Debug.Log("BLENDER: " + _skyboxBlender);
            if (_skyboxBlender > 0.95f)
            {
                CurrentDayOrNight = DayOrNight.Day;
                Debug.LogWarning("finished blending");
                SwitchingSkyboxes = false;
            }
        }
        else
        {
            _skyboxBlender = Mathf.Lerp(_skyboxBlender, 0f, 1f * Time.deltaTime);
            RenderSettings.skybox.SetFloat("_Blend", _skyboxBlender);
            Debug.Log("BLENDER: " + _skyboxBlender);
            if (_skyboxBlender < 0.05f)
            {
                CurrentDayOrNight = DayOrNight.Night;
                Debug.LogWarning("finished blending");
                SwitchingSkyboxes = false;
            }
        }
    }  
}
