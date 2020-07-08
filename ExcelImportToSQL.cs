using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportExcel
{
    class Program
    {
        static void Main(string[] args)
        {

            //ImportArrivalData();
            ImportDepartureData();
        }
        private static void ImportDepartureData()
        {
            try
            {
                string constr = string.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=""Excel 12.0 Xml;HDR=YES;""", @"D:\Gaurav\cfdb_departure");
                OleDbConnection Econ = new OleDbConnection(constr);
                string Query = string.Format("Select DEPARTURE_ID,AAN,ABT,ACM,ADC,ADV,AD1,AD2,AD3,APF,APN,APT,AOT,ASB,ASE,ASI,ASS,ATC,ATD,BGT,BID,BLL,BTL,BTR,BTT,BUS,CAA,CAM,CGO,CIR,CLE,CSG,DAE,DAS,DAY,DDL,DES,DIG,DIT,DL1,DL2,DL3,DL4,DOM,DOP,DPE,DPS,DRM,EAN,ED1,ED2,ED3,ETD,FCC,FCD,GAD,FLC,FLN,FLR,FLT,FLX,FTY,GAT,GA2,GRM,GST,GVF,HCA,HCB,HCG,HCI,HCL,HDI,HDL,HMM,HPU,HPX,HRA,ICT,IR1,IR2,IR3,IR4,IRL,IX1,IX2,IX3,IX4,LDI,LDX,LKD,LKF,LKR,LKS,LMF,LTD,MAL,MFF,MGT,MID,MIS,MSD,NAT,PAX,PBT,PCB,PDS,PLT,PPF,PPN,PSC,PUS,PV1,PV2,PXC,PXL,PXT,RCP,RC2,RDL,REG,REM,REQ,RGA,RHC,RM1,RM2,RM3,RWY,SCH,SCI,SDT,SED,SFI,SRCE,SPV,SP2,SP3,SP4,SST,STD,STN,SUT,TAR,TER,TFM,TGP,TOR,TRA,TYP,TYS,ULC,UPDT,VI1,VI2,ZON,last_update FROM [{0}]", "Sheet1$");
                OleDbCommand Ecom = new OleDbCommand(Query, Econ);
                Econ.Open();
                DataSet ds = new DataSet();
                OleDbDataAdapter oda = new OleDbDataAdapter(Query, Econ);
                Econ.Close();
                oda.Fill(ds);
                DataTable Exceldt = ds.Tables[0];
                //for (int i = Exceldt.Rows.Count - 1; i >= 0; i--)
                //{
                //    if (Exceldt.Rows[i]["AAN"] == DBNull.Value || Exceldt.Rows[i]["ABT"] == DBNull.Value)
                //    {
                //        Exceldt.Rows[i].Delete();
                //    }
                //}
                //Exceldt.AcceptChanges();
                string ConnectionString = "server = DETCSASPMS0193; database = hp-afis-dev; User ID = AFISAdmin; Password = AFISAdmin@1234"; //Connection Details
                SqlBulkCopy objbulk;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConnectionString;
                con.Open();

                // objbulk = GetDepartureAircraftMapping(ConnectionString);
                // objbulk.WriteToServer(Exceldt);
                // objbulk = GetDepartureLoadMapping(ConnectionString);
                //objbulk.WriteToServer(Exceldt);
                //objbulk = GetDeparturePassengerMapping(ConnectionString);
                //objbulk.WriteToServer(Exceldt);
                //objbulk = GetDepartureHandlerMapping(ConnectionString);
                //objbulk.WriteToServer(Exceldt);
                //objbulk = GetDepartureLinkAndShareMapping(ConnectionString);
                //objbulk.WriteToServer(Exceldt);
                //objbulk = GetDepartureBaggageMapping(ConnectionString);
                //objbulk.WriteToServer(Exceldt);
                //objbulk = GetDepartureAirportMapping(ConnectionString);
                //objbulk.WriteToServer(Exceldt);               
                //objbulk = GetDepartureRouteMapping(ConnectionString);
                //objbulk.WriteToServer(Exceldt);

                //NOT WORKING
                //objbulk = GetDepartureDelaysMapping(ConnectionString);
                //objbulk.WriteToServer(Exceldt);
                //Departure Times
                con.Close();
                con.Close();


            }
            catch (Exception ex)
            {


            }
        }

        private static void ImportArrivalData()
        {
            try
            {
                string constr = string.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=""Excel 12.0 Xml;HDR=YES;""", @"D:\Gaurav\cfdb_arrival");
                OleDbConnection Econ = new OleDbConnection(constr);
                string Query = string.Format("Select ARRIVAL_ID,ACM,ADP,APT,ATA,BID,BUS,CGO,CSG,DAY,DDL,DEL,DL1,DL2,DOM,DOP,EDP,ETA,FCC,FCD,FBP,FBR,FLC,FLN,FLR,FLT,FLX,FTY,GAT,GRM,GVF,HCA,HCB,HCG,HCL,HDL,HLF,HMM,HPX,HPU,HRA,IR1,IR2,IRL,IX1,IX2,LAX,LBP,LBR,LDI,LKD,LKF,LKR,LKS,LTA,MAL,MFF,MIA,MIS,MSA,NAT,ORG,PAX,PCB,PLT,PNK,POR,PSC,PUS,PV1,PV2,PXC,PXL,PXT,RCP,RC2,REG,REM,REQ,RGA,RHC,RM1,RM2,RM3,RTK,RWY,SCH,SCI,SDT,SFI,SRCE,SPV,SP2,SP3,SP4,SST,STA,STP,TAR,TDT,TER,TGP,TOR,TRA,TTM,TYP,TYS,UPDT,VI1,VI2,ZON,FSB,FSL,LSB,LSL,FTB,FTL,LTB,LTL,BCT,BLA,DTT,last_update FROM [{0}]", "Sheet1$");
                OleDbCommand Ecom = new OleDbCommand(Query, Econ);
                Econ.Open();
                DataSet ds = new DataSet();
                OleDbDataAdapter oda = new OleDbDataAdapter(Query, Econ);
                Econ.Close();
                oda.Fill(ds);
                DataTable Exceldt = ds.Tables[0];
                //for (int i = Exceldt.Rows.Count - 1; i >= 0; i--)
                //{
                //    if (Exceldt.Rows[i]["Employee Name"] == DBNull.Value || Exceldt.Rows[i]["Email"] == DBNull.Value)
                //    {
                //        Exceldt.Rows[i].Delete();
                //    }
                //}
                //Exceldt.AcceptChanges();
                string ConnectionString = "server = DETCSASPMS0193; database = hp-afis-dev; User ID = AFISAdmin; Password = AFISAdmin@1234"; //Connection Details
                SqlBulkCopy objbulk;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConnectionString;
                con.Open();
                //objbulk = GetArrivalAircraftMapping(ConnectionString);
                //objbulk.WriteToServer(Exceldt);
                //objbulk = GetArrivalLoadMapping(ConnectionString);
                //objbulk.WriteToServer(Exceldt);
                //objbulk = GetArrivalPassengerMapping(ConnectionString);
                //objbulk.WriteToServer(Exceldt);               
                //objbulk = GetArrivalHandlerMapping(ConnectionString);
                //objbulk.WriteToServer(Exceldt);
                //objbulk = GetArrivalLinkAndShareMapping(ConnectionString);
                //objbulk.WriteToServer(Exceldt);
                // objbulk = GetArrivalBaggageMapping(ConnectionString);
                //objbulk.WriteToServer(Exceldt);
                //objbulk = GetArrivalAirportMapping(ConnectionString);
                //objbulk.WriteToServer(Exceldt);


                //NOT WORKING ARRIVAL
                //objbulk = GetArrivalRouteMapping(ConnectionString);
                //objbulk.WriteToServer(Exceldt);
                //objbulk = GetArrivalDelaysMapping(ConnectionString);
                // objbulk.WriteToServer(Exceldt);
                //Arrival Times

                con.Close();
                con.Close();


            }
            catch (Exception ex)
            {


            }
        }
        private static SqlBulkCopy GetDepartureRouteMapping(string con)
        {
            //creating object of SqlBulkCopy      
            SqlBulkCopy objbulk = new SqlBulkCopy(con);
            //assigning Destination table name      
            objbulk.DestinationTableName = "departureroute";
            //Mapping Table column
            objbulk.ColumnMappings.Add("DEPARTURE_ID", "FlightKey");
            objbulk.ColumnMappings.Add("PDS", "PassengersDestination");
            objbulk.ColumnMappings.Add("PV1", "PublicTransitStation1");
            objbulk.ColumnMappings.Add("PV2", "PublicTransitStation2");
            objbulk.ColumnMappings.Add("VI1", "TransitStation1");
            objbulk.ColumnMappings.Add("VI2", "TransitStation2");
            //objbulk.ColumnMappings.Add("EAN", "EstimatedArrivalTimeNext");
            return objbulk;
        }

        private static SqlBulkCopy GetDeparturePassengerMapping(string con)
        {
            //creating object of SqlBulkCopy      
            SqlBulkCopy objbulk = new SqlBulkCopy(con);
            //assigning Destination table name      
            objbulk.DestinationTableName = "departurepassenger";
            //Mapping Table column
            objbulk.ColumnMappings.Add("DEPARTURE_ID", "FlightKey");
            objbulk.ColumnMappings.Add("PAX", "Passengers");
            objbulk.ColumnMappings.Add("PBT", "BookedPassengers");
            objbulk.ColumnMappings.Add("PCB", "PassengersConnectingBaggage");
            objbulk.ColumnMappings.Add("PXL", "LocalPassengers");
            objbulk.ColumnMappings.Add("PXT", "TransferPassengers");
            objbulk.ColumnMappings.Add("PXC", "ConnectingPassengers");
            return objbulk;
        }
        private static SqlBulkCopy GetDepartureLinkAndShareMapping(string con)
        {
            //creating object of SqlBulkCopy      
            SqlBulkCopy objbulk = new SqlBulkCopy(con);
            //assigning Destination table name      
            objbulk.DestinationTableName = "departureLinkAndShare";
            //Mapping Table column
            objbulk.ColumnMappings.Add("DEPARTURE_ID", "FlightKey");
            objbulk.ColumnMappings.Add("LKD", "LinkDay");
            objbulk.ColumnMappings.Add("LKF", "LinkFlightIdentity");
            objbulk.ColumnMappings.Add("LKR", "LinkRepeatCount");
            // objbulk.ColumnMappings.Add("LKS", "LinkScheduledDate");
            objbulk.ColumnMappings.Add("MFF", "MasterFlightIdentity");
            objbulk.ColumnMappings.Add("SST", "SharedStatusCount");

            return objbulk;
        }
        private static SqlBulkCopy GetDepartureHandlerMapping(string con)
        {
            //creating object of SqlBulkCopy      
            SqlBulkCopy objbulk = new SqlBulkCopy(con);
            //assigning Destination table name      
            objbulk.DestinationTableName = "departurehandler";
            //Mapping Table column
            objbulk.ColumnMappings.Add("DEPARTURE_ID", "FlightKey");
            objbulk.ColumnMappings.Add("HCA", "HandlerCatering");
            objbulk.ColumnMappings.Add("HCB", "HandlerCrewBus");
            objbulk.ColumnMappings.Add("HCG", "HandlerCargo");
            objbulk.ColumnMappings.Add("HCI", "HandlerCheckIn");
            objbulk.ColumnMappings.Add("HCL", "HandlerCleaning");
            objbulk.ColumnMappings.Add("HDI", "HandlingDeicing");
            objbulk.ColumnMappings.Add("HDL", "HandlingAgent");
            objbulk.ColumnMappings.Add("HMM", "HandlingMaintenance");
            objbulk.ColumnMappings.Add("HPU", "HandlerPushBack");
            objbulk.ColumnMappings.Add("HPX", "HandlerPassengers");
            objbulk.ColumnMappings.Add("HRA", "HandlerRamp");
            return objbulk;
        }
        private static SqlBulkCopy GetDepartureDelaysMapping(string con)
        {
            //creating object of SqlBulkCopy      
            SqlBulkCopy objbulk = new SqlBulkCopy(con);
            //assigning Destination table name      
            objbulk.DestinationTableName = "departuredelays";
            //Mapping Table column
            objbulk.ColumnMappings.Add("DEPARTURE_ID", "FlightKey");
            objbulk.ColumnMappings.Add("DC1", "IATADelayCode1");
            objbulk.ColumnMappings.Add("DT1", "UTCDateTime1");
            objbulk.ColumnMappings.Add("DC2", "IATADelayCode2");
            objbulk.ColumnMappings.Add("DT2", "UTCDateTime2");
            objbulk.ColumnMappings.Add("DC3", "IATADelayCode3");
            objbulk.ColumnMappings.Add("DT3", "UTCDateTime3");
            objbulk.ColumnMappings.Add("DC4", "IATADelayCode4");
            objbulk.ColumnMappings.Add("DT4", "UTCDateTime4");
            objbulk.ColumnMappings.Add("DC5", "IATADelayCode5");
            objbulk.ColumnMappings.Add("DT5", "UTCDateTime5");
            objbulk.ColumnMappings.Add("DC6", "IATADelayCode6");
            objbulk.ColumnMappings.Add("DT6", "UTCDateTime6");
            return objbulk;
        }

        private static SqlBulkCopy GetDepartureAirportMapping(string con)
        {
            //creating object of SqlBulkCopy      
            SqlBulkCopy objbulk = new SqlBulkCopy(con);
            //assigning Destination table name      
            objbulk.DestinationTableName = "departureairport";
            //Mapping Table column
            objbulk.ColumnMappings.Add("DEPARTURE_ID", "FlightKey");
            objbulk.ColumnMappings.Add("CAA", "CheckinAreaAlternative");
            objbulk.ColumnMappings.Add("CAM", "CheckinAreaMain");
            objbulk.ColumnMappings.Add("CIR", "CheckinRow");
            objbulk.ColumnMappings.Add("DRM", "DeicingRemark");
            objbulk.ColumnMappings.Add("GST", "GateStatus");
            objbulk.ColumnMappings.Add("GAT", "Gate");
            objbulk.ColumnMappings.Add("MID", "MaintenanceInformationDeparture");
            objbulk.ColumnMappings.Add("MSD", "MaintenanceStatusDeparture");
            objbulk.ColumnMappings.Add("RDL", "RemoteDeicingLane");
            objbulk.ColumnMappings.Add("RWY", "Runway");
            //objbulk.ColumnMappings.Add("SG2", "SecondStaffGate");
            // objbulk.ColumnMappings.Add("SGT", "StaffGate");
            objbulk.ColumnMappings.Add("TAR", "Tarmac");
            objbulk.ColumnMappings.Add("TER", "Terminal");
            objbulk.ColumnMappings.Add("TGP", "TarmacGroup");
            objbulk.ColumnMappings.Add("ZON", "Zone");
            objbulk.ColumnMappings.Add("DPE", "PlannedDeicingEndTime");
            objbulk.ColumnMappings.Add("PPF", "PlannedDeicingPadOffBlockTime");
            objbulk.ColumnMappings.Add("PPN", "PlannedDeicingPadOnBlockTime");
            objbulk.ColumnMappings.Add("APF", "ActualDeicingPadOffBlockTime");
            objbulk.ColumnMappings.Add("APN", "ActualDeicingPadOnBlockTime");
            objbulk.ColumnMappings.Add("DPS", "PlannedDeicingStartTime");
            return objbulk;
        }

        private static SqlBulkCopy GetDepartureBaggageMapping(string con)
        {
            //creating object of SqlBulkCopy      
            SqlBulkCopy objbulk = new SqlBulkCopy(con);
            //assigning Destination table name      
            objbulk.DestinationTableName = "departurebaggage";
            //Mapping Table column
            objbulk.ColumnMappings.Add("DEPARTURE_ID", "FlightKey");
            //objbulk.ColumnMappings.Add("BGT", "BagsGate");
            objbulk.ColumnMappings.Add("BID", "BaggageIdentification");
            //objbulk.ColumnMappings.Add("BLL", "BagsLocal");
            //objbulk.ColumnMappings.Add("BTL", "BagsTotal");
            //objbulk.ColumnMappings.Add("BTR", "BagsTransfer");
            return objbulk;

        }
        private static SqlBulkCopy GetDepartureLoadMapping(string con)
        {
            //creating object of SqlBulkCopy      
            SqlBulkCopy objbulk = new SqlBulkCopy(con);
            //assigning Destination table name      
            objbulk.DestinationTableName = "departureload";
            //Mapping Table column 
            objbulk.ColumnMappings.Add("DEPARTURE_ID", "FlightKey");
            objbulk.ColumnMappings.Add("CGO", "CargoLoad");
            objbulk.ColumnMappings.Add("DDL", "Deadload");
            objbulk.ColumnMappings.Add("LDI", "LoadInformation");
            // objbulk.ColumnMappings.Add("MLA", "MailLoad");
            objbulk.ColumnMappings.Add("ULC", "ULDCount");
            return objbulk;

        }
        private static SqlBulkCopy GetDepartureAircraftMapping(string con)
        {
            //creating object of SqlBulkCopy      
            SqlBulkCopy objbulk = new SqlBulkCopy(con);
            //assigning Destination table name      
            objbulk.DestinationTableName = "departureaircraft";
            //Mapping Table column 
            objbulk.ColumnMappings.Add("DEPARTURE_ID", "FlightKey");
            objbulk.ColumnMappings.Add("ACM", "AircraftFleetMembership");
            objbulk.ColumnMappings.Add("CSG", "CallSign");
            objbulk.ColumnMappings.Add("ICT", "ICAOType");
            objbulk.ColumnMappings.Add("LMF", "LastMinuteFuel");
            objbulk.ColumnMappings.Add("PSC", "PassengerSeatCapacity");
            objbulk.ColumnMappings.Add("REG", "Registration");
            objbulk.ColumnMappings.Add("RGA", "AbbreviatedRegistration");
            objbulk.ColumnMappings.Add("TOR", "TypeorRegistration");
            objbulk.ColumnMappings.Add("TYP", "Type");
            objbulk.ColumnMappings.Add("TYS", "Subtype");
            return objbulk;

        }

        private static SqlBulkCopy GetArrivalRouteMapping(string con)
        {
            //creating object of SqlBulkCopy      
            SqlBulkCopy objbulk = new SqlBulkCopy(con);
            //assigning Destination table name      
            objbulk.DestinationTableName = "arrivalroute";
            //Mapping Table column
            objbulk.ColumnMappings.Add("ARRIVAL_ID", "FlightKey");
            //objbulk.ColumnMappings.Add("ADP", "ActualDeparturePrevious");
            // objbulk.ColumnMappings.Add("EDP", "EsitmatedDeparturePrevious");
            // objbulk.ColumnMappings.Add("SDP", "ScheduleDeparturePrevious");
            // objbulk.ColumnMappings.Add("ADP1", "ActualDeparturePrevious1");
            //objbulk.ColumnMappings.Add("EDP1", "EsitmatedDeparturePrevious1");
            //objbulk.ColumnMappings.Add("SDP1", "ScheduleDeparturePrevious1");
            //objbulk.ColumnMappings.Add("ADP2", "ActualDeparturePrevious2");
            //objbulk.ColumnMappings.Add("EDP2", "EsitmatedDeparturePrevious2");
            // objbulk.ColumnMappings.Add("SDP2", "ScheduleDeparturePrevious2");
            //objbulk.ColumnMappings.Add("ADP3", "ActualDeparturePrevious3");
            // objbulk.ColumnMappings.Add("EDP3", "EsitmatedDeparturePrevious3");
            // objbulk.ColumnMappings.Add("SDP3", "ScheduleDeparturePrevious3");
            //objbulk.ColumnMappings.Add("ADP4", "ActualDeparturePrevious4");
            //objbulk.ColumnMappings.Add("EDP4", "EsitmatedDeparturePrevious4");
            //objbulk.ColumnMappings.Add("SDP4", "ScheduleDeparturePrevious4");
            return objbulk;
        }

        private static SqlBulkCopy GetArrivalPassengerMapping(string con)
        {
            //creating object of SqlBulkCopy      
            SqlBulkCopy objbulk = new SqlBulkCopy(con);
            //assigning Destination table name      
            objbulk.DestinationTableName = "arrivalpassenger";
            //Mapping Table column
            objbulk.ColumnMappings.Add("ARRIVAL_ID", "FlightKey");
            objbulk.ColumnMappings.Add("PAX", "Passengers");
            objbulk.ColumnMappings.Add("PXC", "ConnectingPassengers");
            objbulk.ColumnMappings.Add("PXL", "LocalPassengers");
            objbulk.ColumnMappings.Add("PXT", "TransferPassengers");

            return objbulk;
        }
        private static SqlBulkCopy GetArrivalLinkAndShareMapping(string con)
        {
            //creating object of SqlBulkCopy      
            SqlBulkCopy objbulk = new SqlBulkCopy(con);
            //assigning Destination table name      
            objbulk.DestinationTableName = "arrivalLinkAndShare";
            //Mapping Table column
            objbulk.ColumnMappings.Add("ARRIVAL_ID", "FlightKey");
            objbulk.ColumnMappings.Add("LKD", "LinkDay");
            objbulk.ColumnMappings.Add("LKF", "LinkFlightIdentity");
            objbulk.ColumnMappings.Add("LKR", "LinkFlightRepeatCount");
            //objbulk.ColumnMappings.Add("LKS", "LinkScheduledDate");
            objbulk.ColumnMappings.Add("MFF", "MasterFlightIdentity");
            return objbulk;
        }
        private static SqlBulkCopy GetArrivalHandlerMapping(string con)
        {
            //creating object of SqlBulkCopy      
            SqlBulkCopy objbulk = new SqlBulkCopy(con);
            //assigning Destination table name      
            objbulk.DestinationTableName = "arrivalhandler";
            //Mapping Table column
            objbulk.ColumnMappings.Add("ARRIVAL_ID", "FlightKey");
            objbulk.ColumnMappings.Add("HCA", "HandlerCatering");
            objbulk.ColumnMappings.Add("HCB", "HandlerCrewBus");
            objbulk.ColumnMappings.Add("HCG", "HandlerCargo");
            objbulk.ColumnMappings.Add("HCL", "HandlerCleaning");
            objbulk.ColumnMappings.Add("HDL", "HandlingAgent");
            objbulk.ColumnMappings.Add("HLF", "HandlerLostandFound");
            objbulk.ColumnMappings.Add("HMM", "HandlerMaintenance");
            objbulk.ColumnMappings.Add("HPU", "HandlerPushBack");
            objbulk.ColumnMappings.Add("HPX", "HandlerPassengers");
            objbulk.ColumnMappings.Add("HRA", "HandlerRamp");
            return objbulk;
        }
        private static SqlBulkCopy GetArrivalDelaysMapping(string con)
        {
            //creating object of SqlBulkCopy      
            SqlBulkCopy objbulk = new SqlBulkCopy(con);
            //assigning Destination table name      
            objbulk.DestinationTableName = "arrivaldelays";
            //Mapping Table column
            objbulk.ColumnMappings.Add("ARRIVAL_ID", "FlightKey");
            //objbulk.ColumnMappings.Add("DC1", "IATAdelayCode1");
            //objbulk.ColumnMappings.Add("DT1", "datetime1");
            //objbulk.ColumnMappings.Add("DC2", "IATAdelayCode2");
            //objbulk.ColumnMappings.Add("DC2", "IATAdelayCode2");
            //objbulk.ColumnMappings.Add("DC2", "IATAdelayCode2");
            //objbulk.ColumnMappings.Add("DC2", "IATAdelayCode2");
            //objbulk.ColumnMappings.Add("DC2", "IATAdelayCode2");
            //objbulk.ColumnMappings.Add("DC2", "IATAdelayCode2");
            //objbulk.ColumnMappings.Add("DC2", "IATAdelayCode2");
            //objbulk.ColumnMappings.Add("DC2", "IATAdelayCode2");
            //objbulk.ColumnMappings.Add("DC2", "IATAdelayCode2");
            //objbulk.ColumnMappings.Add("DC2", "IATAdelayCode2");
            //objbulk.ColumnMappings.Add("DC2", "IATAdelayCode2");
            //objbulk.ColumnMappings.Add("DC2", "IATAdelayCode2");
            //objbulk.ColumnMappings.Add("DC2", "IATAdelayCode2");
            //objbulk.ColumnMappings.Add("DC2", "IATAdelayCode2");
            //objbulk.ColumnMappings.Add("DC2", "IATAdelayCode2");
            //objbulk.ColumnMappings.Add("DC2", "IATAdelayCode2");
            //objbulk.ColumnMappings.Add("DC2", "IATAdelayCode2");
            //objbulk.ColumnMappings.Add("DC2", "IATAdelayCode2");
            //objbulk.ColumnMappings.Add("DC2", "IATAdelayCode2");
            //objbulk.ColumnMappings.Add("DC2", "IATAdelayCode2");
            //objbulk.ColumnMappings.Add("DT2", "datetime2");
            //objbulk.ColumnMappings.Add("DC3", "IATAdelayCode3");
            //objbulk.ColumnMappings.Add("DT3", "datetime3");
            //objbulk.ColumnMappings.Add("DC4", "IATAdelayCode4");
            //objbulk.ColumnMappings.Add("DT4", "datetime4");
            //objbulk.ColumnMappings.Add("DC5", "IATAdelayCode5");
            //objbulk.ColumnMappings.Add("DT5", "datetime5");
            //objbulk.ColumnMappings.Add("DC6", "IATAdelayCode6");
            //objbulk.ColumnMappings.Add("DT6", "datetime6");
            return objbulk;
        }

        private static SqlBulkCopy GetArrivalAirportMapping(string con)
        {
            //creating object of SqlBulkCopy      
            SqlBulkCopy objbulk = new SqlBulkCopy(con);
            //assigning Destination table name      
            objbulk.DestinationTableName = "arrivalairport";
            //Mapping Table column
            objbulk.ColumnMappings.Add("ARRIVAL_ID", "FlightKey");
            objbulk.ColumnMappings.Add("GAT", "Gate");
            //objbulk.ColumnMappings.Add("CAR", "Racetrack");
            objbulk.ColumnMappings.Add("RWY", "Runway");
            objbulk.ColumnMappings.Add("TAR", "Tarmac");
            objbulk.ColumnMappings.Add("TER", "Terminal");
            objbulk.ColumnMappings.Add("TGP", "TarmacGroup");
            objbulk.ColumnMappings.Add("ZON", "Zone");
            return objbulk;
        }

        private static SqlBulkCopy GetArrivalBaggageMapping(string con)
        {
            //creating object of SqlBulkCopy      
            SqlBulkCopy objbulk = new SqlBulkCopy(con);
            //assigning Destination table name      
            objbulk.DestinationTableName = "arrivalbaggage";
            //Mapping Table column
            objbulk.ColumnMappings.Add("ARRIVAL_ID", "FlightKey");
            //objbulk.ColumnMappings.Add("BGT", "BagsGate");
            objbulk.ColumnMappings.Add("BID", "BaggageIdentification");
            //objbulk.ColumnMappings.Add("BLL", "BagsLocal");
            //objbulk.ColumnMappings.Add("BTL", "BagsTotal");
            //objbulk.ColumnMappings.Add("BTR", "BagsTransfer");
            return objbulk;

        }
        private static SqlBulkCopy GetArrivalLoadMapping(string con)
        {
            //creating object of SqlBulkCopy      
            SqlBulkCopy objbulk = new SqlBulkCopy(con);
            //assigning Destination table name      
            objbulk.DestinationTableName = "arrivalload";
            //Mapping Table column 
            objbulk.ColumnMappings.Add("ARRIVAL_ID", "FlightKey");
            objbulk.ColumnMappings.Add("CGO", "CargoLoad");
            objbulk.ColumnMappings.Add("DDL", "Deadload");
            objbulk.ColumnMappings.Add("LDI", "LoadInformation");
            //objbulk.ColumnMappings.Add("MLA", "MailLoad");
            //objbulk.ColumnMappings.Add("ULC", "ULDCount");
            return objbulk;

        }
        private static SqlBulkCopy GetArrivalAircraftMapping(string con)
        {
            //creating object of SqlBulkCopy      
            SqlBulkCopy objbulk = new SqlBulkCopy(con);
            //assigning Destination table name      
            objbulk.DestinationTableName = "arrivalaircraft";
            //Mapping Table column 
            objbulk.ColumnMappings.Add("ARRIVAL_ID", "FlightKey");
            objbulk.ColumnMappings.Add("ACM", "AircraftFleetmembership");
            objbulk.ColumnMappings.Add("PSC", "PassengerSeatCapacity");
            objbulk.ColumnMappings.Add("REG", "Registration");
            objbulk.ColumnMappings.Add("RGA", "AbbreviatedRegistration");
            objbulk.ColumnMappings.Add("TOR", "TypeorRegistration");
            objbulk.ColumnMappings.Add("TYP", "Type");
            objbulk.ColumnMappings.Add("TYS", "Subtype");
            return objbulk;


        }
    }
}
