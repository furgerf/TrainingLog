namespace TrainingLog.Polar
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.1432")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.polarpersonaltrainer.com")]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.polarpersonaltrainer.com", IsNullable = false)]
  public partial class result : exercise
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

    private power powerField;

    private speed speedField;

    private floatrange altitudeField;

    private floatrange temperatureField;

    private altitudeinfo altitudeinfoField;

    private zone summaryzoneField;

    private limit[] limitsField;

    private sample[] samplesField;

    private activityinfo activityinfoField;

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
    public speed speed
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
    [System.Xml.Serialization.XmlElementAttribute("altitude-info")]
    public altitudeinfo altitudeinfo
    {
      get
      {
        return this.altitudeinfoField;
      }
      set
      {
        this.altitudeinfoField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("summary-zone")]
    public zone summaryzone
    {
      get
      {
        return this.summaryzoneField;
      }
      set
      {
        this.summaryzoneField = value;
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

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("activity-info")]
    public activityinfo activityinfo
    {
      get
      {
        return this.activityinfoField;
      }
      set
      {
        this.activityinfoField = value;
      }
    }
  }
}