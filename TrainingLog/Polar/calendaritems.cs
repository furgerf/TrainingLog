namespace TrainingLog.Polar
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.1432")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(TypeName = "calendar-items", Namespace = "http://www.polarpersonaltrainer.com")]
  [System.Xml.Serialization.XmlRootAttribute("calendar-items", Namespace = "http://www.polarpersonaltrainer.com", IsNullable = false)]
  public partial class calendaritems
  {

    private calendaritem[] itemsField;

    private string countField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("activity-log", typeof(activitylog))]
    [System.Xml.Serialization.XmlElementAttribute("event", typeof(@event))]
    [System.Xml.Serialization.XmlElementAttribute("exercise", typeof(exercisedata))]
    [System.Xml.Serialization.XmlElementAttribute("fitness-data", typeof(fitnessdata))]
    [System.Xml.Serialization.XmlElementAttribute("note", typeof(note))]
    public calendaritem[] Items
    {
      get
      {
        return this.itemsField;
      }
      set
      {
        this.itemsField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "nonNegativeInteger")]
    public string count
    {
      get
      {
        return this.countField;
      }
      set
      {
        this.countField = value;
      }
    }
  }
}