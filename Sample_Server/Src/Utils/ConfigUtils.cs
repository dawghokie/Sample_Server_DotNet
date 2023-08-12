using System.Configuration;

namespace Sample_Server.Src.Utils
{
	public static class ConfigUtils
	{
        private static string PROVIDER_NAME = "PostgreSQL";

        // Retrieving a connection string by provider name
        //  From MS Docs
        public static string GetConnectionString()
        {
            // Return null on failure.
            string returnValue = null;

            // Get the collection of connection strings.
            ConnectionStringSettingsCollection settings =
                System.Configuration.ConfigurationManager.ConnectionStrings;

            // Walk through the collection and return the first
            // connection string matching the providerName.
            if (settings != null)
            {
                foreach (ConnectionStringSettings cs in settings)
                {
                    if (cs.ProviderName == PROVIDER_NAME)
                        returnValue = cs.ConnectionString;
                    break;
                }
            }
            return returnValue;
        }
    }
}

