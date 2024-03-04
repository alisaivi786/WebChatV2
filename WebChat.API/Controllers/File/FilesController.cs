using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebChat.Common.FileType;

namespace WebChat.API.Controllers.File;

[ApiVersion("1")]
[Route("api/v{version:apiVersion}/File")]
public class FilesController : BaseAuthController
{
    #region UploadFile
    [MapToApiVersion(1)]
    [HttpPost("UploadFile")]
    [SwaggerResponse((int)ApiCodeEnum.Success, "Back parameter comments", typeof(ApiResponse<bool>))]
    public async Task<IActionResult> UploadFile(IFormFile file, int? FileCode)
    {
        if (FileCode == 0 || FileCode == null)
        {
            return BadRequest(new { Errno = 1, Message = "File Code Required." });
        }
        if (file == null || file.Length == 0)
        {
            return BadRequest(new { Errno = 1, Message = "No file uploaded." });
        }

        try
        {
            // Get the file extension
            var fileExtension = Path.GetExtension(file.FileName);

            // Check if the file extension is valid (optional)
            if (string.IsNullOrEmpty(fileExtension))
            {
                
                return BadRequest(new { Errno = 1, Message = "Invalid file extension." });
            }
            // check if .exe return badrequest
            if (fileExtension == ".exe")
            {
                return BadRequest(new { Errno = 1, Message = "bad file extension." });
            }

            // Root folder for files
            var fileRootFolder = Path.Combine(Environment.WebRootPath, "Files");

            // Determine subfolder based on the file extension
            string subFolder = fileExtension switch
            {
                ".jpeg" or ".jpg" or ".png" => "UploadImages",
                ".xls" or ".xlsx" or ".csv" => "ExcelFiles",
                ".doc" or ".docx" => "DocumentFiles",
                ".json"  => "JsonFiles",
                ".pdf"  => "PdfFiles",
                _ => "GeneralFiles",
            };

            // Full path to the file
            var uniqueFileName = Guid.NewGuid().ToString() + fileExtension;
            var filePath = Path.Combine(fileRootFolder, subFolder, uniqueFileName);

            // Create subfolder if it doesn't exist
            Directory.CreateDirectory(Path.GetDirectoryName(filePath));

            // Save the file
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            // File URL
            var fileUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}/Files/{subFolder}/{uniqueFileName}";

            var result = new
            {
                Errno = 0,
                Data = new
                {
                    Url = fileUrl,
                    Alt = file.FileName.Replace(" ", "_"),
                    Href = ""
                }
            };

            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Errno = 1, Message = ex.Message });
        }
    }

    #endregion

    [HttpGet("List")]
    public IActionResult GetFileList()
    {
        try
        {
            var fileTypes = Enum.GetValues(typeof(FileTypeEnum)).Cast<FileTypeEnum>();

            var fileList = fileTypes.Select(type => new
            {
                FileType = type.ToString(),
                FileCode = (int)type
            }).ToList();

            return Ok(fileList);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Errno = 1, Message = ex.Message });
        }
    }
}
