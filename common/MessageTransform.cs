using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml;
using System.Xml.Serialization;
 
namespace SAS.AgentRedemption.Common
{

    public static class MessageTransform2
    {
        /// <summary>
        /// Serialize the message object into xml.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static string CreateXML(Object request)
        {
            //Represents an XML document to be queued in Tibco EMS 
            XmlDocument xmlDoc = new XmlDocument();
            XmlSerializer xmlSerializer = new XmlSerializer(request.GetType());
            using (MemoryStream xmlStream = new MemoryStream())
            {
                xmlSerializer.Serialize(xmlStream, request);
                xmlStream.Position = 0;
                xmlDoc.Load(xmlStream);
                return xmlDoc.InnerXml;
            }
        }




        public static Object TransformRetrievePNRObject(string XMLString, Object msgout2)
        {
            try
            {
                XmlSerializer oXmlSerializer = new XmlSerializer(msgout2.GetType());
                msgout2 = oXmlSerializer.Deserialize(new StringReader(XMLString));
            }
            catch (Exception ex)
            {
                LoggingManager.LogError(Constants.Category.Common, ex.Message);
                throw ;
            }
            return msgout2;
        }






    }
    /// <summary>
    /// PNRMessageTransform class is responsible for  serialization and Formatting response object
    /// </summary>
    public static class MessageTransform
    {
        /// <summary>
        /// Serialize the message object into xml.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static string CreateXML(Object request)
        {
            //Represents an XML document to be queued in Tibco EMS 
            XmlDocument xmlDoc = new XmlDocument();
            XmlSerializer xmlSerializer = new XmlSerializer(request.GetType());
            using (MemoryStream xmlStream = new MemoryStream())
            {
                xmlSerializer.Serialize(xmlStream, request);
                xmlStream.Position = 0;
                xmlDoc.Load(xmlStream);
                return xmlDoc.InnerXml;
            }
        }


        public static Object TransformRetrievePNRObject(string XMLString, Object msgout2)
        {
            try
            {
                XmlSerializer oXmlSerializer = new XmlSerializer(msgout2.GetType());
                msgout2 = oXmlSerializer.Deserialize(new StringReader(XMLString));
            }
            catch (Exception ex )
            {
                LoggingManager.LogError(Constants.Category.Common, ex.Message);
                throw ;
            }
            return msgout2;
        }

        public static Object TransformMessageObject(string XMLString, Object msgout2)
        {
            try
            {
                XmlSerializer oXmlSerializer = new XmlSerializer(msgout2.GetType());
                msgout2 = oXmlSerializer.Deserialize(new StringReader(XMLString));
            }
            catch (Exception ex)
            {
                LoggingManager.LogError(Constants.Category.Common, ex.Message);
                throw ;
            }
            return msgout2;
        }


        /// <summary>
        /// Used to Serialize the Audit message object into XML for Audit Logger .
        /// Not to be used for any other Type other than ARS_AuditMessage
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static string CreateAuditXML(Object request)
        {           
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("ns0", "http://www.tibco.com/schemas/Logging/Lib_SharedResources/Lib_Schemas/Schema.xsd");
            XmlSerializer xser = new XmlSerializer(request.GetType());
            XmlDocument xmlDoc = new XmlDocument();
            using (MemoryStream xmlStream = new MemoryStream())
            {
                xser.Serialize(xmlStream, request, ns);
                xmlStream.Position = 0;
                xmlDoc.Load(xmlStream);
                return xmlDoc.InnerXml;
            }     
        }

    }





    

}
