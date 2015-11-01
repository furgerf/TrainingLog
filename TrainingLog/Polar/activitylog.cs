namespace TrainingLog.Polar
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.1432")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(TypeName = "activity-log", Namespace = "http://www.polarpersonaltrainer.com")]
  [System.Xml.Serialization.XmlRootAttribute("activity-log", Namespace = "http://www.polarpersonaltrainer.com", IsNullable = false)]
  public partial class activitylog : calendaritem
  {

    private string activetimeField;

    private string caloriesField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("active-time")]
    public string activetime
    {
      get
      {
        return this.activetimeField;
      }
      set
      {
        this.activetimeField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger")]
    public string calories
    {
      get
      {
        return this.caloriesField;
      }
      set
      {
        this.caloriesField = value;
      }
    }
  }
}