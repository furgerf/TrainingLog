namespace TrainingLog.Polar
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.1432")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(TypeName = "custom-values", Namespace = "http://www.polarpersonaltrainer.com")]
  [System.Xml.Serialization.XmlRootAttribute("custom-values", Namespace = "http://www.polarpersonaltrainer.com", IsNullable = false)]
  public partial class customvalues
  {

    private customvalue[] customvalueField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("custom-value")]
    public customvalue[] customvalue
    {
      get
      {
        return this.customvalueField;
      }
      set
      {
        this.customvalueField = value;
      }
    }
  }
}