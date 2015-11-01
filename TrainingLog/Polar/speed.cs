namespace TrainingLog.Polar
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.1432")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.polarpersonaltrainer.com")]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.polarpersonaltrainer.com", IsNullable = false)]
  public partial class speed
  {

    private speedType typeField;

    private bool typeFieldSpecified;

    private floatrange speed1Field;

    private shortrange cadenceField;

    /// <remarks/>
    public speedType type
    {
      get
      {
        return this.typeField;
      }
      set
      {
        this.typeField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool typeSpecified
    {
      get
      {
        return this.typeFieldSpecified;
      }
      set
      {
        this.typeFieldSpecified = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("speed")]
    public floatrange speed1
    {
      get
      {
        return this.speed1Field;
      }
      set
      {
        this.speed1Field = value;
      }
    }

    /// <remarks/>
    public shortrange cadence
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
  }
}