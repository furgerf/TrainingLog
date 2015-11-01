namespace TrainingLog.Polar
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.1432")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(TypeName = "strength-activity", Namespace = "http://www.polarpersonaltrainer.com")]
  [System.Xml.Serialization.XmlRootAttribute("strength-activity", Namespace = "http://www.polarpersonaltrainer.com", IsNullable = false)]
  public partial class strengthactivity
  {

    private string nameField;

    private activityRegion regionField;

    private bool regionFieldSpecified;

    private float oneroundmaximumField;

    private bool oneroundmaximumFieldSpecified;

    /// <remarks/>
    public string name
    {
      get
      {
        return this.nameField;
      }
      set
      {
        this.nameField = value;
      }
    }

    /// <remarks/>
    public activityRegion region
    {
      get
      {
        return this.regionField;
      }
      set
      {
        this.regionField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool regionSpecified
    {
      get
      {
        return this.regionFieldSpecified;
      }
      set
      {
        this.regionFieldSpecified = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("one-round-maximum")]
    public float oneroundmaximum
    {
      get
      {
        return this.oneroundmaximumField;
      }
      set
      {
        this.oneroundmaximumField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool oneroundmaximumSpecified
    {
      get
      {
        return this.oneroundmaximumFieldSpecified;
      }
      set
      {
        this.oneroundmaximumFieldSpecified = value;
      }
    }
  }
}