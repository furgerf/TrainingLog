namespace TrainingLog.Polar
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.1432")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(TypeName = "polar-exercise-data", Namespace = "http://www.polarpersonaltrainer.com")]
  [System.Xml.Serialization.XmlRootAttribute("polar-exercise-data", Namespace = "http://www.polarpersonaltrainer.com", IsNullable = false)]
  public partial class polarexercisedata
  {

    private user userField;

    private calendaritems calendaritemsField;

    private double versionField;

    /// <remarks/>
    public user user
    {
      get
      {
        return this.userField;
      }
      set
      {
        this.userField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("calendar-items")]
    public calendaritems calendaritems
    {
      get
      {
        return this.calendaritemsField;
      }
      set
      {
        this.calendaritemsField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public double version
    {
      get
      {
        return this.versionField;
      }
      set
      {
        this.versionField = value;
      }
    }
  }
}