namespace TrainingLog.Polar
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.1432")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(TypeName = "blood-pressure", Namespace = "http://www.polarpersonaltrainer.com")]
  [System.Xml.Serialization.XmlRootAttribute("blood-pressure", Namespace = "http://www.polarpersonaltrainer.com", IsNullable = false)]
  public partial class bloodpressure
  {

    private short systolicField;

    private bool systolicFieldSpecified;

    private short diastolicField;

    private bool diastolicFieldSpecified;

    /// <remarks/>
    public short systolic
    {
      get
      {
        return this.systolicField;
      }
      set
      {
        this.systolicField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool systolicSpecified
    {
      get
      {
        return this.systolicFieldSpecified;
      }
      set
      {
        this.systolicFieldSpecified = value;
      }
    }

    /// <remarks/>
    public short diastolic
    {
      get
      {
        return this.diastolicField;
      }
      set
      {
        this.diastolicField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool diastolicSpecified
    {
      get
      {
        return this.diastolicFieldSpecified;
      }
      set
      {
        this.diastolicFieldSpecified = value;
      }
    }
  }
}