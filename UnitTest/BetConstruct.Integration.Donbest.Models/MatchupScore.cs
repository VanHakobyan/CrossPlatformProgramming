using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace BetConstruct.Integration.Donbest.Models
{
    [XmlRoot(ElementName = "matchup_score")]
    public class MatchupScore
    {
        [XmlAttributeAttribute("away_rotation")]
        public int rotationAway { get; set; }
        [XmlAttributeAttribute("home_rotation")]
        public int rotationHome { get; set; }

        [XmlAttributeAttribute("away_rot")]
        public int rotAway { get; set; }
        [XmlAttributeAttribute("home_rot")]
        public int rotHome { get; set; }

        [XmlAttributeAttribute("away_score")]
        public string scoreAwayString { get; set; }
        [XmlAttributeAttribute("home_score")]
        public string scoreHomeString { get; set; }

        public int scoreAway
        {

            get
            {
                try
                {
                    return Convert.ToInt32(scoreAwayString);
                }
                catch (Exception)
                {
                    return 0;
                }
            }

            set
            {
                scoreAwayString = value.ToString();
            }

        }
        public int scoreHome
        {

            get
            {
                try
                {
                    return Convert.ToInt32(scoreHomeString);
                }
                catch (Exception)
                {
                    return 0;
                }
            }

            set
            {
                scoreHomeString = value.ToString();
            }

        }


        [XmlAttributeAttribute("event_id")]
        public int eventId { get; set; }
        [XmlAttributeAttribute("league_id")]
        public int leagueId { get; set; }
        [XmlAttributeAttribute("sport_id")]
        public int sportId { get; set; }
        [XmlAttributeAttribute("period")]
        public string periodName { get; set; }
        [XmlAttributeAttribute("sequence")]
        public int sequence { get; set; }
        [XmlAttributeAttribute("final")]
        public bool final { get; set; }
        [XmlAttributeAttribute("description")]
        public string description { get; set; }
        [XmlAttributeAttribute("strength")]
        public string strength { get; set; }
        [XmlAttributeAttribute("strikes")]
        public string strikes { get; set; }
        [XmlAttributeAttribute("balls")]
        public string balls { get; set; }
        [XmlAttributeAttribute("outs")]
        public string outs { get; set; }
        [XmlAttributeAttribute("bases")]
        public string bases { get; set; }
        [XmlAttributeAttribute("field_pos")]
        public string fieldPos { get; set; }
        [XmlAttributeAttribute("field_side")]
        public string fieldSide { get; set; }
        [XmlAttributeAttribute("down")]
        public string down { get; set; }
        [XmlAttributeAttribute("first_down")]
        public string firstDown { get; set; }
        [XmlAttributeAttribute("possession")]
        public string possession { get; set; }
        [XmlAttributeAttribute("timestamp")]
        public string timeStampField { get; set; }

        public Int32 internalSequenceId { get; set; }

        public Int16 sourceId { get; set; }

        public string sourceName { get; set; }

        public DateTime issuedTimeStamp
        {
            get { return String.IsNullOrEmpty(timeStampField) ? DateTime.UtcNow : Convert.ToDateTime(timeStampField.Replace("+0000", "").Replace("T", " ")); }
        }

        public string getPeriodName()
        {
            if (sequence.Equals(1) && leagueId.Equals(3))
                periodName = "1st Q";
            else if (sequence.Equals(1) && leagueId.Equals(4))
                periodName = "1st H";

            return periodName;
        }

        public string toXml(bool withSourceName = false)
        {
            string xmlString = "";

            try
            {
                XmlDocument doc = new XmlDocument();

                XmlDeclaration xmlDeclaration = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
                XmlElement root = doc.DocumentElement;
                doc.InsertBefore(xmlDeclaration, root);

                XmlElement topLevel = doc.CreateElement(string.Empty, "matchup_score", string.Empty);

                topLevel.Attributes.Append(doc.CreateAttribute("event_id"));
                topLevel.Attributes.Append(doc.CreateAttribute("away_rotation"));
                topLevel.Attributes.Append(doc.CreateAttribute("away_score"));
                topLevel.Attributes.Append(doc.CreateAttribute("home_rotation"));
                topLevel.Attributes.Append(doc.CreateAttribute("home_score"));
                topLevel.Attributes.Append(doc.CreateAttribute("sequence"));
                topLevel.Attributes.Append(doc.CreateAttribute("period"));
                topLevel.Attributes.Append(doc.CreateAttribute("description"));
                topLevel.Attributes.Append(doc.CreateAttribute("final"));
                topLevel.Attributes.Append(doc.CreateAttribute("timestamp"));
                topLevel.Attributes.Append(doc.CreateAttribute("league_id"));
                topLevel.Attributes.Append(doc.CreateAttribute("sport_id"));

                topLevel.Attributes.GetNamedItem("event_id").InnerText = eventId.ToString();
                topLevel.Attributes.GetNamedItem("away_rotation").InnerText = rotationAway.ToString();
                topLevel.Attributes.GetNamedItem("away_score").InnerText = scoreAway.ToString();
                topLevel.Attributes.GetNamedItem("home_rotation").InnerText = rotationHome.ToString();
                topLevel.Attributes.GetNamedItem("home_score").InnerText = scoreHome.ToString();
                topLevel.Attributes.GetNamedItem("sequence").InnerText = sequence.ToString();
                topLevel.Attributes.GetNamedItem("period").InnerText = getPeriodName();
                topLevel.Attributes.GetNamedItem("description").InnerText = description;
                topLevel.Attributes.GetNamedItem("final").InnerText = final.ToString();
                topLevel.Attributes.GetNamedItem("timestamp").InnerText = timeStampField;
                topLevel.Attributes.GetNamedItem("league_id").InnerText = leagueId.ToString();
                topLevel.Attributes.GetNamedItem("sport_id").InnerText = sportId.ToString();

                if (withSourceName)
                {
                    topLevel.Attributes.Append(doc.CreateAttribute("source"));
                    topLevel.Attributes.GetNamedItem("source").InnerText = sourceName.ToString();
                }

                doc.AppendChild(topLevel);

                xmlString = doc.OuterXml;
            }
            catch (Exception) { }
            return xmlString;
        }

        public string toXmlV2(bool withSourceName = false)
        {
            string xmlString = "";

            try
            {
                XmlDocument doc = new XmlDocument();

                XmlDeclaration xmlDeclaration = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
                XmlElement root = doc.DocumentElement;
                doc.InsertBefore(xmlDeclaration, root);

                XmlElement topLevel = doc.CreateElement(string.Empty, "matchup_score", string.Empty);

                topLevel.Attributes.Append(doc.CreateAttribute("event_id"));
                topLevel.Attributes.Append(doc.CreateAttribute("away_rot"));
                topLevel.Attributes.Append(doc.CreateAttribute("away_score"));
                topLevel.Attributes.Append(doc.CreateAttribute("home_rot"));
                topLevel.Attributes.Append(doc.CreateAttribute("home_score"));
                topLevel.Attributes.Append(doc.CreateAttribute("sequence"));
                topLevel.Attributes.Append(doc.CreateAttribute("period"));
                topLevel.Attributes.Append(doc.CreateAttribute("description"));
                topLevel.Attributes.Append(doc.CreateAttribute("final"));
                topLevel.Attributes.Append(doc.CreateAttribute("timestamp"));
                topLevel.Attributes.Append(doc.CreateAttribute("league_id"));
                topLevel.Attributes.Append(doc.CreateAttribute("sport_id"));

                topLevel.Attributes.GetNamedItem("event_id").InnerText = eventId.ToString();
                topLevel.Attributes.GetNamedItem("away_rot").InnerText = rotAway.ToString();
                topLevel.Attributes.GetNamedItem("away_score").InnerText = scoreAway.ToString();
                topLevel.Attributes.GetNamedItem("home_rot").InnerText = rotHome.ToString();
                topLevel.Attributes.GetNamedItem("home_score").InnerText = scoreHome.ToString();
                topLevel.Attributes.GetNamedItem("sequence").InnerText = sequence.ToString();
                topLevel.Attributes.GetNamedItem("period").InnerText = getPeriodName();
                topLevel.Attributes.GetNamedItem("description").InnerText = description;
                topLevel.Attributes.GetNamedItem("final").InnerText = final.ToString();
                topLevel.Attributes.GetNamedItem("timestamp").InnerText = timeStampField;
                topLevel.Attributes.GetNamedItem("league_id").InnerText = leagueId.ToString();
                topLevel.Attributes.GetNamedItem("sport_id").InnerText = sportId.ToString();

                if (withSourceName)
                {
                    topLevel.Attributes.Append(doc.CreateAttribute("source"));
                    topLevel.Attributes.GetNamedItem("source").InnerText = sourceName.ToString();
                }

                doc.AppendChild(topLevel);

                xmlString = doc.OuterXml;
            }
            catch (Exception) { }
            return xmlString;
        }
    }
}
