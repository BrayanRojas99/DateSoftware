using System;
using System.Collections.Generic;
using System.Text;

namespace DateSoftware
{
    public static class CnnToAPI
    {
        //en esta clase vamos a almacenar informacion general de la configuracion para consumir la api
        //como por ejemplo el api key y la direccion http del api

        //vamos a crear dos rutas una usada para produccion y otra para pruebas, esto en ambito laboral

        #region Routes

        public static string ProductionRoute = "http://192.168.1.7:45455/api";

        public static string TestingRoute = "http://192.168.1.7:45455/api";

        #endregion

        //todo: agregar la funcionalidad del JWT

        //valores de api key

        #region apikey

        public static string ApikeyName = "ApiKey";
        public static string ApiKeyValue = "123456";


        #endregion

        #region Usuario global
        public static DateSoftware.Models.User GlobalUser = new DateSoftware.Models.User();
        #endregion

    }
}
