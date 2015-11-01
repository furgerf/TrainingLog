namespace TrainingLog.Polar
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.1432")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(TypeName = "heart-rate-range", Namespace = "http://www.polarpersonaltrainer.com")]
  [System.Xml.Serialization.XmlRootAttribute("heart-rate", Namespace = "http://www.polarpersonaltrainer.com", IsNullable = false)]
  public partial class heartraterange
  {

    private short restingField;

    private bool restingFieldSpecified;

    private short minimumField;

    private bool minimumFieldSpecified;

    private short averageField;

    private bool averageFieldSpecified;

    private short maximumField;

    private bool maximumFieldSpecified;

    private short endingField;

    private bool endingFieldSpecified;

    /// <remarks/>
    public short resting
    {
      get
      {
        return this.restingField;
      }
      set
      {
        this.restingField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool restingSpecified
    {
      get
      {
        return this.restingFieldSpecified;
      }
      set
      {
        this.restingFieldSpecified = value;
      }
    }

    /// <remarks/>
    public short minimum
    {
      get
      {
        return this.minimumField;
      }
      set
      {
        this.minimumField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool minimumSpecified
    {
      get
      {
        return this.minimumFieldSpecified;
      }
      set
      {
        this.minimumFieldSpecified = value;
      }
    }

    /// <remarks/>
    public short average
    {
      get
      {
        return this.averageField;
      }
      set
      {
        this.averageField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool averageSpecified
    {
      get
      {
        return this.averageFieldSpecified;
      }
      set
      {
        this.averageFieldSpecified = value;
      }
    }

    /// <remarks/>
    public short maximum
    {
      get
      {
        return this.maximumField;
      }
      set
      {
        this.maximumField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool maximumSpecified
    {
      get
      {
        return this.maximumFieldSpecified;
      }
      set
      {
        this.maximumFieldSpecified = value;
      }
    }

    /// <remarks/>
    public short ending
    {
      get
      {
        return this.endingField;
      }
      set
      {
        this.endingField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool endingSpecified
    {
      get
      {
        return this.endingFieldSpecified;
      }
      set
      {
        this.endingFieldSpecified = value;
      }
    }
  }
}