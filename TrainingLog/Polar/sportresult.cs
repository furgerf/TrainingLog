namespace TrainingLog.Polar
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.1432")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(TypeName = "sport-result", Namespace = "http://www.polarpersonaltrainer.com")]
  [System.Xml.Serialization.XmlRootAttribute("sport-result", Namespace = "http://www.polarpersonaltrainer.com", IsNullable = false)]
  public partial class sportresult : exercise
  {

    private heartraterange heartrateField;

    private sbyte runningindexField;

    private bool runningindexFieldSpecified;

    private short recordingrateField;

    private bool recordingrateFieldSpecified;

    private sbyte fatconsumptionField;

    private bool fatconsumptionFieldSpecified;

    private lap[] lapsField;

    private lap[] autolapsField;

    private sportspeed sportspeedField;

    private floatrange altitudeField;

    private limit[] limitsField;

    private sample[] samplesField;

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
    [System.Xml.Serialization.XmlElementAttribute("running-index")]
    public sbyte runningindex
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

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("recording-rate")]
    public short recordingrate
    {
      get
      {
        return this.recordingrateField;
      }
      set
      {
        this.recordingrateField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool recordingrateSpecified
    {
      get
      {
        return this.recordingrateFieldSpecified;
      }
      set
      {
        this.recordingrateFieldSpecified = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("fat-consumption")]
    public sbyte fatconsumption
    {
      get
      {
        return this.fatconsumptionField;
      }
      set
      {
        this.fatconsumptionField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool fatconsumptionSpecified
    {
      get
      {
        return this.fatconsumptionFieldSpecified;
      }
      set
      {
        this.fatconsumptionFieldSpecified = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute(IsNullable = false)]
    public lap[] laps
    {
      get
      {
        return this.lapsField;
      }
      set
      {
        this.lapsField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute(IsNullable = false)]
    public lap[] autolaps
    {
      get
      {
        return this.autolapsField;
      }
      set
      {
        this.autolapsField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("sport-speed")]
    public sportspeed sportspeed
    {
      get
      {
        return this.sportspeedField;
      }
      set
      {
        this.sportspeedField = value;
      }
    }

    /// <remarks/>
    public floatrange altitude
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
    [System.Xml.Serialization.XmlArrayItemAttribute(IsNullable = false)]
    public limit[] limits
    {
      get
      {
        return this.limitsField;
      }
      set
      {
        this.limitsField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute(IsNullable = false)]
    public sample[] samples
    {
      get
      {
        return this.samplesField;
      }
      set
      {
        this.samplesField = value;
      }
    }
  }
}