using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace BetConstruct.Integration.Donbest.Models
{
    [XmlRoot(ElementName = "odds")]
    public class Odds
    {
        [XmlAttributeAttribute("event_id")]
        public int eventId { get; set; }

        [XmlAttributeAttribute("ladder")]
        public string ladder { get; set; }

        [XmlAttributeAttribute("status")]
        public bool status { get; set; }

        [XmlAttributeAttribute("timestamp")]
        public string timeStampField { get; set; }

        public Int32 internalSequenceId { get; set; }

        [XmlElement("line")]
        public Line[] lines { get; set; }

        [XmlElement("prop")]
        public Prop[] props { get; set; }

        public Int16 sourceId { get; set; }

        public DateTime issuedTimeStamp
        {
            get { return String.IsNullOrEmpty(timeStampField) ? DateTime.UtcNow : Convert.ToDateTime(timeStampField.Replace("+0000", "").Replace("T", " ")); }
        }
        public DateTime receivedTimeStamp = DateTime.UtcNow;
        public DateTime processedTimeStamp = DateTime.UtcNow;

    }

    #region Base class that all uses
    public class Market
    {
        public Int32 internalSequenceId { get; set; }

        public Int16 sourceId { get; set; }

        [XmlAttributeAttribute("rotation")]
        public int rotation { get; set; }
        [XmlAttributeAttribute("event_id")]
        public int eventId { get; set; }
        [XmlAttributeAttribute("period_id")]
        public int periodId { get; set; }
        [XmlAttributeAttribute("period")]
        public string periodName { get; set; }
        [XmlAttributeAttribute("sportsbook_id")]
        public int sportsbookId { get; set; }
        [XmlAttributeAttribute("lookup")]
        public string lookup { get; set; }
        [XmlAttributeAttribute("description")]
        public string description { get; set; }
        [XmlAttributeAttribute("prematch_flag")]
        public bool prematchFlag { get; set; }
        [XmlAttributeAttribute("league_id")]
        public int leagueId { get; set; }
        [XmlAttributeAttribute("sport_id")]
        public int sportId { get; set; }
        [XmlAttributeAttribute("bet_type_id")]
        public int betTypeId { get; set; }
        [XmlAttributeAttribute("alt_id")]
        public int altId { get; set; }
        [XmlAttributeAttribute("display")]
        public bool display { get; set; }
        [XmlAttributeAttribute("sequence")]
        public int sequence { get; set; }
        [XmlAttributeAttribute("timestamp")]
        public string timeStampField { get; set; }

        // none inplay format
        [XmlAttributeAttribute("alternate")]
        public int otherAlternateId { get; set; }
        [XmlAttributeAttribute("rot")]
        public int otherRotation { get; set; }
        [XmlAttributeAttribute("sportsbook")]
        public int otherSportsbookId { get; set; }
        [XmlAttributeAttribute("league_sub_id")]
        public int leagueSubId { get; set; }


        public DateTime issuedTimeStamp
        {
            get { return String.IsNullOrEmpty(timeStampField) ? DateTime.UtcNow : Convert.ToDateTime(timeStampField.Replace("+0000", "").Replace("T", " ")); }


        }
        public DateTime receivedTimeStamp = DateTime.UtcNow;
        public DateTime processedTimeStamp = DateTime.UtcNow;

        private bool _isInPlayEvent = false;
        public bool isInPlayEvent
        {
            get
            {
                if (leagueId.Equals(97) || leagueId.Equals(98))
                    return (rotation > 396000 && rotation < 397000) ? true : false;
                else
                    return (rotation > 9000 && rotation < 10000) ? true : false;
            }
        }

        public string betTypeName
        {
            get
            {
                string name = "NA";

                switch (betTypeId)
                {
                    case 13:
                        name = "2W-ML";
                        break;
                    case 14:
                        name = "3W-ML";
                        break;
                    case 15:
                        name = "2W-PS";
                        break;
                    case 16:
                        name = "3W-PS";
                        break;
                    case 17:
                        name = "2W-TL";
                        break;
                    case 18:
                        name = "3W-TL";
                        break;
                    case 19:
                        name = "2W-ATL";
                        break;
                    case 20:
                        name = "2W-HTL";
                        break;

                }

                return name;
            }
        }

        public void copyOtherToNormal()
        {
            rotation = otherRotation;
            altId = otherAlternateId;
            sportsbookId = otherSportsbookId;

        }

    }
    #endregion

    #region Line holds most of the types
    [XmlRoot(ElementName = "line")]
    public class Line : Market
    {


        [XmlElement("ps")]
        public Spread spread { get; set; }

        [XmlElement("ml")]
        public MoneyLine moneyLine { get; set; }

        [XmlElement("odd_even")]
        public OddEven oddEven { get; set; }

        [XmlElement("double_chance")]
        public DoubleChance doubleChance { get; set; }

        [XmlElement("ht_ft")]
        public HalfTimeFullTime halftimeFulltime { get; set; }

        [XmlElement("total")]
        public Total total { get; set; }

        [XmlElement("team_total")]
        public TeamTotal teamTotal { get; set; }

        [XmlElement("winning_margin")]
        public WinningMargin winningMargin { get; set; }

        [XmlElement("exact_score")]
        public ExactScore exactScore { get; set; }

        [XmlElement("high_period")]
        public HighPeriod highPeriod { get; set; }

        [XmlElement("total_ranges")]
        public TotalRange totalRange { get; set; }


        private bool _isSpread = false;
        public bool isSpread
        {
            get { return spread != null ? true : false; }
        }

        private bool _isMoneyLine = false;
        public bool isMoneyLine
        {
            get { return moneyLine != null ? true : false; }
        }

        private bool _isTotal = false;
        public bool isTotal
        {
            get { return total != null ? true : false; }
        }

        private bool _isTeamTotal = false;
        public bool isTeamTotal
        {
            get { return teamTotal != null ? true : false; }
        }

        public string GetSimpleInfo()
        {
            return "rotation : " + rotation + " event id : " + eventId + " : from book " + sportsbookId + " for period : " + periodId + " for league : " + leagueId;
        }

    }
    #endregion

    #region Props holds misc types
    [XmlRoot(ElementName = "prop")]
    public class Prop : Market
    {
        [XmlElement("race_to")]
        public RaceTo raceTo { get; set; }

        [XmlElement("next_to_score")]
        public NextToScore nextToScore { get; set; }

    }
    #endregion

    [XmlRoot(ElementName = "ml")]
    public class MoneyLine
    {
        [XmlAttributeAttribute("away_price")]
        public decimal awayPrice { get; set; }

        [XmlAttributeAttribute("home_price")]
        public decimal homePrice { get; set; }

        [XmlAttributeAttribute("draw_price")]
        public decimal drawPrice { get; set; }

    }

    [XmlRoot(ElementName = "odd_even")]
    public class OddEven
    {
        [XmlAttributeAttribute("odd_price")]
        public decimal oddPrice { get; set; }

        [XmlAttributeAttribute("even_price")]
        public decimal evenPrice { get; set; }
    }

    [XmlRoot(ElementName = "double_chance")]
    public class DoubleChance
    {
        [XmlAttributeAttribute("away_point")]
        public decimal awaySpread { get; set; }

        [XmlAttributeAttribute("home_point")]
        public decimal homeSpread { get; set; }

        [XmlAttributeAttribute("draw_point")]
        public decimal drawSpread { get; set; }

        [XmlAttributeAttribute("away_draw")]
        public decimal awayDraw { get; set; }

        [XmlAttributeAttribute("home_draw")]
        public decimal homeDraw { get; set; }

        [XmlAttributeAttribute("home_away")]
        public decimal homeAway { get; set; }
    }

    [XmlRoot(ElementName = "ht_ft")]
    public class HalfTimeFullTime
    {
        [XmlAttributeAttribute("away_away")]
        public decimal awayAway { get; set; }

        [XmlAttributeAttribute("away_draw")]
        public decimal awayDraw { get; set; }

        [XmlAttributeAttribute("away_home")]
        public decimal awayHome { get; set; }

        [XmlAttributeAttribute("home_away")]
        public decimal homeAway { get; set; }

        [XmlAttributeAttribute("home_draw")]
        public decimal homeDraw { get; set; }

        [XmlAttributeAttribute("home_home")]
        public decimal homeHome { get; set; }

        [XmlAttributeAttribute("draw_away")]
        public decimal drawAway { get; set; }

        [XmlAttributeAttribute("draw_draw")]
        public decimal drawDraw { get; set; }

        [XmlAttributeAttribute("draw_home")]
        public decimal drawHome { get; set; }

    }

    [XmlRoot(ElementName = "ps")]

    public class Spread
    {
        [XmlAttributeAttribute("away_spread")]
        public decimal awaySpread { get; set; }

        [XmlAttributeAttribute("away_price")]
        public decimal awayPrice { get; set; }

        [XmlAttributeAttribute("home_spread")]
        public decimal homeSpread { get; set; }

        [XmlAttributeAttribute("home_price")]
        public decimal homePrice { get; set; }

        [XmlAttributeAttribute("draw_spread")]
        public decimal drawSpread { get; set; }

        [XmlAttributeAttribute("draw_price")]
        public decimal drawPrice { get; set; }
    }

    [XmlRoot(ElementName = "total")]
    public class Total
    {
        [XmlAttributeAttribute("total")]
        public decimal total { get; set; }

        [XmlAttributeAttribute("over_price")]
        public decimal overPrice { get; set; }

        [XmlAttributeAttribute("under_price")]
        public decimal underPrice { get; set; }

        [XmlAttributeAttribute("draw_price")]
        public decimal drawPrice { get; set; }
    }

    [XmlRoot(ElementName = "team_total")]
    public class TeamTotal
    {
        [XmlAttributeAttribute("total")]
        public decimal total { get; set; }

        [XmlAttributeAttribute("over_price")]
        public decimal overPrice { get; set; }

        [XmlAttributeAttribute("under_price")]
        public decimal underPrice { get; set; }

    }

    [XmlRoot(ElementName = "winning_margin")]
    public class WinningMargin
    {
        [XmlElement("margin")]
        public Margin[] margins { get; set; }
    }

    [XmlRoot(ElementName = "margin")]
    public class Margin
    {
        [XmlAttributeAttribute("side")]
        public string side { get; set; }

        [XmlAttributeAttribute("margin")]
        public string margin { get; set; }

        [XmlAttributeAttribute("rotation")]
        public int rotation { get; set; }

        [XmlAttributeAttribute("min")]
        public int min { get; set; }

        [XmlAttributeAttribute("max")]
        public int max { get; set; }

        [XmlAttributeAttribute("margin_price")]
        public decimal price { get; set; }

    }

    [XmlRoot(ElementName = "exact_score")]
    public class ExactScore
    {
        [XmlElement("exact")]
        public Exact[] exacts { get; set; }
    }

    [XmlRoot(ElementName = "exact")]
    public class Exact
    {
        [XmlAttributeAttribute("score")]
        public string score { get; set; }

        [XmlAttributeAttribute("away_score")]
        public string awayScore { get; set; }

        [XmlAttributeAttribute("home_score")]
        public string homeScore { get; set; }

        [XmlAttributeAttribute("price")]
        public decimal price { get; set; }

    }

    [XmlRoot(ElementName = "high_period")]
    public class HighPeriod
    {
        [XmlElement("period")]
        public HPeriod[] periods { get; set; }
    }

    [XmlRoot(ElementName = "period")]
    public class HPeriod
    {
        [XmlAttributeAttribute("period_id")]
        public int periodId { get; set; }

        [XmlAttributeAttribute("period")]
        public string periodName { get; set; }

        [XmlAttributeAttribute("high_period_price")]
        public decimal price { get; set; }

    }

    [XmlRoot(ElementName = "total_ranges")]
    public class TotalRange
    {
        [XmlElement("totalRange")]
        public Range[] ranges { get; set; }
    }

    [XmlRoot(ElementName = "totalRange")]
    public class Range
    {
        [XmlAttributeAttribute("range")]
        public string range { get; set; }

        [XmlAttributeAttribute("min")]
        public int min { get; set; }

        [XmlAttributeAttribute("max")]
        public int max { get; set; }

        [XmlAttributeAttribute("price")]
        public decimal price { get; set; }

    }

    [XmlRoot(ElementName = "race_to")]
    public class RaceTo
    {
        [XmlElement("race")]
        public Race[] races { get; set; }
    }

    [XmlRoot(ElementName = "race")]
    public class Race
    {
        [XmlAttributeAttribute("type")]
        public string type { get; set; }

        [XmlAttributeAttribute("index")]
        public int index { get; set; }

        [XmlAttributeAttribute("price")]
        public decimal price { get; set; }

    }

    [XmlRoot(ElementName = "next_to_score")]
    public class NextToScore
    {
        [XmlElement("score")]
        public N2Score[] scores { get; set; }
    }

    [XmlRoot(ElementName = "score")]
    public class N2Score
    {
        [XmlAttributeAttribute("type")]
        public string type { get; set; }

        [XmlAttributeAttribute("index")]
        public int index { get; set; }

        [XmlAttributeAttribute("price")]
        public decimal price { get; set; }

    }


}
