namespace TrainingLog.Polar
{
  /// <remarks/>
  [System.Xml.Serialization.XmlIncludeAttribute(typeof(sportresult))]
  [System.Xml.Serialization.XmlIncludeAttribute(typeof(result))]
  [System.Xml.Serialization.XmlIncludeAttribute(typeof(target))]
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.1432")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.polarpersonaltrainer.com")]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.polarpersonaltrainer.com", IsNullable = false)]
  public partial class exercise
  {

    private string sportField;

    private float distanceField;

    private bool distanceFieldSpecified;

    private string caloriesField;

    private string durationField;

    private usersettings usersettingsField;

    private move[] movesField;

    private zone[] zonesField;

    /// <remarks/>
    public string sport
    {
      get
      {
        return this.sportField;
      }
      set
      {
        this.sportField = value;
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
    [System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger")]
    public string calories
    {
      get
      {
        return this.caloriesField;
      }
      set
      {
        this.caloriesField = value;
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
    [System.Xml.Serialization.XmlElementAttribute("user-settings")]
    public usersettings usersettings
    {
      get
      {
        return this.usersettingsField;
      }
      set
      {
        this.usersettingsField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute(IsNullable = false)]
    public move[] moves
    {
      get
      {
        return this.movesField;
      }
      set
      {
        this.movesField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute(IsNullable = false)]
    public zone[] zones
    {
      get
      {
        return this.zonesField;
      }
      set
      {
        this.zonesField = value;
      }
    }
  }
}