namespace TrainingLog.Polar
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.1432")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(TypeName = "exercise-data", Namespace = "http://www.polarpersonaltrainer.com")]
  [System.Xml.Serialization.XmlRootAttribute("exercise-data", Namespace = "http://www.polarpersonaltrainer.com", IsNullable = false)]
  public partial class exercisedata : calendaritem
  {

    private string sportField;

    private string nameField;

    private target targetField;

    private result resultField;

    private sportresult[] sportresultsField;

    private string noteField;

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
    public target target
    {
      get
      {
        return this.targetField;
      }
      set
      {
        this.targetField = value;
      }
    }

    /// <remarks/>
    public result result
    {
      get
      {
        return this.resultField;
      }
      set
      {
        this.resultField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayAttribute("sport-results")]
    [System.Xml.Serialization.XmlArrayItemAttribute(IsNullable = false)]
    public sportresult[] sportresults
    {
      get
      {
        return this.sportresultsField;
      }
      set
      {
        this.sportresultsField = value;
      }
    }

    /// <remarks/>
    public string note
    {
      get
      {
        return this.noteField;
      }
      set
      {
        this.noteField = value;
      }
    }
  }
}