﻿using Paulino.Motorbike.Infra.Data.Dapper.Base;

namespace Paulino.Motorbike.Infra.Data.Dapper.Queries
{
    public class GetCNHTypeByDriverIdDapperQuery(int driverId) : IDapperQuery
    {
        public int DriverId { get; } = driverId;

        public string Query => @"select ct.name from driver d
                                inner join cnh c on c.Id = d.cnh_id
                                inner join cnh_type ct on ct.id = c.cnh_type_id
                                where d.id = @DriverId";

        public object Params => new { DriverId };
    }
}
