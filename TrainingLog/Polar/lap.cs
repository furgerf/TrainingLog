namespace TrainingLog.Polar
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.1432")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.polarpersonaltrainer.com")]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.polarpersonaltrainer.com", IsNullable = false)]
  public partial class lap
  {

    private string durationField;

    private heartraterange heartrateField;

    private floatrange speedField;

    private shortrange cadenceField;

    private power powerField;

    private floatrange temperatureField;

    private float altitudeField;

    private bool altitudeFieldSpecified;

    private float ascentField;

    private bool ascentFieldSpecified;

    private float descentField;

    private bool descentFieldSpecified;

    private float distanceField;

    private bool distanceFieldSpecified;

    private short directionField;

    private bool directionFieldSpecified;

    private endingvalues endingvaluesField;

    private string indexField;

    /// <remarks/>
    public string duration
    {
      get
      {
        return this.durationField;
      }
      set
      {
        this.durationField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("heart-rate")]
    public heartraterange heartrate
    {
      get
      {
        return this.heartrateField;
      }
      set
      {
        this.heartrateField = value;
      }
    }

    /// <remarks/>
    public floatrange speed
    {
      get
      {
        return this.speedField;
      }
      set
      {
        this.speedField = value;
      }
    }

    /// <remarks/>
    public shortrange cadence
    {
      get
      {
        return this.cadenceField;
      }
      set
      {
        this.cadenceField = value;
      }
    }

    /// <remarks/>
    public power power
    {
      get
      {
        return this.powerField;
      }
      set
      {
        this.powerField = value;
      }
    }

    /// <remarks/>
    public floatrange temperature
    {
      get
      {
        return this.temperatureField;
      }
      set
      {
        this.temperatureField = value;
      }
    }

    /// <remarks/>
    public float altitude
    {
      get
      {
        return this.altitudeField;
      }
      set
      {
        this.altitudeField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool altitudeSpecified
    {
      get
      {
        return this.altitudeFieldSpecified;
      }
      set
      {
        this.altitudeFieldSpecified = value;
      }
    }

    /// <remarks/>
    public float ascent
    {
      get
      {
        return this.ascentField;
      }
      set
      {
        this.ascentField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool ascentSpecified
    {
      get
      {
        return this.ascentFieldSpecified;
      }
      set
      {
        this.ascentFieldSpecified = value;
      }
    }

    /// <remarks/>
    public float descent
    {
      get
      {
        return this.descentField;
      }
      set
      {
        this.descentField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool descentSpecified
    {
      get
      {
        return this.descentFieldSpecified;
      }
      set
      {
        this.descentFieldSpecified = value;
      }
    }

    /// <remarks/>
    public float distance
    {
      get
      {
        return this.distanceField;
      }
      set
      {
        this.distanceField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool distanceSpecified
    {
      get
      {
        return this.distanceFieldSpecified;
      }
      set
      {
        this.distanceFieldSpecified = value;
      }
    }

    /// <remarks/>
    public short direction
    {
      get
      {
        return this.directionField;
      }
      set
      {
        this.directionField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool directionSpecified
    {
      get
      {
        return this.directionFieldSpecified;
      }
      set
      {
        this.directionFieldSpecified = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("ending-values")]
    public endingvalues endingvalues
    {
      get
      {
        return this.endingvaluesField;
      }
      set
      {
        this.endingvaluesField = value;
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