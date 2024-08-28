using MultiShopProject.Dto.CatalogDtos.ProductDetailDtos;

namespace MultiShopProject.WebUI.Services.CatalogServices.ProductDetailServices
{
    public class ProductDetailService : IProductDetailService
    {
        private readonly HttpClient _httpClient;

        public ProductDetailService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateProductDetailAsync(CreateProductDetailDto createProductDetailDto)
        {
            await _httpClient.PostAsJsonAsync<CreateProductDetailDto>("productdetails", createProductDetailDto);
        }

        public async Task DeleteProductDetailAsync(string id)
        {
            await _httpClient.DeleteAsync("productdetails?id=" + id);
        }

        //public async Task<List<ResultProductDetailDto>> GetAllProductDetailAsync()
        //{
        //    #region Old Method
        //    //var responseMessage = await _httpClient.GetAsync("categories");
        //    //var jsonData = await responseMessage.Content.ReadAsStringAsync();
        //    //var values = JsonConvert.DeserializeObject<List<ResultProductDetailDto>>(jsonData);
        //    //return values;
        //    #endregion

        //    var responseMessage = await _httpClient.GetAsync("categories");
        //    var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultProductDetailDto>>();
        //    return values;
        //}

        public async Task<List<ResultProductDetailDto>> GetAllProductDetailAsync()
        {
            var responseMessage = await _httpClient.GetAsync("productdetails");
            var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultProductDetailDto>>();
            return values;
        }

        public async Task<GetByIdProductDetailDto> GetByIdProductDetailAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("productdetails/" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<GetByIdProductDetailDto>();
            return values;
        }

        public async Task<GetByIdProductDetailDto> GetByProductIdProductDetailAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("productdetails/GetProductDetailByProductId/" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<GetByIdProductDetailDto>();
            return values;
        }

        public async Task UpdateProductDetailAsync(UpdateProductDetailDto updateProductDetailDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateProductDetailDto>("productdetails", updateProductDetailDto);
        }
    }
}
