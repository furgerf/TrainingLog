namespace TrainingLog.Polar
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.1432")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.polarpersonaltrainer.com")]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.polarpersonaltrainer.com", IsNullable = false)]
  public partial class move
  {

    private strengthactivity activityField;

    private float weightField;

    private bool weightFieldSpecified;

    private sbyte setsField;

    private bool setsFieldSpecified;

    private byterange repetitionsField;

    private string starttimeField;

    private string endtimeField;

    private string indexField;

    /// <remarks/>
    public strengthactivity activity
    {
      get
      {
        return this.activityField;
      }
      set
      {
        this.activityField = value;
      }
    }

    /// <remarks/>
    public float weight
    {
      get
      {
        return this.weightField;
      }
      set
      {
        this.weightField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool weightSpecified
    {
      get
      {
        return this.weightFieldSpecified;
      }
      set
      {
        this.weightFieldSpecified = value;
      }
    }

    /// <remarks/>
    public sbyte sets
    {
      get
      {
        return this.setsField;
      }
      set
      {
        this.setsField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool setsSpecified
    {
      get
      {
        return this.setsFieldSpecified;
      }
      set
      {
        this.setsFieldSpecified = value;
      }
    }

    /// <remarks/>
    public byterange repetitions
    {
      get
      {
        return this.repetitionsField;
      }
      set
      {
        this.repetitionsField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("start-time")]
    public string starttime
    {
      get
      {
        return this.starttimeField;
      }
      set
      {
        this.starttimeField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("end-time")]
    public string endtime
    {
      get
      {
        return this.endtimeField;
      }
      set
      {
        this.endtimeField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "nonNegativeInteger")]
    public string index
    {
      get
      {
        return this.indexField;
      }
      set
      {
        this.indexField = value;
      }
    }
  }
}