namespace TrainingLog.Polar
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.1432")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(TypeName = "fitness-data", Namespace = "http://www.polarpersonaltrainer.com")]
  [System.Xml.Serialization.XmlRootAttribute("fitness-data", Namespace = "http://www.polarpersonaltrainer.com", IsNullable = false)]
  public partial class fitnessdata : calendaritem
  {

    private heartraterange heartrateField;

    private sbyte ownindexField;

    private bool ownindexFieldSpecified;

    private short ownrelaxField;

    private bool ownrelaxFieldSpecified;

    private sbyte ownoptimizerField;

    private bool ownoptimizerFieldSpecified;

    private sbyte walkindexField;

    private bool walkindexFieldSpecified;

    private short runningindexField;

    private bool runningindexFieldSpecified;

    private float weightField;

    private bool weightFieldSpecified;

    private string noteField;

    private bool ownindexfromwristunitField;

    private bool ownindexfromwristunitFieldSpecified;

    private bool ownrelaxfromwristunitField;

    private bool ownrelaxfromwristunitFieldSpecified;

    private fitnessdetails fitnessdetailsField;

    private customvalue[] customvaluesField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("heart-rate")]
    public heartraterange heartrate
    {
      get
      {
        return this.heartrateField;
      }
      set
      {
        this.heartrateField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("own-index")]
    public sbyte ownindex
    {
      get
      {
        return this.ownindexField;
      }
      set
      {
        this.ownindexField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool ownindexSpecified
    {
      get
      {
        return this.ownindexFieldSpecified;
      }
      set
      {
        this.ownindexFieldSpecified = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("own-relax")]
    public short ownrelax
    {
      get
      {
        return this.ownrelaxField;
      }
      set
      {
        this.ownrelaxField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool ownrelaxSpecified
    {
      get
      {
        return this.ownrelaxFieldSpecified;
      }
      set
      {
        this.ownrelaxFieldSpecified = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("own-optimizer")]
    public sbyte ownoptimizer
    {
      get
      {
        return this.ownoptimizerField;
      }
      set
      {
        this.ownoptimizerField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool ownoptimizerSpecified
    {
      get
      {
        return this.ownoptimizerFieldSpecified;
      }
      set
      {
        this.ownoptimizerFieldSpecified = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("walk-index")]
    public sbyte walkindex
    {
      get
      {
        return this.walkindexField;
      }
      set
      {
        this.walkindexField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool walkindexSpecified
    {
      get
      {
        return this.walkindexFieldSpecified;
      }
      set
      {
        this.walkindexFieldSpecified = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("running-index")]
    public short runningindex
    {
      get
      {
        return this.runningindexField;
      }
      set
      {
        this.runningindexField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool runningindexSpecified
    {
      get
      {
        return this.runningindexFieldSpecified;
      }
      set
      {
        this.runningindexFieldSpecified = value;
      }
    }

    /// <remarks/>
    public float weight
    {
      get
      {
        return this.weightField;
      }
      set
      {
        this.weightField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool weightSpecified
    {
      get
      {
        return this.weightFieldSpecified;
      }
      set
      {
        this.weightFieldSpecified = value;
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

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("own-index-from-wrist-unit")]
    public bool ownindexfromwristunit
    {
      get
      {
        return this.ownindexfromwristunitField;
      }
      set
      {
        this.ownindexfromwristunitField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool ownindexfromwristunitSpecified
    {
      get
      {
        return this.ownindexfromwristunitFieldSpecified;
      }
      set
      {
        this.ownindexfromwristunitFieldSpecified = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("own-relax-from-wrist-unit")]
    public bool ownrelaxfromwristunit
    {
      get
      {
        return this.ownrelaxfromwristunitField;
      }
      set
      {
        this.ownrelaxfromwristunitField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool ownrelaxfromwristunitSpecified
    {
      get
      {
        return this.ownrelaxfromwristunitFieldSpecified;
      }
      set
      {
        this.ownrelaxfromwristunitFieldSpecified = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("fitness-details")]
    public fitnessdetails fitnessdetails
    {
      get
      {
        return this.fitnessdetailsField;
      }
      set
      {
        this.fitnessdetailsField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayAttribute("custom-values")]
    [System.Xml.Serialization.XmlArrayItemAttribute(IsNullable = false)]
    public customvalue[] customvalues
    {
      get
      {
        return this.customvaluesField;
      }
      set
      {
        this.customvaluesField = value;
      }
    }
  }
}