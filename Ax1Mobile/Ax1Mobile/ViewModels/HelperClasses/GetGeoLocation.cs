using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Xml.Linq;

namespace Ax1Mobile.ViewModels.HelperClasses
{
    /// <summary>
    /// Gets Geo Location.
    /// </summary>
    public static class GetGeoLocation
    {
        /// <summary>
        /// Uses Google API to return the Geo Location based on the address. 
        /// </summary>
        /// <param name="addrs"></param>
        /// <returns></returns>
        public static Tuple<string, string, bool, int> GetLocatoinServices(string addrs)
        {
            string address = addrs;
            string requestUri = string.Format("http://maps.googleapis.com/maps/api/geocode/xml?address={0}&sensor=false", Uri.EscapeDataString(address));

            WebRequest request = WebRequest.Create(requestUri);
            WebResponse response = request.GetResponse();
            XDocument xdoc = XDocument.Load(response.GetResponseStream());

            XElement result = xdoc.Element("GeocodeResponse").Element("result");
            if (result != null)
            {
                XElement locationElement = result.Element("geometry").Element("location");
                XElement lat = locationElement.Element("lat");
                XElement lng = locationElement.Element("lng");
                string latitude = lat.ToString().Substring(5);
                latitude = latitude.Substring(0, latitude.Length - 6);
                string longitude = lng.ToString().Substring(5);
                longitude = longitude.Substring(0, longitude.Length - 6);
                bool valid = true;
                int zoom = 5;

                Tuple<string, string, bool, int> GeoLocation = new Tuple<string, string, bool, int>(latitude, longitude, valid, zoom);
                return GeoLocation;
            }
            else
            {
                string latitude = "39.757";
                string longitude = "-101.381";
                int zoom = 4;
                bool valid = false;

                Tuple<string, string, bool, int> GeoLocation = new Tuple<string, string, bool, int>(latitude, longitude, valid, zoom);
                return GeoLocation;
            }

        }
    }
}
