using Dapper;
using Demo.Common;
using Demo.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Repository
{
    public class DemoRepository:IDemoRepository
    {
        private readonly IAppSetting _appSetting;
        public DemoRepository(IAppSetting appSetting)
        {
            _appSetting = appSetting;
        }
        public bool DemoCrud(int id)
        {
            using (var cnn = new SqlConnection(_appSetting.DataContext))
            {
                var sql = @"
                    INSERT INTO dbo.Product 
                    ( Name, Price,CreateDate ) 
                    VALUES 
                    ( @Name, @Price ,@CreateDate);
                    SELECT SCOPE_IDENTITY();
                ";
                var product = new Product
                {
                    Name = "Jack",
                    Price = 330,
                    CreateDate = DateTime.Now
                };
                cnn.Open();
                var Id1 = cnn.Query<long>(sql, product).First();
                var Id2 = cnn.QueryFirst<long>(sql, product);
                var Id3 = cnn.QueryFirstOrDefault<long>(sql, product);
                var Id4 = cnn.QuerySingle<long>(sql, product);
                var Id5 = cnn.QuerySingleOrDefault<long>(sql, product);

                sql = @"
                    UPDATE  Product 
                    SET     Name = @Data
                    WHERE   Id = @Id
                ";

                var updateRow = cnn.Execute(sql, new {Id=1, Data = "ABC" });

                sql = @"
                    SELECT  COUNT(*) 
                    FROM    Product;
                    SELECT  Id, Name, Price, CreateDate
                    FROM    Product
                    WHERE   Id = @Id
                ";
                var p = new DynamicParameters();
                p.Add("@Id", 1);

                var gridReader = cnn.QueryMultiple(sql, p);
                var totalCount1 = gridReader.ReadSingle<int>();
                var result1 = gridReader.ReadSingleOrDefault<Product>();
                gridReader.Dispose();

                sql = @"
                    DELETE FROM Product 
                    WHERE   Id > @Id
                ";

                var deleteRow = cnn.Execute(sql, new { Id = 10 });

                sql = @"
                    SELECT  Id, Name, Price, CreateDate
                    FROM    Product
                ";
                var list = cnn.Query<Product>(sql);
                var notNull = list.Count() == 0;
            }
            return false;
        }
    }
}
