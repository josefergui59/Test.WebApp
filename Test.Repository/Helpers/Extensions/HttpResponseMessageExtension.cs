using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Net;
using System.Net.Http;

namespace Test.Repository.Helpers.Extensions
{
    public static class HttpResponseMessageExtension
    {
        public static bool HandleResponse(this HttpResponseMessage response, bool throwException = true)
        {
            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            string errorMessage = "" + response.StatusCode + response.RequestMessage + response.Content;

            if (!throwException)
            {
                return false;
            }

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new UnauthorizedAccessException(errorMessage);
            }

            throw new Exception(errorMessage);
        }

        public static void CleanModel(this ModelStateDictionary modelState)
        {
            foreach (var modelValue in modelState.Values)
            {
                modelValue.Errors.Clear();
            }
        }
    }
}
