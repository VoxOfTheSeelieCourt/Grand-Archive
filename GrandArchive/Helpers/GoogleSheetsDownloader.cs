using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GrandArchive.Helpers;

public static class GoogleSheetsDownloader
{
    /// <summary>
    /// Downloads a Google Sheet as XLSX without using Google APIs.
    /// The sheet must be accessible to "Anyone with the link" or published.
    /// </summary>
    /// <param name="shareUrlOrId">Either the full sharing URL or just the spreadsheet ID.</param>
    /// <param name="outputPath">Where to write the .xlsx file.</param>
    /// <param name="gid">
    /// Optional: a specific sheet/tab gid (string or number). If omitted, all tabs are included.
    /// You can see gid in the sheet URL as "...#gid=123456789".
    /// </param>
    public static async Task DownloadXlsxAsync(string shareUrlOrId, string outputPath, string? gid = null)
    {
        if (string.IsNullOrWhiteSpace(shareUrlOrId))
            throw new ArgumentException("shareUrlOrId is required.");

        var id = ExtractSpreadsheetId(shareUrlOrId);
        if (string.IsNullOrEmpty(id))
            throw new ArgumentException("Could not extract a spreadsheet ID from the input.");

        var url = $"https://docs.google.com/spreadsheets/d/{id}/export?format=xlsx";
        if (!string.IsNullOrEmpty(gid))
            url += $"&gid={Uri.EscapeDataString(gid)}";

        var handler = new HttpClientHandler
        {
            AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate,
            AllowAutoRedirect = true
        };

        using var http = new HttpClient(handler);
        http.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0");

        using var resp = await http.GetAsync(url, HttpCompletionOption.ResponseHeadersRead);
        if (resp.StatusCode == HttpStatusCode.Forbidden || resp.StatusCode == HttpStatusCode.Unauthorized)
            throw new InvalidOperationException(
                "Permission denied. Make sure the sheet is shared as 'Anyone with the link can view' or is published."
            );

        resp.EnsureSuccessStatusCode();

        // Basic sanity check: make sure we didn't get an HTML "sign in" page
        var contentType = resp.Content.Headers.ContentType?.MediaType ?? "";
        if (!contentType.Contains("application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", StringComparison.OrdinalIgnoreCase))
        {
            // You can also read a small buffer and look for "<html" if you want.
            throw new InvalidOperationException($"Unexpected content type '{contentType}'. The file may not be publicly accessible.");
        }

        Directory.CreateDirectory(Path.GetDirectoryName(Path.GetFullPath(outputPath))!);
        await using var fs = new FileStream(outputPath, FileMode.Create, FileAccess.Write, FileShare.None);
        await resp.Content.CopyToAsync(fs);
    }

    private static string ExtractSpreadsheetId(string input)
    {
        // 1) Standard Sheets URL: https://docs.google.com/spreadsheets/d/{ID}/...
        var m = Regex.Match(input, @"docs\.google\.com/spreadsheets/d/([a-zA-Z0-9-_]+)", RegexOptions.IgnoreCase);
        if (m.Success) return m.Groups[1].Value;

        // 2) Drive sharing URL with ?id=... pattern
        var q = Regex.Match(input, @"[?&]id=([a-zA-Z0-9-_]+)", RegexOptions.IgnoreCase);
        if (q.Success) return q.Groups[1].Value;

        // 3) Assume it's already an ID
        if (Regex.IsMatch(input, @"^[a-zA-Z0-9-_]{20,}$")) return input;

        return string.Empty;
    }
}
