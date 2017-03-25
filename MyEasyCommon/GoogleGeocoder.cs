using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Net;

namespace MyEasy.Common
{
	public interface ISpatialCoordinate
	{
		decimal Latitude { get; set; }
		decimal Longitude { get; set; }
	}

	/// <summary>
	/// Coordiate structure. Holds Latitude and Longitude.
	/// </summary>
	public struct Coordinate : ISpatialCoordinate
	{
		private decimal mLatitude;
		private decimal mLongitude;

		public Coordinate(decimal latitude, decimal longitude)
		{
			mLatitude = latitude;
			mLongitude = longitude;
		}

		#region ISpatialCoordinate Members

		public decimal Latitude
		{
			get { return mLatitude; }
			set { this.mLatitude = value;}
		}

		public decimal Longitude
		{	
			get { return mLongitude; }
			set { this.mLongitude = value;}
		}

		#endregion
	}

	public class Geocode
	{
		private const string mGoogleUri = "http://maps.google.com/maps/geo?q=";
		private const string mGoogleKey = "yourkey";  // Sign up for the goolge Maps API: http://code.google.com/apis/maps/signup.html
		private const string mOutputType = "csv"; // Available options: csv, xml, kml, json

		private static Uri GetGeocodeUri(string address)
		{
			address = HttpUtility.UrlEncode(address);
			return new Uri(String.Format("{0}{1}&output={2}&key={3}", mGoogleUri, address, mOutputType, mGoogleKey));
		}

		/// <summary>
		/// Gets a Coordinate from a address.
		/// </summary>
		/// <param name="address">An address.
		/// <remarks>
		/// <example>1600 Amphitheatre Parkway Mountain View, CA 94043</example>
		/// </remarks>
		/// </param>
		/// <returns>A spatial coordinate that contains the latitude and longitude of the address.</returns>
		public static Coordinate GetCoordinates(string address)
		{
			WebClient client = new WebClient();
			Uri uri = GetGeocodeUri(address);


			/* The first number is the status code, 
			* the second is the accuracy, 
			* the third is the latitude, 
			* the fourth one is the longitude.
			*/
			string[] geocodeInfo = client.DownloadString(uri).Split(',');

			return new Coordinate(Convert.ToDecimal(geocodeInfo[2]), Convert.ToDecimal(geocodeInfo[3]));
		}
	}

}
