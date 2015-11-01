namespace TrainingLog.Polar
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.1432")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(TypeName = "custom-value", Namespace = "http://www.polarpersonaltrainer.com")]
  [System.Xml.Serialization.XmlRootAttribute("custom-value", Namespace = "http://www.polarpersonaltrainer.com", IsNullable = false)]
  public partial class customvalue
  {

    private string nameField;

    private string valueField;

    private string unitField;

    private string descriptionField;

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
    public string value
    {
      get
      {
        return this.valueField;
      }
      set
      {
        this.valueField = value;
      }
    }

    /// <remarks/>
    public string unit
    {
      get
      {
        return this.unitField;
      }
      set
      {
        this.unitField = value;
      }
    }

    /// <remarks/>
    public string description
    {
      get
      {
        return this.descriptionField;
      }
      set
      {
        this.descriptionField = value;
      }
    }
  }
}