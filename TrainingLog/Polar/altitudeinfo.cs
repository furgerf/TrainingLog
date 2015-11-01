namespace TrainingLog.Polar
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.1432")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(TypeName = "altitude-info", Namespace = "http://www.polarpersonaltrainer.com")]
  [System.Xml.Serialization.XmlRootAttribute("altitude-info", Namespace = "http://www.polarpersonaltrainer.com", IsNullable = false)]
  public partial class altitudeinfo
  {

    private floatrange verticalspeedupField;

    private floatrange verticalspeeddownField;

    private float ascentField;

    private bool ascentFieldSpecified;

    private float descentField;

    private bool descentFieldSpecified;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("vertical-speed-up")]
    public floatrange verticalspeedup
    {
      get
      {
        return this.verticalspeedupField;
      }
      set
      {
        this.verticalspeedupField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("vertical-speed-down")]
    public floatrange verticalspeeddown
    {
      get
      {
        return this.verticalspeeddownField;
      }
      set
      {
        this.verticalspeeddownField = value;
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
  }
}