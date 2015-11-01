namespace TrainingLog.Polar
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.1432")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(TypeName = "float-range", Namespace = "http://www.polarpersonaltrainer.com")]
  public partial class floatrange
  {

    private float minimumField;

    private bool minimumFieldSpecified;

    private float averageField;

    private bool averageFieldSpecified;

    private float maximumField;

    private bool maximumFieldSpecified;

    /// <remarks/>
    public float minimum
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
    public float average
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
    public float maximum
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
  }
}