using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Threading.Tasks;

public class FileSharingAppModel : PageModel
{
    private readonly IConfiguration _configuration;

    public FileSharingAppModel(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task<IActionResult> OnPostAsync(IFormFile file)
    {
        if (file == null || file.Length == 0)
        {
            ModelState.AddModelError("file", "Please select a file.");
            return Page();
        }

        string connectionString = "DefaultEndpointsProtocol=https;AccountName=documentvaultbtcloud;AccountKey=VSae++lFkREzSvSty07SJZA+wQ3ExhWy7e83yZgr1v9TN+k9xmEKB+v5HUfoNr2rpAokyVc8AlCS+AStz41dzQ==;EndpointSuffix=core.windows.net";
        BlobServiceClient blobServiceClient = new BlobServiceClient(connectionString);
        
        string containerName = "uploadeddocuments";
        BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(containerName);

        await containerClient.CreateIfNotExistsAsync();
        string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
        BlobClient blobClient = containerClient.GetBlobClient(fileName);

        using (var stream = file.OpenReadStream())
        {
            await blobClient.UploadAsync(stream, true);
        }
        
        return RedirectToPage("/FileSharingApp");
    }
}









































































































