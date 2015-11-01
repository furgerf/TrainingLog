namespace TrainingLog.Polar
{
  /// <remarks/>
  [System.Xml.Serialization.XmlIncludeAttribute(typeof(@event))]
  [System.Xml.Serialization.XmlIncludeAttribute(typeof(exercisedata))]
  [System.Xml.Serialization.XmlIncludeAttribute(typeof(fitnessdata))]
  [System.Xml.Serialization.XmlIncludeAttribute(typeof(note))]
  [System.Xml.Serialization.XmlIncludeAttribute(typeof(activitylog))]
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.1432")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(TypeName = "calendar-item", Namespace = "http://www.polarpersonaltrainer.com")]
  [System.Xml.Serialization.XmlRootAttribute("calendar-item", Namespace = "http://www.polarpersonaltrainer.com", IsNullable = false)]
  public partial class calendaritem
  {

    private string createdField;

    private string timeField;

    /// <remarks/>
    public string created
    {
      get
      {
        return this.createdField;
      }
      set
      {
        this.createdField = value;
      }
    }

    /// <remarks/>
    public string time
    {
      get
      {
        return this.timeField;
      }
      set
      {
        this.timeField = value;
      }
    }
  }
}