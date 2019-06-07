using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using Denion.WebService.Database;
using Denion.WebService.Cryptography;
using Itenso.TimePeriod;
using Denion.WebService;

namespace Denion.WebService.VerwijsIndex
{
    public class DatabaseFunctions
    {

        /// <summary>
        /// Insert or update the Link record in the database
        /// </summary>
        public static LinkRegistrationResponse VerifyLink(LinkRegistrationRequest req)
        {
            LinkRegistrationResponse res = new LinkRegistrationResponse();
            Providers provs = GetProviders2(req);
            if (provs.Count > 0) //if (VerifyProvider(req))
            {
                Links ls = GetLinks2(req);

                for (int i = ls.Count-1; i >= 0; i--)
                {
                    Link l = ls[i];
                    TimeRange rLink = new TimeRange(l.STARTDATE, l.ENDDATE);
                    TimeRange rReq = new TimeRange(req.ValidFrom, req.ValidUntil);
                    if (!rLink.OverlapsWith(rReq))
                    {
                        ls.Remove(l);
                    }
                }


                if (ls.Count == 0)
                {
                    CreateLink(req.VehicleId, req.CountryCode, req.ProviderId, null, req.ValidFrom, req.ValidUntil, null, req.AreaId, req.VehicleIdType, null);
                    res.Remark = "Information; new link";
                    res.RemarkId = "131";
                }
                else if (ls.Count > 1)
                {
                    if (provs.Where(s => s.linkType == Provider.LinkType.eXclusive).Count() > 0)
                    {
                        res.Remark = "Exception; Multiple candidates with eXclusive LinkType";
                        res.RemarkId = "132";
                    }
                    else if (provs.Where(s => s.linkType == Provider.LinkType.Overrule).Count() > 0)
                    {
                        res.Remark = "Exception; Multiple candidates with Overrule LinkType";
                        res.RemarkId = "133";
                    }
                    else
                    {
                        //Meedere overlappende links update laatste?
                        Link lastLink = ls.Last();
                        if (lastLink != null) {
                            UpdateLink(req.CountryCode, null, req.ValidFrom, req.ValidUntil, null, lastLink.ID, req.VehicleIdType, null);
                            res.Remark = "Information; update link";
                            res.RemarkId = "137";
                        } else { 
                            //Zou niet voor mogen komen maar just in case 
                            CreateLink(req.VehicleId, req.CountryCode, req.ProviderId, null, req.ValidFrom, req.ValidUntil, null, req.AreaId, req.VehicleIdType, null);
                            res.Remark = "Information; new link";
                            res.RemarkId = "134";
                        }
                    }
                }
                else if (ls.Count == 1)
                {
                    Link l = ls.First();

                    if (l.PROVIDERID != req.ProviderId && provs.Where(s => s.linkType == Provider.LinkType.eXclusive).Count() > 0)
                    {
                        // overlap, doe niets
                        res.Remark = "Exception; eXclusive LinkType, no update";
                        res.RemarkId = "135";
                    }
                    else if (l.PROVIDERID != req.ProviderId && provs.Where(s => s.linkType == Provider.LinkType.Overrule).Count() > 0)
                    {
                        //update enddate of old link
                        UpdateLink(req.CountryCode, null, l.STARTDATE, req.ValidFrom, null, l.ID, req.VehicleIdType, null);
                        //create new link
                        CreateLink(req.VehicleId, req.CountryCode, req.ProviderId, null, req.ValidFrom, req.ValidUntil, null, req.AreaId, req.VehicleIdType, null);
                        //send notification to other party
                        var otherParty = provs.Find(p => p.id == l.PROVIDERID);
                        
                        Timing t = new Timing("VerwijsIndexService", "LinkTerminationNotification", otherParty.url);
                        ProviderClient pc = Service.LinkClient(otherParty.url);
                        LinkTerminationNotification ltn = new LinkTerminationNotification()
                        {
                            CountryCode = req.CountryCode,
                            VehicleId = req.VehicleId,
                            VehicleIdType = req.VehicleIdType,
                            TerminationDateTime = req.ValidFrom
                        };
                        LinkTerminationAcknowledged lta = pc.Terminated(ltn);
                        t.Finish();
                        res.Remark = "Information; link overruled, message send to other provider: " + l.PROVIDERID;
                        res.RemarkId = "136";
                    }
                    else if (l.PROVIDERID == req.ProviderId && l.AREAID == req.AreaId)
                    {
                        UpdateLink(req.CountryCode, null, req.ValidFrom, req.ValidUntil, null, l.ID, req.VehicleIdType, null);
                        res.Remark = "Information; update link";
                        res.RemarkId = "137";
                    }
                    else
                    {
                        //oude verloopt vanzelf, maak een nieuwe aan
                        CreateLink(req.VehicleId, req.CountryCode, req.ProviderId, null, req.ValidFrom, req.ValidUntil, null, req.AreaId, req.VehicleIdType, null);
                        res.Remark = "Information; new link";
                        res.RemarkId = "138";
                    }
                }
            } else {
                Database.Database.Log("GetLink; ProviderId '" + req.ProviderId + "' invalid or expired: " + ", " + req.ValidFrom + '/' + req.ValidUntil);

                res.Remark = "ProviderId invalid or expired";
                res.RemarkId = "130";
            }
            return res;
        }

      

