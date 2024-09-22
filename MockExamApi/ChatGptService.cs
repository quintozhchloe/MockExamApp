public class ChatGptService
{
    private readonly HttpClient _httpClient;

    public ChatGptService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<string> GenerateQuestion(string prompt)
    {
        // 发送API请求并获取ChatGPT返回的内容
        var response = await _httpClient.PostAsync("https://api.openai.com/v1/completions", new StringContent(prompt));
        return await response.Content.ReadAsStringAsync();
    }
}
