namespace TrainingLog.Polar
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.1432")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(TypeName = "ending-values", Namespace = "http://www.polarpersonaltrainer.com")]
  [System.Xml.Serialization.XmlRootAttribute("ending-values", Namespace = "http://www.polarpersonaltrainer.com", IsNullable = false)]
  public partial class endingvalues
  {

    private short heartrateField;

    private bool heartrateFieldSpecified;

    private float speedField;

    private bool speedFieldSpecified;

    private short cadenceField;

    private bool cadenceFieldSpecified;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("heart-rate")]
    public short heartrate
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
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool heartrateSpecified
    {
      get
      {
        return this.heartrateFieldSpecified;
      }
      set
      {
        this.heartrateFieldSpecified = value;
      }
    }

    /// <remarks/>
    public float speed
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
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool speedSpecified
    {
      get
      {
        return this.speedFieldSpecified;
      }
      set
      {
        this.speedFieldSpecified = value;
      }
    }

    /// <remarks/>
    public short cadence
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
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool cadenceSpecified
    {
      get
      {
        return this.cadenceFieldSpecified;
      }
      set
      {
        this.cadenceFieldSpecified = value;
      }
    }
  }
}