namespace TrainingLog.Polar
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.1432")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.polarpersonaltrainer.com")]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.polarpersonaltrainer.com", IsNullable = false)]
  public partial class user : usersettings
  {

    private string emailField;

    private string nicknameField;

    /// <remarks/>
    public string email
    {
      get
      {
        return this.emailField;
      }
      set
      {
        this.emailField = value;
      }
    }

    /// <remarks/>
    public string nickname
    {
      get
      {
        return this.nicknameField;
      }
      set
      {
        this.nicknameField = value;
      }
    }
  }
}