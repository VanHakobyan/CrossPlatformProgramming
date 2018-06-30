using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace BetConstruct.Integration.Donbest.Models
{
    [XmlRoot(ElementName = "period_score")]
    public class PeriodScore
    {
        [XmlElement("event")]
        public ScoreEvent eventInfo { get; set; }

        public Int32 internalSequenceId { get; set; }

        public Int16 sourceId { get; set; }

        public string timeStampField { get; set; }

        public DateTime issuedTimeStamp { get; set; }
    }

    [XmlRoot(ElementName = "event")]
    public class ScoreEvent
    {
        [XmlAttributeAttribute("away_rotation")]
        public int rotationAway { get; set; }
        [XmlAttributeAttribute("home_rotation")]
        public int rotationHome { get; set; }
        [XmlAttributeAttribute("event_id")]
        public int eventId { get; set; }
        [XmlAttributeAttribute("league_id")]
        public int leagueId { get; set; }
        [XmlAttributeAttribute("sport_id")]
        public int sportId { get; set; }
        [XmlAttributeAttribute("final")]
        public bool final { get; set; }

        [XmlElement("period_summary")]
        public PeriodSummary periodSummary { get; set; }
    }

    [XmlRoot(ElementName = "period_summary")]
    public class PeriodSummary
    {
        [XmlElement("period")]
        public Period[] periods { get; set; }
    }

    [XmlRoot(ElementName = "period")]
    public class Period
    {
        [XmlAttributeAttribute("name")]
        public string periodName { get; set; }
        [XmlAttributeAttribute("sequence")]
        public int sequence { get; set; }
        [XmlAttributeAttribute("description")]
        public string description { get; set; }
        [XmlAttributeAttribute("bet_period_scope")]
        public string betPeriodScope { get; set; }
        [XmlElement("score")]
        public Score[] scores { get; set; }
        [XmlAttributeAttribute("timestamp")]
        public string timeStampField { get; set; }

        public DateTime issuedTimeStamp
        {
            get { return String.IsNullOrEmpty(timeStampField) ? DateTime.UtcNow : Convert.ToDateTime(timeStampField.Replace("+0000", "").Replace("T", " ")).ToUniversalTime(); }
        }

    }

    [XmlRoot(ElementName = "score")]
    public class Score
    {
        [XmlAttributeAttribute("rotation")]
        public int rotation { get; set; }
        [XmlAttributeAttribute("value")]
        public int score { get; set; }

    }

}
