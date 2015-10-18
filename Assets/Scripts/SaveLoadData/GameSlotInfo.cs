using System;
using System.Collections.Generic;
//using System.Xml;
//using System.Xml.Serialization;

public enum GameSlot { None, Slot1, Slot2, Slot3, Slot4 };

/// <summary>
/// GameSlotInfo holds information to be displayed on the slots for save and load games.
/// </summary>
public class GameSlotInfo
{
  //  [XmlAttribute("ID")]
    public int ID;
  //  [XmlElement("GameSlot")]
    public GameSlot Slot;
  //  [XmlElement("LastSaveDate")]
    public DateTime LastSaveDate;
 //   [XmlElement("Location")]
    public Areas Location;
 //   [XmlElement("Level")]
    public int Level;

}

