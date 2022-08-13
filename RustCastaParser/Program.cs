const string domain = "rust_casta";
const string query = "ПРОМОКОД";
const string token = "token";

var vkApi = new VkNet.VkApi();
vkApi.Authorize(new VkNet.Model.ApiAuthParams()
{
	AccessToken = token
});

var castaWall = vkApi.Wall.Search(new VkNet.Model.RequestParams.WallSearchParams()
{
	Domain = domain,
	Query = query,
	Count = 1
});


static string promoString(List<string> l)
{
	string? str = l.Find(s => s.Contains(query)); //Поиск строки с промокодом
	return string.IsNullOrEmpty(str) ? "" : str;
}

var promo = new List<string>(from p in castaWall.WallPosts
							  where p.Text.Contains(query) && 
							  (DateTime.Now - p.Date) <= new TimeSpan(1, 0, 0, 0) //Отбор постов по наличию слова запроса и по дате
							  select promoString(new List<string>(p.Text.Split("\n")))
							  .Split(" ")[4]).FirstOrDefault(); //Выбор последнего слова с промокодом

if (string.IsNullOrEmpty(promo))
	return;
Console.WriteLine(HttpController.PostQuery(promo));