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

    public async Task<IActionResult> OnPostAsync(IFormFile file, string email, string? userName, string? notes)
    {
        if (file == null || file.Length == 0)
        {
            ModelState.AddModelError("file", "Please select a file.");
            return Page();
        }

        if (string.IsNullOrEmpty(email))
        {
            ModelState.AddModelError("email", "Please provide an email address.");
            return Page();
        }

        if (string.IsNullOrEmpty(userName))
        {
            ModelState.AddModelError("userName", "Please provide a user name.");
            return Page();
        }
 
        #pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
        string connectionString = _configuration.GetConnectionString("DocumentVaultConnection");
        #pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

        if (string.IsNullOrEmpty(connectionString))
        {
            ModelState.AddModelError("file", "Connection string is missing or empty.");
            return Page();
        }      

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
        
        // Set email as metadata
        var metadata = new Dictionary<string, string>
        {
            { "SendToEmail", email },
            { "userName", userName },
            { "UploadedOn", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") },
        };

        // Add notes to metadata if provided
        if (!string.IsNullOrEmpty(notes))
        {
            metadata.Add("Notes", notes);
        }

        await blobClient.SetMetadataAsync(metadata);
        
        return RedirectToPage("/FileSharingApp");
    }
}









































































































