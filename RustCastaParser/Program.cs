var vkApi = new VkNet.VkApi();
vkApi.Authorize(new VkNet.Model.ApiAuthParams()
{
	AccessToken = "752f15f9752f15f9752f15f93f763f58037752f752f15f917d95457bc2ab7f53168d7de"
});

var castaWall = vkApi.Wall.Search(new VkNet.Model.RequestParams.WallSearchParams()
{
	Domain = "rust_casta",
	Query = "ПРОМОКОД",
	Count = 1
});

#pragma warning disable CS8602
var promo = new List<string>(from p in castaWall.WallPosts
								  where p.Text.Contains("ПРОМОКОД")
								  select (new List<string>(p.Text.Split("\n")).Find(s => s.Contains("ПРОМОКОД"))).Split(" ")[4]).FirstOrDefault();
#pragma warning restore CS8602

Console.WriteLine(promo);