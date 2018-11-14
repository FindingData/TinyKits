using Microsoft.VisualStudio.TestTools.UnitTesting;
using FD.Tiny.FormBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FD.Tiny.FormBuilder.Tests
{
    [TestClass()]
    public class SingleSqlParserFactoryTests
    {
        [TestMethod()]
        public void GenerateParserTest()
        {
            var sql = @"select c.construction_code, c.construction_name, c.pca_code from redas.v_construction c where rownum < 10;";
            SqlParserUtil sqlParser = new SqlParserUtil();
            Console.WriteLine(sqlParser.GetParsedSql(sql));
            Console.WriteLine("---------------");
            sqlParser.GetParsedSqlSegmentList(sql).ForEach(f =>
            {
                Console.Write(f.GetParsedSqlSegment());
            });
            
        }
    }
}