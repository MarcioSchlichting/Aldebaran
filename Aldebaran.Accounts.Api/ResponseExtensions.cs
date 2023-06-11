﻿using Aldebaran.Domain.ApiResponses;
using Microsoft.AspNetCore.Mvc;

namespace Aldebaran.Accounts.Api;

public static class ResponseExtensions
{
    public static ActionResult<T> ToResponse<T>(this ServiceResponse<T> response) where T : class, new()
    {
        if (response.HasErrors is true)
        {
            return new ObjectResult(response.Messages)
            {
                StatusCode = StatusCodes.Status400BadRequest
            };
        }

        return new ActionResult<T>(response.Response);
    }
}