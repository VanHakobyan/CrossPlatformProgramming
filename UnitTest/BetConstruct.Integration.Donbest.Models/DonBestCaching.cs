using System;
using System.Collections.Concurrent;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Timers;
using System.Xml.Serialization;

namespace BetConstruct.Integration.Donbest.Models
{
    public class DonBestCaching
    {
        private const string TOPIC_NAME = "com.donbest.message.public.inplay.xmlbetconstruct";
        private const string USERNAME = "xmlbetconstruct";
        private const string PASSWORD = "xmlsports";
        private const string BROKER = "failover://(tcp://inplayamq.donbest.com:61616)?randomize=false&updateURIsSupported=true&wireFormat.maxInactivityDuration=60000";
        private const string SCHEDULE = @"http://xml.donbest.com/v2/schedule/?token=18Sbl9!0-__--9-7";
        private const string TEAMS = @"http://xml.donbest.com/v2/team/?token=18Sbl9!0-__--9-7";
        private const string LEAGUES = @"http://xml.donbest.com/v2/league/?token=18Sbl9!0-__--9-7";
        public static ConcurrentDictionary<int, Odds> OddsDictionary { get; set; }
        public static ConcurrentDictionary<int, MatchupScore> MatchupScoreDictionary { get; set; }
        public static ConcurrentDictionary<int, PeriodScore> PeriodScoreDictionary { get; set; }
        public static ConcurrentDictionary<int, EventState> EventStateDictionary { get; set; }
        public static Models.Statics.Scedule.don_best_sports DonBestschedule;

        public static Timer Timer;

        public DonBestCaching()
        {
            Timer = new Timer(60 * 1000);
            Timer.Elapsed += RemoveOldMatches;
            Timer.Start();
        }
        static DonBestCaching()
        {
            if (OddsDictionary is null) OddsDictionary = new ConcurrentDictionary<int, Odds>();
            DonBestschedule = GetSchedule();
            MatchupScoreDictionary = new ConcurrentDictionary<int, MatchupScore>();
            PeriodScoreDictionary = new ConcurrentDictionary<int, PeriodScore>();
            EventStateDictionary = new ConcurrentDictionary<int, EventState>();
        }

        private void RemoveOldMatches(object sender, ElapsedEventArgs elapsedEventArgs)
        {
            DonBestschedule = GetSchedule();
            foreach (var odds in OddsDictionary)
            {
                foreach (var donBestSport in DonBestschedule.schedule)
                {
                    foreach (var donBestLeague in donBestSport.league)
                    {
                        foreach (var donBestGroup in donBestLeague.group)
                        {
                            foreach (var donBestEvent in donBestGroup.@event)
                            {
                                if (donBestEvent.id == odds.Value.eventId)
                                {

                                    if (DateTime.UtcNow - DateTime.Parse(donBestEvent.date) > TimeSpan.FromHours(1))
                                        OddsDictionary.TryRemove(odds.Key, out var value);

                                }
                            }
                        }
                    }
                }
            }
        }

        public static Models.Statics.Scedule.don_best_sports GetSchedule()
        {
            var scheduleXml = SendGetRequest(SCHEDULE);
            TextReader reader = new StringReader(scheduleXml);
            XmlSerializer deserializer = new XmlSerializer(typeof(Models.Statics.Scedule.don_best_sports));
            object content = deserializer.Deserialize(reader);
            Models.Statics.Scedule.don_best_sports obj = (Models.Statics.Scedule.don_best_sports)content;
            return obj;
        }

        public Models.Statics.League.don_best_sports GetLeagues()
        {
            var leagueXml = SendGetRequest(LEAGUES);
            TextReader reader = new StringReader(leagueXml);
            XmlSerializer deserializer = new XmlSerializer(typeof(Models.Statics.League.don_best_sports));
            object content = deserializer.Deserialize(reader);
            Models.Statics.League.don_best_sports obj = (Models.Statics.League.don_best_sports)content;
            return obj;
        }


        public Models.Statics.Team.don_best_sports GetTeams()
        {
            var teamXml = SendGetRequest(TEAMS);
            TextReader reader = new StringReader(teamXml);
            XmlSerializer deserializer = new XmlSerializer(typeof(Models.Statics.Team.don_best_sports));
            object content = deserializer.Deserialize(reader);
            Models.Statics.Team.don_best_sports obj = (Models.Statics.Team.don_best_sports)content;
            return obj;
        }

