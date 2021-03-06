﻿using mRemoteNG.Config.DatabaseConnectors;
using mRemoteNG.Config.DataProviders;
using mRemoteNG.Config.Serializers;
using mRemoteNG.Config.Serializers.Versioning;
using mRemoteNG.Tree;

namespace mRemoteNG.Config.Connections
{
    public class SqlConnectionsLoader
    {
        public ConnectionTreeModel Load()
        {
            var connector = new SqlDatabaseConnector();
            var dataProvider = new SqlDataProvider(connector);
            var databaseVersionVerifier = new SqlDatabaseVersionVerifier(connector);
            databaseVersionVerifier.VerifyDatabaseVersion();
            var dataTable = dataProvider.Load();
            var deserializer = new DataTableDeserializer();
            return deserializer.Deserialize(dataTable);
        }
    }
}