using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class MockExamController : ControllerBase
{
    // Upload interface
    [HttpPost("upload")]
    public IActionResult UploadMaterials(IFormFile[] files)
    {
        // deal with the logic
        foreach (var file in files)
        {
            if (file.Length > 0)
            {
                var filePath = Path.Combine("uploads", file.FileName);  // save path
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }
        }
        return Ok(new { message = "Upload success" });
    }

    // interface
    [HttpPost("generate-questions")]
    public async Task<IActionResult> GenerateQuestions([FromBody] GenerateQuestionRequest request)
    {
        // use chatgpt to generate questions
        var questions = await GenerateMockQuestions(request);
        return Ok(questions);
    }

    private Task<string[]> GenerateMockQuestions(GenerateQuestionRequest request)
    {
        // mock logic
        var questions = new string[] { "Q1", "Q2", "Q3" }; // mock data
        return Task.FromResult(questions);
    }
}

// request model
public class GenerateQuestionRequest
{
    public string? MaterialId { get; set; }  
    public int QuestionCount { get; set; }
    public string? QuestionType { get; set; }  
}

