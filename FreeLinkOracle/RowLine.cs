using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Oracle.DataAccess.Client;

namespace FreeLinkOracle
{
    class RowLine
    {
        //.....................................................................
        /// <summary>
        /// 
        /// </summary>
        private Dictionary<string, string> ListData = new Dictionary<string, string>( );

        /// <summary>
        /// 字段的名称，为了和上面的数据对应，方便后面使用序号查找。
        /// </summary>
        private List<string> ListName = new List<string>( );

        //.....................................................................
        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader"></param>
        public void Read( OracleDataReader reader )
        {
            try
            {

                for ( int idx = 0; idx < reader.FieldCount; idx++ )
                {
                    bool isNULL = reader.IsDBNull( idx );

                    string name = reader.GetName( idx );

                    string valu = ( isNULL ) ? string.Empty
                                             : reader.GetValue( idx ).ToString();

                    //Console.WriteLine( name + " = " + valu.ToString( ) );

                    this.ListData.Add( name, valu );
                    this.ListName.Add( name );
                }
            }
            catch ( Exception ex )
            {
                Console.WriteLine( ex.Message );
            }

            return;
        }

        //.....................................................................
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public string GetByName( string name )
        {
            bool hasKey = ( this.ListData.Keys.Contains( name.ToUpper( ) ) );

            if ( hasKey ) return this.ListData[ name.ToUpper( ) ];

            return string.Empty;
        }

        //.....................................................................
    }
}
