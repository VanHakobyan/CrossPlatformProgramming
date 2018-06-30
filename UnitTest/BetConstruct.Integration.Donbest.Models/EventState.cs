using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace BetConstruct.Integration.Donbest.Models
{
    [XmlRoot(ElementName = "event_state")]
    public class EventState
    {
        [XmlAttributeAttribute("rot")]
        public int rotation { get; set; }
        [XmlAttributeAttribute("event_state_type_id")]
        public int eventStateTypeId { get; set; }
        [XmlAttributeAttribute("event_state")]
        public string eventState { get; set; }
        [XmlAttributeAttribute("event_id")]
        public int eventId { get; set; }
        [XmlAttributeAttribute("league_id")]
        public int leagueId { get; set; }
        [XmlAttributeAttribute("sport_id")]
        public int sportId { get; set; }

        public Int32 internalSequenceId { get; set; }

        public Int16 sourceId { get; set; }

        [XmlAttributeAttribute("timestamp")]
        public string timeStampField { get; set; }

        public DateTime issuedTimeStamp
        {
            get { return String.IsNullOrEmpty(timeStampField) ? DateTime.UtcNow : Convert.ToDateTime(timeStampField.Replace("+0000", "").Replace("T", " ")).ToUniversalTime(); }
        }
    }
}
