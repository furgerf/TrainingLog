namespace TrainingLog.Polar
{
  /// <remarks/>
  [System.Xml.Serialization.XmlIncludeAttribute(typeof(user))]
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.1432")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(TypeName = "user-settings", Namespace = "http://www.polarpersonaltrainer.com")]
  [System.Xml.Serialization.XmlRootAttribute("user-settings", Namespace = "http://www.polarpersonaltrainer.com", IsNullable = false)]
  public partial class usersettings
  {

    private heartraterange heartrateField;

    private sbyte vo2maxField;

    private bool vo2maxFieldSpecified;

    private float weightField;

    private bool weightFieldSpecified;

    private float heightField;

    private bool heightFieldSpecified;

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
    public sbyte vo2max
    {
      get
      {
        return this.vo2maxField;
      }
      set
      {
        this.vo2maxField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool vo2maxSpecified
    {
      get
      {
        return this.vo2maxFieldSpecified;
      }
      set
      {
        this.vo2maxFieldSpecified = value;
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
    public float height
    {
      get
      {
        return this.heightField;
      }
      set
      {
        this.heightField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool heightSpecified
    {
      get
      {
        return this.heightFieldSpecified;
      }
      set
      {
        this.heightFieldSpecified = value;
      }
    }
  }
}