namespace TrainingLog.Polar
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.1432")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.polarpersonaltrainer.com")]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.polarpersonaltrainer.com", IsNullable = false)]
  public partial class power
  {

    private shortrange power1Field;

    private floatrange pedalindexField;

    private float leftrightbalanceField;

    private bool leftrightbalanceFieldSpecified;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("power")]
    public shortrange power1
    {
      get
      {
        return this.power1Field;
      }
      set
      {
        this.power1Field = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("pedal-index")]
    public floatrange pedalindex
    {
      get
      {
        return this.pedalindexField;
      }
      set
      {
        this.pedalindexField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("left-right-balance")]
    public float leftrightbalance
    {
      get
      {
        return this.leftrightbalanceField;
      }
      set
      {
        this.leftrightbalanceField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool leftrightbalanceSpecified
    {
      get
      {
        return this.leftrightbalanceFieldSpecified;
      }
      set
      {
        this.leftrightbalanceFieldSpecified = value;
      }
    }
  }
}