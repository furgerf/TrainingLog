namespace TrainingLog.Polar
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.1432")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(TypeName = "blood-values", Namespace = "http://www.polarpersonaltrainer.com")]
  [System.Xml.Serialization.XmlRootAttribute("blood-values", Namespace = "http://www.polarpersonaltrainer.com", IsNullable = false)]
  public partial class bloodvalues
  {

    private float totalcholesterolField;

    private bool totalcholesterolFieldSpecified;

    private float ldlcholesterolField;

    private bool ldlcholesterolFieldSpecified;

    private float hdlcholesterolField;

    private bool hdlcholesterolFieldSpecified;

    private float triglyseridesField;

    private bool triglyseridesFieldSpecified;

    private float glucoseField;

    private bool glucoseFieldSpecified;

    private float insulinField;

    private bool insulinFieldSpecified;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("total-cholesterol")]
    public float totalcholesterol
    {
      get
      {
        return this.totalcholesterolField;
      }
      set
      {
        this.totalcholesterolField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool totalcholesterolSpecified
    {
      get
      {
        return this.totalcholesterolFieldSpecified;
      }
      set
      {
        this.totalcholesterolFieldSpecified = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("ldl-cholesterol")]
    public float ldlcholesterol
    {
      get
      {
        return this.ldlcholesterolField;
      }
      set
      {
        this.ldlcholesterolField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool ldlcholesterolSpecified
    {
      get
      {
        return this.ldlcholesterolFieldSpecified;
      }
      set
      {
        this.ldlcholesterolFieldSpecified = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("hdl-cholesterol")]
    public float hdlcholesterol
    {
      get
      {
        return this.hdlcholesterolField;
      }
      set
      {
        this.hdlcholesterolField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool hdlcholesterolSpecified
    {
      get
      {
        return this.hdlcholesterolFieldSpecified;
      }
      set
      {
        this.hdlcholesterolFieldSpecified = value;
      }
    }

    /// <remarks/>
    public float triglyserides
    {
      get
      {
        return this.triglyseridesField;
      }
      set
      {
        this.triglyseridesField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool triglyseridesSpecified
    {
      get
      {
        return this.triglyseridesFieldSpecified;
      }
      set
      {
        this.triglyseridesFieldSpecified = value;
      }
    }

    /// <remarks/>
    public float glucose
    {
      get
      {
        return this.glucoseField;
      }
      set
      {
        this.glucoseField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool glucoseSpecified
    {
      get
      {
        return this.glucoseFieldSpecified;
      }
      set
      {
        this.glucoseFieldSpecified = value;
      }
    }

    /// <remarks/>
    public float insulin
    {
      get
      {
        return this.insulinField;
      }
      set
      {
        this.insulinField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool insulinSpecified
    {
      get
      {
        return this.insulinFieldSpecified;
      }
      set
      {
        this.insulinFieldSpecified = value;
      }
    }
  }
}