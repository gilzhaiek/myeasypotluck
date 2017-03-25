using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Text;
using System.Security.Cryptography;

/// <summary>
/// Summary description for GoogleMapsWebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class GoogleMapsWebService : System.Web.Services.WebService
{
	// http://maps.google.com/maps/geo?q=1600+Amphitheatre+Parkway,+Mountain+View,+CA&output=json&oe=utf8\&sensor=false&key=ABQIAAAAvKghNFPqsONC3g67U5mZJRTUvIj97xt9BBSxDLobPwItczcCghRMD2ySd6sqh0dLJwAfBo2_FzHytA
	public GoogleMapsWebService()
	{

		//Uncomment the following line if using designed components 
		//InitializeComponent(); 
	}

	public static string Sign(string url, string keyString)
	{
		ASCIIEncoding encoding = new ASCIIEncoding();

		// converting key to bytes will throw an exception, need to replace '-' and '_' characters first.
		string usablePrivateKey = keyString.Replace("-", "+").Replace("_", "/");
		byte[] privateKeyBytes = Convert.FromBase64String(usablePrivateKey);

		Uri uri = new Uri(url);
		byte[] encodedPathAndQueryBytes = encoding.GetBytes(uri.LocalPath + uri.Query);

		// compute the hash
		HMACSHA1 algorithm = new HMACSHA1(privateKeyBytes);
		byte[] hash = algorithm.ComputeHash(encodedPathAndQueryBytes);

		// convert the bytes to string and make url-safe by replacing '+' and '/' characters
		string signature = Convert.ToBase64String(hash).Replace("+", "-").Replace("/", "_");

		// Add the signature to the existing URI.
		return uri.Scheme+"://"+uri.Host+uri.LocalPath + uri.Query +"&signature=" + signature;
	}


	[WebMethod]
	public string HelloWorld()
	{
		return "Hello World";
	}

}

