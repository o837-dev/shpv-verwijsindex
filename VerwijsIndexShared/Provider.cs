using System;
using System.Collections.Generic;
using System.Data;

namespace Denion.WebService.VerwijsIndex
{
    /// <summary>
    /// List of provider
    /// </summary>
    public class Providers : List<Provider>
    {

        /// <summary>
        /// Constructor, converts a DataTable
        /// </summary>
        /// <param name="dt">DataTable containing providers</param>
        public Providers(DataTable dt)
        {
            //list = new List<Provider>();
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Add(new Provider(dr));
                }
            }

            //Providers hebben een volgorde als geheel getal, indien twee providers het zelfde 'gewicht' hebben, worden ze binnen gehele getal grezen gehusseld 
            if (Count > 1)
            {
                foreach (Provider pr in this)
                {
                    pr.priority += (Service.rnd.NextDouble() * 0.8);
                }
                Sort();
            }

            //Report new sorting
            //StringBuilder sb = new StringBuilder();
            //foreach (Provider pr in list)
            //{
            //    sb.Append(pr.description + "(" + pr.priority.ToString("F1") + "); ");
            //}
            //Database.Database.Log("Provider priority adjusted (with randomness): " + sb.ToString());
        }
    }

    /// <summary>
    /// Provider
    /// </summary>
    public class Provider : IComparable
    {
        #region Properties

        /// <summary>
        /// het id van de provider in kwestie
        /// </summary>
        public string id { get;  set; }

        /// <summary>
        /// prioriteit in koppeling
        /// </summary>
        /// 
        private double _priority;

        /// <summary>
        /// prioriteit in koppeling
        /// </summary>
        public double priority
        {
            get
            {
                return _priority;
            }
            set
            {
                _priority = value;
            }
        }

        /// <summary>
        /// omschrijving van de provider
        /// </summary>
        public string description { get;  set; }

        /// <summary>
        /// provider URL
        /// </summary>
        public string url { get;  set; }

        /// <summary>
        /// type koppeling
        /// </summary>
        public SendLinkRequest sendlinkrequest { get; private set; }

        /// <summary>
        /// Make a NPR registration if provider granted
        /// </summary>
        public bool NPRRegistration { get;  set; }
        
        public LinkType linkType { get; private set; }

        public ProtocollType Protocoll { get; private set; }

        public enum ProtocollType
        {
            Unknown,
            VerwijsIndex,
            NprPlus
        }

        /// <summary>
        /// type koppeling
        /// </summary>
        public enum SendLinkRequest
        {
            /// <summary>
            /// Geen autorisatieverzoeken voor voertuigen waarvoor geen koppeling bestaat
            /// </summary>
            NO,
            /// <summary>
            /// Autorisatieverzoek sturen en als daar een positief antwoord op komt een koppeling registreren met de einddatumtijd van de autorisatie als einddatumtijd van de koppeling,
            /// </summary>
            IMPLICIT,
            /// <summary>
            /// Eerst een koppelingsverzoek sturen vragen bij een voertuig waarvoor nog geen Koppeling bestaat
            /// </summary>
            //EXPLICIT
        }

        /// <summary>
        /// link type
        /// </summary>
        public enum LinkType
        {
            /// <summary>
            /// N: Niet exclusieve koppelingen: er mogen op hettzelfde prioriteitsniveau meerdere koppelingen bestaan. Bij autorisatie vragen wordt de volgorde door loting bepaald.
            /// </summary>
            iNclusive,

            /// <summary>
            /// X: (eXclusieve koppelingen):, Een koppelingsverzoek van een provider wordt afgewezen (met anonieme vermelding van de reden), als er reeds een koppeling bestaat van een andere provider
            /// </summary>
            eXclusive,

            /// <summary>
            /// O: Overneembare koppelingen: Een koppelingsverzoek van een provider vervangt een eventuele koppeling van een andere provider op hetzelfde niveau
            /// </summary>
            Overrule
        }
        #endregion

        /// <summary>
        /// Constructor, converts a DataRow
        /// </summary>
        /// <param name="dr">DataRow containing provider</param>
        public Provider(DataRow dr)
        {
            DataColumnCollection col = dr.Table.Columns;

            if (col.Contains("PROVIDERID"))
                id = dr["PROVIDERID"].ToString();

            if (col.Contains("PRIORITY"))
                double.TryParse(dr["PRIORITY"].ToString(), out _priority);

            if (col.Contains("DESCRIPTION"))
                description = dr["DESCRIPTION"].ToString();

            if (col.Contains("URL"))
                url = dr["URL"].ToString();

            if (col.Contains("SENDLINKREQUEST"))
            {
                string slq = dr["SENDLINKREQUEST"].ToString().ToUpper();
                if (Enum.IsDefined(typeof(SendLinkRequest), slq))
                {
                    sendlinkrequest = (SendLinkRequest)Enum.Parse(typeof(SendLinkRequest), slq, true);
                }
            }

            if (col.Contains("LINKTYPE"))
            {
                string slt = dr["LINKTYPE"].ToString();
                if (Enum.IsDefined(typeof(LinkType), slt))
                {
                    linkType = (LinkType)Enum.Parse(typeof(LinkType), slt, true);
                }
            }

            if (col.Contains("NPRREGISTRATION"))
                NPRRegistration = (bool)dr["NPRREGISTRATION"];

            if (col.Contains("PROTOCOLL"))
            {
                string prot = dr["PROTOCOLL"].ToString();
                if (Enum.IsDefined(typeof(ProtocollType), prot))
                {
                    Protocoll = (ProtocollType)Enum.Parse(typeof(ProtocollType), prot, true);
                }

            }
        }

        public Provider() {
        }

        /// <summary>
        /// default sort order, based upon priority
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int CompareTo(object obj)
        {
            return this.priority.CompareTo(((Provider)obj).priority);
        }
    }

/*    public class Consumer
    {
        public string ID { get; set; }
        public string Url { get; set; }

        public Consumer(DataRow dr)
        {
            ID = dr["Id"] as string;
            Url = dr["Url"] as string;
        }
    }*/
}