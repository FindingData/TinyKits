using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FD.Tiny.ProjectBuilder
{
    public class OracleDbSchemaProvider : DbSchemaProvider
    {
        protected override string GetTableInfoListSql
        {
            get
            {
                return @"SELECT t.table_name ""NAME"", c.comments ""COMMENT""
                      from user_tables t
                     inner
                      join user_tab_comments c
                    on t.TABLE_NAME = c.table_name
                     where t.table_name != 'HELP'
                       AND t.table_name NOT LIKE '%$%'
                       AND t.table_name NOT LIKE 'LOGMNRC_%'
                       AND t.table_name != 'LOGMNRP_CTAS_PART_MAP'
                       AND t.table_name != 'LOGMNR_LOGMNR_BUILDLOG'
                       AND t.table_name != 'SQLPLUS_PRODUCT_PROFILE'";
            }
        }

        protected override string GetColumnInfosByTableNameSql
        {
            get
            {
                return @" select c.COLUMN_NAME ""NAME"",
                    cc.comments ""COMMENT"",
                    c.DATA_TYPE,
                    c.DATA_LENGTH ""LENGTH"",
                    c.DATA_PRECISION ""PRECISION"",
                    c.DATA_SCALE SCALE,
                    (case
                    when exists(select 1
                            from user_cons_columns ucc
                            inner
                            join user_constraints cst
                            on ucc.constraint_name = cst.constraint_name
                            where ucc.table_name = c.TABLE_NAME
                                and ucc.column_name = c.COLUMN_NAME
                                and cst.constraint_type = 'P') then
                        1
                    else
                        0
                    end) as IS_PRIMARY,
                    (case c.NULLABLE when
                     'Y' then 1
                     else 0 end) as IS_NULLABLE,
                    c.DATA_DEFAULT DEFAULT_VALUE
                from user_tab_columns c
            inner
                join user_col_comments cc
                on cc.table_name = c.TABLE_NAME
                and cc.column_name = c.COLUMN_NAME
                where c.table_name = '{0}'";
            }
        }
    }
}
