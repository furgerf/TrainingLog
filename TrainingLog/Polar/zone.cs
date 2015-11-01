namespace TrainingLog.Polar
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.1432")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.polarpersonaltrainer.com")]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.polarpersonaltrainer.com", IsNullable = false)]
  public partial class zone
  {

    private short upperField;

    private bool upperFieldSpecified;

    private short lowerField;

    private bool lowerFieldSpecified;

    private string aboveField;

    private string inzoneField;

    private string belowField;

    private float calorieexpenditureField;

    private bool calorieexpenditureFieldSpecified;

    private string indexField;

    /// <remarks/>
    public short upper
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
    public short lower
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
    public string above
    {
      get
      {
        return this.aboveField;
      }
      set
      {
        this.aboveField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("in-zone")]
    public string inzone
    {
      get
      {
        return this.inzoneField;
      }
      set
      {
        this.inzoneField = value;
      }
    }

    /// <remarks/>
    public string below
    {
      get
      {
        return this.belowField;
      }
      set
      {
        this.belowField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("calorie-expenditure")]
    public float calorieexpenditure
    {
      get
      {
        return this.calorieexpenditureField;
      }
      set
      {
        this.calorieexpenditureField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool calorieexpenditureSpecified
    {
      get
      {
        return this.calorieexpenditureFieldSpecified;
      }
      set
      {
        this.calorieexpenditureFieldSpecified = value;
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