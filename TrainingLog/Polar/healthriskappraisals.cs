namespace TrainingLog.Polar
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.1432")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(TypeName = "health-risk-appraisals", Namespace = "http://www.polarpersonaltrainer.com")]
  [System.Xml.Serialization.XmlRootAttribute("health-risk-appraisals", Namespace = "http://www.polarpersonaltrainer.com", IsNullable = false)]
  public partial class healthriskappraisals
  {

    private hraqDepression depressionField;

    private bool depressionFieldSpecified;

    private hraqHeartDisease heartdiseaseField;

    private bool heartdiseaseFieldSpecified;

    private hraqNutrition nutritionField;

    private bool nutritionFieldSpecified;

    private hraqStress stressField;

    private bool stressFieldSpecified;

    /// <remarks/>
    public hraqDepression depression
    {
      get
      {
        return this.depressionField;
      }
      set
      {
        this.depressionField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool depressionSpecified
    {
      get
      {
        return this.depressionFieldSpecified;
      }
      set
      {
        this.depressionFieldSpecified = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("heart-disease")]
    public hraqHeartDisease heartdisease
    {
      get
      {
        return this.heartdiseaseField;
      }
      set
      {
        this.heartdiseaseField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool heartdiseaseSpecified
    {
      get
      {
        return this.heartdiseaseFieldSpecified;
      }
      set
      {
        this.heartdiseaseFieldSpecified = value;
      }
    }

    /// <remarks/>
    public hraqNutrition nutrition
    {
      get
      {
        return this.nutritionField;
      }
      set
      {
        this.nutritionField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool nutritionSpecified
    {
      get
      {
        return this.nutritionFieldSpecified;
      }
      set
      {
        this.nutritionFieldSpecified = value;
      }
    }

    /// <remarks/>
    public hraqStress stress
    {
      get
      {
        return this.stressField;
      }
      set
      {
        this.stressField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool stressSpecified
    {
      get
      {
        return this.stressFieldSpecified;
      }
      set
      {
        this.stressFieldSpecified = value;
      }
    }
  }
}