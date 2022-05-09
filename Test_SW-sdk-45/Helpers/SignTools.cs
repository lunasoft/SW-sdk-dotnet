﻿using System;
using System.Xml;
using SW.Tools.Services.Fiscal;
using SW.Tools.Services.Sign;

namespace Test_SW.Helpers
{
    public static class SignTools
    {
        static Random randomNumber = new Random(1);
        public static string SigXml(string xml, byte[] pfx, string password, bool setDate = true)
        {
            xml = Fiscal.RemoverCaracteresInvalidosXml(xml);
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            if (setDate)
            {
                doc.DocumentElement.SetAttribute("Fecha", DateTime.Now.AddHours(-12).ToString("s"));
            }
            doc.DocumentElement.SetAttribute("Folio", DateTime.Now.Ticks.ToString() + randomNumber.Next(100));
            xml = doc.OuterXml;
            xml = Sign.SellarCFDIv33(pfx, password, xml);
            return xml;
        }
    }
}
