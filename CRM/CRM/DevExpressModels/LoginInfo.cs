using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.XamarinForms.DataForm;
using DevExpress.XamarinForms.Editors;
namespace CRM.DevExpressModels
{ 
    public enum Language
    {
        Arabic,
        English
    }
    public class LoginInfo
    {
        [DataFormTextEditor(Placeholder = "User Name")]
        public string UserName { get; set; }  
        
                  
        [DataFormPasswordEditor(Placeholder ="Password")]           
        public string Password { get; set; } 


        [DataFormComboBoxEditor(Placeholder = "Language")]
        public Language Language { get; set; }

    }
}
