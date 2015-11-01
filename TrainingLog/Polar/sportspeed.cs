namespace TrainingLog.Polar
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.1432")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(TypeName = "sport-speed", Namespace = "http://www.polarpersonaltrainer.com")]
  [System.Xml.Serialization.XmlRootAttribute("sport-speed", Namespace = "http://www.polarpersonaltrainer.com", IsNullable = false)]
  public partial class sportspeed
  {

    private float stridelengthavgField;

    private bool stridelengthavgFieldSpecified;

    private float runningindexField;

    private bool runningindexFieldSpecified;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("stride-length-avg")]
    public float stridelengthavg
    {
      get
      {
        return this.stridelengthavgField;
      }
      set
      {
        this.stridelengthavgField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool stridelengthavgSpecified
    {
      get
      {
        return this.stridelengthavgFieldSpecified;
      }
      set
      {
        this.stridelengthavgFieldSpecified = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("running-index")]
    public float runningindex
    {
      get
      {
        return this.runningindexField;
      }
      set
      {
        this.runningindexField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool runningindexSpecified
    {
      get
      {
        return this.runningindexFieldSpecified;
      }
      set
      {
        this.runningindexFieldSpecified = value;
      }
    }
  }
}