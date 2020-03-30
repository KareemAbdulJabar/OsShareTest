using System.Collections.Generic;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using SMBLibrary;
using SMBLibrary.Client;

namespace OsShareTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        // GET api/values/5
        [HttpPut("CreateFile")]
        public IActionResult Get(string fileName)
        {

            var client = new SMB2Client();
            client.Connect(IPAddress.Parse("192.168.1.166"), SMBTransportType.DirectTCPTransport);
            client.Login("WORKGROUP", "Alon Amrani", "alon1023");
            var tree = client.TreeConnect("Users", out var e);
            var result = tree.CreateFile(out var h, out var status, $"Efrat\\Desktop\\Hackathon\\AlonShare\\{fileName}",
                AccessMask.GENERIC_ALL, FileAttributes.Normal, ShareAccess.Read, CreateDisposition.FILE_CREATE, CreateOptions.FILE_NON_DIRECTORY_FILE, null);
            return Ok();
        }
    }
}
