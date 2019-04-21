using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Oracle.DataAccess.Client;

namespace FreeLinkOracle
{
    class Department
    {
        public string Code { get; set; }

        public string Vati { get; set; }

        public string Kurz { get; set; }

        public string Name { get; set; }

        //.....................................................................
        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader"></param>
        public void Read( OracleDataReader reader )
        {
            RowLine line = new RowLine( );
            line.Read( reader );

            this.Code = line.GetByName( "DEPT_CODE" );
            this.Vati = line.GetByName( "VATI_CODE" );
            this.Kurz = line.GetByName( "KURZ_CODE" );
            this.Name = line.GetByName( "DEPT_NAME" );

            return;
        }

        //.....................................................................
    }
}
