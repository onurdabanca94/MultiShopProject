﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MultiShopProject.Images.Controllers;

[AllowAnonymous]
[Route("api/[controller]")]
[ApiController]
public class GoogleDriveImageUploadsController : ControllerBase
{
}
