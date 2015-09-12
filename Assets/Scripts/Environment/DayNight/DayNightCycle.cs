using UnityEngine;

public class DayNightCycle
{
    public float HourDuratarionInSeconds;
    public float DayDurationInSeconds;
    public float RealTimeSecondsOfDayPassed;
    public float CurrentTime;
    public int CurrentHour;
    public int CurrentMinute;

    public bool SwitchingSkyboxes;
  //  public bool ChangingLightStrength;
    public DayOrNight CurrentDayOrNight;

    public Clock UIClock;
   // public Light DirectionalLight;

    private float _skyboxBlender;
    private float _lightStrengthBlender;
  //  private float _daytimeLightStrength = 1.1f;
   // private float _nighttimeLightStrength = 0.55f;

    public void InitialiseCycle()
    {
        UIClock = GameObject.Find("Clock").GetComponent<Clock>();
     //   DirectionalLight = GameObject.Find("Sun").GetComponent<Light>();
       // _lightStrengthBlender = DirectionalLight.intensity;
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
      //  Debug.Log(CurrentDayOrNight + " " + CurrentTime);

        UIClock.TurnPointer();

        if(CurrentTime > 6 && CurrentTime < 18 && 
            CurrentDayOrNight == DayOrNight.Night)
        {
            if(!SwitchingSkyboxes)
            {
                _skyboxBlender = 0;
                SwitchingSkyboxes = true;
       //         ChangingLightStrength = true;
            }

            SwitchSkybox(DayOrNight.Day);
          //  ChangeDirectionalLightStrength(DayOrNight.Day);
        }
        else if (CurrentTime > 18 && 
            CurrentDayOrNight == DayOrNight.Day)
        {
            if (!SwitchingSkyboxes)
            {
                _skyboxBlender = 1;
                SwitchingSkyboxes = true;
         //       ChangingLightStrength = true;
            }

            SwitchSkybox(DayOrNight.Night);
       //     ChangeDirectionalLightStrength(DayOrNight.Night);
        }
    }

    public void SwitchSkybox(DayOrNight goToTime)
    {
        if (goToTime == DayOrNight.Day)
        {
            _skyboxBlender = Mathf.Lerp(_skyboxBlender, 1f, 1f * Time.deltaTime);
            RenderSettings.skybox.SetFloat("_Blend", _skyboxBlender);
     //       Debug.Log("BLENDER: " + _skyboxBlender);
            if (_skyboxBlender > 0.95f)
            {
                CurrentDayOrNight = DayOrNight.Day;
        //        Debug.LogWarning("finished blending");
                SwitchingSkyboxes = false;
            }
        }
        else
        {
            _skyboxBlender = Mathf.Lerp(_skyboxBlender, 0f, 1f * Time.deltaTime);
            RenderSettings.skybox.SetFloat("_Blend", _skyboxBlender);
        //    Debug.Log("BLENDER: " + _skyboxBlender);
            if (_skyboxBlender < 0.05f)
            {
                CurrentDayOrNight = DayOrNight.Night;
         //       Debug.LogWarning("finished blending");
                SwitchingSkyboxes = false;
            }
        }
    }

    public void ChangeDirectionalLightStrength(DayOrNight goToTime)
    {
        //This seems to slow down the game significantly
        //if (goToTime == DayOrNight.Day)
        //{
        //    _lightStrengthBlender = Mathf.Lerp(_lightStrengthBlender, _daytimeLightStrength, .5f * Time.deltaTime);
        //    DirectionalLight.intensity = _lightStrengthBlender;
        //    if(DirectionalLight.intensity > (_daytimeLightStrength - .05f))
        //    {
        //        ChangingLightStrength = false;
        //    }
        //}
        //else
        //{
        //    _lightStrengthBlender = Mathf.Lerp(_lightStrengthBlender, _nighttimeLightStrength, .5f * Time.deltaTime);
        //    DirectionalLight.intensity = _lightStrengthBlender;
        //    if (DirectionalLight.intensity > (_nighttimeLightStrength + .05f))
        //    {
        //        ChangingLightStrength = false;
        //    }
        //}
    }
}
