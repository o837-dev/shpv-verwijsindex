﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GarageClient.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "14.0.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Replace")]
        public string SqlServer {
            get {
                return ((string)(this["SqlServer"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute(@"<s:Envelope xmlns:s=""http://www.w3.org/2003/05/soap-envelope"" xmlns:a=""http://www.w3.org/2005/08/addressing"">
  <s:Header>
    <a:Action s:mustUnderstand=""1"">https://verwijsindex.shpv.nl/service/VerwijsIndex/PaymentStart</a:Action>
    <a:MessageID>urn:uuid:<!--GUID--></a:MessageID>
    <a:ReplyTo>
      <a:Address>http://www.w3.org/2005/08/addressing/anonymous</a:Address>
    </a:ReplyTo>
    <a:To s:mustUnderstand=""1""><!--To--></a:To>
  </s:Header>
  <s:Body>
    <PaymentStart xmlns=""https://verwijsindex.shpv.nl/service/"">
      <PaymentStartRequest xmlns:b=""https://verwijsindex.shpv.nl/messages/"" xmlns:i=""http://www.w3.org/2001/XMLSchema-instance"">
        <b:AreaManagerId><!--AreaManagerId--></b:AreaManagerId>
        <b:AreaId><!--AreaId--></b:AreaId>
        <b:VehicleId><!--VehicleId--></b:VehicleId>
        <b:CountryCode><!--CountryCode--></b:CountryCode>
        <b:AccessId><!--AccessId--></b:AccessId>
        <b:StartDateTime><!--StartDateTime--></b:StartDateTime>
        <b:EndDateTime><!--EndDateTime--></b:EndDateTime>
        <b:Amount><!--Amount--></b:Amount>
        <b:VAT><!--VAT--></b:VAT>
        <b:Token><!--Token--></b:Token>
      </PaymentStartRequest>
    </PaymentStart>
  </s:Body>
</s:Envelope>")]
        public string PaymentStartTemplate {
            get {
                return ((string)(this["PaymentStartTemplate"]));
            }
        }
    }
}
