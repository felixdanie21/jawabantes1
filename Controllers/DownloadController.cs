using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using PdfSharpCore.Drawing;
using PdfSharpCore.Pdf;
using System.IO;

namespace RotativeDownloadApp.Controllers;

[ApiController]
[Route("download")]
public class DownloadController : ControllerBase
{
    [HttpGet("excel")]
    public IActionResult DownloadExcel()
    {
        using var workbook = new XLWorkbook();
        var worksheet = workbook.Worksheets.Add("Sheet1");
        worksheet.Cell(1, 1).Value = "Hello";
        worksheet.Cell(1, 2).Value = "World";

        using var stream = new MemoryStream();
        workbook.SaveAs(stream);
        var content = stream.ToArray();

        return File(content, 
            "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", 
            "example.xlsx");
    }

    [HttpGet("pdf")]
    public IActionResult DownloadPdf()
    {
        using var document = new PdfDocument();
        var page = document.AddPage();
        var gfx = XGraphics.FromPdfPage(page);
        var font = new XFont("Verdana", 20, XFontStyle.Bold);
        gfx.DrawString("Hello PDF!", font, XBrushes.Black, new XRect(0, 0, page.Width, page.Height),
            XStringFormats.Center);

        using var stream = new MemoryStream();
        document.Save(stream, false);
        var content = stream.ToArray();

        return File(content, "application/pdf", "example.pdf");
    }
}