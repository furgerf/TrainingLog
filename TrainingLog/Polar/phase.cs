namespace TrainingLog.Polar
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.1432")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.polarpersonaltrainer.com")]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.polarpersonaltrainer.com", IsNullable = false)]
  public partial class phase
  {

    private float upperField;

    private bool upperFieldSpecified;

    private float lowerField;

    private bool lowerFieldSpecified;

    private string durationField;

    private string indexField;

    /// <remarks/>
    public float upper
    {
      get
      {
        return this.upperField;
      }
      set
      {
        this.upperField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool upperSpecified
    {
      get
      {
        return this.upperFieldSpecified;
      }
      set
      {
        this.upperFieldSpecified = value;
      }
    }

    /// <remarks/>
    public float lower
    {
      get
      {
        return this.lowerField;
      }
      set
      {
        this.lowerField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool lowerSpecified
    {
      get
      {
        return this.lowerFieldSpecified;
      }
      set
      {
        this.lowerFieldSpecified = value;
      }
    }

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