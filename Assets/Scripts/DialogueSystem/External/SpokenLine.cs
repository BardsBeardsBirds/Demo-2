using UnityEngine;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;

public class SpokenLine 
{
    [XmlAttribute("ID")]
    public int ID;

    [XmlElement("Speaker")]
    public Character Speaker;

    [XmlElement("Text")]
    public string Text;

    [XmlElement("DialogueType")]
    public DialogueType DialogueType;

    [XmlElement("AudioId")]
    public int AudioId;

    [XmlElement("CameraAngle")]
    public CameraAngle CamAngle;

    [XmlElement("CameraMovement")]
    public CameraMoves CamMovement;

    [XmlElement("CameraMoveSmoothing")]
    public SmoothCameraMovement CamSmoothing;

    [XmlElement("CameraMoveStartTime")]
    public int CamMoveStartTime;

    [XmlElement("CameraMoveEndTime")]
    public int CamMoveEndTime;

    //[XmlElement("CameraMovementTiming")]
    //public CameraMovementTiming CamMovementTiming;

    [XmlElement("Object")]
    public string Object;

    [XmlElement("Notes")]
    public string Notes;


}
