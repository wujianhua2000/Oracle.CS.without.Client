using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;

using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace FreeLinkOracle
{
    /// <summary>
    /// 
    /// </summary>
    class HansOracle
    {
        /// <summary>
        /// 
        /// </summary>
        public string Message;

        //.....................................................................
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private string MakeString( string hostIP, string svName, string user, string pass )
        {
            StringBuilder buffer = new StringBuilder( );

            buffer.Append( "        Data Source=                        ".Trim( ) )
                  .Append( "            (DESCRIPTION =                  ".Trim( ) )
                  .Append( "                (ADDRESS_LIST =             ".Trim( ) )
                  .Append( "                    (ADDRESS =              ".Trim( ) )
                  .Append( "                        (PROTOCOL = TCP)    ".Trim( ) )
                  .AppendFormat( "                  (HOST = {0})        ".Trim( ), hostIP )
                  .Append( "                        (PORT = 1521))      ".Trim( ) )
                  .Append( "                    )                       ".Trim( ) )
                  .Append( "                (CONNECT_DATA =             ".Trim( ) )
                  .AppendFormat( "              (SID = {0})             ".Trim( ), svName )
                  .Append( "                    (SERVER = DEDICATED)    ".Trim( ) )
                  .Append( "                )                           ".Trim( ) )
                  .Append( "            );                              ".Trim( ) )
                  .AppendFormat( "  Password={0};                       ".Trim( ), pass )
                  .AppendFormat( "  User ID={0};                        ".Trim( ), user );

            return buffer.ToString( );
        }

        //.....................................................................
        /// <summary>
        /// 
        /// </summary>
        public void Test( )
        {
            string connSTR = LinkWasserWelt( );

            Console.WriteLine( connSTR );

            try
            {
                OracleConnection conn = new OracleConnection( );
                conn.ConnectionString = connSTR;
                conn.Open( );

                Console.WriteLine( "open is ok." );

                OracleCommand select = new OracleCommand( );
                select.CommandText = "select * from cgn_department";
                select.Connection = conn;
                OracleDataReader reader = select.ExecuteReader( );

                while ( reader.Read( ) )
                {
                    Console.Write( reader.GetString( 0 ) + ";" );
                    Console.Write( reader.GetString( 2 ) + ";" );
                    Console.Write( " NAME = " + reader.GetName( 3 ) );
                    Console.WriteLine( );
                }

                conn.Close( );
                reader.Dispose( );
                select.Dispose( );
                conn.Dispose( );

                this.Message = "Alles in Ordnung!!!";
            }
            catch ( Exception ex )
            {
                this.Message = ex.Message;
            }

            return;
        }

        //.....................................................................
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private string LinkWasserWelt( )
        {
            string hostIP = "10.78.23.141";
            string servID = "cwcsn";
            string userNM = "wasser";
            string passWD = "king";

            string hostName = Environment.MachineName;

            bool isASUS = hostName.Contains( "ASUS" );
            if ( isASUS ) hostIP = "localhost";
            if ( isASUS ) servID = "CSNIS";
            if ( isASUS ) servID = "XE";

            Console.WriteLine( hostIP );

            return this.MakeString( hostIP, servID, userNM, passWD );
        }

        //.....................................................................
        /// <summary>
        /// 
        /// </summary>
        public List<Department> SelectBasic( )
        {
            List<Department> listing = new List<Department>( );

            string connSTR = LinkWasserWelt( );

            Console.WriteLine( connSTR );

            try
            {
                OracleConnection conn = new OracleConnection( );
                conn.ConnectionString = connSTR;
                conn.Open( );

                Console.WriteLine( "open is ok." );

                OracleCommand select = new OracleCommand( );
                select.CommandText = "select * from cgn_department";
                select.Connection = conn;
                OracleDataReader reader = select.ExecuteReader( );

                while ( reader.Read( ) )
                {
                    Department dept = new Department( );
                    dept.Read( reader );

                    listing.Add( dept );
                }

                conn.Close( );
                reader.Dispose( );
                select.Dispose( );
                conn.Dispose( );
            }
            catch ( Exception ex )
            {
                this.Message = ex.Message;
            }

            return listing;
        }

        //.....................................................................
        /// <summary>
        /// 
        /// </summary>
        public List<Schedule> SelectSchedule( )
        {
            List<Schedule> listing = new List<Schedule>( );

            string connSTR = this.LinkWasserWelt( );
            this.Message = string.Empty;

            try
            {
                OracleConnection conn = new OracleConnection( );
                conn.ConnectionString = connSTR;
                conn.Open( );

                Console.WriteLine( "open is ok." );

                OracleCommand select = new OracleCommand( );
                select.CommandText = "select * from vv_schedule_tree";
                select.Connection = conn;
                OracleDataReader reader = select.ExecuteReader( );

                while ( reader.Read( ) )
                {
                    Schedule plan = new Schedule( );
                    plan.Read( reader );

                    listing.Add( plan );
                }

                conn.Close( );
                reader.Dispose( );
                select.Dispose( );
                conn.Dispose( );
            }
            catch ( Exception ex )
            {
                this.Message = ex.Message;
            }

            return listing;
        }

        //.....................................................................
        /// <summary>
        /// 
        /// </summary>
        public List<Schedule> SelectSchedule( int vatiID )
        {
            List<Schedule> listing = new List<Schedule>( );

            string connSTR = this.LinkWasserWelt( );
            this.Message = string.Empty;

            try
            {
                OracleConnection conn = new OracleConnection( );
                conn.ConnectionString = connSTR;
                conn.Open( );

                Console.WriteLine( "open is ok." );

                OracleCommand select = new OracleCommand( );
                select.CommandType = CommandType.StoredProcedure;
                select.CommandText = "SQL_HL1K_SCHEDULE.SelectByVatiID";
                select.Connection = conn;

                OracleParameter pmVatiID = select.Parameters.Add( "vatiID", OracleDbType.Int32 );
                OracleParameter pmListPL = select.Parameters.Add( "listPL", OracleDbType.RefCursor );
                
                pmVatiID.Direction = ParameterDirection.Input;
                pmListPL.Direction = ParameterDirection.Output;

                pmVatiID.Value = vatiID.ToString( );
                select.ExecuteNonQuery( );

                OracleDataReader reader = ( ( OracleRefCursor ) pmListPL.Value ).GetDataReader( );

                while ( reader.Read( ) )
                {
                    Schedule plan = new Schedule( );
                    plan.Read( reader );

                    listing.Add( plan );
                }

                conn.Close( );
                reader.Dispose( );
                select.Dispose( );
                conn.Dispose( );
            }
            catch ( Exception ex )
            {
                this.Message = ex.Message;
            }

            return listing;
        }

        //.....................................................................
    }
}