        public void Listening()
        {

            try
            {
                SimpleTopicSubscriber subscriber = new SimpleTopicSubscriber(TOPIC_NAME, BROKER, Environment.MachineName.ToLower() + ".xmlbetconstruct-" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss"), USERNAME, PASSWORD);
                subscriber.OnMessageReceived += subscriber_OnMessageReceived;
            }
            catch
            {
                //ignore
            }

        }



        static void subscriber_OnMessageReceived(string message)
        {
            try
            {
                // this sample listener outputs to the screen and saves the packets to a file
                // alternatively, you can edit it to suit your needs such as pushing to your processing module, updating your database, etc

                TextReader reader = new StringReader(message);

                if (message.Contains("<odds"))
                {

                    XmlSerializer deserializer = new XmlSerializer(typeof(Odds));
                    object content = deserializer.Deserialize(reader);
                    Odds obj = (Odds)content;
                    if (!obj.lines.Any(x => x.isInPlayEvent)) OddsDictionary.AddOrUpdate(obj.eventId, obj, (oldKey, oldValue) => obj);
                    Console.WriteLine(DateTime.Now.ToString("yyy-MM-dd HH:mm:ss.ffff") +
                                      " RECV ODDS OBJECT FOR EVENT : " + obj.eventId + " : " + message);
                }
                else if (message.Contains("<matchup_score"))
                {

                    XmlSerializer deserializer = new XmlSerializer(typeof(MatchupScore));
                    object content = deserializer.Deserialize(reader);
                    MatchupScore obj = (MatchupScore)content;
                    MatchupScoreDictionary.AddOrUpdate(obj.eventId, obj, (oldKey, oldValue) => obj);
                    Console.WriteLine(DateTime.Now.ToString("yyy-MM-dd HH:mm:ss.ffff") + " RECV SCORE OBJECT FOR EVENT : " + obj.eventId + " : " + message);
                }
                else if (message.Contains("<period_score"))
                {

                    XmlSerializer deserializer = new XmlSerializer(typeof(PeriodScore));
                    object content = deserializer.Deserialize(reader);
                    PeriodScore obj = (PeriodScore)content;
                    PeriodScoreDictionary.AddOrUpdate(obj.eventInfo.eventId, obj, (oldKey, oldValue) => obj);
                    Console.WriteLine(DateTime.Now.ToString("yyy-MM-dd HH:mm:ss.ffff") +
                                      " RECV SETTLEMENT OBJECT FOR EVENT : " + obj.eventInfo.eventId + " : " + message);
                }
                else if (message.Contains("<event_state"))
                {

                    XmlSerializer deserializer = new XmlSerializer(typeof(EventState));
                    object content = deserializer.Deserialize(reader);
                    EventState obj = (EventState)content;
                    EventStateDictionary.AddOrUpdate(obj.eventId, obj, (oldKey, oldValue) => obj);
                    Console.WriteLine(DateTime.Now.ToString("yyy-MM-dd HH:mm:ss.ffff") +
                                      " RECV EVENT STATE OBJECT FOR EVENT : " + obj.eventId + " : " + message);
                }


                FileStream oFileStream = new FileStream(DateTime.Now.ToString("yyy-MM-dd") + ".txt",
                    FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter oStreamWriter = new StreamWriter(oFileStream);
                oStreamWriter.BaseStream.Seek(0, SeekOrigin.End);
                oStreamWriter.WriteLine(DateTime.Now.ToString("yyy-MM-dd HH:mm:ss.ffff") + " RECV: " + message);
                //oStreamWriter.WriteLine(message);
                oStreamWriter.Flush();
                oStreamWriter.Close();
                oStreamWriter = null;
                oFileStream = null;
                oStreamWriter = null;
            }
            catch (Exception)
            {
            }
        }

        private static string SendGetRequest(string uri)
        {
            try
            {
                ServicePointManager.DefaultConnectionLimit = 10;
                ServicePointManager.Expect100Continue = false;
                ServicePointManager.DnsRefreshTimeout = 1000;
                ServicePointManager.UseNagleAlgorithm = false;

                string response = "";
                var request = (HttpWebRequest)WebRequest.Create(uri);
                request.Method = "GET";
                request.UserAgent =
                    "Mozilla/5.0 (Windows NT 6.2; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/31.0.1650.57 Safari/537.36";
                request.Timeout = 3000000;

                using (var stream = request.GetResponse().GetResponseStream())
                {
                    stream.ReadTimeout = 300000;
                    using (var streamReader = new StreamReader(stream, Encoding.GetEncoding("UTF-8")))
                    {
                        response = streamReader.ReadToEnd();
                    }
                }
                return response;
            }
            catch (Exception ex)
            {

            }
            return "";
        }
    }

}
