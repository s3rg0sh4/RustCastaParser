using System.Net;
using System.Net.Http;
//using System.Web.Mvc;

public class HttpController
{
	private static readonly HttpClient client = new HttpClient();
	public static async Task<string> PostQuery(string query)
	{
		var content	= new FormUrlEncodedContent(new Dictionary<string, string>
			{
				{ "promo", query }
			}
		);
		var response = await client.PostAsync("http://localhost:5374/promo/post", content);
		
		return await response.Content.ReadAsStringAsync();
	}
}