        private static Providers ListOfProviders(LinkRegistrationRequest req)
        {
            using (SqlCommand com = new SqlCommand(@"
                Select distinct p.ID as [ProviderId], c.PRIORITY, p.DESCRIPTION, p.URL, c.SENDLINKREQUEST, c.LINKTYPE, c.NPRREGISTRATION
                from provider as p join Contract as c on p.PID = c.PROVIDERID2 
                where p.ID= @PROVIDERID 
                 and @STARTDATE between STARTDATE and ENDDATE 
                 and @ENDDATE between STARTDATE and ENDDATE"))
            {
                com.Parameters.Add("@PROVIDERID", SqlDbType.NVarChar, 200).Value = req.ProviderId;
                com.Parameters.Add("@STARTDATE", SqlDbType.DateTime).Value = req.ValidFrom;
                com.Parameters.Add("@ENDDATE", SqlDbType.DateTime).Value = req.ValidUntil;

                DataTable dt = Database.Database.ExecuteQuery(com);
                return new Providers(dt);
            }
        }

        private static Providers GetProviders2(LinkRegistrationRequest req)
        {
            using (SqlCommand com = new SqlCommand(@"
                 Select distinct p.ID as [ProviderId], c.PRIORITY, p.DESCRIPTION, p.URL, c.SENDLINKREQUEST, c.LINKTYPE, c.NPRREGISTRATION
                    from Contract as c
	                join Provider  as p on  c.PROVIDERID2 = p.PID
	                join (Select AreaManagerId, ProviderId2, PRIORITY, linkType 
			                from Contract as c 
			                join Provider as p on  c.Providerid2 = p.PID
			                where p.ID = @PROVIDERID 
                                and @STARTDATE between STARTDATE and ENDDATE 
                                or @ENDDATE between STARTDATE and ENDDATE) as cs on c.AREAMANAGERID = cs.AREAMANAGERID and c.PRIORITY = cs.PRIORITY
                    where @STARTDATE between STARTDATE and ENDDATE 
                        or @ENDDATE between STARTDATE and ENDDATE"))
            {
                com.Parameters.Add("@PROVIDERID", SqlDbType.NVarChar, 200).Value = req.ProviderId;
                com.Parameters.Add("@STARTDATE", SqlDbType.DateTime).Value = req.ValidFrom;
                com.Parameters.Add("@ENDDATE", SqlDbType.DateTime).Value = req.ValidUntil;

                DataTable dt = Database.Database.ExecuteQuery(com);
                return new Providers(dt);
            }
        }

        private static Links GetLinks(LinkRegistrationRequest req)
        {
            using (SqlCommand com = new SqlCommand(@"Select [ID], [VEHICLEID], [COUNTRYCODE], [PROVIDERID], [AUTHORISATIONTHRESHOLD], [STARTDATE], [ENDDATE], [TOKEN], [AREAID], [VEHICLEIDTYPE], [TOKENTYPE] from Link where VEHICLEID=@VEHICLEID"))
            {
                com.Parameters.Add("@VEHICLEID", SqlDbType.NVarChar, 100).Value = Rijndael.Encrypt(req.VehicleId);
                /*if (!string.IsNullOrEmpty(req.AreaId))
                {
                    com.CommandText += " AND AREAID=@AREAID";
                    com.Parameters.Add("@AREAID", SqlDbType.NVarChar, 100).Value = req.AreaId;
                }*/
                /*if (!string.IsNullOrEmpty(req.VehicleIdType))
                {
                    com.CommandText += " and (VEHICLEIDTYPE is null or VEHICLEIDTYPE=@VEHICLEIDTYPE)"; // Voorstel aanpassing, deze constructie verder opzoeken !
                    com.Parameters.Add("@VEHICLEIDTYPE", SqlDbType.NVarChar, 50).Value = req.VehicleIdType;
                }*/
                DataTable dt = Database.Database.ExecuteQuery(com);
                return new Links(dt);
            }
        }

        private static Links GetLinks2(LinkRegistrationRequest req)
        {
            using (SqlCommand com = new SqlCommand(@"
                Select distinct l.[ID], [VEHICLEID], [COUNTRYCODE], [PROVIDERID], [AUTHORISATIONTHRESHOLD], [STARTDATE], [ENDDATE], [TOKEN], [AREAID], [VEHICLEIDTYPE], [TOKENTYPE] from link as l join 
                    (Select p.ID, c.LinkType
                        from Contract as c
                        join Provider  as p on  c.PROVIDERID2 = p.PID
                        join (Select AreaManagerId, ProviderId2, PRIORITY, linkType 
                            from Contract as c 
                            join Provider as p on  c.Providerid2 = p.PID
                            where p.ID = @PROVIDERID) as cs on c.AREAMANAGERID = cs.AREAMANAGERID and c.PRIORITY = cs.PRIORITY ) as pla on pla.ID = l.PROVIDERID
                where l.VEHICLEID = @VEHICLEID && l.AREAID = @AREAID 
                and (@STARTDATE between STARTDATE and ENDDATE OR @ENDDATE between STARTDATE and ENDDATE)"))
                
            {
                com.Parameters.Add("@PROVIDERID", SqlDbType.NVarChar, 200).Value = req.ProviderId;
                com.Parameters.Add("@AREAID", SqlDbType.NVarChar, 200).Value = req.AreaId;
                com.Parameters.Add("@VEHICLEID", SqlDbType.NVarChar, 100).Value = Rijndael.Encrypt(req.VehicleId);
                com.Parameters.Add("@STARTDATE", SqlDbType.DateTime).Value = req.ValidFrom;
                com.Parameters.Add("@ENDDATE", SqlDbType.DateTime).Value = req.ValidUntil;

                DataTable dt = Database.Database.ExecuteQuery(com);
                return new Links(dt);
            }
        }

        //private static Providers getSimular(LinkRegistrationRequest req)
        //{
        //    using (SqlCommand com = new SqlCommand(@"
        //        Select otherP.ID, [otherCU].ISUNIQUE
        //        FROM [Provider] as [p]
        //        join [Contract] as [c] on c.PROVIDERID2 = p.PID
        //        left join [Contract] as [otherC] on c.AREAMANAGERID = otherC.AREAMANAGERID and c.PRIORITY = otherC.PRIORITY
        //        join [Provider] as [otherP] on [otherC].PROVIDERID2 = otherP.PID
        //        left join [ContractUniqueness] as [otherCU] on [otherCU].PRIORITY = [otherC].PRIORITY and [otherCU].AREAMANAGERID = [otherC].AREAMANAGERID
        //        where p.ID = @PROVIDERID 
        //        group by otherP.ID, [otherCU].ISUNIQUE"))
        //    {
        //        com.Parameters.Add("@PROVIDERID", SqlDbType.NVarChar, 200).Value = req.ProviderId;

        //        DataTable dt = Database.Database.ExecuteQuery(com);
        //        return new Providers(dt);
        //    }
        //}

        private static bool VerifyProvider(LinkRegistrationRequest req)
        {
            SqlCommand com = new SqlCommand();
            com.CommandText = "select count(*) from [PROVIDER] where [ID]=@PROVIDERID";
            com.Parameters.Add("@PROVIDERID", SqlDbType.NVarChar, 200).Value = req.ProviderId;

            object rv = Database.Database.ExecuteScalar(com);
            return (rv != DBNull.Value && (int)rv > 0);
        }

        internal static DataTable GetConsumer(CancelAuthorisationRequest req)
        {

            // in basis hebben we geen gegevens/ constrole nodig uit/in de lokale administratie
            // we zouden 'vandaag' ook kunnen gebruiken voor het betpalen van het actuele consumer contract.
            //AREAMANAGERID uit contract of uit de AUTHORISATION tabel ??

            /*            using (SqlCommand com = new SqlCommand(
                            " Select c.DESCRIPTION, c.URL, a.SETTLED, a.StartDate as [AuthorisationStartDate], cc.StartDate as [ContractStartDate], cc.EndDate as [ContractEndDate] " +
                            " from Authorisation a " +
                            " join ConsumerContract cc on a.AREAMANAGERID = cc.AreaManagerId and a.AREAID = cc.AreaId "+ // and a.STARTDATE between cc.StartDate and cc.enddate " +
                            " join Consumer c on cc.ConsumerId=c.CID " +
                            " where a.AUTHORISATIONID=@AUTHORISATIONID and a.VEHICLEID=@VEHICLEID and a.PROVIDERID=@PROVIDERID and cc.AREAMANAGERID=@AREAMANAGERID and cc.AREAID=@AREAID")) // and a.SETTLED=@SETTLED "))
                            */
            /*
                        string sql = 
                            "Select auth.SETTLED, auth.AuthorisationStartDate, co.URL, co.ContractStartDate, co.ContractEndDate " +
                            " from AreaManager as am " +
                            " left outer join (Select a.SETTLED, a.StartDate as [AuthorisationStartDate], a.AREAMANAGERID from  " +
                            " Authorisation a where a.AUTHORISATIONID=@AUTHORISATIONID and a.VEHICLEID=@VEHICLEID and a.PROVIDERID=@PROVIDERID  " +
                            " and a.AREAMANAGERID=@AREAMANAGERID and a.AREAID=@AREAID {0}) as auth " +
                            " on auth.AREAMANAGERID = am.ID " +
                            " left outer join  " +
                            " (Select c.URL, cc.StartDate as [ContractStartDate], cc.EndDate as [ContractEndDate], cc.AREAMANAGERID  " +
                            " from ConsumerContract cc join Consumer c on cc.ConsumerId=c.CID where cc.AREAMANAGERID=@AREAMANAGERID and cc.AREAID=@AREAID) as co  " +
                            " on am.ID = co.AREAMANAGERID " +
                            " where am.ID = @AREAMANAGERID ";*/
            string sql =
                " Select a.SETTLED, a.STARTDATE as [AuthorisationStartDate], co.URL, co.ContractStartDate, co.ContractEndDate " +
                " from Authorisation a  " +
                " left outer join  " +
                " (Select c.URL, cc.StartDate as [ContractStartDate], cc.EndDate as [ContractEndDate], cc.AREAMANAGERID from  " +
                " ConsumerContract cc join Consumer c on cc.ConsumerId=c.CID where cc.AREAMANAGERID=@AREAMANAGERID and cc.AREAID=@AREAID) as co  " +
                " on a.AREAMANAGERID = co.AREAMANAGERID " +
                " where a.AUTHORISATIONID=@AUTHORISATIONID and a.VEHICLEID=@VEHICLEID and a.PROVIDERID=@PROVIDERID " +
                " and a.AREAMANAGERID=@AREAMANAGERID and a.AREAID=@AREAID ";

            string sqlDynWhere = "";
            using (SqlCommand com = new SqlCommand())
            {
                com.Parameters.Add("@AUTHORISATIONID", SqlDbType.NVarChar, 50).Value = req.PaymentAuthorisationId;
                com.Parameters.Add("@VEHICLEID", SqlDbType.NVarChar, 100).Value = Cryptography.Rijndael.Encrypt(req.VehicleId);
                com.Parameters.Add("@PROVIDERID", SqlDbType.NVarChar, 200).Value = req.ProviderId;
                com.Parameters.Add("@AREAMANAGERID", SqlDbType.NVarChar, 200).Value = req.AreaManagerId;
                // Authorisation heeft geen paraplu gebieden, alleeen maar concrete garages (anders hadden we een join met AreaGroups moeten maken)
                com.Parameters.Add("@AREAID", SqlDbType.NVarChar, 100).Value = req.AreaId;
                if (!string.IsNullOrEmpty(req.CountryCode))
                {
                    //com.CommandText += " and [COUNTRYCODE]=@COUNTRYCODE";
                    sqlDynWhere = " AND (a.COUNTRYCODE = @COUNTRYCODE or a.COUNTRYCODE IS NULL) ";
                    com.Parameters.Add("@COUNTRYCODE", SqlDbType.NVarChar, 10).Value = req.CountryCode;
                }

                //settled handelen we later af (zodat we een specifiekere fout kunnen geven, (indien gesetteled))
                //com.Parameters.Add("@SETTLED", System.Data.SqlDbType.Bit).Value = false;

                if (!string.IsNullOrEmpty(req.VehicleIdType))
                {
                    //com.CommandText += " AND a.VEHICLEIDTYPE=@VEHICLEIDTYPE";
                    sqlDynWhere = " AND (a.VEHICLEIDTYPE = @VEHICLEIDTYPE or a.VEHICLEIDTYPE is null) ";
                    com.Parameters.Add("@VEHICLEIDTYPE", SqlDbType.NVarChar, 50).Value = req.VehicleIdType;
                }
                //Database.Database.Log(Database.Database.PrintExecutableCommand(com));
                com.CommandText = string.Format(sql, sqlDynWhere);
                return Database.Database.ExecuteQuery(com);
            }
        }

        /// <summary>
        /// Update Link record in the database
        /// </summary>
        internal static void UpdateLink(string countryCode, double? authorisationMaxAmount, DateTime authorisationValidFrom, DateTime? authorisationValidUntil, string token, int Id, string vehicleIdType, string tokenType)
        {
            SqlCommand com = new SqlCommand();
            string update = "update Link set [AUTHORISATIONTHRESHOLD]=@AUTHORISATIONTHRESHOLD, [STARTDATE]=@STARTDATE, [ENDDATE]=@ENDDATE, [TOKEN]=@TOKEN, [TOKENTYPE]=@TOKENTYPE";
            string where = " where [Id]=@ID";

            com.Parameters.Add("@STARTDATE", SqlDbType.DateTime).Value = Denion.WebService.Functions.DateTimeToLocalTimeZone(authorisationValidFrom);
            com.Parameters.Add("@ID", SqlDbType.Int).Value = Id;

            if (authorisationMaxAmount.HasValue)
                com.Parameters.Add("@AUTHORISATIONTHRESHOLD", SqlDbType.SmallMoney).Value = authorisationMaxAmount;
            else
                com.Parameters.Add("@AUTHORISATIONTHRESHOLD", SqlDbType.SmallMoney).Value = DBNull.Value;

            if (authorisationValidUntil.HasValue)
                com.Parameters.Add("@ENDDATE", SqlDbType.DateTime).Value = Denion.WebService.Functions.DateTimeToLocalTimeZone(authorisationValidUntil.Value);
            else
                com.Parameters.Add("@ENDDATE", SqlDbType.DateTime).Value = Denion.WebService.Functions.DateTimeToLocalTimeZone(authorisationValidFrom);

            if (!string.IsNullOrEmpty(token))
                com.Parameters.Add("@TOKEN", SqlDbType.NVarChar, 200).Value = token;
            else
                com.Parameters.Add("@TOKEN", SqlDbType.NVarChar, 200).Value = DBNull.Value;

            if (!string.IsNullOrEmpty(tokenType))
                com.Parameters.Add("@TOKENTYPE", SqlDbType.NVarChar, 50).Value = tokenType;
            else
                com.Parameters.Add("@TOKENTYPE", SqlDbType.NVarChar, 50).Value = DBNull.Value;

            if (!string.IsNullOrEmpty(countryCode))
            {
                update += ", [COUNTRYCODE]=@COUNTRYCODE";
                com.Parameters.Add("@COUNTRYCODE", SqlDbType.NVarChar, 10).Value = countryCode;
            }

            if (!string.IsNullOrEmpty(vehicleIdType))
            {
                update += ", [VEHICLEIDTYPE]=@VEHICLEIDTYPE";
                com.Parameters.Add("@VEHICLEIDTYPE", SqlDbType.NVarChar, 50).Value = vehicleIdType;
            }

            com.CommandText = update + where;
            //Database.Database.ExecuteScalar(com);
            Database.DatabaseQueue.Add(new QueueObject(com));
        }

        /// <summary>
        /// retrieve a list of providers, which matches the request
        /// </summary>
        /// <returns>list of providers</returns>
        internal static Providers ListOfProvider(string areaManagerId, DateTime dateTime)
        {
            SqlCommand com = new SqlCommand();
            com.CommandText = @"Select p.ID as [PROVIDERID], c.PRIORITY, p.DESCRIPTION, p.URL, c.SENDLINKREQUEST, c.NPRREGISTRATION , p.PROTOCOLL
                from Provider p join Contract c on p.PID = c.PROVIDERID2 
                where c.AREAMANAGERID = @AREAMANAGERID and c.STARTDATE <= @STARTDATE and c.ENDDATE > @ENDDATE order by c.PRIORITY";
            com.Parameters.Add("@AREAMANAGERID", SqlDbType.NVarChar, 200).Value = areaManagerId;
            com.Parameters.Add("@STARTDATE", SqlDbType.DateTime, 100).Value = dateTime;
            com.Parameters.Add("@ENDDATE", SqlDbType.DateTime, 100).Value = dateTime;

            DataTable dt = Denion.WebService.Database.Database.ExecuteQuery(com);
            return new Providers(dt);
        }

        internal static Providers GetProvider(string areaManagerId, string providerId, DateTime dateTime)
        {
            SqlCommand com = new SqlCommand();
            com.CommandText = "Select p.ID  as [PROVIDERID], c.PRIORITY, p.DESCRIPTION, p.URL, c.SENDLINKREQUEST, c.NPRREGISTRATION, p.PROTOCOLL from Provider p join Contract c on p.PID = c.PROVIDERID2 where c.AREAMANAGERID = @AREAMANAGERID and c.STARTDATE <= @STARTDATE and c.ENDDATE > @ENDDATE and p.ID=@PROVIDERID";
            com.Parameters.Add("@AREAMANAGERID", SqlDbType.NVarChar, 200).Value = areaManagerId;
            com.Parameters.Add("@STARTDATE", SqlDbType.DateTime, 100).Value = dateTime;
            com.Parameters.Add("@ENDDATE", SqlDbType.DateTime, 100).Value = dateTime;
            com.Parameters.Add("@PROVIDERID", SqlDbType.NVarChar, 200).Value = providerId;

            DataTable dt = Denion.WebService.Database.Database.ExecuteQuery(com);
            return new Providers(dt);
        }

        /// <summary>
        /// Select the Link from the database
        /// </summary>
        /// <param name="ProviderId">the provider to check</param>
        /// <returns>When found in the database, the record id of the link</returns>
        internal static Link GetLink(string providerId, string vehicleId, DateTime? startDateTime, DateTime? endDateTime, double? amount, string AreaId, bool useGroups, string vehicleIdType)
        {
            string select = "select l.[ID], coalesce (g.AREAID, l.[AreaID]) as [AREAID] from [Link] l left join AreaGroup g on l.AREAID = g.AREAGROUP";
            string where = " where l.[PROVIDERID]=@PROVIDERID and l.[VEHICLEID]=@VEHICLEID ";
            SqlCommand com = new SqlCommand();

            com.Parameters.Add("@PROVIDERID", SqlDbType.NVarChar, 200).Value = providerId;
            com.Parameters.Add("@VEHICLEID", SqlDbType.NVarChar, 100).Value = Cryptography.Rijndael.Encrypt(vehicleId);

            //if (!string.IsNullOrEmpty(_request.CountryCode))
            //{
            //    where += " and [COUNTRYCODE]=@COUNTRYCODE";
            //    com.Parameters.Add("@COUNTRYCODE", SqlDbType.NVarChar, 10).Value = _request.CountryCode;
            //}
            if (!string.IsNullOrEmpty(AreaId))
            {
                if (useGroups)
                    where += " and (l.AREAID = @AREAID or g.AREAID = @AREAID or l.AREAID is null)";
                else
                    where += " and (l.AREAID = @AREAID)";
                com.Parameters.Add("@AREAID", SqlDbType.NVarChar, 100).Value = AreaId;
            }
            if (startDateTime.HasValue)
            {
                where += " and @STARTDATE BETWEEN [STARTDATE] and [ENDDATE]";
                com.Parameters.Add("@STARTDATE", SqlDbType.DateTime).Value = startDateTime;
            }
            if (amount.HasValue)
            {
                where += " and @AMOUNT<=[AUTHORISATIONTHRESHOLD]";
                com.Parameters.Add("@AMOUNT", SqlDbType.SmallMoney).Value = amount;
            }
            if (endDateTime.HasValue)
            {
                where += " and @ENDDATE BETWEEN [STARTDATE] and [ENDDATE]";
                com.Parameters.Add("@ENDDATE", SqlDbType.DateTime).Value = endDateTime;
            }
            if (!string.IsNullOrEmpty(vehicleIdType))
            {
                where += " and (VEHICLEIDTYPE=@VEHICLEIDTYPE or VEHICLEIDTYPE IS NULL)";
                //where += " and (VEHICLEIDTYPE is null or VEHICLEIDTYPE=@VEHICLEIDTYPE)"; // Voorstel aanpassing, deze constructie verder opzoeken !
                com.Parameters.Add("@VEHICLEIDTYPE", SqlDbType.NVarChar, 50).Value = vehicleIdType;
            }

            Link lnk = null;
            com.CommandText = select + where;
            //Database.Database.Log("GET Link:" + Database.Database.PrintCommand(com));
            DataTable dt = Database.Database.ExecuteQuery(com);
            if (dt != null && dt.Rows.Count > 0)
            {
                lnk = new Link(dt.Rows[0]["ID"], dt.Rows[0]["AreaID"]);
            }
            //else
            //{
            //    Database.Database.Log("No Link:" + Database.Database.PrintCommand(com));
            //}
            return lnk;
        }

        /// <summary>
        /// Update Autorisation request in the database
        /// </summary>
        /// <param name="LinkId">optional record id of the link record</param>
        internal static void UpdateAuthorisation(string providerId, string paymentAuthorisationId, string remark, object requestId, Link link, DateTime? startDateTime)
        {
            SqlCommand com = new SqlCommand();
            com.CommandText = "Update Authorisation set PROVIDERID=@PROVIDERID, AUTHORISATIONID=@AUTHORISATIONID, REMARK=@REMARK {0} where REQUESTID=@REQUESTID";
            com.Parameters.Add("@PROVIDERID", SqlDbType.NVarChar, 200).Value = providerId;
            if (!string.IsNullOrEmpty(paymentAuthorisationId))
                com.Parameters.Add("@AUTHORISATIONID", SqlDbType.NVarChar, 50).Value = paymentAuthorisationId;
            else
                com.Parameters.Add("@AUTHORISATIONID", SqlDbType.NVarChar, 50).Value = "";

            if (!string.IsNullOrEmpty(remark))
                com.Parameters.Add("@REMARK", SqlDbType.NVarChar, 200).Value = remark;
            else
                com.Parameters.Add("@REMARK", SqlDbType.NVarChar, 200).Value = "";

            com.Parameters.Add("@REQUESTID", SqlDbType.Int).Value = requestId;
            //com.Parameters.Add("@SETTLED", SqlDbType.Bit).Value = true;

            if (startDateTime.HasValue && link != null) {
                com.CommandText = string.Format(com.CommandText, ", LINKID=@LINKID, STARTDATE=@STARTDATE");
                com.Parameters.Add("@STARTDATE", SqlDbType.DateTime).Value = Denion.WebService.Functions.DateTimeToLocalTimeZone(startDateTime.Value);
                com.Parameters.Add("@LINKID", SqlDbType.Int).Value = link.ID;
            } else if (startDateTime.HasValue && link == null) {
                com.CommandText = string.Format(com.CommandText, ", STARTDATE=@STARTDATE");
                com.Parameters.Add("@STARTDATE", SqlDbType.DateTime).Value = Denion.WebService.Functions.DateTimeToLocalTimeZone(startDateTime.Value);
            } else if (link != null) {
                com.CommandText = string.Format(com.CommandText, ", LINKID=@LINKID ");
                com.Parameters.Add("@LINKID", SqlDbType.Int).Value = link.ID;
            } else {
                com.CommandText = string.Format(com.CommandText, "");
            }

            Database.Database.ExecuteQuery(com);
            //Database.DatabaseQueue.Add(new QueueObject(com));
        }

        /// <summary>
        /// Insert Link record into the database
        /// </summary>
        internal static Link CreateLink(string vehicleId, string countryCode, string providerId, double? authorisationMaxAmount, DateTime authorisationValidFrom, DateTime? authorisationValidUntil, string token, string AreaId, string vehicleIdType, string tokenType)
        {
            checkForUniqueness(providerId, vehicleId);

            SqlCommand com = new SqlCommand();
            com.CommandText = "insert into Link ([VEHICLEID],[COUNTRYCODE],[PROVIDERID],[AUTHORISATIONTHRESHOLD],[STARTDATE],[ENDDATE],[TOKEN],[AREAID],[VEHICLEIDTYPE],[TOKENTYPE]) output inserted.id values (@VEHICLEID, @COUNTRYCODE, @PROVIDERID, @AUTHORISATIONTHRESHOLD, @STARTDATE, @ENDDATE, @TOKEN, @AREAID, @VEHICLEIDTYPE, @TOKENTYPE)";
            com.Parameters.Add("@STARTDATE", SqlDbType.DateTime).Value = Denion.WebService.Functions.DateTimeToLocalTimeZone(authorisationValidFrom);
            com.Parameters.Add("@VEHICLEID", SqlDbType.NVarChar, 100).Value = Cryptography.Rijndael.Encrypt(vehicleId);
            com.Parameters.Add("@PROVIDERID", SqlDbType.NVarChar, 200).Value = providerId;
            com.Parameters.Add("@AUTHORISATIONTHRESHOLD", SqlDbType.SmallMoney).Value = (authorisationMaxAmount.HasValue) ? (object)authorisationMaxAmount : DBNull.Value;
            com.Parameters.Add("@ENDDATE", SqlDbType.DateTime).Value = Denion.WebService.Functions.DateTimeToLocalTimeZone((authorisationValidUntil.HasValue) ? authorisationValidUntil.Value : authorisationValidFrom);
            com.Parameters.Add("@COUNTRYCODE", SqlDbType.NVarChar, 10).Value = (!string.IsNullOrEmpty(countryCode)) ? countryCode : "";
            com.Parameters.Add("@TOKEN", SqlDbType.NVarChar, 200).Value = (!string.IsNullOrEmpty(token)) ? (object)token : DBNull.Value;
            com.Parameters.Add("@AREAID", SqlDbType.NVarChar, 100).Value = (!string.IsNullOrEmpty(AreaId)) ? (object)AreaId : DBNull.Value;
            com.Parameters.Add("@VEHICLEIDTYPE", SqlDbType.NVarChar, 50).Value = (!string.IsNullOrEmpty(vehicleIdType)) ? (object)vehicleIdType : DBNull.Value;
            com.Parameters.Add("@TOKENTYPE", SqlDbType.NVarChar, 50).Value = (!string.IsNullOrEmpty(tokenType)) ? (object)tokenType : DBNull.Value;

            Link lnk = null;
            Object obj = Database.Database.ExecuteScalar(com);
            if (obj != null)
            {
                lnk = new Link(obj);
            }
            return lnk;
        }

        private static void checkForUniqueness(String providerId, String vehicleId)
        {
            return;
            //SqlCommand com = new SqlCommand("Select ISUNIQUE FROM ContractUniqueness where AREAMANAGERID=@AREAMANAGERID and PRIORITY=@PRIORITY");
            //com.Parameters.Add("@AREAMANAGERID", SqlDbType.NVarChar, 60).Value = providerId;
            //com.Parameters.Add("@PRIORITY", SqlDbType.Int).Value = Cryptography.Rijndael.Encrypt(vehicleId);
            //object oIsUnique = Database.Database.ExecuteScalar(com);

            //bool isUnique = bool.Parse(oIsUnique.ToString())
            //if (ISUNIQUE )


        }

        /// <summary>
        /// Create Authorisation record in the database and stores the inserted id in the _requestid value
        /// </summary>
        internal static object RegisterRequest(string accessId, string vehicleId, string countryCode, string areaManagerId, DateTime startDateTime, string areaId, string vehicleIdType, string paymentAuthorisationId)
        {
            SqlCommand com = new SqlCommand();
            com.CommandText = "INSERT INTO Authorisation ([ACCESSID], [VEHICLEID], [COUNTRYCODE], [AREAMANAGERID], [STARTDATE], [SETTLED], [AREAID], [VEHICLEIDTYPE], [AUTHORISATIONID]) OUTPUT INSERTED.REQUESTID VALUES (@ACCESSID, @VEHICLEID, @COUNTRYCODE, @AREAMANAGERID, @STARTDATE, @SETTLED, @AREAID, @VEHICLEIDTYPE, @AUTHORISATIONID)";

            if (!string.IsNullOrEmpty(accessId))
                com.Parameters.Add("@ACCESSID", SqlDbType.NVarChar, 200).Value = accessId;
            else
                com.Parameters.Add("@ACCESSID", SqlDbType.NVarChar, 200).Value = "";
            
            com.Parameters.Add("@AUTHORISATIONID", SqlDbType.NVarChar, 50).Value = paymentAuthorisationId;
            com.Parameters.Add("@VEHICLEID", SqlDbType.NVarChar, 100).Value = Rijndael.Encrypt(vehicleId);

            if (!string.IsNullOrEmpty(countryCode))
                com.Parameters.Add("@COUNTRYCODE", SqlDbType.NVarChar, 10).Value = countryCode;
            else
                com.Parameters.Add("@COUNTRYCODE", SqlDbType.NVarChar, 10).Value = "";
            com.Parameters.Add("@AREAMANAGERID", SqlDbType.NVarChar, 200).Value = areaManagerId;
            com.Parameters.Add("@STARTDATE", SqlDbType.DateTime).Value = Denion.WebService.Functions.DateTimeToLocalTimeZone(startDateTime);
            com.Parameters.Add("@SETTLED", SqlDbType.Bit).Value = false;
            com.Parameters.Add("@AREAID", SqlDbType.NVarChar, 200).Value = areaId;
            com.Parameters.Add("@VEHICLEIDTYPE", SqlDbType.NVarChar, 50).Value = (!string.IsNullOrEmpty(vehicleIdType)) ? (object)vehicleIdType : DBNull.Value;

            return Database.Database.ExecuteScalar(com);
        }

        /// <summary>
        /// Remove unsettled registrations
        /// </summary>
        internal static void UnregisterRequest(object RecordID)
        {
            //Database.Database.Log(string.Format("DELETE FROM Authorisation; {0}", _request.VehicleId));

            SqlCommand com = new SqlCommand();
            com.CommandText = "DELETE FROM Authorisation where REQUESTID=@REQUESTID";
            com.Parameters.Add("@REQUESTID", SqlDbType.Int).Value = RecordID;

            //Database.Database.ExecuteQuery(com);
            Database.DatabaseQueue.Add(new QueueObject(com));
        }

        internal static void InitializeConstants()
        {
            DataTable dt = Database.Database.ExecuteQuery("Select Type FROM Types");
            if (dt != null && dt.Rows.Count > 0)
            {
                lock (Functions.ValidTypes)
                {
                    Functions.ValidTypes.Clear();
                    foreach (DataRow dr in dt.Rows)
                    {
                        Functions.ValidTypes.Add(dr["Type"].ToString().ToUpper());
                    }
                }
            }

            dt = Database.Database.ExecuteQuery("Select ID FROM AreaManager");
            if (dt != null && dt.Rows.Count > 0)
            {
                lock (Functions.ValidAreaManagerIds)
                {
                    Functions.ValidAreaManagerIds.Clear();
                    foreach (DataRow dr in dt.Rows)
                    {
                        Functions.ValidAreaManagerIds.Add(dr["ID"].ToString().ToUpper());
                    }
                }
            }
        }

        internal static Providers ListOfParkingFacilities(string areaManagerId, string AreaId, DateTime dateTime)
        {
            SqlCommand com = new SqlCommand();
            com.CommandText = @"
  SELECT 
      c.ID, c.URL
  FROM [dbo].[ConsumerContract] as cc
  join [Consumer] as c on cc.[CONSUMERID] = c.CID
  where cc.[AREAMANAGERID] = @AREAMANAGERID and cc.[AREAID] = @AREAID and @DATE between cc.[STARTDATE] and cc.[ENDDATE]";
            com.Parameters.Add("@AREAMANAGERID", SqlDbType.NVarChar, 200).Value = areaManagerId;
            com.Parameters.Add("@AREAID", SqlDbType.NVarChar, 200).Value = AreaId;
            com.Parameters.Add("@DATE", SqlDbType.DateTime, 100).Value = dateTime;
            
            DataTable dt = Database.Database.ExecuteQuery(com);
            return new Providers(dt);
        }

        /// <summary>
        /// Retrieves a property value from the database
        /// </summary>
        /// <param name="PropertyName">the name of the propery to fetch</param>
        /// <param name="defaultValue">a default return value</param>
        /// <returns></returns>
        internal static int GetProperty(string PropertyName, int defaultValue)
        {
            int intValue;
            object objValue = Database.Database.GetProperty(PropertyName);
            if (objValue != null)
            {
                if (int.TryParse(objValue.ToString(), out intValue))
                    return intValue;
            }
            return defaultValue;
        }
    }
}